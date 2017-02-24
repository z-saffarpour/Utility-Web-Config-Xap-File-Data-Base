using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.WinFormUserInterfaces
{
    public enum UserControlType
    {
        Connectionstring,
        ServiceModelClient,
        XapConfig,
        GenerateDataBase,
        GenerateValue,
        ExecuteDataBase,
        ExecuteValue,
    }
    public class Common
    {
        public static void InitializeDataGridView(List<ScriptFile> scriptFiles, DataGridView dgvConfig)
        {
            dgvConfig.DataSource = null;
            var temp = scriptFiles.Where(x => !(x.FileName.StartsWith("_"))).ToList();
            dgvConfig.DataSource = temp;
            var name = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FileName",
                HeaderText = @"نام",
                Name = "FileName",
                ReadOnly = true,
                Width = 250
            };
            var address = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DirectoryName",
                HeaderText = @"مسیر",
                Name = "DirectoryName",
                ReadOnly = true,
                Width = 330
            };
            var isExecute = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsExecute",
                HeaderText = @"اجرا شده",
                Name = "IsExecute",
                ReadOnly = true,
                Width = 70
            };
            dgvConfig.Columns.Clear();
            dgvConfig.AutoGenerateColumns = false;
            dgvConfig.Columns.AddRange(new DataGridViewColumn[] { name, address, isExecute });
        }

        public static void InitializeDataGridView(List<Table> list, DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = list;
            var checkBox = new DataGridViewCheckBoxColumn
            {
                HeaderText = @"انتخاب",
                DataPropertyName = "IsSelected",
                Name = "IsSelected",
                ReadOnly = false,
                Width = 60
            };
            var name = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = @"نام",
                Name = "Name",
                ReadOnly = true,
                Width = 165
            };
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.Columns.AddRange(new DataGridViewColumn[] { checkBox, name });
        }

        internal static void InitializeDataGridView(List<Column> list, DataGridView dgv)
        {
            dgv.DataSource = null;
            dgv.DataSource = list;
            var checkBox = new DataGridViewCheckBoxColumn
            {
                HeaderText = @"انتخاب",
                ReadOnly = false,
                DataPropertyName = "IsSelected",
                Name = "IsSelected",
                Width = 60
            };
            var name = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = @"نام",
                Name = "Name",
                ReadOnly = true,
                Width = 190
            };
            var type = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = @"نوع",
                Name = "Type",
                ReadOnly = true,
                Width = 90
            };
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false;
            dgv.Columns.AddRange(new DataGridViewColumn[] { checkBox, name, type });
        }
    }
}
