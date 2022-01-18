namespace MagicLinkCGM
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSetData = new System.Windows.Forms.Button();
            this.btnSetFiscalCompany = new System.Windows.Forms.Button();
            this.tbxFiscalCompany = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSetData
            // 
            this.btnSetData.Location = new System.Drawing.Point(12, 97);
            this.btnSetData.Name = "btnSetData";
            this.btnSetData.Size = new System.Drawing.Size(100, 23);
            this.btnSetData.TabIndex = 17;
            this.btnSetData.Text = "SetData";
            this.btnSetData.UseVisualStyleBackColor = true;
            this.btnSetData.Click += new System.EventHandler(this.btnSetData_Click);
            // 
            // btnSetFiscalCompany
            // 
            this.btnSetFiscalCompany.Location = new System.Drawing.Point(146, 53);
            this.btnSetFiscalCompany.Name = "btnSetFiscalCompany";
            this.btnSetFiscalCompany.Size = new System.Drawing.Size(41, 23);
            this.btnSetFiscalCompany.TabIndex = 18;
            this.btnSetFiscalCompany.Text = "Set";
            this.btnSetFiscalCompany.UseVisualStyleBackColor = true;
            this.btnSetFiscalCompany.Click += new System.EventHandler(this.btnSetFiscalCompany_Click);
            // 
            // tbxFiscalCompany
            // 
            this.tbxFiscalCompany.Location = new System.Drawing.Point(96, 55);
            this.tbxFiscalCompany.Name = "tbxFiscalCompany";
            this.tbxFiscalCompany.Size = new System.Drawing.Size(44, 20);
            this.tbxFiscalCompany.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fiscal Company";
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(12, 134);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 23);
            this.btnReport.TabIndex = 22;
            this.btnReport.Text = "List Companies";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 169);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxFiscalCompany);
            this.Controls.Add(this.btnSetFiscalCompany);
            this.Controls.Add(this.btnSetData);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainForm";
            this.Text = "MagicLink and CGM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSetData;
        private System.Windows.Forms.Button btnSetFiscalCompany;
        private System.Windows.Forms.TextBox tbxFiscalCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
    }
}

