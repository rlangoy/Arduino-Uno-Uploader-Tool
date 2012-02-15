/*
* Copyright (c) 2011 Rune Langøy
* All rights reserved.
*
* Permission to use, copy, modify, and distribute this software for any
* purpose with or without fee is hereby granted, provided that the above
* copyright notice and this permission notice appear in all copies.
*
* THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
* WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
* ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
* WHATSOEVER RESULTING FROM LOSS OF MIND, USE, DATA OR PROFITS, WHETHER IN
* AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT
* OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArduinoUpload));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new BSE.Windows.Forms.Panel();
            this.btBrowse = new System.Windows.Forms.Button();
            this.comboBoxSerailPorts = new System.Windows.Forms.ComboBox();
            this.lbPortNotAvailable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btUpload = new System.Windows.Forms.Button();
            this.textBoxHexFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanel4 = new BSE.Windows.Forms.XPanderPanel();
            this.xPanderPanel1 = new BSE.Windows.Forms.XPanderPanel();
            this.xPanderPanel2 = new BSE.Windows.Forms.XPanderPanel();
            this.xPanderPanel3 = new BSE.Windows.Forms.XPanderPanel();
            this.panel3LinkXp3 = new BSE.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSerialUploadSpeed = new HIVE.TEKMAR.ITEK.ArduinoUnoToolGui.cmbSerial();
            this.textBoxArduinoUnoParamsVer5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textParams = new System.Windows.Forms.TextBox();
            this.btCinfigDefault = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkUSBNotify = new System.Windows.Forms.CheckBox();
            this.btConfigSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSerialSpeedCfg = new HIVE.TEKMAR.ITEK.ArduinoUnoToolGui.cmbSerial();
            this.panelMainPlugin = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.xPanderPanelList1.SuspendLayout();
            this.panel3LinkXp3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelMainPlugin.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(874, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AssociatedSplitter = null;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.CaptionFont = new System.Drawing.Font("Segoe UI", 11.75F, System.Drawing.FontStyle.Bold);
            this.panel2.CaptionHeight = 27;
            this.panel2.Controls.Add(this.btBrowse);
            this.panel2.Controls.Add(this.comboBoxSerailPorts);
            this.panel2.Controls.Add(this.lbPortNotAvailable);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btUpload);
            this.panel2.Controls.Add(this.textBoxHexFile);
            this.panel2.Controls.Add(this.label3);
            this.panel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel2.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel2.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Image = null;
            this.panel2.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel2.Location = new System.Drawing.Point(178, 372);
            this.panel2.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel2.Name = "panel2";
            this.panel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel2.ShowTransparentBackground = false;
            this.panel2.ShowXPanderPanelProfessionalStyle = true;
            this.panel2.Size = new System.Drawing.Size(696, 128);
            this.panel2.TabIndex = 10;
            this.panel2.Text = "Hex Uploader";
            this.panel2.ToolTipTextCloseIcon = null;
            this.panel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Location = new System.Drawing.Point(576, 54);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(36, 24);
            this.btBrowse.TabIndex = 6;
            this.btBrowse.Text = "..";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // comboBoxSerailPorts
            // 
            this.comboBoxSerailPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerailPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSerailPorts.FormattingEnabled = true;
            this.comboBoxSerailPorts.Location = new System.Drawing.Point(28, 92);
            this.comboBoxSerailPorts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerailPorts.Name = "comboBoxSerailPorts";
            this.comboBoxSerailPorts.Size = new System.Drawing.Size(62, 21);
            this.comboBoxSerailPorts.TabIndex = 0;
            this.comboBoxSerailPorts.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBoxSerailPorts.SelectedValueChanged += new System.EventHandler(this.comboBoxSerailPorts_SelectedValueChanged);
            // 
            // lbPortNotAvailable
            // 
            this.lbPortNotAvailable.AutoSize = true;
            this.lbPortNotAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPortNotAvailable.ForeColor = System.Drawing.Color.Red;
            this.lbPortNotAvailable.Location = new System.Drawing.Point(98, 96);
            this.lbPortNotAvailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPortNotAvailable.Name = "lbPortNotAvailable";
            this.lbPortNotAvailable.Size = new System.Drawing.Size(114, 17);
            this.lbPortNotAvailable.TabIndex = 8;
            this.lbPortNotAvailable.Text = "Port removed !";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // btUpload
            // 
            this.btUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpload.Location = new System.Drawing.Point(576, 88);
            this.btUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(108, 29);
            this.btUpload.TabIndex = 7;
            this.btUpload.Text = "Upload";
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // textBoxHexFile
            // 
            this.textBoxHexFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHexFile.Location = new System.Drawing.Point(26, 50);
            this.textBoxHexFile.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHexFile.Name = "textBoxHexFile";
            this.textBoxHexFile.Size = new System.Drawing.Size(537, 20);
            this.textBoxHexFile.TabIndex = 4;
            this.textBoxHexFile.TextChanged += new System.EventHandler(this.textBoxHexFile_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "HEX File to Upload";
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel4);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel1);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel2);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel3);
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Location = new System.Drawing.Point(0, 2);
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelColors = null;
            this.xPanderPanelList1.Size = new System.Drawing.Size(179, 498);
            this.xPanderPanelList1.TabIndex = 9;
            this.xPanderPanelList1.Text = "xPanderPanelList1";
            // 
            // xPanderPanel4
            // 
            this.xPanderPanel4.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel4.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel4.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel4.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel4.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel4.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel4.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel4.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel4.Expand = true;
            this.xPanderPanel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.Image = null;
            this.xPanderPanel4.Name = "xPanderPanel4";
            this.xPanderPanel4.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderPanel4.Size = new System.Drawing.Size(179, 423);
            this.xPanderPanel4.TabIndex = 3;
            this.xPanderPanel4.Text = "Serial Tools";
            this.xPanderPanel4.ToolTipTextCloseIcon = null;
            this.xPanderPanel4.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel4.ToolTipTextExpandIconPanelExpanded = null;
            this.xPanderPanel4.Visible = false;
            this.xPanderPanel4.Click += new System.EventHandler(this.xPanderPanel4_Click);
            // 
            // xPanderPanel1
            // 
            this.xPanderPanel1.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel1.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel1.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.Image = null;
            this.xPanderPanel1.Name = "xPanderPanel1";
            this.xPanderPanel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderPanel1.Size = new System.Drawing.Size(179, 25);
            this.xPanderPanel1.TabIndex = 0;
            this.xPanderPanel1.Text = "Intro";
            this.xPanderPanel1.ToolTipTextCloseIcon = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelExpanded = null;
            this.xPanderPanel1.Click += new System.EventHandler(this.xPanderPanel1_Click);
            // 
            // xPanderPanel2
            // 
            this.xPanderPanel2.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel2.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel2.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.Image = null;
            this.xPanderPanel2.Name = "xPanderPanel2";
            this.xPanderPanel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderPanel2.Size = new System.Drawing.Size(179, 25);
            this.xPanderPanel2.TabIndex = 1;
            this.xPanderPanel2.Text = "Serial Terminal";
            this.xPanderPanel2.ToolTipTextCloseIcon = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelExpanded = null;
            this.xPanderPanel2.Click += new System.EventHandler(this.xPanderPanel2_Click);
            // 
            // xPanderPanel3
            // 
            this.xPanderPanel3.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel3.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel3.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel3.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.Image = null;
            this.xPanderPanel3.Name = "xPanderPanel3";
            this.xPanderPanel3.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.xPanderPanel3.Size = new System.Drawing.Size(179, 25);
            this.xPanderPanel3.TabIndex = 2;
            this.xPanderPanel3.Text = "Configuration";
            this.xPanderPanel3.ToolTipTextCloseIcon = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelExpanded = null;
            this.xPanderPanel3.Click += new System.EventHandler(this.xPanderPanel3_Click);
            this.xPanderPanel3.Enter += new System.EventHandler(this.xPanderPanel3_Enter);
            // 
            // panel3LinkXp3
            // 
            this.panel3LinkXp3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3LinkXp3.AssociatedSplitter = null;
            this.panel3LinkXp3.BackColor = System.Drawing.Color.Transparent;
            this.panel3LinkXp3.CaptionFont = new System.Drawing.Font("Segoe UI", 11.75F, System.Drawing.FontStyle.Bold);
            this.panel3LinkXp3.CaptionHeight = 27;
            this.panel3LinkXp3.Controls.Add(this.groupBox1);
            this.panel3LinkXp3.Controls.Add(this.chkUSBNotify);
            this.panel3LinkXp3.Controls.Add(this.btConfigSave);
            this.panel3LinkXp3.Controls.Add(this.groupBox2);
            this.panel3LinkXp3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel3LinkXp3.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel3LinkXp3.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panel3LinkXp3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel3LinkXp3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel3LinkXp3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel3LinkXp3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp3.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp3.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panel3LinkXp3.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panel3LinkXp3.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panel3LinkXp3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3LinkXp3.Image = null;
            this.panel3LinkXp3.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel3LinkXp3.Location = new System.Drawing.Point(285, 43);
            this.panel3LinkXp3.MinimumSize = new System.Drawing.Size(27, 27);
            this.panel3LinkXp3.Name = "panel3LinkXp3";
            this.panel3LinkXp3.PanelStyle = BSE.Windows.Forms.PanelStyle.Default;
            this.panel3LinkXp3.ShowCloseIcon = true;
            this.panel3LinkXp3.ShowExpandIcon = true;
            this.panel3LinkXp3.ShowXPanderPanelProfessionalStyle = true;
            this.panel3LinkXp3.Size = new System.Drawing.Size(691, 370);
            this.panel3LinkXp3.TabIndex = 13;
            this.panel3LinkXp3.Text = "Configuration";
            this.panel3LinkXp3.ToolTipTextCloseIcon = null;
            this.panel3LinkXp3.ToolTipTextExpandIconPanelCollapsed = null;
            this.panel3LinkXp3.ToolTipTextExpandIconPanelExpanded = null;
            this.panel3LinkXp3.Visible = false;
            this.panel3LinkXp3.CloseClick += new System.EventHandler<System.EventArgs>(this.panel3LinkXp3_CloseClick);
            this.panel3LinkXp3.VisibleChanged += new System.EventHandler(this.panel3LinkXp3_VisibleChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbSerialUploadSpeed);
            this.groupBox1.Controls.Add(this.textBoxArduinoUnoParamsVer5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textParams);
            this.groupBox1.Controls.Add(this.btCinfigDefault);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 264);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AVRDUDE - AVR Downloader/UploaDEr parameters";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(365, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Baud Rate";
            // 
            // cmbSerialUploadSpeed
            // 
            this.cmbSerialUploadSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialUploadSpeed.FormattingEnabled = true;
            this.cmbSerialUploadSpeed.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            ""});
            this.cmbSerialUploadSpeed.Location = new System.Drawing.Point(383, 32);
            this.cmbSerialUploadSpeed.Name = "cmbSerialUploadSpeed";
            this.cmbSerialUploadSpeed.Size = new System.Drawing.Size(69, 21);
            this.cmbSerialUploadSpeed.TabIndex = 13;
            this.cmbSerialUploadSpeed.SelectedIndexChanged += new System.EventHandler(this.cmbSerialUploadSpeed_SelectedIndexChanged);
            // 
            // textBoxArduinoUnoParamsVer5
            // 
            this.textBoxArduinoUnoParamsVer5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArduinoUnoParamsVer5.Location = new System.Drawing.Point(22, 70);
            this.textBoxArduinoUnoParamsVer5.Name = "textBoxArduinoUnoParamsVer5";
            this.textBoxArduinoUnoParamsVer5.Size = new System.Drawing.Size(432, 20);
            this.textBoxArduinoUnoParamsVer5.TabIndex = 6;
            this.textBoxArduinoUnoParamsVer5.TextChanged += new System.EventHandler(this.textBoxArduinoUnoParamsVer5_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "arduinoUnoParamsVer5";
            // 
            // textParams
            // 
            this.textParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textParams.Location = new System.Drawing.Point(22, 121);
            this.textParams.Margin = new System.Windows.Forms.Padding(4);
            this.textParams.Multiline = true;
            this.textParams.Name = "textParams";
            this.textParams.ReadOnly = true;
            this.textParams.Size = new System.Drawing.Size(433, 65);
            this.textParams.TabIndex = 2;
            // 
            // btCinfigDefault
            // 
            this.btCinfigDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCinfigDefault.Location = new System.Drawing.Point(280, 220);
            this.btCinfigDefault.Name = "btCinfigDefault";
            this.btCinfigDefault.Size = new System.Drawing.Size(175, 27);
            this.btCinfigDefault.TabIndex = 7;
            this.btCinfigDefault.Text = "Default";
            this.btCinfigDefault.UseVisualStyleBackColor = true;
            this.btCinfigDefault.Click += new System.EventHandler(this.btCinfigDefault_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "AVR Dude Params";
            // 
            // chkUSBNotify
            // 
            this.chkUSBNotify.AutoSize = true;
            this.chkUSBNotify.Location = new System.Drawing.Point(35, 53);
            this.chkUSBNotify.Name = "chkUSBNotify";
            this.chkUSBNotify.Size = new System.Drawing.Size(117, 19);
            this.chkUSBNotify.TabIndex = 8;
            this.chkUSBNotify.Text = "USB Notifycation";
            this.chkUSBNotify.UseVisualStyleBackColor = true;
            this.chkUSBNotify.CheckedChanged += new System.EventHandler(this.chkUSBNotify_CheckedChanged);
            // 
            // btConfigSave
            // 
            this.btConfigSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btConfigSave.Location = new System.Drawing.Point(571, 339);
            this.btConfigSave.Name = "btConfigSave";
            this.btConfigSave.Size = new System.Drawing.Size(108, 27);
            this.btConfigSave.TabIndex = 4;
            this.btConfigSave.Text = "Save";
            this.btConfigSave.UseVisualStyleBackColor = true;
            this.btConfigSave.Click += new System.EventHandler(this.btConfigSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbSerialSpeedCfg);
            this.groupBox2.Location = new System.Drawing.Point(537, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 207);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Terminal";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "None";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Bits";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Parity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "One";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Stopbit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Baud Rate";
            // 
            // cmbSerialSpeedCfg
            // 
            this.cmbSerialSpeedCfg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialSpeedCfg.FormattingEnabled = true;
            this.cmbSerialSpeedCfg.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbSerialSpeedCfg.Location = new System.Drawing.Point(15, 45);
            this.cmbSerialSpeedCfg.Name = "cmbSerialSpeedCfg";
            this.cmbSerialSpeedCfg.Size = new System.Drawing.Size(69, 21);
            this.cmbSerialSpeedCfg.TabIndex = 5;
            this.cmbSerialSpeedCfg.SelectedIndexChanged += new System.EventHandler(this.cmbSerialSpeedCfg_SelectedIndexChanged);
            // 
            // panelMainPlugin
            // 
            this.panelMainPlugin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMainPlugin.Controls.Add(this.panel3LinkXp3);
            this.panelMainPlugin.Location = new System.Drawing.Point(179, 2);
            this.panelMainPlugin.Name = "panelMainPlugin";
            this.panelMainPlugin.Size = new System.Drawing.Size(694, 370);
            this.panelMainPlugin.TabIndex = 16;
            // 
            // FormArduinoUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 522);
            this.Controls.Add(this.panelMainPlugin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.xPanderPanelList1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormArduinoUpload";
            this.Text = "Arduino UNO Programmer Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.xPanderPanelList1.ResumeLayout(false);
            this.panel3LinkXp3.ResumeLayout(false);
            this.panel3LinkXp3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelMainPlugin.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lbPortNotAvailable;
        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel2;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel3;
        private BSE.Windows.Forms.Panel panel2;
        private BSE.Windows.Forms.Panel panel3LinkXp3;
        private System.Windows.Forms.TextBox textBoxArduinoUnoParamsVer5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btConfigSave;
        private System.Windows.Forms.Button btCinfigDefault;
        private System.Windows.Forms.CheckBox chkUSBNotify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel4;
        private System.Windows.Forms.Label label5;
        private cmbSerial cmbSerialSpeedCfg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label13;
        private cmbSerial cmbSerialUploadSpeed;
        private System.Windows.Forms.Panel panelMainPlugin;
    }
}

