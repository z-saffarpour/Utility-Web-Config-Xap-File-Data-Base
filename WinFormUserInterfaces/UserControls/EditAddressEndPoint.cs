using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ZaHra.Utility;
using ZaHra.Utility.DTO.Config;

namespace ZaHra.WinFormUserInterfaces.UserControls
{
    public partial class EditAddressEndPoint : Form
    {
        private readonly Endpoint _endpoint;
        public EditAddressEndPoint(Endpoint endpoint)
        {
            _endpoint = endpoint;
            InitializeComponent();

        }
        private void EditAddressEndPoint_Load(object sender, System.EventArgs e)
        {
            ConfigFont.LoadFont();
            AllocFont(btnConfirm);
            AllocFont(btnCancel);
            lnkAddress.Text = _endpoint.Address;
            lnkAddress.Links.Add(0, lnkAddress.Text.Length, _endpoint.Address);
            txtIp.Text = _endpoint.Host;
            txtPort.Text = _endpoint.Port.ToString(CultureInfo.InvariantCulture);
        }

        static void AllocFont(Control ctrl)
        {
            ConfigFont.AllocFont(ctrl, FontStyle.Regular, 9f);
        }
        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            _endpoint.Host = txtIp.Text;
            _endpoint.Port = System.Convert.ToInt32(txtPort.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lnkAddress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkAddress.LinkVisited = true;
            System.Diagnostics.Process.Start(lnkAddress.Text);
        }
    }
}
