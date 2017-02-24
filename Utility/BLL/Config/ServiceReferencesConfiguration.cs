using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Ionic.Zip;
using ZaHra.Utility.DTO.Config;

namespace ZaHra.Utility.BLL.Config
{
    public class ServiceReferencesConfiguration
    {
        #region Fields
        const string ConfigFile = "ServiceReferences.ClientConfig";
        #endregion

        #region Constructor

        #endregion

        #region Methods
        #region Public
        public static List<Endpoint> ReadConfiguaration(string xapFilePath)
        {
            return ReadConfiguaration(ConfigFile, xapFilePath);
        }

        public static bool Configuaration(string path, List<Endpoint> list)
        {
            return UpdateSilverlightConfigurationFile(ConfigFile, path, list);
        }
        #endregion

        #region Private
        private static List<Endpoint> ReadConfiguaration(string configFileName, string xapFilePath)
        {
            if (!File.Exists(xapFilePath))
            {
                return null;
            }
            var sericeClientPath = Environment.CurrentDirectory + "\\EnpPointXAP.config";
            var stream = UnZipXapFile(configFileName, xapFilePath);
            File.WriteAllBytes(sericeClientPath, stream.ToArray());
            var list = ReadAppConfig(sericeClientPath);
            if (File.Exists(sericeClientPath))
            {
                File.Delete(sericeClientPath);
            }
            return list;
        }

        private static bool UpdateSilverlightConfigurationFile(string configFileName, string xapFilePath, List<Endpoint> list)
        {
            if (!File.Exists(xapFilePath))
            {
                return false;
            }
            var sericeClientPath = Environment.CurrentDirectory + "\\EnpPointXAP.config";
            var sericeClientPathSave = Environment.CurrentDirectory + "\\EnpPointXAPSave.config";
            var stream = UnZipXapFile(configFileName, xapFilePath);
            File.WriteAllBytes(sericeClientPath, stream.ToArray());
            UpdateAppConfig(sericeClientPath, sericeClientPathSave, list);

            using (var newsStream = new FileStream(sericeClientPathSave, FileMode.Open, FileAccess.Read))
            {
                ZipXapFile(configFileName, xapFilePath, newsStream);
            }
            if (File.Exists(sericeClientPath))
            {
                File.Delete(sericeClientPath);
            }
            if (File.Exists(sericeClientPathSave))
            {
                File.Delete(sericeClientPathSave);
            }
            return true;
        }

        private static List<Endpoint> ReadAppConfig(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);
            var endpoints = doc.GetElementsByTagName("endpoint");
            var list = new List<Endpoint>();
            foreach (XmlNode item in endpoints)
            {
                if (item.Attributes != null)
                {
                    var nameAttribute = item.Attributes["name"];
                    var adressAttribute =item.Attributes["address"];
                    if (!ReferenceEquals(null, adressAttribute) && !ReferenceEquals(null, nameAttribute))
                    {
                        var name = nameAttribute.Value.Split('_');
                        var uri = new Uri(adressAttribute.Value);
                        list.Add(new Endpoint
                        {
                            Address = adressAttribute.Value,
                            AbsolutePath = uri.AbsolutePath,
                            Host = uri.Host,
                            Port = uri.Port,
                            Scheme = uri.Scheme,
                            Name = nameAttribute.Value,
                            ServiceName = name[1]
                        });
                    }
                }
            }
            return list;
        }

        private static void UpdateAppConfig(string path, string pathSave, List<Endpoint> list)
        {
            var doc = new XmlDocument();
            doc.Load(path);
            var endpoints = doc.GetElementsByTagName("endpoint");
            var endpointsRemove = new List<XmlNode>();
            foreach (XmlNode item in endpoints)
            {
                if (item.Attributes != null)
                {
                    var nameAttribute = item.Attributes["name"];
                    var endpoint = list.FirstOrDefault(x => x.Name == nameAttribute.Value);
                    if (endpoint != null)
                    {
                        var adressAttribute = item.Attributes["address"];
                        if (!ReferenceEquals(null, adressAttribute))
                        {
                            var uri = new Uri(adressAttribute.Value);
                            var absolutePath = uri.AbsolutePath;
                            var scheme = uri.Scheme;
                            var host = endpoint.Host;
                            var port = endpoint.Port;

                            adressAttribute.Value =string.Format("{0}://{1}:{2}{3}", scheme, host, port, absolutePath);
                        }
                    }
                    else
                    {
                        endpointsRemove.Add(item);
                    }
                }
            }
            foreach (var endpoint in endpointsRemove)
            {
                if (endpoint.Attributes != null)
                {
                    var nameAttribute = endpoint.Attributes["name"];
                    if (endpoints.Cast<XmlNode>().Any(x => x.Attributes != null && x.Attributes["name"].Value == nameAttribute.Value))
                    {
                        var tmp = endpoints.Cast<XmlNode>().FirstOrDefault(x => x.Attributes != null && x.Attributes["name"].Value == nameAttribute.Value);
                        if (tmp != null)
                        {
                            var parent = tmp.ParentNode;
                            if (parent != null) parent.RemoveChild(tmp);
                        }
                    }
                }
            }
            doc.Save(pathSave);
        }

        private static MemoryStream UnZipXapFile(string configFileName, string xapFilePath)
        {
            var stream = new MemoryStream();
            // Open XAP and modify configuration
            using (var zip = ZipFile.Read(xapFilePath))
            {
                // Get config file
                var entry = zip[configFileName];

                entry.Extract(stream);

                stream.Position = 0;
            }
            return stream;
        }

        private static void ZipXapFile(string configFileName, string xapFilePath, Stream stream)
        {
            // Replace existing configuration file in XAP
            using (var zip = ZipFile.Read(xapFilePath))
            {
                zip.UpdateEntry(configFileName, stream);
                zip.Save();
            }
        }
        #endregion
        #endregion
    }
}
