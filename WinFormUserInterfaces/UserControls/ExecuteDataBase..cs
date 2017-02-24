using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZaHra.Utility.BLL.DataBases;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.WinFormUserInterfaces.UserControls
{
    public partial class ExecuteDataBase : UserControl
    {
        private List<ScriptFile> _scriptFiles;
        private readonly UserControlType _userControlType;
        public ExecuteDataBase(UserControlType userControlType)
        {
            _userControlType = userControlType;
            InitializeComponent();
            _scriptFiles = new List<ScriptFile>();
        }

        private void DataBaseConfig_Load(object sender, EventArgs e)
        {
            ConfigFont.LoadFont();
            AllocFont(btnOpenPath);
            AllocFont(btnOpenDirectory);
            AllocFont(btnTestConnection);
            AllocFont(btnReadFile);
            AllocFont(btnOpenFile);
            AllocFont(btnOpenDirectorySelected);
            AllocFont(btnConfig);
            AllocFont(btnAllConfig);
        }

        static void AllocFont(Control ctrl)
        {
            ConfigFont.AllocFont(ctrl, FontStyle.Regular, 9f);
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = new System.Data.SqlClient.SqlConnection();
                var connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                    txtServer.Text, txtDataBase.Text, txtUser.Text, txtPassword.Text);
                connection.ConnectionString = connectionString;
                connection.Open();
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
                if (_userControlType == UserControlType.ExecuteDataBase)
                {
                    _scriptFiles = Execute.ReadAllScript(path);
                }
                else if (_userControlType == UserControlType.ExecuteValue)
                {
                    _scriptFiles = Execute.ReadAllXml(path);
                }
                Common.InitializeDataGridView(_scriptFiles, dgvConfig);
                CheckPathFile();
            }
        }

        private bool CheckConnection()
        {
            var isEnabled = !string.IsNullOrEmpty(txtServer.Text) && !string.IsNullOrEmpty(txtDataBase.Text) &&
                            !string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text);
            btnTestConnection.Enabled = isEnabled;
            btnConfig.Enabled = isEnabled && dgvConfig.RowCount > 0;
            btnAllConfig.Enabled = isEnabled && dgvConfig.RowCount > 0;
            return isEnabled;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckConnection();
        }

        private void dgvConfig_SelectionChanged(object sender, EventArgs e)
        {
            btnOpenDirectorySelected.Enabled = ((DataGridView)sender).SelectedRows.Count > 0;
            btnOpenFile.Enabled = ((DataGridView)sender).SelectedRows.Count > 0;
            btnConfig.Enabled = CheckConnection() && ((DataGridView)sender).SelectedRows.Count > 0;
        }

        private void txtPath_Leave(object sender, EventArgs e)
        {
            CheckPathFile();
        }

        private void CheckPathFile()
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                var directory = Path.GetDirectoryName(txtPath.Text);
                if (directory != null) btnOpenDirectory.Enabled = Directory.Exists(directory);
            }
            else
                btnOpenDirectory.Enabled = false;
            btnReadFile.Enabled = Directory.Exists(txtPath.Text);
            btnConfig.Enabled = CheckConnection() && dgvConfig.RowCount > 0;
            btnAllConfig.Enabled = CheckConnection() && dgvConfig.RowCount > 0;
        }

        private void InitializeDataGridView(ICollection endpointList)
        {
            btnConfig.Enabled = endpointList.Count > 0;
            Common.InitializeDataGridView(_scriptFiles, dgvConfig);
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            if (_userControlType == UserControlType.ExecuteDataBase)
            {
                _scriptFiles = Execute.ReadAllScript(path);
            }
            else if (_userControlType == UserControlType.ExecuteValue)
            {
                _scriptFiles = Execute.ReadAllXml(path);
            }
            Common.InitializeDataGridView(_scriptFiles, dgvConfig);
        }

        private void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtPath.Text);
        }

        private void btnAllConfig_Click(object sender, EventArgs e)
        {
            ConfigAllScript();
        }

        private void ConfigAllScript()
        {
            _scriptFiles = Execute.ExecuteAllScript(txtPath.Text, new DataBase
            {
                Server = txtServer.Text,
                NewDataBase = txtDataBase.Text,
                Username = txtUser.Text,
                Password = txtPassword.Text
            });
            InitializeDataGridView(_scriptFiles);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var selectedItem in dgvConfig.SelectedRows)
                {
                    var scriptFileItem = ((DataGridViewRow)selectedItem).DataBoundItem as ScriptFile;
                    if (scriptFileItem != null)
                    {
                        if (_userControlType == UserControlType.ExecuteDataBase)
                        {
                            Execute.ExecuteScript(scriptFileItem.DirectoryName, new DataBase
                            {
                                Server = txtServer.Text,
                                NewDataBase = txtDataBase.Text,
                                Username = txtUser.Text,
                                Password = txtPassword.Text
                            });
                            scriptFileItem.IsExecute = true;
                        }
                        else if (_userControlType == UserControlType.ExecuteValue)
                        {
                            var tabelpath = _scriptFiles.FirstOrDefault(x => x.FileName == "_" + scriptFileItem.FileName);
                            if (tabelpath != null)
                                Execute.ExecuteValue(tabelpath.DirectoryName, scriptFileItem.DirectoryName, new DataBase
                                {
                                    Server = txtServer.Text,
                                    NewDataBase = txtDataBase.Text,
                                    Username = txtUser.Text,
                                    Password = txtPassword.Text
                                });
                            scriptFileItem.IsExecute = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenDirectorySelected_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in dgvConfig.SelectedRows)
            {
                var scriptFileItem = ((DataGridViewRow)selectedItem).DataBoundItem as ScriptFile;
                if (scriptFileItem != null)
                {
                    var directoryName = Path.GetDirectoryName(scriptFileItem.DirectoryName);
                    if (directoryName != null)
                        System.Diagnostics.Process.Start(directoryName);
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in dgvConfig.SelectedRows)
            {
                var scriptFileItem = ((DataGridViewRow)selectedItem).DataBoundItem as ScriptFile;
                if (scriptFileItem != null)
                {
                    System.Diagnostics.Process.Start(scriptFileItem.DirectoryName);
                }
            }
        }
    }
}
