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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Management;
using BSE.Windows.Forms;
using System.IO.Ports;
using System.Reflection;
using System.Threading;

namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    public partial class FormArduinoUpload : Form, IUSBAddedOrRemoved
    {
        //class for handeling the notifycation
        // described in IUSBAddedOrRemoved
        private USBWatcher usbWatcher;

        private BSE.Windows.Forms.Panel panel1;


        public FormArduinoUpload()
        {
            InitializeComponent();

            // Create and initialize a Panel.
            this.panel1 = new BSE.Windows.Forms.Panel();
            this.panel1.Text = "panel1";
            // Set the panel background.
            this.panel1.ShowTransparentBackground = false;
            // Set the panel's DockStyle to DockStyle.Fill
            this.panel1.Dock = DockStyle.Fill;
            // Add the panel to the form
            this.Controls.Add(this.panel1);

            // Create and initialize a ToolStripProfessionalRenderer.
            ToolStripProfessionalRenderer renderer =
                new BSE.Windows.Forms.Office2007Renderer();
            // Add it to the ToolStripManager.Renderer
            ToolStripManager.Renderer = renderer;

            // Get the ProfessionalColorTable colorTable for the current renderer.
            BSE.Windows.Forms.ProfessionalColorTable colorTable =
                renderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
            if (colorTable != null)
            {
                // Get the PanelColors panelColorTable for the 
                // current  colortable.
                BSE.Windows.Forms.PanelColors panelColorTable =
                            colorTable.PanelColorTable;
                if (panelColorTable != null)
                {
                    // Set the panel properties for the form 
                    // controls collection
                    BSE.Windows.Forms.PanelSettingsManager.
                    SetPanelProperties(this.Controls, panelColorTable);
                }
            }


        }

        //List of serial ports
        private string[] ports;

        //serial dropdown list
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            chkIfComPortIsAvailable();

            comboBoxSerailPorts.Items.Clear();
            foreach (string name in ports)
                comboBoxSerailPorts.Items.Add(name);
                         
        }

        //Config parameters
        private bool bUseUsbNotifycations;
        private string comPort=   "COM1";
        private string fileName = "";
        private int baudRate = 19200;
        private SerialPort serialPort1;


        //params for avrdude: Version 5.11-Patch#7610
        private string arduinoUnoParams = "";

        private void restoreDefaultConfigParams()
        {
            //params for avrdude: Version 5.11-Patch#7610
            arduinoUnoParams = "-F -v -pm328p -c arduino -b 115200";
            bUseUsbNotifycations = true;
            baudRate = 19200;
        }

        public void USBRemoved()
        {
            closeSerial();
            chkIfComPortIsAvailable();
        }

        //show if selected Usb serial port is removed
        public void USBNotifyRemoved()
        {
            //The notify is from another thread
            //   run the code in the same thread as this form
            this.Invoke(new MethodInvoker(USBRemoved));
        }

        // If Usb port is inserted
        //     Show new port as selected in the serial combobox
        //         and update comPort and the textParams
        public void USBInserted()
        {
            string[] newPorts = System.IO.Ports.SerialPort.GetPortNames(); // Get serial ports

            foreach (string strPort in newPorts)
            {   //If new port is selected
                if (!ports.Contains(strPort))
                {
                    comPort = strPort;
                    updateParams();
                    if (!comboBoxSerailPorts.Items.Contains(strPort))
                        comboBoxSerailPorts.Items.Add(strPort);
                    comboBoxSerailPorts.Text = strPort;
                    chkIfComPortIsAvailable();
                    break;
                }
            }
            chkIfComPortIsAvailable();
        }

        // If Usb port is inserted
        //     Show new port as selected in the serial combobox
        //         and update comPort and the textParams
        public void USBNotifyInserted()
        {
            //The notify is from another thread
            //   run the code in the same thread as this form
            this.Invoke(new MethodInvoker(USBInserted));
        }

        //Update the textParams.Text field
        private void updateParams()
        {
            string defParam = arduinoUnoParams + " -P\\\\.\\" + comPort + " -D -Uflash:w:\"" + fileName + "\":i";
            textParams.Text = defParam;
            textBoxHexFile.Text = fileName;
            cmbSerialSpeedCfg.Text = baudRate.ToString();
            chkUSBNotify.Checked = bUseUsbNotifycations;
            cmbSerialTerm.Text = baudRate.ToString();
            cmbSerialSpeedCfg.Text = baudRate.ToString();
            comboBoxSerailPorts.Text = comPort.ToString();        
        }

        // Store configuration
        private void WriteConfigToFile()
        {
            ReadWriteInitFile inifile = new ReadWriteInitFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\config.ini");
            inifile.Write("Config", "bUseUsbNotifycations", bUseUsbNotifycations.ToString());
            inifile.Write("Config", "comPort", comPort);
            inifile.Write("Config", "fileName", fileName);
            inifile.Write("Config", "arduinoUnoParamsVer5", arduinoUnoParams);
            inifile.Write("Config", "SerialTerminalSpeed", baudRate.ToString());
        }

        // Read configuration
        private void ReadConfigToFile()
        {
            ReadWriteInitFile inifile = new ReadWriteInitFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\config.ini");

            string readString = inifile.Read("Config", "comPort");
            if (readString.Length > 0)
                comPort = readString;

            readString = inifile.Read("Config", "fileName");
            if (readString.Length > 0)
                fileName = readString;

            readString = inifile.Read("Config", "arduinoUnoParamsVer5");
            if (readString.Length > 0)
                arduinoUnoParams = readString;

            readString = inifile.Read("Config", "bUseUsbNotifycations");
            if (readString.Length > 0)
                bUseUsbNotifycations = Convert.ToBoolean(readString);

            readString = inifile.Read("Config", "SerialTerminalSpeed");
            if (readString.Length > 0)
                baudRate = Convert.ToInt32(readString);  

        }


        private bool chkIfComPortIsAvailable()
        {
            try
            {
                ports = System.IO.Ports.SerialPort.GetPortNames(); // Get serial ports
            }
            catch (Exception) 
            {   lbPortNotAvailable.Visible = true;
                return false;
            }
                
            if (ports.Contains(comPort) == true)
            {
                lbPortNotAvailable.Visible = false;
                if (panel3LinkXp2.Visible == true)
                {
                    startSerialPort();
                }
            }
            else
            {
                lbPortNotAvailable.Visible = true;                
            }

            return !lbPortNotAvailable.Visible;
        }

        //Metod called upon by use of 
        //this.Invoke(new MethodInvoker(clSerial));
        //to avoid use of critical sections
        // trying to assess a textbox while closing.....
        private void clSerial()
        {
            try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
            }
            catch (Exception) { ;};
            serialPort1.Dispose();
            serialPort1 = null;                
            bClosingComPort = false;        
        }

        private bool closeOnce = true;
        private void closeSerial()
        {
            if (closeOnce == true)
            {
                if (serialPort1 != null)
                {
                    closeOnce = false;
                    bClosingComPort = true;                    
                    serialPort1.DataReceived -= new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                    this.Invoke(new MethodInvoker(clSerial));
                    closeOnce = true;
                }            
            }//end closeOnce

        }

        private void startSerialPort()
        {
            try
            {
                //Release handler to old serial port
                if (serialPort1 != null)
                {
                    if (serialPort1.IsOpen)
                    {
                        closeSerial();
                        while (bClosingComPort) { System.Threading.Thread.Sleep(10); ;}
                    }
                }
                this.txtSerialTerminal.Text = "";

                //Open New 
                serialPort1 = new SerialPort(comPort, baudRate, Parity.None, 8, StopBits.One);
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                serialPort1.Open();
                
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
                toolStripStatusLabel1.Text = ex.ToString().Trim('\n');
            }

        
        }

        private static bool bProsessingRS232Data = false;

        private  void rs232DataRecieved()
        {
            if (bClosingComPort == true)
                return;

            lock (lockobj)
            {

                bProsessingRS232Data = true;

                this.txtSerialTerminal.AddString(serialPort1.ReadExisting());

                bProsessingRS232Data = false;
            }
        }

        static bool bClosingComPort = false;

        static Object lockobj = new Object();

        void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //lock (lockobj)
            {
                if (bClosingComPort == false)
                {
                    while (bProsessingRS232Data) { System.Threading.Thread.Sleep(10); }
                    this.Invoke(new MethodInvoker(rs232DataRecieved));
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //Display Version Information
            Version version = new Version(Application.ProductVersion);
            this.Text += " "+version.Major+"."+version.Minor+"."+ version.Build ;
            
            //use default params if no config.ini is present
            restoreDefaultConfigParams();
            
            //Try to read config params from file
            ReadConfigToFile();
            
            textBoxHexFile.Text = fileName;

            updateParams();

            //start listen for USBNotifycations 
            // as described in IUSBAddedOrRemoved
            if (bUseUsbNotifycations)
                usbWatcher = new USBWatcher(this);

            chkIfComPortIsAvailable();

            ShowLinkedPanelNo(1);
            textBoxArduinoUnoParamsVer5.Text = this.arduinoUnoParams;
            toolStripStatusLabel1.Text = "Ready";

            comboBoxSerailPorts.Items.Clear();
            comboBoxSerailPorts.Items.Add(comPort);

            if (!comboBoxSerailPorts.Items.Contains(comPort))
                comboBoxSerailPorts.Items.Add(comPort);

            comboBoxSerailPorts.Text = comPort;            
        }

        private void comboBoxSerailPorts_SelectedValueChanged(object sender, EventArgs e)
        {
            comPort = comboBoxSerailPorts.Text;
            updateParams();
            chkIfComPortIsAvailable();             
        }

        private void textBoxHexFile_TextChanged(object sender, EventArgs e)
        {
            fileName = textBoxHexFile.Text;
            updateParams();
        }


        /*
         *    Upload .hex flie to the Arduino uno board 
         *    start avrdude width the pramas described in 
         *    textParams.Text
         */
        private void btUpload_Click(object sender, EventArgs e)
        {

            bool bSerialLineWasUsed = false;

            if (chkIfComPortIsAvailable() == false)
            {
                MessageBox.Show("COM-port is not Available\nPlease select another COM-port", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }

            if (serialPort1 != null)
            {
                if (serialPort1.IsOpen)
                {
                    this.closeSerial();
                    bSerialLineWasUsed = true;
                    this.txtSerialTerminal.Text = "";
                }
            }

            if (fileName.Length <= 0)
            {
                MessageBox.Show("Please specify .hex flile to upload", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string AVRDudeFileNameAndLocation = Path.GetDirectoryName(Application.ExecutablePath) + @"\avrdude.exe";
            if (!File.Exists(AVRDudeFileNameAndLocation))
            {
                MessageBox.Show("AVRDUDE.EXE could not found\nPlease copy avrdude.exe to the location: \n" + AVRDudeFileNameAndLocation , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;            
            }
            
            Process p = null;
            try
            {
                toolStripStatusLabel1.Text = "Uploading " + AVRDudeFileNameAndLocation;
                p = new Process();
                p.StartInfo.FileName = AVRDudeFileNameAndLocation;

                p.StartInfo.Arguments = textParams.Text;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();

                if (p.ExitCode == 0)
                    toolStripStatusLabel1.Text = "Upload finished";
                else
                {  
                    toolStripStatusLabel1.Text = "Error while Uploading. Please retry";
                    System.Media.SystemSounds.Hand.Play();  //Play Error sound 
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}",
                          ex.Message, ex.StackTrace.ToString());
            }

            // if the serial port was opened before 
            // you entered this function then reopen it
            if (bSerialLineWasUsed)
            {
                try
                {
                    //serialPort1.Open();
                    this.startSerialPort();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    toolStripStatusLabel1.Text = ex.ToString().Trim('\n'); ;
                }
                
            }

        }

        /*
         *    Find / browse for the .hex file 
        */
        private void btBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpenDlg = new OpenFileDialog();
            string  strFileName = "C:\\Users\\rul\\Documents\\Skole\\POM1000\\Atmega323 eksempler\\LysKryss\\LysKryss\\Debug\\LysKryss.hex";
            
            int iLastSlash=strFileName.LastIndexOf('\\');
            string strDirName=strFileName.Remove(iLastSlash);
            strFileName = strFileName.Substring(iLastSlash);

            fileOpenDlg.Filter = "Intel HEX file (*.hex)|*.hex";
            fileOpenDlg.FilterIndex = 1;
            fileOpenDlg.InitialDirectory = strDirName;

            if (fileOpenDlg.ShowDialog() == DialogResult.OK)
            {
                fileName = fileOpenDlg.FileName;                
                updateParams();
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeSerial();
            WriteConfigToFile();

            try
            {
                if (usbWatcher!=null)
                    usbWatcher.ReleaseHanlders();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             
        }

        private void ShowLinkedPanelNo(int panelNo)
        {
            toolStripStatusLabel1.Text = "";
            panel3LinkXp1.Visible = false;
            panel3LinkXp2.Visible = false;
            panel3LinkXp3.Visible = false;
            panel3LinkXp4.Visible = false;
            
            if(panelNo ==1 )
                panel3LinkXp1.Visible = true;

            if (panelNo == 2)
                panel3LinkXp2.Visible = true;

            if (panelNo == 3)
                panel3LinkXp3.Visible = true;

            if (panelNo == 4)
                panel3LinkXp4.Visible = true;

        }

        private void xPanderPanel1_Click(object sender, EventArgs e)
        {
            ShowLinkedPanelNo(1);
        }

        private void xPanderPanel2_Click(object sender, EventArgs e)
        {
            ShowLinkedPanelNo(2);
        }

        private void xPanderPanel3_Click(object sender, EventArgs e)
        {
            ShowLinkedPanelNo(3);
            textBoxArduinoUnoParamsVer5.Text = this.arduinoUnoParams;
        }

        private void panel3LinkXp3_CloseClick(object sender, EventArgs e)
        {
            textBoxArduinoUnoParamsVer5.Text=this.arduinoUnoParams;
        }

        private void textBoxArduinoUnoParamsVer5_TextChanged(object sender, EventArgs e)
        {
            this.arduinoUnoParams = textBoxArduinoUnoParamsVer5.Text;

            string[] args = this.textBoxArduinoUnoParamsVer5.Text.Split('-');            

            foreach (string param in args)
            {
                if (param.Length>0)
                {
                    if (param[0] == 'b')
                    {
                        cmbSerialUploadSpeed.Text = param.Substring(1).Trim();
                        if (cmbSerialUploadSpeed.Text != param.Substring(1).Trim())
                        {
                            //ComboBox.ObjectCollection mySpeeds = cmbSerialUploadSpeed.Items;
                            //cmbSerialUploadSpeed.Items.Clear();                            
                            //cmbSerialUploadSpeed.Items = mySpeeds;

                            cmbSerialUploadSpeed.Text="";

                        }

                    }
                }
            }
            

            updateParams(); //Show changes
        }

        private void panel3LinkXp3_VisibleChanged(object sender, EventArgs e)
        {            
            
        }

        private void btCinfigDefault_Click(object sender, EventArgs e)
        {
            restoreDefaultConfigParams();
            textBoxArduinoUnoParamsVer5.Text = this.arduinoUnoParams;
            updateParams(); //Show changes
        }

        private void xPanderPanel3_Enter(object sender, EventArgs e)
        {
        }

        private void btConfigSave_Click(object sender, EventArgs e)
        {
            WriteConfigToFile();
        }

        private void chkUSBNotify_CheckedChanged(object sender, EventArgs e)
        {
            this.bUseUsbNotifycations = chkUSBNotify.Checked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void xPanderPanel4_Click(object sender, EventArgs e)
        {            
            ShowLinkedPanelNo(4);
        }

        private void txtSerialTerminal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chkSreialEcho.Checked == false)
                e.Handled = true;
            try
            {
                //chk if port is open if not then check if
                //--If serial port is available 
                if (serialPort1.IsOpen)
                {
                    serialPort1.Write(e.KeyChar.ToString());
                }
            }
            catch (Exception ex) 
            {  //ToDO show error in status bar ;
                toolStripStatusLabel1.Text = ex.ToString().Trim('\n'); ;
            };
        }

        private void btCelarSerialTerminalWindow_Click(object sender, EventArgs e)
        {
            txtSerialTerminal.Clear();
        }

        private void panel3LinkXp2_VisibleChanged(object sender, EventArgs e)
        {
            if (chkIfComPortIsAvailable() == false)
            {
                //MessageBox.Show("COM-port is not Available\nPlease select another COM-port", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "COM-port is not Available - Please select another COM-port";
                return;
            }


            if (panel3LinkXp2.Visible == true)
            {                
                startSerialPort();
                
            }
            else
            {
                closeSerial();
                toolStripStatusLabel1.Text = "";
                this.txtSerialTerminal.Text = ""; //clear recieved RS232 data
            
            }
        }

        private void chkWrapSerialData_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSerialTerminal.WrapText = chkWrapSerialData.Checked;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmbSerialTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.baudRate = Convert.ToInt32(cmbSerialTerm.Text);
            this.updateParams();
            if(serialPort1!=null)
                if (serialPort1.IsOpen)
                startSerialPort();
        }

        private void cmbSerialSpeedCfg_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.baudRate = Convert.ToInt32(cmbSerialSpeedCfg.Text);
            this.updateParams();

            if (serialPort1!=null)
                if(serialPort1.IsOpen)
                    startSerialPort();
                
        }

        private void chkSreialEcho_CheckedChanged(object sender, EventArgs e)
        {
            txtSerialTerminal.Focus();
        }


        //Update the AvrDude argument string
        private void UpdateAvrDudeParameterString()
        {
            //Return if not a valid baud rate (set manualy in textbox)
            if (cmbSerialUploadSpeed.Text.Length==0)
                return;

            string[] args = this.textBoxArduinoUnoParamsVer5.Text.Split('-');
            string newArgs = "";

            foreach (string param in args)
            {
                if (param.Length > 0)
                {
                    if (param[0]=='b')
                        newArgs += "-b " + cmbSerialUploadSpeed.Text;
                    else
                        newArgs += "-" + param;
                }
            }

            this.textBoxArduinoUnoParamsVer5.Text = newArgs;
        }

        //Baudrate changed by using the coombobox 
        private void cmbSerialUploadSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Make av new AVRDude parameter string 
            UpdateAvrDudeParameterString();
        }


    }
}
