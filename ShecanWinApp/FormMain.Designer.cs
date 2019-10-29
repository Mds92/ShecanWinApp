namespace ShecanWinApp
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxNetworks = new System.Windows.Forms.ComboBox();
            this.labelNetworks = new System.Windows.Forms.Label();
            this.buttonSetDns = new System.Windows.Forms.Button();
            // 
            // comboBoxNetworks
            // 
            this.comboBoxNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetworks.FormattingEnabled = true;
            this.comboBoxNetworks.Location = new System.Drawing.Point(71, 9);
            this.comboBoxNetworks.Name = "comboBoxNetworks";
            this.comboBoxNetworks.Size = new System.Drawing.Size(204, 23);
            this.comboBoxNetworks.TabIndex = 1;
            this.comboBoxNetworks.SelectedIndexChanged += new System.EventHandler(this.comboBoxNetworks_SelectedIndexChanged);
            // 
            // labelNetworks
            // 
            this.labelNetworks.AutoSize = true;
            this.labelNetworks.Location = new System.Drawing.Point(8, 12);
            this.labelNetworks.Name = "labelNetworks";
            this.labelNetworks.Size = new System.Drawing.Size(57, 15);
            this.labelNetworks.TabIndex = 2;
            this.labelNetworks.Text = "Networks";
            // 
            // buttonSetDns
            // 
            this.buttonSetDns.Location = new System.Drawing.Point(8, 57);
            this.buttonSetDns.Name = "buttonSetDns";
            this.buttonSetDns.Size = new System.Drawing.Size(267, 48);
            this.buttonSetDns.TabIndex = 3;
            this.buttonSetDns.Text = "Active";
            this.buttonSetDns.UseVisualStyleBackColor = true;
            this.buttonSetDns.Click += new System.EventHandler(this.buttonSetDns_Click);
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.Controls.Add(this.buttonSetDns);
            this.Controls.Add(this.labelNetworks);
            this.Controls.Add(this.comboBoxNetworks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxNetworks;
        private System.Windows.Forms.Label labelNetworks;
        private System.Windows.Forms.Button buttonSetDns;
    }
}

