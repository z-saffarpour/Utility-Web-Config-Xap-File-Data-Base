using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ZaHra.Utility.BLL.DataBases;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.WinFormUserInterfaces.UserControls
{
    public partial class GenerateDataBase : UserControl
    {
        private List<Table> _tables;
        private UserControlType _userControlType;
        public GenerateDataBase(UserControlType userControlType)
        {
            _userControlType = userControlType;
            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = BaseDataBase.GetSqlConnection(new DataBase
                {
                    Server = txtServer.Text,
                    NewDataBase = txtDataBase.Text,
                    Username = txtUser.Text,
                    Password = txtPassword.Text
                });
                if (connection.State == ConnectionState.Open)
                    MessageBox.Show(@"تست ارتباط با دیتابیس با موفقیت انجام شد.", @"اطلاع رسانی", MessageBoxButtons.OK, MessageBoxIcon.Question);
                connection.Close();
            }
            catch
            {
                MessageBox.Show(@"تست ارتباط با دیتابیس با خطا همراه است", @"خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                txtPath.Text = path;
                CheckConnection();
            }
        }

        private void CheckConnection()
        {
            var isEnabled = !string.IsNullOrEmpty(txtServer.Text) && !string.IsNullOrEmpty(txtDataBase.Text) &&
                            !string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text);
            btnTestConnection.Enabled = isEnabled;
            btnConfig.Enabled = !string.IsNullOrEmpty(txtPath.Text) && isEnabled && dgvTabel.RowCount > 0;
            btnAllConfig.Enabled = !string.IsNullOrEmpty(txtPath.Text) && isEnabled && dgvTabel.RowCount > 0;
            btnReadFile.Enabled = isEnabled;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                _tables = Generate.ReadTable(new DataBase
                {
                    Server = txtServer.Text,
                    NewDataBase = txtDataBase.Text,
                    Username = txtUser.Text,
                    Password = txtPassword.Text
                });
                Common.InitializeDataGridView(_tables, dgvTabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTabel_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ((DataGridView)sender).SelectedRows)
            {
                var temp = row.DataBoundItem as Table;
                if (temp != null)
                    Common.InitializeDataGridView(temp.Columns, dgvColumn);
            }
        }

        private void btnAllConfig_Click(object sender, EventArgs e)
        {
            if (_userControlType == UserControlType.GenerateValue)
            {
                if (Generate.SaveXmlValue(new DataBase
                {
                    Server = txtServer.Text,
                    NewDataBase = txtDataBase.Text,
                    Username = txtUser.Text,
                    Password = txtPassword.Text
                }, new List<Table>(_tables.Where(x => x.IsSelected)), txtPath.Text + "\\GenerateValue"))
                    MessageBox.Show(@"success");
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (_userControlType == UserControlType.GenerateValue)
            {
                foreach (DataGridViewRow row in dgvTabel.SelectedRows)
                {
                    var temp = row.DataBoundItem as Table;
                    if (Generate.SaveXmlValue(new DataBase
                    {
                        Server = txtServer.Text,
                        NewDataBase = txtDataBase.Text,
                        Username = txtUser.Text,
                        Password = txtPassword.Text
                    }, temp, txtPath.Text + "\\GenerateValue"))
                        MessageBox.Show(@"success");
                }
            }
        }

    }
}
