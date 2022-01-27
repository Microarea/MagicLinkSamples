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
    public partial class MainForm : Form
    {
        private string authenticationToken = "";
        private string server;
        private string instance;
        private int tbPort;

        private string JournalEntryID = string.Empty;
        private string SupplierCode = string.Empty;
        private string DocumentDate = string.Empty;
        private string DocumentNumber = string.Empty;
        private string TotalAmount = string.Empty;
        private string TaxAmount = string.Empty;
        private string LogNo = string.Empty;
        private string PaymentJournalEntryID = string.Empty;
        private string PaymentDocumentDate = string.Empty;
        private string PaymentAmount = string.Empty;

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
                        // The Id of the created Journal entry and other useful data are extracted
                        // from the returned XML, by matching the first node containing the corresponding tag
                        JournalEntryID = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:JournalEntryId", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        SupplierCode = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:CustSupp", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        DocumentDate = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:DocumentDate", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        DocumentNumber = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:DocNo", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        TotalAmount = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:TotalAmount", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        TaxAmount = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:TaxAmount", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        LogNo = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:LogNo", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;

                        rtbxResults.Text = $"success \n{xmlResult}\n";

                        //to show on the interface:
                        lblJournalEntryID.Text = JournalEntryID;
                        lblSupplierCode.Text = SupplierCode;
                        lblDocNo.Text = DocumentNumber;
                        lblDocumentDate.Text = DocumentDate;
                        lblTotalAmount.Text = TotalAmount;
                        lblTaxAmount.Text = TaxAmount;
                        lblLogNo.Text = LogNo;
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


        private void btnCreatePayable_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("Please login before posting");
                return;
            }

            if (tbxPaymentTerm.Text == string.Empty)
            {
                MessageBox.Show("Please set a payment term code");
                return;
            }

            if (JournalEntryID == string.Empty)
            {
                MessageBox.Show("Please post a purchase document before the payable");
                return;
            }

            // omitting the PaymentTerm node will apply the default payment of the Supplier master
            XElement xmlPayable = XElement.Parse($@"<?xml version='1.0'?>
            <maxs:Payables xmlns:maxs='http://www.microarea.it/Schema/2004/Smart/ERP/AP_AR/Payables/AllUsers/Basic.xsd' tbNamespace='Document.ERP.AP_AR.Documents.Payables' xTechProfile='Basic'>
                <maxs:Data>
                    <maxs:AP_AR master='true'>
                        <maxs:CustSuppType>3211265</maxs:CustSuppType>
                        <maxs:CustSupp>{SupplierCode}</maxs:CustSupp>
                        <maxs:Payment>{tbxPaymentTerm.Text}</maxs:Payment>
                        <maxs:DocNo>{DocumentNumber}</maxs:DocNo>
                        <maxs:DocumentDate>{DocumentDate}</maxs:DocumentDate>
                        <maxs:TotalAmount>{TotalAmount}</maxs:TotalAmount>
                        <maxs:TaxAmount>{TaxAmount}</maxs:TaxAmount>
                        <maxs:JournalEntryId>{JournalEntryID}</maxs:JournalEntryId>
                        <maxs:LogNo>{LogNo}</maxs:LogNo>
                        <maxs:CRRefType>27066420</maxs:CRRefType>
                        <maxs:CRRefID>{JournalEntryID}</maxs:CRRefID>
                    </maxs:AP_AR>
                </maxs:Data>
            </maxs:Payables>");

            /*
            It is possible to use a custom set of installments instead of accepting the automatic calculation 
            (see "Custom Installments" below)
            *//*
            XNamespace maxs = xmlPayable.Name.NamespaceName;
            var data = xmlPayable.Descendants(maxs + "Data").FirstOrDefault();
            var detail = new XElement("Detail");
            data.Add(detail);

            CreateInstallments();
            foreach (var installment in installments)
            {
                XElement xmlInstallment = XElement.Parse($@"
                <maxs:DetailRow xmlns:maxs='http://www.microarea.it/Schema/2004/Smart/ERP/AP_AR/Payables/AllUsers/Basic.xsd'>
                    <maxs:PaymentTerm>{installment.PaymentTerm}</maxs:PaymentTerm>
                    <maxs:InstallmentDate>{installment.Date}</maxs:InstallmentDate>
                    <maxs:DebitCreditSign>4980737</maxs:DebitCreditSign>
                    <maxs:Amount>{installment.Amount.ToString(CultureInfo.InvariantCulture)}</maxs:Amount>
                    <maxs:PayableAmountInBaseCurr>{installment.Amount.ToString(CultureInfo.InvariantCulture)}</maxs:PayableAmountInBaseCurr>
                </maxs:DetailRow>");

                detail.Add(xmlInstallment);
            }
            /**/

            using (MagoTBServices.TbServicesSoapClient aTbSvc = new MagoTBServices.TbServicesSoapClient())
            {
                aTbSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress($"http://{server}/{instance}/TBServices/TBServices.asmx");

                string strResult;
                bool bSuccess = aTbSvc.SetData(authenticationToken, xmlPayable.ToString(), DateTime.Now, 0, true, out strResult);
                if (bSuccess)
                {
                    XElement xmlResult = XElement.Parse(strResult);

                    rtbxResults.Text = $"success \n{xmlResult}\n";
                }
                else
                {
                    rtbxResults.Text = $"!!!FAILED!!! \n[{strResult}]\n";
                }
            }

        }

        private void btnBrowsePayment_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (tbxPaymentXML.Text != string.Empty)
            {
                dlg.InitialDirectory = Directory.GetParent(tbxPaymentXML.Text).FullName;
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
                tbxPaymentXML.Text = dlg.FileName;
                Properties.Settings.Default.StartFolder = Directory.GetParent(dlg.FileName).FullName;
            }

        }

        private void btnPostPayment_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("Please login before posting");
                return;
            }

            if (tbxPaymentXML.Text == string.Empty)
            {
                MessageBox.Show("Please select an XML file to load");
                return;
            }

            using (MagoTBServices.TbServicesSoapClient aTbSvc = new MagoTBServices.TbServicesSoapClient())
            {
                aTbSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress($"http://{server}/{instance}/TBServices/TBServices.asmx");

                XElement xmlDoc = XElement.Load(tbxPaymentXML.Text);
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
                        // The Id of the created Journal entry and other useful data are are extracted from the returned XML,
                        // by matching the first node containing the corresponding tag
                        PaymentJournalEntryID = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:JournalEntryId", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        PaymentDocumentDate = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:DocumentDate", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;
                        PaymentAmount = (((IEnumerable)xmlResult.XPathEvaluate("//maxs:Amount", nsmgr)).Cast<XElement>()).FirstOrDefault().Value;

                        rtbxResults.Text = $"success \n{xmlResult}\n";

                        //to show on the interface:
                        lblPaymentJournalEntryID.Text = PaymentJournalEntryID;
                        lblPaymentDocumentDate.Text = PaymentDocumentDate;
                        lblPaymentAmount.Text = PaymentAmount;
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

        private void btnClosePayable_Click(object sender, EventArgs e)
        {
            if (authenticationToken == string.Empty)
            {
                MessageBox.Show("Please login before posting");
                return;
            }

            if (PaymentJournalEntryID == string.Empty)
            {
                MessageBox.Show("Please post the accounting payment before closing the payable");
                return;
            }

            if (tbxPayableDocID.Text == string.Empty)
            {
                MessageBox.Show("Please set the ID of the payable to close");
                return;
            }

            XElement xmlClosing = XElement.Parse($@"<?xml version='1.0'?>
                <maxs:Payables xmlns:maxs='http://www.microarea.it/Schema/2004/Smart/ERP/AP_AR/Payables/AllUsers/Basic.xsd' tbNamespace='Document.ERP.AP_AR.Documents.Payables' xTechProfile='Basic'>
                    <maxs:Data>
                        <maxs:AP_AR master='true'>
                            <maxs:PymtSchedId>{tbxPayableDocID.Text}</maxs:PymtSchedId>
                        </maxs:AP_AR>
                        <maxs:Detail updateType='OnlyInsert'>
                            <maxs:DetailRow>
                                <maxs:InstallmentNo>1</maxs:InstallmentNo>
                                <maxs:InstallmentType>5505025</maxs:InstallmentType>
                                <maxs:InstallmentDate>{PaymentDocumentDate}</maxs:InstallmentDate>
                                <maxs:OpeningDate>{tbxInstallmentDueDate.Text}</maxs:OpeningDate>
                                <maxs:PaymentTerm>2686976</maxs:PaymentTerm>
                                <maxs:DebitCreditSign>4980736</maxs:DebitCreditSign>
                                <maxs:Amount>{PaymentAmount}</maxs:Amount>
                                <maxs:PayableAmountInBaseCurr>{PaymentAmount}</maxs:PayableAmountInBaseCurr>
                                <maxs:JournalEntryId>{PaymentJournalEntryID}</maxs:JournalEntryId>
                                <maxs:PresentationJEId>{PaymentJournalEntryID}</maxs:PresentationJEId>
                            </maxs:DetailRow>
                        </maxs:Detail>
                    </maxs:Data>
                </maxs:Payables>");

            using (MagoTBServices.TbServicesSoapClient aTbSvc = new MagoTBServices.TbServicesSoapClient())
            {
                aTbSvc.Endpoint.Address = new System.ServiceModel.EndpointAddress($"http://{server}/{instance}/TBServices/TBServices.asmx");

                string strResult;
                bool bSuccess = aTbSvc.SetData(authenticationToken, xmlClosing.ToString(), DateTime.Now, 0, true, out strResult);
                if (bSuccess)
                {
                    XElement xmlResult = XElement.Parse(strResult);

                    rtbxResults.Text = $"success \n{xmlResult}\n";
                }
                else
                {
                    rtbxResults.Text = $"!!!FAILED!!! \n[{strResult}]\n";
                }
            }
        }
    }

}
// 169

/*
    Custom Installments
    ===================

    It is possible to submit a custom list of installments, using a similar structure
    
        private List<Installment> installments = new List<Installment>();

        public class Installment
        {
            public string Date = string.Empty;
            public double Amount = 0.0;
            public int Type = 0;
        }

    don't forget to set in the Payable header the installment starting date:

        <maxs:InstallmStartDate>{MyStartingDate}</maxs:InstallmStartDate>


    As a matter of example, this is how to ask Mago to calculate the installments starting from a Payment Term Code.
    It is required to add a Web Reference (not a Connected Service) to the Mago4 component that exposes the web method: http://[Mago4 server]:[port]/ERP.AP_AR.Components/AP_ARComponents

        private void CreateInstallments()
        {
            AP_AR_Components.AP_ARComponents AP_AR = new AP_AR_Components.AP_ARComponents();
            AP_AR.Url = string.Format("http://{0}:{1}/ERP.AP_AR.Components/AP_ARComponents", server, tbPort);

            AP_AR.HeaderInfo = new AP_AR_Components.TBHeaderInfo();
            AP_AR.HeaderInfo.AuthToken = authenticationToken;

            int handle = AP_AR.InstallmentDetails_Create();

            int InstNo = 0;

            bool bMore;
            installments.Clear();
            do
            {
                Installment installment = new Installment();
                bMore = AP_AR.InstallmentDetails_CalculateInstallmentData(
                    handle,
                    MyCustomPayment,
                    "EUR",
                    MyStartingDate,
                    double.Parse(TotalAmount, CultureInfo.InvariantCulture),
                    double.Parse(TaxAmount, CultureInfo.InvariantCulture),
                    ref InstNo,
                    ref installment.Date,
                    ref installment.PaymentTerm,
                    ref installment.Amount
                );
                if (bMore)
                {
                    installments.Add(installment);
                    InstNo++;
                }
            } while (bMore);

            AP_AR.InstallmentDetails_Dispose(handle);
        }

 */





