using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZaHra.Utility;
using ZaHra.Utility.BLL.Config;
using ZaHra.Utility.DTO.DataBases;

namespace ZaHra.WinFormUserInterfaces.UserControls
{
    public partial class DataBaseManagement : Form
    {
        private readonly DataBase _dataBase;
        public DataBaseManagement(DataBase dataBase)
        {
            _dataBase = dataBase;
            InitializeComponent();
        }

        private void DataBaseManagement_Load(object sender, EventArgs e)
        {
            ConfigFont.LoadFont();
            AllocFont(btnConfirm);
            AllocFont(btnCancel);
            AllocFont(btnTestConnection);
            AllocFont(btnDataBaseManegment);
            var dataBaseManegments = WebConnectionStringConfiguration.ReadConfigFile();
            InitializeComboBox(dataBaseManegments);
            cmb.SelectedItem = dataBaseManegments.FirstOrDefault(x => x.Caption == _dataBase.Caption);
            cmb.Enabled = string.IsNullOrEmpty(_dataBase.Caption);
            txtDataBase.Text = _dataBase.NewDataBase;
            txtPassword.Text = _dataBase.Password;
            txtServer.Text = _dataBase.Server;
            txtUser.Text = _dataBase.Username;
            chkEncryption.Checked = _dataBase.IsEncryption;
        }

        static void AllocFont(Control ctrl)
        {
            ConfigFont.AllocFont(ctrl, FontStyle.Regular, 9f);
        }

        private void InitializeComboBox(IEnumerable<DataBase> dataBaseManegments)
        {
            var dataSource = new List<DataBase>(dataBaseManegments.OrderBy(x => x.Index));
            cmb.DataSource = null;
            var bindingSource = new BindingSource { DataSource = dataSource };
            cmb.DataSource = bindingSource.DataSource;
            cmb.DisplayMember = "Caption";
            cmb.ValueMember = "Name";
            if (cmb.Items.Count > 0)
                cmb.SelectedIndex = 0;
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
                    MessageBox.Show(@"تست ارتباط با دیتابیس با موفقیت انجام شد..", @"اطلاع رسانی", MessageBoxButtons.OK, MessageBoxIcon.Question);
                connection.Close();
            }
            catch
            {
                MessageBox.Show(@"تست ارتباط با دیتابیس با خطا همراه است", @"خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServer.Text) || string.IsNullOrEmpty(txtDataBase.Text) || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(@"آدرس سرور؛نام دیتابیس؛نام کاربری و کلمه عبور را وارد نمایید.", @"خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dbManegment = (DataBase)cmb.SelectedItem;
                dbManegment.NewDataBase = txtDataBase.Text;
                dbManegment.Password = txtPassword.Text;
                dbManegment.Server = txtServer.Text;
                dbManegment.Username = txtUser.Text;
                dbManegment.IsEncryption = chkEncryption.Checked;
                Tag = dbManegment;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CheckConnection()
        {
            var isEnabled = !string.IsNullOrEmpty(txtServer.Text) && !string.IsNullOrEmpty(txtDataBase.Text) &&
                   !string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text) &&
                   cmb.SelectedIndex != -1;
            btnTestConnection.Enabled = isEnabled;
            btnConfirm.Enabled = isEnabled;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckConnection();
        }
        private void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            var cmbItem = ((ComboBox)sender).SelectedItem;
            if (cmbItem != null)
            {
                txtDataBase.Text = ((DataBase)cmbItem).DefualtDataBase;
                CheckConnection();
            }
        }
    }
}
