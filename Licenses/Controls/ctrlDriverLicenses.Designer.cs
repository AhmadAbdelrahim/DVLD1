namespace DVLD1.Licenses.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Local = new System.Windows.Forms.TabPage();
            this.International = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.LocalLicensesHistory = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.InternationalLicensesHistory = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Local.SuspendLayout();
            this.International.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Local);
            this.tabControl1.Controls.Add(this.International);
            this.tabControl1.Location = new System.Drawing.Point(7, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(769, 208);
            this.tabControl1.TabIndex = 0;
            // 
            // Local
            // 
            this.Local.Controls.Add(this.label3);
            this.Local.Controls.Add(this.label4);
            this.Local.Controls.Add(this.tabControl2);
            this.Local.Location = new System.Drawing.Point(4, 25);
            this.Local.Name = "Local";
            this.Local.Padding = new System.Windows.Forms.Padding(3);
            this.Local.Size = new System.Drawing.Size(761, 179);
            this.Local.TabIndex = 0;
            this.Local.Text = "Local";
            this.Local.UseVisualStyleBackColor = true;
            // 
            // International
            // 
            this.International.Controls.Add(this.label2);
            this.International.Controls.Add(this.label1);
            this.International.Controls.Add(this.tabControl3);
            this.International.Location = new System.Drawing.Point(4, 25);
            this.International.Name = "International";
            this.International.Padding = new System.Windows.Forms.Padding(3);
            this.International.Size = new System.Drawing.Size(761, 179);
            this.International.TabIndex = 1;
            this.International.Text = "International";
            this.International.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.LocalLicensesHistory);
            this.tabControl2.Location = new System.Drawing.Point(6, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(749, 142);
            this.tabControl2.TabIndex = 0;
            // 
            // LocalLicensesHistory
            // 
            this.LocalLicensesHistory.Location = new System.Drawing.Point(4, 25);
            this.LocalLicensesHistory.Name = "LocalLicensesHistory";
            this.LocalLicensesHistory.Padding = new System.Windows.Forms.Padding(3);
            this.LocalLicensesHistory.Size = new System.Drawing.Size(741, 113);
            this.LocalLicensesHistory.TabIndex = 0;
            this.LocalLicensesHistory.Text = "Local Licenses History";
            this.LocalLicensesHistory.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.InternationalLicensesHistory);
            this.tabControl3.Location = new System.Drawing.Point(6, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(749, 142);
            this.tabControl3.TabIndex = 1;
            // 
            // InternationalLicensesHistory
            // 
            this.InternationalLicensesHistory.Location = new System.Drawing.Point(4, 25);
            this.InternationalLicensesHistory.Name = "InternationalLicensesHistory";
            this.InternationalLicensesHistory.Padding = new System.Windows.Forms.Padding(3);
            this.InternationalLicensesHistory.Size = new System.Drawing.Size(741, 113);
            this.InternationalLicensesHistory.TabIndex = 0;
            this.InternationalLicensesHistory.Text = "International Licenses History";
            this.InternationalLicensesHistory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "# Records:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "# Records:";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(788, 242);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Local.ResumeLayout(false);
            this.Local.PerformLayout();
            this.International.ResumeLayout(false);
            this.International.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Local;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage LocalLicensesHistory;
        private System.Windows.Forms.TabPage International;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage InternationalLicensesHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
