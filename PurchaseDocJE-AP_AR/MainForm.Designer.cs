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
            this.tbxDocumentNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxSupplierCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxJournalEntryID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCreatePayable = new System.Windows.Forms.Button();
            this.tbxTaxAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDocumentDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPaymentTerm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbxInstTaxAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxInstTotAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxInstStartDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnInstallments = new System.Windows.Forms.Button();
            this.tbxInstPayment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblConnectionInfo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.tbxDocumentNumber);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbxSupplierCode);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tbxJournalEntryID);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnCreatePayable);
            this.tabPage2.Controls.Add(this.tbxTaxAmount);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbxTotalAmount);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbxDocumentDate);
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
            // tbxDocumentNumber
            // 
            this.tbxDocumentNumber.Location = new System.Drawing.Point(115, 58);
            this.tbxDocumentNumber.Name = "tbxDocumentNumber";
            this.tbxDocumentNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxDocumentNumber.TabIndex = 32;
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
            // tbxSupplierCode
            // 
            this.tbxSupplierCode.Location = new System.Drawing.Point(115, 31);
            this.tbxSupplierCode.Name = "tbxSupplierCode";
            this.tbxSupplierCode.Size = new System.Drawing.Size(100, 20);
            this.tbxSupplierCode.TabIndex = 30;
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
            // tbxJournalEntryID
            // 
            this.tbxJournalEntryID.Location = new System.Drawing.Point(115, 6);
            this.tbxJournalEntryID.Name = "tbxJournalEntryID";
            this.tbxJournalEntryID.Size = new System.Drawing.Size(100, 20);
            this.tbxJournalEntryID.TabIndex = 28;
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
            // tbxTaxAmount
            // 
            this.tbxTaxAmount.Location = new System.Drawing.Point(115, 136);
            this.tbxTaxAmount.Name = "tbxTaxAmount";
            this.tbxTaxAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxTaxAmount.TabIndex = 25;
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
            // tbxTotalAmount
            // 
            this.tbxTotalAmount.Location = new System.Drawing.Point(115, 110);
            this.tbxTotalAmount.Name = "tbxTotalAmount";
            this.tbxTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxTotalAmount.TabIndex = 23;
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
            // tbxDocumentDate
            // 
            this.tbxDocumentDate.Location = new System.Drawing.Point(115, 84);
            this.tbxDocumentDate.Name = "tbxDocumentDate";
            this.tbxDocumentDate.Size = new System.Drawing.Size(100, 20);
            this.tbxDocumentDate.TabIndex = 21;
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
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.tbxInstTaxAmount);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.tbxInstTotAmount);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.tbxInstStartDate);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.btnInstallments);
            this.tabPage3.Controls.Add(this.tbxInstPayment);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(767, 217);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Installments";
            // 
            // tbxInstTaxAmount
            // 
            this.tbxInstTaxAmount.Location = new System.Drawing.Point(116, 96);
            this.tbxInstTaxAmount.Name = "tbxInstTaxAmount";
            this.tbxInstTaxAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxInstTaxAmount.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tax amount";
            // 
            // tbxInstTotAmount
            // 
            this.tbxInstTotAmount.Location = new System.Drawing.Point(116, 70);
            this.tbxInstTotAmount.Name = "tbxInstTotAmount";
            this.tbxInstTotAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxInstTotAmount.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Total amount";
            // 
            // tbxInstStartDate
            // 
            this.tbxInstStartDate.Location = new System.Drawing.Point(116, 44);
            this.tbxInstStartDate.Name = "tbxInstStartDate";
            this.tbxInstStartDate.Size = new System.Drawing.Size(100, 20);
            this.tbxInstStartDate.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Starting Date";
            // 
            // btnInstallments
            // 
            this.btnInstallments.Location = new System.Drawing.Point(9, 138);
            this.btnInstallments.Name = "btnInstallments";
            this.btnInstallments.Size = new System.Drawing.Size(207, 23);
            this.btnInstallments.TabIndex = 20;
            this.btnInstallments.Text = "Calculate Installments";
            this.btnInstallments.UseVisualStyleBackColor = true;
            this.btnInstallments.Click += new System.EventHandler(this.btnInstallments_Click);
            // 
            // tbxInstPayment
            // 
            this.tbxInstPayment.Location = new System.Drawing.Point(116, 18);
            this.tbxInstPayment.Name = "tbxInstPayment";
            this.tbxInstPayment.Size = new System.Drawing.Size(100, 20);
            this.tbxInstPayment.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Payment terms code";
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
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TextBox tbxDocumentNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxSupplierCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxJournalEntryID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreatePayable;
        private System.Windows.Forms.TextBox tbxTaxAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxTotalAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDocumentDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPaymentTerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbxInstTaxAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxInstTotAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxInstStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnInstallments;
        private System.Windows.Forms.TextBox tbxInstPayment;
        private System.Windows.Forms.Label label12;
    }
}

