using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YourFirstMagicLinkApplication
{
    public partial class Form1 : Form
    {
        string server = ""; // the server where Mago is installed: "localhost" or some PC in the LAN
        string instance = "Mago4"; // Mago4 is the default instance name, but it can be changed
        string loginName = ""; // a valid user name
        string password = ""; // its password
        string companyName = ""; // name of the company, owner of the DB

        string authenticationToken;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            using (MagoLoginManager.MicroareaLoginManagerSoapClient aLogMng = new MagoLoginManager.MicroareaLoginManagerSoapClient())
            {
                aLogMng.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/LoginManager/LoginManager.asmx", server, instance));

                try
                {
                    int aRes = aLogMng.LoginCompact(ref loginName, ref companyName, password, "Your code here", true, out authenticationToken);

                    if (aRes != 0) // 0 means no errors
                        MessageBox.Show(string.Format("Error occurred, code: {0}", aRes));
                    else
                        MessageBox.Show("Connected!");
                }
                catch (Exception logExc)
                {
                    MessageBox.Show(string.Format("Exception occurred: {0}", logExc.Message));
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnPost_Click(object sender, EventArgs e)
        {
            // 1
            string xmlData = $@"<?xml version='1.0'?>
<maxs:Contacts xmlns:maxs='http://www.microarea.it/Schema/2004/Smart/ERP/Contacts/Contacts/Standard/DefaultLight.xsd' tbNamespace = 'Document.ERP.Contacts.Documents.Contacts' xTechProfile = 'DefaultLight' >
    <maxs:Data>
        <maxs:Contacts master='true'>
            <maxs:CompanyName>{txtCompanyName.Text}</maxs:CompanyName>
            <maxs:Address>{txtAddress.Text}</maxs:Address>
            <maxs:Telephone1>{txtPhone.Text}</maxs:Telephone1>
            <maxs:ContactPerson>{txtContactName.Text}</maxs:ContactPerson>
        </maxs:Contacts>
    </maxs:Data>
</maxs:Contacts> ";

            // 2
            using (MagoTBService.TbServicesSoapClient aTbSvc = new MagoTBService.TbServicesSoapClient())
            {
                aTbSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://localhost/{0}/TBServices/TBServices.asmx", instance));
                string aResult = string.Empty;

                // 3
                try
                {
                    // 4
                    if (aTbSvc.SetData(authenticationToken, xmlData, System.DateTime.Now, 0, false, out aResult))
                        MessageBox.Show("Posted!");
                    else
                        MessageBox.Show("Not posted, some error occurred!");
                }
                catch (Exception tbExc)
                {
                    MessageBox.Show(string.Format("Exception occurred: {0}", tbExc.Message));
                }
            }

        }
    }
}
