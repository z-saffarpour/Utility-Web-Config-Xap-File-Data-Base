using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ZaHra.Utility.BLL.Common;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.Utility.BLL.Config
{
    public class WebConnectionStringConfiguration : WebConfiguration
    {
        #region Fields
        private static RijndaelEnhancedHelper _helper;
        #endregion

        #region Constructor
        public WebConnectionStringConfiguration()
        {
            Set();
        }
        #endregion

        #region Methods
        #region Public
        public static void ConfigurationConnectionStrings(string pathWebConfig, List<DataBase> dataBaseList)
        {
            foreach (var dataBase in dataBaseList)
            {
                if (dataBase.IsEncryption)
                {
                    dataBase.Server = _helper.Encrypt(dataBase.Server);
                    dataBase.Password = _helper.Encrypt(dataBase.Password);
                    dataBase.Username = _helper.Encrypt(dataBase.Username);
                    dataBase.NewDataBase = _helper.Encrypt(dataBase.NewDataBase);
                }
            }
            foreach (var item in dataBaseList)
                ConfigurationConnectionStrings(pathWebConfig, item);
        }

        public static List<DataBase> ReadConnectionStrings(string pathWebConfig)
        {
            var webConfig = ReadWebConfigFile(pathWebConfig);
            var connectionStrings = webConfig.GetSection("connectionStrings");
            var temp = new List<DataBase>();
            var list = new List<DataBase>();
            if (_helper == null)
                Set();
            foreach (ConnectionStringSettings connectionString in connectionStrings.CurrentConfiguration.ConnectionStrings.ConnectionStrings)
            {
                if (_helper != null)
                {
                    var decrypt = _helper.Decrypt(connectionString.ToString());
                    var stringConnection = decrypt ?? connectionString.ToString();
                    var builder = new SqlConnectionStringBuilder(stringConnection);
                    var server = _helper.Decrypt(builder.DataSource) ?? builder.DataSource;
                    var user = _helper.Decrypt(builder.UserID) ?? builder.UserID;
                    var database = _helper.Decrypt(builder.InitialCatalog) ?? builder.InitialCatalog;
                    var password = _helper.Decrypt(builder.Password) ?? builder.Password;
                    var isEncryption = !string.IsNullOrEmpty(decrypt);
                    temp.Add(new DataBase { Name = connectionString.Name, NewDataBase = database, Password = password, Username = user, Server = server, IsEncryption = isEncryption });
                }
            }
            temp = temp.Where(x => !string.IsNullOrEmpty(x.NewDataBase)).ToList();
            var listDataBase = ReadConfigFile();
            if (listDataBase != null && listDataBase.Any())
            {
                foreach (var dataBase in listDataBase)
                {
                    var tmp = temp.GroupBy(x => x.Name).ToList();
                    var dataBaseMappingTo = (from t in dataBase.MappingTo
                                             join x in tmp on t equals x.Key
                                             select t).ToList();
                    var tmpDataBase = temp.FirstOrDefault(x => x.Name == dataBaseMappingTo.FirstOrDefault());
                    if (tmpDataBase != null)
                    {
                        var newDataBase = new DataBase
                        {
                            Caption = dataBase.Caption,
                            NewDataBase = tmpDataBase.NewDataBase,
                            Password = tmpDataBase.Password,
                            Server = tmpDataBase.Server,
                            Username = tmpDataBase.Username,
                            MappingTo = dataBaseMappingTo,
                            IsEncryption = tmpDataBase.IsEncryption,
                        };
                        list.Add(newDataBase);
                    }
                }
            }
            else
            {
                list = temp;
            }
            return list;
        }

        public static List<DataBase> ReadConfigFile()
        {
            var configPath = GetConfigPath();
            List<DataBase> listDataBase;
            using (var mst = new FileStream(configPath, FileMode.Open, FileAccess.Read))
            {
                var serializer = new XmlSerializer(typeof(List<DataBase>));
                listDataBase = serializer.Deserialize(mst) as List<DataBase>;
            }
            return listDataBase;
        }

        #endregion

        #region Private
        private static void Set()
        {
            _helper = new RijndaelEnhancedHelper("Pas5pr@se", "@1B2c3D4e5F6g7H8");
        }

        private static string GetConfigPath()
        {
            var myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory;
            return myExeDir + "\\" + "DataBaseConfig.xml";
        }

        private static void ConfigurationConnectionStrings(string pathWebConfig, DataBase itemSelected)
        {
            var configuration = ReadWebConfigFile(pathWebConfig);
            if (configuration.GetSection("connectionStrings") != null)
            {
                foreach (var mappingTo in itemSelected.MappingTo)
                {
                    GetConnectionStrings(itemSelected.IsEncryption, configuration, mappingTo, itemSelected.Server, itemSelected.NewDataBase, itemSelected.Username, itemSelected.Password);
                }
            }
            else
            {
                configuration.Sections.Add("connectionStrings", configuration.GetSection("connectionStrings"));
                ConfigurationConnectionStrings(pathWebConfig, itemSelected);
            }
        }

        private static void GetConnectionStrings(bool isEncryption, Configuration configuration, string connectionStrings, string server, string db, string user, string password)
        {
            if (configuration.ConnectionStrings.ConnectionStrings[connectionStrings] != null)
                ConStrEdit(isEncryption, configuration, connectionStrings, server, db, user, password);
            else
                ConStrAdd(isEncryption, configuration, connectionStrings, server, db, user, password);
        }

        private static void ConStrEdit(bool isEncryption, Configuration configuration, string connectionStrings, string server, string db, string user, string password)
        {
            var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            var connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", server, db, user, password);
            section.ConnectionStrings[connectionStrings].ConnectionString = isEncryption ? _helper.Encrypt(connectionString) : connectionString;
            configuration.Save(ConfigurationSaveMode.Modified);
        }

        private static void ConStrAdd(bool isEncryption, Configuration configuration, string conStr, string server, string db, string user, string password)
        {
            var connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", server, db, user, password);

            var csSection = configuration.ConnectionStrings;
            var csSettings = new ConnectionStringSettings(conStr, isEncryption ? _helper.Encrypt(connectionString) : connectionString);
            csSection.ConnectionStrings.Add(csSettings);
            configuration.Save(ConfigurationSaveMode.Modified);
        }
        #endregion
        #endregion
    }
}
