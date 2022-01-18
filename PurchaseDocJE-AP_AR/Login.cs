using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseDocJE_AP_AR
{
    public partial class Login : Form
    {
        private string authenticationToken = "";
        private string server;
        private string instance;
        private int tbPort;
        private string user;
        public string easyLookToken = string.Empty;

        public string AuthenticationToken { get { return authenticationToken; } }
        public string Server { get { return server; } }
        public string Instance { get { return instance; } }
        public string User { get { return user; } }

        public int TbPort { get { return tbPort; } }

        public Login()
        {
            InitializeComponent();
            tbxServer.Text = Properties.Settings.Default.server;
            tbxInstance.Text = Properties.Settings.Default.instance;
            tbxCompany.Text = Properties.Settings.Default.company;
            tbxUser.Text = Properties.Settings.Default.user;
            tbxPassword.Text = Properties.Settings.Default.password;
            chbStartTbLoader.Checked = Properties.Settings.Default.startTB;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.server = tbxServer.Text;
            Properties.Settings.Default.instance = tbxInstance.Text;
            Properties.Settings.Default.company = tbxCompany.Text;
            Properties.Settings.Default.user = tbxUser.Text;
            Properties.Settings.Default.password = tbxPassword.Text;
            Properties.Settings.Default.startTB = chbStartTbLoader.Checked;

            Properties.Settings.Default.Save();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            server = tbxServer.Text;
            instance = tbxInstance.Text;
            user = tbxUser.Text;
            string company = tbxCompany.Text;
            string password = tbxPassword.Text;

            Cursor.Current = Cursors.WaitCursor;

            using (MagoLoginManager.MicroareaLoginManagerSoapClient aLogMng = new MagoLoginManager.MicroareaLoginManagerSoapClient())
            {
                aLogMng.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/LoginManager/LoginManager.asmx", server, instance));

                try
                {
                    int aRes = aLogMng.LoginCompact(ref user, ref company, password, "BPM", true, out authenticationToken);

                    if (aRes != 0) // 0 means no errors
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(string.Format("Error occurred, code: {0}", aRes));
                        DialogResult = DialogResult.Abort;
                        Close();
                        return;
                    }
                }
                catch (Exception logExc)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(string.Format("Exception occurred: {0}", logExc.Message));
                    DialogResult = DialogResult.Abort;
                    Close();
                    return;
                }
            }

            if (chbStartTbLoader.Checked)
            {
                using (MagoTBServices.TbServicesSoapClient aTbService = new MagoTBServices.TbServicesSoapClient())
                {
                    aTbService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/TBServices/TBServices.asmx", server, instance));
                    try
                    {
                        tbPort = aTbService.CreateTB(authenticationToken, DateTime.Today, true, out easyLookToken);

                        if (tbPort <= 0)
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show(string.Format("CreateTB: some error occurred, returned value: {0}", tbPort));
                            DialogResult = DialogResult.Abort;
                            Close();
                            return;
                        }
                    }
                    catch (Exception exc)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show(string.Format("CreateTB: Exception occurred: {0}", exc.Message));
                        DialogResult = DialogResult.Abort;
                        Close();
                        return;
                    }
                }
            }

            Cursor.Current = Cursors.Default;
            if (chbStartTbLoader.Checked)
                MessageBox.Show(string.Format("Connected! Port: {0}", tbPort));
            else
                MessageBox.Show("Connected! (no TBLoader requested)");
            DialogResult = DialogResult.OK;
            Close();
            return;
        }

        public static void DoLogout(string authenticationToken, string server, string instance)
        {
            if (authenticationToken != string.Empty)
            {
                using (MagoLoginManager.MicroareaLoginManagerSoapClient aLog = new MagoLoginManager.MicroareaLoginManagerSoapClient())
                {
                    aLog.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/LoginManager/LoginManager.asmx", server, instance));
                    aLog.LogOff(authenticationToken);
                }
            }

        }

    }
}
