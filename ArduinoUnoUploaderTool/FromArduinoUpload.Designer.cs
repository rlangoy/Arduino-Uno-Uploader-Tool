namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    partial class FormArduinoUpload
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
            this.comboBoxSerailPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textParams = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHexFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btBrowse = new System.Windows.Forms.Button();
            this.btUpload = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.lbPortNotAvailable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxSerailPorts
            // 
            this.comboBoxSerailPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSerailPorts.FormattingEnabled = true;
            this.comboBoxSerailPorts.Location = new System.Drawing.Point(26, 91);
            this.comboBoxSerailPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerailPorts.Name = "comboBoxSerailPorts";
            this.comboBoxSerailPorts.Size = new System.Drawing.Size(64, 21);
            this.comboBoxSerailPorts.TabIndex = 0;
            this.comboBoxSerailPorts.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBoxSerailPorts.SelectedValueChanged += new System.EventHandler(this.comboBoxSerailPorts_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // textParams
            // 
            this.textParams.Location = new System.Drawing.Point(26, 145);
            this.textParams.Margin = new System.Windows.Forms.Padding(4);
            this.textParams.Multiline = true;
            this.textParams.Name = "textParams";
            this.textParams.ReadOnly = true;
            this.textParams.Size = new System.Drawing.Size(456, 65);
            this.textParams.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "AVR Dude Params";
            // 
            // textBoxHexFile
            // 
            this.textBoxHexFile.Location = new System.Drawing.Point(26, 30);
            this.textBoxHexFile.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHexFile.Name = "textBoxHexFile";
            this.textBoxHexFile.Size = new System.Drawing.Size(372, 20);
            this.textBoxHexFile.TabIndex = 4;
            this.textBoxHexFile.TextChanged += new System.EventHandler(this.textBoxHexFile_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "HEX File to Upload";
            // 
            // btBrowse
            // 
            this.btBrowse.Location = new System.Drawing.Point(408, 25);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(72, 28);
            this.btBrowse.TabIndex = 6;
            this.btBrowse.Text = "Browse";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // btUpload
            // 
            this.btUpload.Location = new System.Drawing.Point(408, 91);
            this.btUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(72, 29);
            this.btUpload.TabIndex = 7;
            this.btUpload.Text = "Upload";
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // lbPortNotAvailable
            // 
            this.lbPortNotAvailable.AutoSize = true;
            this.lbPortNotAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPortNotAvailable.ForeColor = System.Drawing.Color.Red;
            this.lbPortNotAvailable.Location = new System.Drawing.Point(98, 95);
            this.lbPortNotAvailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPortNotAvailable.Name = "lbPortNotAvailable";
            this.lbPortNotAvailable.Size = new System.Drawing.Size(114, 17);
            this.lbPortNotAvailable.TabIndex = 8;
            this.lbPortNotAvailable.Text = "Port removed !";
            // 
            // FormArduinoUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 130);
            this.Controls.Add(this.lbPortNotAvailable);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxHexFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textParams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSerailPorts);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormArduinoUpload";
            this.Text = "Arduino UNO HEX File Uploader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerailPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textParams;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHexFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.Button btUpload;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label lbPortNotAvailable;
    }
}

