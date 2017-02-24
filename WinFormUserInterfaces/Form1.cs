using System;
using System.Drawing;
using System.Windows.Forms;
using ZaHra.WinFormUserInterfaces.UserControls;

namespace ZaHra.WinFormUserInterfaces
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void XapConfiguration_Click(object sender, EventArgs e)
        {
            InitializeWebConfig(sender, UserControlType.XapConfig);
        }

        private void Connectionstring_Click(object sender, EventArgs e)
        {
            InitializeWebConfig(sender, UserControlType.Connectionstring);
        }
        
        private void ServiceModelClient_Click(object sender, EventArgs e)
        {
            InitializeWebConfig(sender, UserControlType.ServiceModelClient);
        }

        private void InitializeWebConfig(object sender, UserControlType userControlType)
        {
            var web = new WebConfig(userControlType);
            InitializeGridMenu(sender, web);
        }

        private void InitializeGridMenu(object sender, UserControl userControl)
        {
            var menu = (ToolStripMenuItem)sender;
            grdMain.Controls.Clear();
            grdMain.Text = menu.Text;
            userControl.Location = new Point(10, 15);
            grdMain.Controls.Add(userControl);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
        private void InitializeDataBase(object sender)
        {
            var dataBaseConfig = new ExecuteDataBase(UserControlType.ExecuteDataBase);
            InitializeGridMenu(sender, dataBaseConfig);
        }
        private void ExecuteSrciptDataBase_Click(object sender, EventArgs e)
        {
            InitializeDataBase(sender);
        }

        private void GeneratDataBase_Click(object sender, EventArgs e)
        {

        }

        private void GeneratData_Click(object sender, EventArgs e)
        {
            var generateDataBase = new GenerateDataBase(UserControlType.GenerateValue);
            InitializeGridMenu(sender, generateDataBase);
        }

        private void ExecuteSrciptData_Click(object sender, EventArgs e)
        {
            var dataBaseConfig = new ExecuteDataBase(UserControlType.ExecuteValue);
            InitializeGridMenu(sender, dataBaseConfig);
        }
    }
}
