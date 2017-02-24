using System.Collections.Generic;

namespace ZaHra.Utility.DTO.DataBases
{
    public class DataBase
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string DefualtDataBase { get; set; }

        public string Server { get; set; }
        public string NewDataBase { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEncryption { get; set; }

        public List<string> MappingTo { get; set; }
        public DataBase()
        {
            MappingTo = new List<string>();
        }
    }
}
