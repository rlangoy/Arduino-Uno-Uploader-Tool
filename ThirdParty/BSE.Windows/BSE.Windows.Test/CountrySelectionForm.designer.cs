namespace BSE.Windows.Test
{
	partial class CCountrySelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCountrySelectionForm));
            this.m_cboCountryList = new System.Windows.Forms.ComboBox();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_lblSelectCulture = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_cboCountryList
            // 
            this.m_cboCountryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCountryList.FormattingEnabled = true;
            this.m_cboCountryList.Items.AddRange(new object[] {
            resources.GetString("m_cboCountryList.Items"),
            resources.GetString("m_cboCountryList.Items1")});
            resources.ApplyResources(this.m_cboCountryList, "m_cboCountryList");
            this.m_cboCountryList.Name = "m_cboCountryList";
            this.m_cboCountryList.SelectedIndexChanged += new System.EventHandler(this.CboCountryListSelectedIndexChanged);
            // 
            // m_btnOk
            // 
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.m_btnOk, "m_btnOk");
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.UseVisualStyleBackColor = true;
            // 
            // m_lblSelectCulture
            // 
            resources.ApplyResources(this.m_lblSelectCulture, "m_lblSelectCulture");
            this.m_lblSelectCulture.Name = "m_lblSelectCulture";
            // 
            // CCountrySelectionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblSelectCulture);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_cboCountryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CCountrySelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox m_cboCountryList;
		private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Label m_lblSelectCulture;
	}
}