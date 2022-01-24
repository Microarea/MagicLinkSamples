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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tabPage1.Text = "Purchase Document";
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
            this.tabPage2.Text = "Payable document";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Location = new System.Drawing.Point(115, 139);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(67, 13);
            this.lblTaxAmount.TabIndex = 38;
            this.lblTaxAmount.Text = "(TaxAmount)";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(115, 113);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 13);
            this.lblTotalAmount.TabIndex = 37;
            this.lblTotalAmount.Text = "(TotalAmount)";
            // 
            // lblDocumentDate
            // 
            this.lblDocumentDate.AutoSize = true;
            this.lblDocumentDate.Location = new System.Drawing.Point(115, 87);
            this.lblDocumentDate.Name = "lblDocumentDate";
            this.lblDocumentDate.Size = new System.Drawing.Size(85, 13);
            this.lblDocumentDate.TabIndex = 36;
            this.lblDocumentDate.Text = "(DocumentDate)";
            // 
            // lblDocNo
            // 
            this.lblDocNo.AutoSize = true;
            this.lblDocNo.Location = new System.Drawing.Point(115, 61);
            this.lblDocNo.Name = "lblDocNo";
            this.lblDocNo.Size = new System.Drawing.Size(47, 13);
            this.lblDocNo.TabIndex = 35;
            this.lblDocNo.Text = "(DocNo)";
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(115, 34);
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
            this.label8.Location = new System.Drawing.Point(5, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Document number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 34);
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
            this.label5.Location = new System.Drawing.Point(5, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tax amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Total amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 87);
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
    }
}

