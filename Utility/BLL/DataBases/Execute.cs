using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.Utility.BLL.DataBases
{
    public class Execute : BaseDataBase
    {
        public static List<ScriptFile> ReadAllScript(string path)
        {
            var scriptFiles = new List<ScriptFile>();
            if (Directory.GetDirectories(path).Any())
                foreach (var directory in Directory.GetDirectories(path))
                {
                    scriptFiles.AddRange(ReadAllScriptFile(directory));
                }
            else
            {
                scriptFiles = ReadAllScriptFile(path);
            }
            return scriptFiles;
        }

        private static List<ScriptFile> ReadAllScriptFile(string directory)
        {
            return Directory.GetFiles(directory, "*.sql").Select(file => new ScriptFile { FileName = Path.GetFileName(file), DirectoryName = file }).ToList();
        }

        public static List<ScriptFile> ExecuteAllScript(string path, DataBase dataBase)
        {
            var list = new List<ScriptFile>();
            var di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles("*.sql").OrderBy(x => x.Name))
            {
                try
                {
                    ExecuteScript(file, dataBase);
                    list.Add(new ScriptFile { DirectoryName = file.FullName, FileName = file.Name, IsExecute = true });
                }
                catch
                {
                    list.Add(new ScriptFile { DirectoryName = file.FullName, FileName = file.Name, IsExecute = false });
                }
            }
            return list;
        }

        public static ScriptFile ExecuteScript(string path, DataBase dataBase)
        {
            var fileInfo = new FileInfo(path);
            ExecuteScript(fileInfo, dataBase);
            return new ScriptFile { DirectoryName = path, FileName = fileInfo.Name, IsExecute = false };
        }

        private static void ExecuteScript(FileSystemInfo file, DataBase dataBase)
        {
            var fileInfo = new FileInfo(file.FullName);
            var script = fileInfo.OpenText().ReadToEnd();
            var server = new Server(new ServerConnection(GetSqlConnection(dataBase)) { StatementTimeout = 240 });
            server.ConnectionContext.ExecuteNonQuery(script);
        }

        public static List<DTO.DataBases.Table> ExecuteValue(string pathTabel, string path, DataBase dataBase)
        {
            var xmlDocument = new XmlDocument();
            var xmlReader = new XmlTextReader(pathTabel);
            xmlDocument.Load(path);
            var list = new List<DTO.DataBases.Table>();
            var element = new List<XmlList>();
            var xmlItems = new List<List<XmlItem>>();
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (element.All(x => x.Name != xmlReader.Name))
                            element.Add(new XmlList { Name = xmlReader.Name, Depth = xmlReader.Depth });
                        break;
                    case XmlNodeType.Text:
                        if (element.All(x => x.Name != xmlReader.Value))
                            element.Add(new XmlList { Name = xmlReader.Value, Depth = xmlReader.Depth });
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }
            var root = element.FirstOrDefault(x => x.Depth == 0);
            if (root != null)
            {
                list.Add(new DTO.DataBases.Table { Name = root.Name });
                var nodeList = xmlDocument.SelectNodes("//" + root.Name);
                if (nodeList != null)
                    foreach (XmlNode node in nodeList)
                    {
                        var xmlChildItems = new List<XmlItem>();
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            xmlChildItems.Add(new XmlItem { Name = childNode.Name, Value = childNode.InnerText });
                        }
                        xmlItems.Add(xmlChildItems);
                    }
            }
            return list;
        }

        public static List<ScriptFile> ReadAllXml(string path)
        {
            var scriptFiles = new List<ScriptFile>();
            if (Directory.GetDirectories(path).Any())
                foreach (var directory in Directory.GetDirectories(path))
                {
                    scriptFiles.AddRange(ReadAllXmlFile(directory));
                }
            else
            {
                scriptFiles = ReadAllXmlFile(path);
            }
            return scriptFiles;
        }

        private static List<ScriptFile> ReadAllXmlFile(string directory)
        {
            return Directory.GetFiles(directory, "*.xml").Select(file => new ScriptFile { FileName = Path.GetFileName(file), DirectoryName = file }).ToList();
        }

    }

    public class XmlList
    {
        public string Name { get; set; }
        public int Depth { get; set; }
    }

    public class XmlItem
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
