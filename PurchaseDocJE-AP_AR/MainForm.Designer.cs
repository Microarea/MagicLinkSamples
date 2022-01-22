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
            this.label2 = new System.Windows.Forms.Label();
            this.tbxPaymentTerm = new System.Windows.Forms.TextBox();
            this.btnInstallments = new System.Windows.Forms.Button();
            this.lblConnectionInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxDocumentDate = new System.Windows.Forms.TextBox();
            this.tbxTotalAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTaxAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tabPage2.Controls.Add(this.tbxTaxAmount);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbxTotalAmount);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbxDocumentDate);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnInstallments);
            this.tabPage2.Controls.Add(this.tbxPaymentTerm);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 217);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Payable document";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Payment terms code";
            // 
            // tbxPaymentTerm
            // 
            this.tbxPaymentTerm.Location = new System.Drawing.Point(126, 19);
            this.tbxPaymentTerm.Name = "tbxPaymentTerm";
            this.tbxPaymentTerm.Size = new System.Drawing.Size(100, 20);
            this.tbxPaymentTerm.TabIndex = 1;
            // 
            // btnInstallments
            // 
            this.btnInstallments.Location = new System.Drawing.Point(19, 150);
            this.btnInstallments.Name = "btnInstallments";
            this.btnInstallments.Size = new System.Drawing.Size(75, 23);
            this.btnInstallments.TabIndex = 2;
            this.btnInstallments.Text = "Installments";
            this.btnInstallments.UseVisualStyleBackColor = true;
            this.btnInstallments.Click += new System.EventHandler(this.btnInstallments_Click);
            // 
            // lblConnectionInfo
            // 
            this.lblConnectionInfo.Location = new System.Drawing.Point(93, 17);
            this.lblConnectionInfo.Name = "lblConnectionInfo";
            this.lblConnectionInfo.Size = new System.Drawing.Size(264, 18);
            this.lblConnectionInfo.TabIndex = 6;
            this.lblConnectionInfo.Text = "(not connected)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Document Date";
            // 
            // tbxDocumentDate
            // 
            this.tbxDocumentDate.Location = new System.Drawing.Point(126, 45);
            this.tbxDocumentDate.Name = "tbxDocumentDate";
            this.tbxDocumentDate.Size = new System.Drawing.Size(100, 20);
            this.tbxDocumentDate.TabIndex = 4;
            // 
            // tbxTotalAmount
            // 
            this.tbxTotalAmount.Location = new System.Drawing.Point(126, 71);
            this.tbxTotalAmount.Name = "tbxTotalAmount";
            this.tbxTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxTotalAmount.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total amount";
            // 
            // tbxTaxAmount
            // 
            this.tbxTaxAmount.Location = new System.Drawing.Point(126, 97);
            this.tbxTaxAmount.Name = "tbxTaxAmount";
            this.tbxTaxAmount.Size = new System.Drawing.Size(100, 20);
            this.tbxTaxAmount.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tax amount";
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
        private System.Windows.Forms.Button btnInstallments;
        private System.Windows.Forms.TextBox tbxPaymentTerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConnectionInfo;
        private System.Windows.Forms.TextBox tbxDocumentDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTaxAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxTotalAmount;
        private System.Windows.Forms.Label label4;
    }
}

