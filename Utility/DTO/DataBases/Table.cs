using System.Collections.Generic;

namespace ZaHra.Utility.DTO.DataBases
{
    public class Table
    {
        public bool IsSelected { get; set; }
        public string SchemaName { get; set; }
        public string TabelName { get; set; }
        public string Name { get; set; }
        public List<Column> Columns { get; set; }

        public Table()
        {
            Columns = new List<Column>();
        }
    }
}
