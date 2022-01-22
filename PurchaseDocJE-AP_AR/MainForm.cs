using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PurchaseDocJE_AP_AR
{
    public class Installment
    {
        public string Date = string.Empty;
        public double Amount = 0.0;
        public int Type = 0;
    }
    public partial class MainForm : Form
    {
        private string authenticationToken = "";
        private string user = "";
        private string server;
        private string instance;
        private int tbPort;

        private string JournalEntryId;
        private List<Installment> installments = new List<Installment>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login aLog = new Login();
            if (aLog.ShowDialog() == DialogResult.OK)
            {
                authenticationToken = aLog.AuthenticationToken;
                user = aLog.User;
                server = aLog.Server;
                instance = aLog.Instance;
                tbPort = aLog.TbPort;

                if (tbPort == 0)
                {
                    rtbxResults.Text = $"Authentication token: {authenticationToken}";
                    lblConnectionInfo.Text = "Connected";
                }
                else
                {
                    lblConnectionInfo.Text = $"Connected, port {tbPort}";
                }
            }

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login.DoLogout(authenticationToken, server, instance);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (tbxXMLFile.Text != string.Empty)
            {
                dlg.InitialDirectory = Directory.GetParent(tbxXMLFile.Text).FullName;
            }
            else if (Properties.Settings.Default.StartFolder != string.Empty)
            {
                dlg.InitialDirectory = Properties.Settings.Default.StartFolder;
            }
            else
            {
                dlg.InitialDirectory = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName, "samples");
            }

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbxXMLFile.Text = dlg.FileName;
                Properties.Settings.Default.StartFolder = Directory.GetParent(dlg.FileName).FullName;
            }
        }

        private void btnPostDocument_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("Please login before posting");
                return;
            }

            if (tbxXMLFile.Text == string.Empty)
            {
                MessageBox.Show("Please select an XML file to load");
                return;
            }

            using (MagoTBServices.TbServicesSoapClient aTbSvc = new MagoTBServices.TbServicesSoapClient())
            {
                aTbSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress($"http://{server}/{instance}/TBServices/TBServices.asmx");

                XElement xmlDoc = XElement.Load(tbxXMLFile.Text);
                // remove comments from sample XML if any, SetData does not accept them
                xmlDoc.DescendantNodes().OfType<XComment>().Remove();
                string strResult;
                bool bSuccess = aTbSvc.SetData(authenticationToken, xmlDoc.ToString(), DateTime.Now, 0, true, out strResult);
                if (bSuccess)
                {
                    XElement xmlResult = XElement.Parse(strResult);

                    // the returned XML has a namespace, need to be matched for the XPath query below
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
                    nsmgr.AddNamespace("maxs", xmlResult.Name.NamespaceName);

                    try
                    {
                        // the Id of the created Journal entry is extracted from the returned XML, by matching the first node containing it
                        JournalEntryId = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:JournalEntryId", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        // extract some other useful data for the next steps
                        tbxDocumentDate.Text = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:DocumentDate", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        tbxTotalAmount.Text = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:TotalAmount", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        tbxTaxAmount.Text = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:TaxAmount", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;

                        rtbxResults.Text = $"success \n{xmlResult}\n";
                    }
                    catch (Exception ex)
                    {
                        rtbxResults.Text = $"!!!FAILED!!! \n[{ex.Message}]\n";
                    }
                }
                else
                {
                    rtbxResults.Text = $"!!!FAILED!!! \n[{strResult}]\n";
                }
            }

        }

        private void btnInstallments_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("Please login before posting");
                return;
            }

            if (tbxPaymentTerm.Text == string.Empty || tbxDocumentDate.Text == string.Empty || tbxTotalAmount.Text == string.Empty || tbxTaxAmount.Text == string.Empty)
            {
                MessageBox.Show("Please set a payment term code, a document date, a total amount and a tax amount");
                return;
            }

            AP_AR_Components.AP_ARComponents AP_AR = new AP_AR_Components.AP_ARComponents();
            AP_AR.Url = string.Format("http://{0}:{1}/ERP.AP_AR.Components/AP_ARComponents", server, tbPort);

            AP_AR.HeaderInfo = new AP_AR_Components.TBHeaderInfo();
            AP_AR.HeaderInfo.AuthToken = authenticationToken;

            int handle = AP_AR.InstallmentDetails_Create();

            int InstNo = 0;
            Installment installment = new Installment();
            try
            {
                bool bMore;
                installments.Clear();
                do
                {
                    bMore = AP_AR.InstallmentDetails_CalculateInstallmentData(
                        handle,
                        tbxPaymentTerm.Text,
                        "EUR",
                        tbxDocumentDate.Text,
                        double.Parse(tbxTotalAmount.Text, CultureInfo.InvariantCulture),
                        double.Parse(tbxTaxAmount.Text, CultureInfo.InvariantCulture),
                        ref InstNo,
                        ref installment.Date,
                        ref installment.Type,
                        ref installment.Amount
                    );
                    if (bMore)
                    {
                        installments.Add(installment);
                        InstNo++;
                    }
                } while (bMore);

                rtbxResults.Text = string.Empty;
                foreach (var inst in installments)
                {
                    rtbxResults.Text += $"{inst.Date}  {inst.Amount}\n";
                }
            }
            catch (Exception ex)
            {
                rtbxResults.Text = $"!!!FAILED!!! \n[{ex.Message}]\n";
            }

            AP_AR.InstallmentDetails_Dispose(handle);
        }
    }
}
