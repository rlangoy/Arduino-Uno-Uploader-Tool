/*
* Copyright (c) 2011-2012 Rune Langøy
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
    public partial class FormArduinoUpload : Form, IUSBAddedOrRemoved, IRS232Data, IWriteConfig
    {
        //class for handeling the notifycation
        // described in IUSBAddedOrRemoved
        private USBWatcher usbWatcher;

        private BSE.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer StatusBlinkWarning = new System.Windows.Forms.Timer();

        public FormArduinoUpload()
        {
            InitializeComponent();
            StatusBlinkWarning.Tick += new EventHandler(StatusBlinkWarning_Tick);
            toolStripStatusLabel1.TextChanged += new EventHandler(toolStripStatusLabel1_TextChanged);

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
            comboBoxSerailPorts.Text = comPort.ToString();

            //Update params in other components
            foreach (object plugInForms in UploaderPluginForms)
            {
                //Check for Forms that want to send RS232 to the ucontroller
                if (plugInForms is IRS232Data)
                {
                    IRS232Data rs232Interface = plugInForms as IRS232Data;
                    rs232Interface.BaudRate = this.baudRate;
                }
            }
        }

        // Store configuration
        private void WriteConfigToFile()
        {
            ReadWriteInitFile inifile = new ReadWriteInitFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\config.ini",this.lstConfigStorage);
            inifile.Write("Config", "bUseUsbNotifycations", bUseUsbNotifycations.ToString());
            inifile.Write("Config", "comPort", comPort);
            inifile.Write("Config", "fileName", fileName);
            inifile.Write("Config", "arduinoUnoParamsVer5", arduinoUnoParams);
            inifile.Write("Config", "SerialTerminalSpeed", baudRate.ToString());
        }

        // Read configuration
        private void ReadConfigToFile()
        {
            ReadWriteInitFile inifile = new ReadWriteInitFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\config.ini",this.lstConfigStorage);

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
                lbPortNotAvailable.Visible = false;
            else
                lbPortNotAvailable.Visible = true;                

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

                //Send the RS232 incoming data the the plugins
                sendRS232DataToThePlugins(serialPort1.ReadExisting());

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

        //List for forms/plugable components
        List<Form> UploaderPluginForms = new List<Form>();

        // Load the forms/plugable components        
        private void loadPlugableComponents()
        {
            //Load the form components
            UploaderPluginForms.Add(new FormIntro());
            UploaderPluginForms.Add(new FormSerialTerminal());
            UploaderPluginForms.Add(new FormConfiguration());
        }

        //init forms/plugable components
        private void initPlugableComponents()
        {

            //Load the form components
            loadPlugableComponents();
            
            //Scan for event interfaces
            foreach (object plugInForms in UploaderPluginForms)
            {
                //Check for Forms that want to send RS232 to the ucontroller
                if (plugInForms is IRS232Data)
                {
                    IRS232Data rs232Interface = plugInForms as IRS232Data;
                    try { rs232Interface.OnDataRecieved += new EventHandler(pluginFormWanstTosendRS232Data); }
                    catch (NotImplementedException e) { ;}
                    rs232Interface.iRS232Data = this;
                    rs232Interface.BaudRate = this.baudRate;
                }

                if (plugInForms is IWriteConfig)
                {
                    IWriteConfig writeConfig = plugInForms as IWriteConfig;
                    writeConfig.LstConfigStorage = this.lstConfigStorage;  //tansfer the configuration list
                }
            }

        }

        //trigered when a plgin wants to send RS232 data
        void pluginFormWanstTosendRS232Data(object sender, EventArgs e)
        {
            RS232DataEventArgs rs232Data = e as RS232DataEventArgs;

            //Debug only            
            //toolStripStatusLabel1.Text = "RS232: " + rs232Data.RS232String;

            //chk if port is open if not then check if
            //--If serial port is available 
            if (serialPort1.IsOpen)
                serialPort1.Write(rs232Data.RS232String);
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

            //init the form components
            initPlugableComponents();

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


            //Start the serial port so that the listening plugins
            //could use it.
            startSerialPort();
        }

        private void comboBoxSerailPorts_SelectedValueChanged(object sender, EventArgs e)
        {
            comPort = comboBoxSerailPorts.Text;
            updateParams();
            chkIfComPortIsAvailable();
            //Stop serial data if it is open and running
            closeSerial();
            //Start the serial port so that the listening plugins
            //could use it.
            startSerialPort();

        }

        private void textBoxHexFile_TextChanged(object sender, EventArgs e)
        {
            fileName = textBoxHexFile.Text;
            updateParams();
        }

        private Color orgStatusLabelClr;   //Status Strip original colour
        private Color warningStstusLabelClr= Color.Red; //Warning colour

        private void StartStatusWarningBlink()
        {
            orgStatusLabelClr = statusStrip1.BackColor; // Save original background clr
            this.StatusBlinkWarning.Interval = 250;
            StatusBlinkWarning.Enabled = true;
            StatusBlinkCounter = 0;
            this.StatusBlinkWarning.Start();     
        }

        private void StopStatusWarningBlink()
        {
            this.StatusBlinkWarning.Stop();
            statusStrip1.BackColor = orgStatusLabelClr;  //Restore original background clr            
        }
        
        private int StatusBlinkCounter;                   //Timer blink counter
        private int StatusBlinkNumberOfWarningBlinks = 5; //Number of blinks to show if a warning

        private void StatusBlinkWarning_Tick(object sender, EventArgs e)
        {
            //Stop blinking after StatusBlinkNumberOfBlinks 
            if (StatusBlinkCounter >= StatusBlinkNumberOfWarningBlinks)
                StopStatusWarningBlink();
            else
            {
                //Toogle status strip background colour toogle
                if (warningStstusLabelClr == statusStrip1.BackColor)
                    statusStrip1.BackColor = orgStatusLabelClr;
                else
                {
                    statusStrip1.BackColor = warningStstusLabelClr;
                    StatusBlinkCounter++;
                }
            }//end else StatusBlinkCounter > StatusBlinkNumberOfBlinks

        }

        void toolStripStatusLabel1_TextChanged(object sender, EventArgs e)
        {
            //IF toolStripLabel was displaying a warning (reset the bkgcolour)
            if (StatusBlinkWarning.Enabled == true)
                StopStatusWarningBlink();            
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
                }
            }

            if (fileName.Length <= 0)
            {
                MessageBox.Show("Please specify .hex flile to upload", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(fileName))
            {
                MessageBox.Show("The upload file " + fileName + " was not found\nPlease check if the file exists", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    StartStatusWarningBlink();
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
            panel3LinkXp3.Visible = false;

            //Select the form to be displayed
            Form newForm = UploaderPluginForms[panelNo-1];
            
            panelMainPlugin.Visible = true;
            newForm.TopLevel = false;
            //Remove the border
            newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            
            panelMainPlugin.Controls.Clear();//Remove old form

            panelMainPlugin.Controls.Add(newForm);
            newForm.Show();
            newForm.Dock = DockStyle.Fill;
            newForm.BringToFront();            
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




        private void label11_Click(object sender, EventArgs e)
        {

        }
        
        private void cmbSerialSpeedCfg_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.baudRate = Convert.ToInt32(cmbSerialSpeedCfg.Text);
            this.updateParams();

            if (serialPort1!=null)
                if(serialPort1.IsOpen)
                    startSerialPort();
                
        }
        

        #region IRS232Data Members

//        public event EventHandler OnDataRecieved;
        event EventHandler dataRecievedEvent;

        object objectLock = new Object();

        // Explicit interface implementation required.
        // Associate IRS232Data's event with
        // dataRecievedEvent
        event EventHandler IRS232Data.OnDataRecieved
        {
            add
            {
                lock (objectLock)
                {
                    dataRecievedEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    dataRecievedEvent -= value;
                }
            }
        }

        public void sendRS232DataToThePlugins(string data)
        {
            // Raise IRS232Data's event 
            EventHandler handler = dataRecievedEvent;
            if (handler != null)
            {
                handler(this, new RS232DataEventArgs() { RS232String = data });
            }
        }

        //Not to be used by the parent
        //This is only used by the parent (FormArduinoUpload.cs)
        public IRS232Data iRS232Data
        {
            set { throw new NotImplementedException(); }
        }

        //sets and gets the baud rate
        public int BaudRate
        {
            get
            {
                return this.baudRate;
            }
            set
            {               
                this.baudRate = value;
                this.updateParams();
                if (serialPort1 != null)
                    if (serialPort1.IsOpen)
                        startSerialPort();
            }
        }


        #endregion


        #region IWriteConfig Members
        private List<ConfigStorage> lstConfigStorage = new List<ConfigStorage>();
        public  List<ConfigStorage> LstConfigStorage
        {
            set { lstConfigStorage=value; }           
        }

        public void WriteConfig()
        {
            throw new NotImplementedException();
        }

        public void UpdateConfig()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
