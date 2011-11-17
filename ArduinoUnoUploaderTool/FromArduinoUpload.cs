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

namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    public partial class FormArduinoUpload : Form, IUSBAddedOrRemoved
    {
        //class for handeling the notifycation
        // described in IUSBAddedOrRemoved
        private USBWatcher usbWatcher;

        public FormArduinoUpload()
        {
            InitializeComponent();
        }

        //List of serial ports
        private string[] ports;

        //serial dropdown list
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            chkIfPortIsAvailable();

            comboBoxSerailPorts.Items.Clear();
            foreach (string name in ports)
                comboBoxSerailPorts.Items.Add(name);
        }

        //Config parameters
        private bool bUseUsbNotifycations = true;
        private string comPort=   "COM1";
        private string fileName = "";
        private string arduinoUnoParams = "-F -v -pm328p -cstk500v1 ";

        public void USBRemoved()
        {
            chkIfPortIsAvailable();
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
                    comboBoxSerailPorts.Text = strPort;
                    chkIfPortIsAvailable();
                    break;
                }
            }
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
        }

        // Store configuration
        private void WriteConfigToFile()
        {
            ReadWriteInitFile inifile = new ReadWriteInitFile(Directory.GetCurrentDirectory() + "\\config.ini");
            inifile.Write("Config", "bUseUsbNotifycations", bUseUsbNotifycations.ToString());
            inifile.Write("Config", "comPort", comPort);
            inifile.Write("Config", "fileName", fileName);
            inifile.Write("Config", "arduinoUnoParams", arduinoUnoParams);
        }

        // Read configuration
        private void ReadConfigToFile()
        {
            ReadWriteInitFile inifile = new ReadWriteInitFile(Directory.GetCurrentDirectory() + "\\config.ini");

            string readString = inifile.Read("Config", "comPort");
            if (readString.Length > 0)
                comPort = readString;

            readString = inifile.Read("Config", "fileName");
            if (readString.Length > 0)
                fileName = readString;

            readString = inifile.Read("Config", "arduinoUnoParams");
            if (readString.Length > 0)
                arduinoUnoParams = readString;

            readString = inifile.Read("Config", "bUseUsbNotifycations");
            if (readString.Length > 0)
                bUseUsbNotifycations = Convert.ToBoolean(readString);

        }


        private void chkIfPortIsAvailable()
        {
            ports = System.IO.Ports.SerialPort.GetPortNames(); // Get serial ports

            if (ports.Contains(comPort) == true)
                lbPortNotAvailable.Visible = false;
            else
                lbPortNotAvailable.Visible = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            ReadConfigToFile();
            
            textBoxHexFile.Text = fileName;
            comboBoxSerailPorts.Text = comPort;

            updateParams();

            //start listen for USBNotifycations 
            // as described in IUSBAddedOrRemoved
            if (bUseUsbNotifycations)
                usbWatcher = new USBWatcher(this);

            chkIfPortIsAvailable();
        }

        private void comboBoxSerailPorts_SelectedValueChanged(object sender, EventArgs e)
        {
            comPort = comboBoxSerailPorts.Text;
            updateParams();
            chkIfPortIsAvailable();
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

            if (fileName.Length <= 0)
            {
                MessageBox.Show("Please specify .hex flile to upload", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Process p = null;
            try
            {   //string targetDir;
                //targetDir = string.Format(@"C:\Temp\CallBatchFile\BatchFile");
                p = new Process();
               // p.StartInfo.WorkingDirectory = targetDir;
                p.StartInfo.FileName = "avrdude.exe";

                p.StartInfo.Arguments = textParams.Text;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}",
                          ex.Message, ex.StackTrace.ToString());
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
    }
}
