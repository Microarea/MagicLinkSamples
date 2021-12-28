using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MagicLinkCGM
{
    public partial class MainForm : Form
    {
        string server = ""; // the server where Mago is installed: "localhost" or some PC in the LAN
        string instance = "Mago4"; // Mago4 is the default instance name, but it can be changed
        string loginName = ""; // a valid user name
        string companyName = ""; // its password
        string password = ""; // name of the company (this is the company owning of the DB, containing the "fiscal" ones)

        string authenticationToken = "";
        public int tbPort;

        public MainForm()
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

            using (MagoTBServices.TbServicesSoapClient aTbService = new MagoTBServices.TbServicesSoapClient())
            {
                aTbService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/TBServices/TBServices.asmx", server, instance));
                string easyLookToken = string.Empty;

                try
                {
                    tbPort = aTbService.CreateTB(authenticationToken, DateTime.Today, true, out easyLookToken);

                    if (tbPort > 0)
                        MessageBox.Show(string.Format("Connected! Port: {0}", tbPort));
                    else
                        MessageBox.Show(string.Format("CreateTB: some error occurred, returned value: {0}", tbPort));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(string.Format("CreateTB: Exception occurred: {0}", exc.Message));
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

        private void btnSetFiscalCompany_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("You need to connect before setting the fiscal company");
            }

            try
            {
                int aFiscalCompany = int.Parse(tbxFiscalCompany.Text);

                TbGenlibUI.TbGenlibUI tbGenlib = new TbGenlibUI.TbGenlibUI();
                tbGenlib.Url = string.Format("http://{0}:{1}/Framework.TbGenlibUI.TbGenlibUI/TbGenlibUI", server, tbPort);

                tbGenlib.HeaderInfo = new TbGenlibUI.TBHeaderInfo();
                tbGenlib.HeaderInfo.AuthToken = authenticationToken;

                tbGenlib.SetFiscalCompany(aFiscalCompany, "");

                MessageBox.Show(string.Format("Fiscal company now is {0}", aFiscalCompany));
            }
            catch (FormatException fmt)
            {
                MessageBox.Show(string.Format("Invalid Fiscal Company number: {0}", fmt.Message));
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Format("Set Fiscal Company: Exception occurred: {0}", exc.Message));
            }

        }

        private void btnSetData_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("You need to connect before sending data");
            }

            using (MagoTBServices.TbServicesSoapClient aTbService = new MagoTBServices.TbServicesSoapClient())
            {
                aTbService.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/TBServices/TBServices.asmx", server, instance));

                string aXMLData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\sample.xml"));
                string aResult = string.Empty;

                try
                {
                    if (aTbService.SetData(authenticationToken, aXMLData, System.DateTime.Now, 0, false, out aResult))
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
        private void btnReport_Click(object sender, EventArgs e)
        {
            using (MagoEasyLookService.EasyLookServiceSoapClient aEasyLookSvc = new MagoEasyLookService.EasyLookServiceSoapClient())
            {
                aEasyLookSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress(string.Format("http://{0}/{1}/EasyLook/EasyLookService.asmx", server, instance));

                try
                {

                  string XMLParameters =
                  $@"<?xml version='1.0' encoding='utf-16'?>
                            <maxs:Companies tbNamespace = 'Report.CGM.Core.Companies' xmlns:maxs = 'http://www.microarea.it/Schema/2004/Smart/CGM/Core/Companies.xsd'>
                                <maxs:Parameters>
                                </maxs:Parameters>
                            </maxs:Companies>";
                    MagoEasyLookService.ArrayOfString xmlResult = aEasyLookSvc.XmlExecuteReport(authenticationToken, XMLParameters, DateTime.Now, "MicroareaAdmin", true);
                    //MessageBox.Show(xmlResult[0]);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlResult[0]);
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsmgr.AddNamespace("maxs", xmlDoc.DocumentElement.NamespaceURI);

                    XmlNodeList itemNodes = xmlDoc.SelectNodes("//maxs:Row", nsmgr);

                    string companyList = string.Empty;
                    foreach (XmlNode node in itemNodes)
                    {
                        companyList += $"id {node.SelectSingleNode("maxs:CompanyId", nsmgr).InnerText} : {node.SelectSingleNode("maxs:CompanyName", nsmgr).InnerText}\n";
                    }
                    MessageBox.Show(companyList);

                }
                catch (Exception exc)
                {
                    MessageBox.Show(string.Format("GetData: Exception occurred: {0}", exc.Message));
                    return;
                }
            }

        }
    }
}
