using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZaHra.Utility.DTO.DataBases;
using Table = ZaHra.Utility.DTO.DataBases.Table;

namespace ZaHra.Utility.BLL.DataBases
{
    public class Generate : BaseDataBase
    {
        public static List<Table> ReadTable(DataBase dataBase)
        {
            var commandStr = "Select s.name AS SchemaName,t.name AS TabelName,s.name+'.'+t.name AS Name  FROM sys.Tables AS t INNER JOIN sys.schemas AS s ON t.schema_id = s.schema_id ORDER BY s.name,t.name";
            var list = new List<Table>();
            foreach (DataRow dr in ExecuteReader(dataBase, commandStr).Rows)
            {
                var temp = new Table
                {
                    Name = Convert.ToString(dr["Name"]),
                    SchemaName = Convert.ToString(dr["SchemaName"]),
                    TabelName = Convert.ToString(dr["TabelName"])
                };
                list.Add(temp);
            }
            foreach (var item in list)
            {
                commandStr = string.Format("SELECT COLUMN_NAME as Name,DATA_TYPE as Type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", item.TabelName);
                foreach (DataRow dr in ExecuteReader(dataBase, commandStr).Rows)
                {
                    var column = new Column { Name = Convert.ToString(dr["Name"]), Type = Convert.ToString(dr["Type"]) };
                    item.Columns.Add(column);
                }
            }
            return list;
        }

        public static bool SaveXmlValue(DataBase dataBase, List<Table> tables, string directory)
        {
            foreach (var table in tables)
            {
                SaveXmlValue(dataBase, table, directory);
            }
            return true;
        }

        public static bool SaveXmlValue(DataBase dataBase, Table table, string directory)
        {
            SaveXmlDataBase(dataBase, table, directory);
            var columnStr = string.Empty;
            foreach (var column in table.Columns)
            {
                if (column.IsSelected)
                {
                    if (!string.IsNullOrEmpty(columnStr))
                        columnStr += ',';
                    columnStr += column.Name;
                }
            }
            if (string.IsNullOrEmpty(columnStr))
                columnStr = "*";
            var commandStr = string.Format("SELECT {0} FROM {1} FOR XML PATH('{2}') ,ROOT('{3}'),TYPE", columnStr, table.Name,
                table.TabelName, table.Name);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            var fileName = directory + "\\" + table.TabelName + ".xml";
            if (!File.Exists(fileName))
                File.Delete(fileName);
            var xmlDocument = ExecuteXmlReader(dataBase, commandStr);
            xmlDocument.Save(fileName);
            return true;
        }
        private static void SaveXmlDataBase(DataBase dataBase, Table table, string directory)
        {
            var columnStr = string.Empty;
            foreach (var column in table.Columns)
            {
                if (column.IsSelected)
                {
                    if (!string.IsNullOrEmpty(columnStr))
                        columnStr += ',';
                    columnStr += "'" + column.Name + "'";
                }
            }
            var commandStr = string.Format("SELECT COLUMN_NAME AS Name,DATA_TYPE AS Type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'", table.TabelName);
            if (!string.IsNullOrEmpty(columnStr))
                commandStr += string.Format("AND COLUMN_NAME IN ({0})", columnStr);
            commandStr += string.Format(" FOR XML PATH('Column'),ROOT('{0}') ,TYPE", table.Name);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            var fileName = directory + "\\" + '_' + table.TabelName + ".xml";
            if (!File.Exists(fileName))
                File.Delete(fileName);
            var xmlDocument = ExecuteXmlReader(dataBase, commandStr);
            xmlDocument.Save(fileName);
        }
    }
}
