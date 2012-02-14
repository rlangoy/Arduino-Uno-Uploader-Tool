namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    partial class FormSerialTerminal
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
            this.panel3LinkXp2 = new BSE.Windows.Forms.Panel();
            this.chkSreialEcho = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSerialTerm = new HIVE.TEKMAR.ITEK.ArduinoUnoToolGui.cmbSerial();
            this.chkWrapSerialData = new System.Windows.Forms.CheckBox();
            this.btCelarSerialTerminalWindow = new System.Windows.Forms.Button();
            this.txtSerialTerminal = new HIVE.TEKMAR.ITEK.ArduinoUnoToolGui.textNormalView();
            this.panel3LinkXp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3LinkXp2
            // 
            this.panel3LinkXp2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3LinkXp2.AssociatedSplitter = null;
            this.panel3LinkXp2.BackColor = System.Drawing.Color.Transparent;
            this.panel3LinkXp2.CaptionFont = new System.Drawing.Font("Segoe UI", 11.75F, System.Drawing.FontStyle.Bold);
            this.panel3LinkXp2.CaptionHeight = 27;
            this.panel3LinkXp2.Controls.Add(this.chkSreialEcho);
            this.panel3LinkXp2.Controls.Add(this.label12);
            this.panel3LinkXp2.Controls.Add(this.cmbSerialTerm);
            this.panel3LinkXp2.Controls.Add(this.chkWrapSerialData);
            this.panel3LinkXp2.Controls.Add(this.btCelarSerialTerminalWindow);
            this.panel3LinkXp2.Controls.Add(this.txtSerialTerminal);
            this.panel3LinkXp2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel3LinkXp2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel3LinkXp2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel3LinkXp2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel3LinkXp2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel3LinkXp2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel3LinkXp2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp2.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel3LinkXp2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel3LinkXp2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel3LinkXp2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp2.Image = null;
            this.panel3LinkXp2.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel3LinkXp2.Location = new System.Drawing.Point(2, 0);
            this.panel3LinkXp2.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel3LinkXp2.Name = "panel3LinkXp2";
            this.panel3LinkXp2.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel3LinkXp2.ShowCloseIcon = true;
            this.panel3LinkXp2.ShowExpandIcon = true;
            this.panel3LinkXp2.ShowXPanderPanelProfessionalStyle = true;
            this.panel3LinkXp2.Size = new System.Drawing.Size(695, 370);
            this.panel3LinkXp2.TabIndex = 13;
            this.panel3LinkXp2.Text = "Serial Terminal";
            this.panel3LinkXp2.ToolTipTextCloseIcon = null;
            this.panel3LinkXp2.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel3LinkXp2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // chkSreialEcho
            // 
            this.chkSreialEcho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSreialEcho.AutoSize = true;
            this.chkSreialEcho.Checked = true;
            this.chkSreialEcho.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSreialEcho.Location = new System.Drawing.Point(300, 341);
            this.chkSreialEcho.Name = "chkSreialEcho";
            this.chkSreialEcho.Size = new System.Drawing.Size(51, 17);
            this.chkSreialEcho.TabIndex = 17;
            this.chkSreialEcho.Text = "Echo";
            this.chkSreialEcho.UseVisualStyleBackColor = true;
            this.chkSreialEcho.CheckedChanged += new System.EventHandler(this.chkSreialEcho_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(369, 327);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Baud Rate";
            // 
            // cmbSerialTerm
            // 
            this.cmbSerialTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSerialTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialTerm.FormattingEnabled = true;
            this.cmbSerialTerm.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbSerialTerm.Location = new System.Drawing.Point(378, 345);
            this.cmbSerialTerm.Name = "cmbSerialTerm";
            this.cmbSerialTerm.Size = new System.Drawing.Size(69, 21);
            this.cmbSerialTerm.TabIndex = 15;
            this.cmbSerialTerm.SelectedIndexChanged += new System.EventHandler(this.cmbSerialTerm_SelectedIndexChanged);
            // 
            // chkWrapSerialData
            // 
            this.chkWrapSerialData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWrapSerialData.AutoSize = true;
            this.chkWrapSerialData.Location = new System.Drawing.Point(475, 341);
            this.chkWrapSerialData.Name = "chkWrapSerialData";
            this.chkWrapSerialData.Size = new System.Drawing.Size(78, 17);
            this.chkWrapSerialData.TabIndex = 2;
            this.chkWrapSerialData.Text = "Wrap Data";
            this.chkWrapSerialData.UseVisualStyleBackColor = true;
            this.chkWrapSerialData.CheckedChanged += new System.EventHandler(this.chkWrapSerialData_CheckedChanged);
            // 
            // btCelarSerialTerminalWindow
            // 
            this.btCelarSerialTerminalWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCelarSerialTerminalWindow.Location = new System.Drawing.Point(575, 332);
            this.btCelarSerialTerminalWindow.Name = "btCelarSerialTerminalWindow";
            this.btCelarSerialTerminalWindow.Size = new System.Drawing.Size(106, 30);
            this.btCelarSerialTerminalWindow.TabIndex = 1;
            this.btCelarSerialTerminalWindow.Text = "Clear";
            this.btCelarSerialTerminalWindow.UseVisualStyleBackColor = true;
            this.btCelarSerialTerminalWindow.Click += new System.EventHandler(this.btCelarSerialTerminalWindow_Click);
            // 
            // txtSerialTerminal
            // 
            this.txtSerialTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialTerminal.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialTerminal.Location = new System.Drawing.Point(24, 31);
            this.txtSerialTerminal.Multiline = true;
            this.txtSerialTerminal.Name = "txtSerialTerminal";
            this.txtSerialTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialTerminal.Size = new System.Drawing.Size(657, 296);
            this.txtSerialTerminal.TabIndex = 0;
            this.txtSerialTerminal.WrapText = false;
            // 
            // FormSerialTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 373);
            this.Controls.Add(this.panel3LinkXp2);
            this.Name = "FormSerialTerminal";
            this.Text = "FormSerialTerminal";
            this.panel3LinkXp2.ResumeLayout(false);
            this.panel3LinkXp2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel panel3LinkXp2;
        private System.Windows.Forms.CheckBox chkSreialEcho;
        private System.Windows.Forms.Label label12;
        private cmbSerial cmbSerialTerm;
        private System.Windows.Forms.CheckBox chkWrapSerialData;
        private System.Windows.Forms.Button btCelarSerialTerminalWindow;
        private textNormalView txtSerialTerminal;
    }
}