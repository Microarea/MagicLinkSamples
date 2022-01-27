namespace PurchaseDocJE_AP_AR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.rtbxResults = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnPostDocument = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbxXMLFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblLogNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblDocumentDate = new System.Windows.Forms.Label();
            this.lblDocNo = new System.Windows.Forms.Label();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.lblJournalEntryID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreatePayable = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPaymentTerm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnectionInfo = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnPostPayment = new System.Windows.Forms.Button();
            this.btnBrowsePayment = new System.Windows.Forms.Button();
            this.tbxPaymentXML = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lblPaymentJournalEntryID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnClosePayable = new System.Windows.Forms.Button();
            this.tbxPayableDocID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPaymentDocumentDate = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxInstallmentDueDate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // rtbxResults
            // 
            this.rtbxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbxResults.Location = new System.Drawing.Point(12, 291);
            this.rtbxResults.Name = "rtbxResults";
            this.rtbxResults.Size = new System.Drawing.Size(776, 147);
            this.rtbxResults.TabIndex = 4;
            this.rtbxResults.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 243);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.btnPostDocument);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Controls.Add(this.tbxXMLFile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 217);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step 1 - Purchase Document";
            // 
            // btnPostDocument
            // 
            this.btnPostDocument.Location = new System.Drawing.Point(24, 87);
            this.btnPostDocument.Name = "btnPostDocument";
            this.btnPostDocument.Size = new System.Drawing.Size(75, 23);
            this.btnPostDocument.TabIndex = 8;
            this.btnPostDocument.Text = "Post";
            this.btnPostDocument.UseVisualStyleBackColor = true;
            this.btnPostDocument.Click += new System.EventHandler(this.btnPostDocument_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(455, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 20);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxXMLFile
            // 
            this.tbxXMLFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxXMLFile.Location = new System.Drawing.Point(83, 25);
            this.tbxXMLFile.Name = "tbxXMLFile";
            this.tbxXMLFile.Size = new System.Drawing.Size(366, 20);
            this.tbxXMLFile.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Load XML";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblLogNo);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.lblTaxAmount);
            this.tabPage2.Controls.Add(this.lblTotalAmount);
            this.tabPage2.Controls.Add(this.lblDocumentDate);
            this.tabPage2.Controls.Add(this.lblDocNo);
            this.tabPage2.Controls.Add(this.lblSupplierCode);
            this.tabPage2.Controls.Add(this.lblJournalEntryID);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnCreatePayable);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbxPaymentTerm);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step 2 - Payable document";
            // 
            // lblLogNo
            // 
            this.lblLogNo.AutoSize = true;
            this.lblLogNo.Location = new System.Drawing.Point(117, 140);
            this.lblLogNo.Name = "lblLogNo";
            this.lblLogNo.Size = new System.Drawing.Size(45, 13);
            this.lblLogNo.TabIndex = 40;
            this.lblLogNo.Text = "(LogNo)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Log No";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Location = new System.Drawing.Point(115, 119);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(67, 13);
            this.lblTaxAmount.TabIndex = 38;
            this.lblTaxAmount.Text = "(TaxAmount)";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(115, 97);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 13);
            this.lblTotalAmount.TabIndex = 37;
            this.lblTotalAmount.Text = "(TotalAmount)";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.AutoSize = true;
            this.lblDocumentDate.Location = new System.Drawing.Point(115, 73);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(85, 13);
            this.lblDocumentDate.TabIndex = 36;
            this.lblDocumentDate.Text = "(DocumentDate)";
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.Location = new System.Drawing.Point(115, 48);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(47, 13);
            this.lblDocNo.TabIndex = 35;
            this.lblDocNo.Text = "(DocNo)";
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(115, 27);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(59, 13);
            this.lblSupplierCode.TabIndex = 34;
            this.lblSupplierCode.Text = "(CustSupp)";
            // 
            // lblJournalEntryID
            // 
            this.lblJournalEntryID.AutoSize = true;
            this.lblJournalEntryID.Location = new System.Drawing.Point(115, 7);
            this.lblJournalEntryID.Name = "lblJournalEntryID";
            this.lblJournalEntryID.Size = new System.Drawing.Size(80, 13);
            this.lblJournalEntryID.TabIndex = 33;
            this.lblJournalEntryID.Text = "(JournalEntryId)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Document number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Supplier code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Journal entry ID";
            // 
            // btnCreatePayable
            // 
            this.btnCreatePayable.Location = new System.Drawing.Point(8, 188);
            this.btnCreatePayable.Name = "btnCreatePayable";
            this.btnCreatePayable.Size = new System.Drawing.Size(207, 23);
            this.btnCreatePayable.TabIndex = 26;
            this.btnCreatePayable.Text = "Create Payable";
            this.btnCreatePayable.UseVisualStyleBackColor = true;
            this.btnCreatePayable.Click += new System.EventHandler(this.btnCreatePayable_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tax amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Total amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Document Date";
            // 
            // tbxPaymentTerm
            // 
            this.tbxPaymentTerm.Location = new System.Drawing.Point(115, 162);
            this.tbxPaymentTerm.Name = "tbxPaymentTerm";
            this.tbxPaymentTerm.Size = new System.Drawing.Size(100, 20);
            this.tbxPaymentTerm.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Payment terms code";
            // 
            // lblConnectionInfo
            // 
            this.lblConnectionInfo.Location = new System.Drawing.Point(93, 17);
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.Size = new System.Drawing.Size(264, 18);
            this.lblConnectionInfo.TabIndex = 6;
            this.lblConnectionInfo.Text = "(not connected)";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.btnPostPayment);
            this.tabPage3.Controls.Add(this.btnBrowsePayment);
            this.tabPage3.Controls.Add(this.tbxPaymentXML);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(767, 217);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step 3 - Accounting Payment";
            // 
            // btnPostPayment
            // 
            this.btnPostPayment.Location = new System.Drawing.Point(35, 85);
            this.btnPostPayment.Name = "btnPostPayment";
            this.btnPostPayment.Size = new System.Drawing.Size(75, 23);
            this.btnPostPayment.TabIndex = 12;
            this.btnPostPayment.Text = "Post";
            this.btnPostPayment.UseVisualStyleBackColor = true;
            this.btnPostPayment.Click += new System.EventHandler(this.btnPostPayment_Click);
            // 
            // btnBrowsePayment
            // 
            this.btnBrowsePayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePayment.Location = new System.Drawing.Point(466, 23);
            this.btnBrowsePayment.Name = "btnBrowsePayment";
            this.btnBrowsePayment.Size = new System.Drawing.Size(30, 20);
            this.btnBrowsePayment.TabIndex = 11;
            this.btnBrowsePayment.Text = "...";
            this.btnBrowsePayment.UseVisualStyleBackColor = true;
            this.btnBrowsePayment.Click += new System.EventHandler(this.btnBrowsePayment_Click);
            // 
            // tbxPaymentXML
            // 
            this.tbxPaymentXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPaymentXML.Location = new System.Drawing.Point(94, 23);
            this.tbxPaymentXML.Name = "tbxPaymentXML";
            this.tbxPaymentXML.Size = new System.Drawing.Size(366, 20);
            this.tbxPaymentXML.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Load XML";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.tbxInstallmentDueDate);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.lblPaymentAmount);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.lblPaymentDocumentDate);
            this.tabPage4.Controls.Add(this.label99);
            this.tabPage4.Controls.Add(this.btnClosePayable);
            this.tabPage4.Controls.Add(this.tbxPayableDocID);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.lblPaymentJournalEntryID);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(767, 217);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step 4 - Payable Closing";
            // 
            // lblPaymentJournalEntryID
            // 
            this.lblPaymentJournalEntryID.AutoSize = true;
            this.lblPaymentJournalEntryID.Location = new System.Drawing.Point(173, 13);
            this.lblPaymentJournalEntryID.Name = "lblPaymentJournalEntryID";
            this.lblPaymentJournalEntryID.Size = new System.Drawing.Size(123, 13);
            this.lblPaymentJournalEntryID.TabIndex = 35;
            this.lblPaymentJournalEntryID.Text = "(PaymentJournalEntryID)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Payment Journal entry ID";
            // 
            // btnClosePayable
            // 
            this.btnClosePayable.Location = new System.Drawing.Point(33, 134);
            this.btnClosePayable.Name = "btnClosePayable";
            this.btnClosePayable.Size = new System.Drawing.Size(207, 23);
            this.btnClosePayable.TabIndex = 38;
            this.btnClosePayable.Text = "Close Payable";
            this.btnClosePayable.UseVisualStyleBackColor = true;
            this.btnClosePayable.Click += new System.EventHandler(this.btnClosePayable_Click);
            // 
            // tbxPayableDocID
            // 
            this.tbxPayableDocID.Location = new System.Drawing.Point(176, 104);
            this.tbxPayableDocID.Name = "tbxPayableDocID";
            this.tbxPayableDocID.Size = new System.Drawing.Size(100, 20);
            this.tbxPayableDocID.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Payable document ID";
            // 
            // lblPaymentDocumentDate
            // 
            this.lblPaymentDocumentDate.AutoSize = true;
            this.lblPaymentDocumentDate.Location = new System.Drawing.Point(173, 35);
            this.lblPaymentDocumentDate.Name = "lblPaymentDocumentDate";
            this.lblPaymentDocumentDate.Size = new System.Drawing.Size(126, 13);
            this.lblPaymentDocumentDate.TabIndex = 40;
            this.lblPaymentDocumentDate.Text = "(PaymentDocumentDate)";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(30, 35);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(126, 13);
            this.label99.TabIndex = 39;
            this.label99.Text = "Payment Document Date";
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Location = new System.Drawing.Point(173, 57);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(90, 13);
            this.lblPaymentAmount.TabIndex = 42;
            this.lblPaymentAmount.Text = "(PaymentAmount)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "Payment Amount";
            // 
            // tbxInstallmentDueDate
            // 
            this.tbxInstallmentDueDate.Location = new System.Drawing.Point(176, 78);
            this.tbxInstallmentDueDate.Name = "tbxInstallmentDueDate";
            this.tbxInstallmentDueDate.Size = new System.Drawing.Size(100, 20);
            this.tbxInstallmentDueDate.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Installment due date";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblConnectionInfo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rtbxResults);
            this.Controls.Add(this.btnLogin);
            this.Name = "MainForm";
            this.Text = "PurchaseDocJE - AP_AR";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RichTextBox rtbxResults;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbxXMLFile;
        private System.Windows.Forms.Button btnPostDocument;
        private System.Windows.Forms.Label lblConnectionInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreatePayable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPaymentTerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblJournalEntryID;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.Label lblDocNo;
        private System.Windows.Forms.Label lblDocumentDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label lblLogNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnPostPayment;
        private System.Windows.Forms.Button btnBrowsePayment;
        private System.Windows.Forms.TextBox tbxPaymentXML;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblPaymentJournalEntryID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClosePayable;
        private System.Windows.Forms.TextBox tbxPayableDocID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblPaymentDocumentDate;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.TextBox tbxInstallmentDueDate;
        private System.Windows.Forms.Label label13;
    }
}

