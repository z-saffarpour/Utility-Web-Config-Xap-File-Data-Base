using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZaHra.Utility.BLL.Config;
using ZaHra.Utility.DTO.Config;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.WinFormUserInterfaces.UserControls
{
    public partial class WebConfig : UserControl
    {
        private readonly UserControlType _userControlType;
        private List<DataBase> _dataBaseList;
        private List<Endpoint> _endpointList;

        public WebConfig(UserControlType userControlType)
        {
            _userControlType = userControlType;
            InitializeComponent();
            btnAdd.Visible = _userControlType == UserControlType.Connectionstring;
        }

        private void WebConfig_Load(object sender, EventArgs e)
        {
            ConfigFont.LoadFont();
            AllocFont(btnAdd);
            AllocFont(btnConfig);
            AllocFont(btnDelete);
            AllocFont(btnEdit);
            AllocFont(btnOpenDirectory);
            AllocFont(btnOpenDirectory);
            AllocFont(btnOpenFile);
            AllocFont(btnOpenPath);
            AllocFont(btnReadFile);
        }

        static void AllocFont(Control ctrl)
        {
            ConfigFont.AllocFont(ctrl, FontStyle.Regular, 9f);
        }

        private void btnOpenPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = string.Empty;
            openFileDialog1.FileName = string.Empty;
            if (_userControlType == UserControlType.Connectionstring || _userControlType == UserControlType.ServiceModelClient)
            {
                openFileDialog1.Filter = @"web (*.config)|*.config";
                openFileDialog1.FileName = "web.config";
            }
            else if (_userControlType == UserControlType.XapConfig)
            {
                openFileDialog1.Filter = @"Xap File (*.XAP)|*.XAP";
                openFileDialog1.FileName = "File Name.xap";
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = txtPath.Text = openFileDialog1.FileName;
            }
            CheckPathFile();
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            statusStrip1.Visible = true;
            Read();
            if (_dataBaseList != null && _dataBaseList.Any())
                toolStripStatusLabel1.Text = @"خواندن از فایل با موفقیت انجام شد";
            else if (_endpointList != null && _endpointList.Any())
                toolStripStatusLabel1.Text = @"خواندن از فایل با موفقیت انجام شد";
            Cursor = Cursors.Default;
        }

        private void Read()
        {
            switch (_userControlType)
            {
                case UserControlType.Connectionstring:
                    _dataBaseList = WebConnectionStringConfiguration.ReadConnectionStrings(txtPath.Text);
                    InitializeDataGridView(_dataBaseList);
                    break;
                case UserControlType.XapConfig:
                    _endpointList = ServiceReferencesConfiguration.ReadConfiguaration(txtPath.Text);
                    InitializeDataGridView(_endpointList);
                    break;
                case UserControlType.ServiceModelClient:
                    _endpointList = ClientEndpointAddressConfiguration.ReadClientEndpointAddress(txtPath.Text);
                    InitializeDataGridView(_endpointList);
                    break;
            }
        }

        private void InitializeDataGridView(List<DataBase> dataBaseList)
        {
            dgvConfig.DataSource = null;
            dgvConfig.DataSource = dataBaseList;
            btnConfig.Enabled = dataBaseList.Count > 0;
            var caption = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Caption",
                HeaderText = @" ",
                Name = "Caption",
                ReadOnly = true,
                Width = 75
            };
            var newDataBase = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NewDataBase",
                HeaderText = @"نام دیتابیس",
                Name = "newDataBase",
                ReadOnly = true,
                Width = 183
            };
            var serverAddress = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Server",
                HeaderText = @"آدرس سرور",
                Name = "serverAddress",
                ReadOnly = true,
                Width = 120
            };
            var username = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = @"نام کاربری",
                Name = "username",
                ReadOnly = true,
                Width = 85
            };
            var password = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Password",
                HeaderText = @"کلمه عبور",
                Name = "password",
                ReadOnly = true,
                Width = 120
            };
            var isEncryption = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsEncryption",
                HeaderText = @"رمزگذاری",
                Name = "IsEncryption",
                ReadOnly = true,
                Width = 70
            };
            dgvConfig.Columns.Clear();
            dgvConfig.AutoGenerateColumns = false;
            dgvConfig.Columns.AddRange(new DataGridViewColumn[] { caption, newDataBase, serverAddress, username, password, isEncryption });
        }

        private void InitializeDataGridView(ICollection endpointList)
        {
            dgvConfig.DataSource = null;
            dgvConfig.DataSource = endpointList;
            btnConfig.Enabled = endpointList.Count > 0;
            var name = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ServiceName",
                HeaderText = @"نام",
                Name = "ServiceName",
                ReadOnly = true,
                Width = 150
            };
            var address = new DataGridViewLinkColumn
            {
                DataPropertyName = "Address",
                HeaderText = @"آدرس",
                Name = "address",
                ReadOnly = true,
                Width = 250
            };
            var host = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Host",
                HeaderText = @"ای پی",
                Name = "host",
                ReadOnly = true
            };
            var port = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Port",
                HeaderText = @"پورت",
                Name = "port",
                ReadOnly = true
            };
            dgvConfig.Columns.Clear();
            dgvConfig.AutoGenerateColumns = false;
            dgvConfig.Columns.AddRange(new DataGridViewColumn[] { name, address, host, port });
        }

        private void dgvConfig_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = File.Exists(txtPath.Text) && ((DataGridView)sender).SelectedRows.Count > 0;
            btnDelete.Enabled = File.Exists(txtPath.Text) && ((DataGridView)sender).SelectedRows.Count > 0;
        }

        private void txtPath_Leave(object sender, EventArgs e)
        {
            CheckPathFile();
        }

        private void CheckPathFile()
        {
            btnReadFile.Enabled = File.Exists(txtPath.Text);
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                var directory = Path.GetDirectoryName(txtPath.Text);
                if (directory != null) btnOpenDirectory.Enabled = Directory.Exists(directory);
            }
            else
                btnOpenDirectory.Enabled = false;
            btnOpenFile.Enabled = File.Exists(txtPath.Text);
            btnConfig.Enabled = File.Exists(txtPath.Text) && dgvConfig.RowCount > 0;
            btnEdit.Enabled = File.Exists(txtPath.Text) && dgvConfig.RowCount > 0;
            btnDelete.Enabled = File.Exists(txtPath.Text) && dgvConfig.RowCount > 0;
            btnAdd.Enabled = File.Exists(txtPath.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_userControlType == UserControlType.Connectionstring)
            {
                var dataBaseManagement = new DataBaseManagement(new DataBase());
                if (dataBaseManagement.ShowDialog() == DialogResult.OK)
                {
                    var temp = dataBaseManagement.Tag as DataBase;
                    if (_dataBaseList.All(x => temp != null && x.Caption != temp.Caption))
                    {
                        _dataBaseList.Add(temp);
                        InitializeDataGridView(_dataBaseList);
                    }
                    else
                    {
                        MessageBox.Show(@"دیتابیس موردنظر در لیست موجود است.", @"خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (_userControlType == UserControlType.XapConfig)
            {

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in dgvConfig.SelectedRows)
            {
                if (_userControlType == UserControlType.Connectionstring)
                {
                    var dataBaseItem = ((DataGridViewRow)selectedItem).DataBoundItem as DataBase;

                    var dataBaseManagement = new DataBaseManagement(dataBaseItem);
                    if (dataBaseManagement.ShowDialog() == DialogResult.OK)
                    {
                        var temp = dataBaseManagement.Tag as DataBase;
                        var tmp = _dataBaseList.FirstOrDefault(x => dataBaseItem != null && x.Caption == dataBaseItem.Caption);
                        if (tmp != null)
                        {
                            var index = _dataBaseList.IndexOf(tmp);
                            tmp = temp;
                            _dataBaseList.RemoveAt(index);
                            _dataBaseList.Insert(index, tmp);
                        }
                        InitializeDataGridView(_dataBaseList);
                    }
                }
                else if ((_userControlType == UserControlType.ServiceModelClient) || (_userControlType == UserControlType.XapConfig))
                {
                    var endPointItem = ((DataGridViewRow)selectedItem).DataBoundItem as Endpoint;
                    var editAddressEndPoint = new EditAddressEndPoint(endPointItem);
                    if (editAddressEndPoint.ShowDialog() == DialogResult.OK)
                    {
                        if (endPointItem != null)
                        {
                            var uri = new Uri(endPointItem.Address);
                            endPointItem.Address = string.Format("{0}://{1}:{2}{3}", uri.Scheme, endPointItem.Host, endPointItem.Port, uri.AbsolutePath);
                        }
                        InitializeDataGridView(_endpointList);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (var selectedItem in dgvConfig.SelectedRows)
            {
                if (_userControlType == UserControlType.Connectionstring)
                {
                    var dataBaseItem = ((DataGridViewRow)selectedItem).DataBoundItem as DataBase;
                    _dataBaseList.Remove(dataBaseItem);
                    InitializeDataGridView(_dataBaseList);
                }
                else if (_userControlType == UserControlType.XapConfig)
                {
                    var endpointItem = ((DataGridViewRow)selectedItem).DataBoundItem as Endpoint;
                    _endpointList.Remove(endpointItem);
                    InitializeDataGridView(_endpointList);
                }
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                switch (_userControlType)
                {
                    case UserControlType.Connectionstring:
                        WebConnectionStringConfiguration.ConfigurationConnectionStrings(txtPath.Text, _dataBaseList);
                        toolStripStatusLabel1.Text = @"تنظیم فایل با موفقیت انجام شد";
                        break;
                    case UserControlType.ServiceModelClient:
                        ClientEndpointAddressConfiguration.ConfigClientEndpointAddress(txtPath.Text, _endpointList);
                        toolStripStatusLabel1.Text = @"تنظیم فایل با موفقیت انجام شد";
                        break;
                    case UserControlType.XapConfig:
                        ServiceReferencesConfiguration.Configuaration(txtPath.Text, _endpointList);
                        toolStripStatusLabel1.Text = @"تنظیم فایل با موفقیت انجام شد";
                        break;
                }
                Read();
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                toolStripStatusLabel1.Text = @"به دلیل بروز مشکل؛تنظیم فایل با موفقیت انجام نشد";
                MessageBox.Show(ex.Message, @"خطا");
            }
        }

        private void dgvConfig_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dgvConfig.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var linkCell = cell as DataGridViewLinkCell;
            if (linkCell != null)
            {
                System.Diagnostics.Process.Start(linkCell.Value.ToString());
            }
        }

        private void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            var directory = File.Exists(txtPath.Text) ? Path.GetDirectoryName(txtPath.Text) : txtPath.Text;
            if (directory != null)
            {
                System.Diagnostics.Process.Start(directory);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtPath.Text);
        }
    }
}
