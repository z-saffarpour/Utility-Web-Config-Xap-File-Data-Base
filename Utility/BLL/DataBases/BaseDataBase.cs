using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.Utility.BLL.DataBases
{
    public class BaseDataBase
    {
        private static string GetConnectionString(DataBase dataBase)
        {
            return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", dataBase.Server, dataBase.NewDataBase, dataBase.Username, dataBase.Password);
        }

        public static SqlConnection GetSqlConnection(DataBase dataBase)
        {
            return new SqlConnection(GetConnectionString(dataBase));
        }

        protected static DataTable ExecuteReader(DataBase dataBase, string commandStr)
        {
            var connection = GetSqlConnection(dataBase);
            var command = new SqlCommand(commandStr, connection);
            var dt = new DataTable();
            connection.Open();
            dt.Load(command.ExecuteReader());
            connection.Close();
            command.Dispose();
            return dt;
        }

        protected static XmlDocument ExecuteXmlReader(DataBase dataBase, string commandStr)
        {
            var xmlDocument = new XmlDocument();
            var connection = GetSqlConnection(dataBase);
            var command = new SqlCommand(commandStr, connection);
            connection.Open();
            var xml=command.ExecuteXmlReader();
            xmlDocument.Load(xml);
            connection.Close();
            command.Dispose();
            return xmlDocument;
        }
    }
}
