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

namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    public partial class FormConfiguration : Form, IWriteConfig,IRS232Data
    {
        public FormConfiguration()
        {
            InitializeComponent();
        }


        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            UpdateConfig();
        }

        #region IWriteConfig Members

        private List<ConfigStorage> lstConfigStorage;
        public List<ConfigStorage>  LstConfigStorage
        {
            set { lstConfigStorage=value; }
        }

        public void WriteConfig()
        {
            throw new NotImplementedException();
        }

        public void UpdateConfig()
        {
            foreach (ConfigStorage config in lstConfigStorage)
            {
                if (config.Section.ToLower().CompareTo("config") == 0)
                {                    
                    if (config.Parameter.ToLower().CompareTo("arduinounoparamsver5") == 0)
                        textBoxArduinoUnoParamsVer5.Text = config.Value;

                    if (config.Parameter.ToLower().CompareTo("buseusbnotifycations") == 0)
                        chkUSBNotify.Checked = Convert.ToBoolean(config.Value);

                    if (config.Parameter.ToLower().CompareTo("serialterminalspeed") == 0)
                        cmbSerialSpeedCfg.Text = config.Value;
                    
                }
            }
        }

        #endregion

        //Update the AvrDude argument string
        private void UpdateAvrDudeParameterString()
        {
            //Return if not a valid baud rate (set manualy in textbox)
            if (cmbSerialUploadSpeed.Text.Length == 0)
                return;

            string[] args = this.textBoxArduinoUnoParamsVer5.Text.Split('-');
            string newArgs = "";

            foreach (string param in args)
            {
                if (param.Length > 0)
                {
                    if (param[0] == 'b')
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

        private void textBoxArduinoUnoParamsVer5_TextChanged(object sender, EventArgs e)
        {
            string[] args = this.textBoxArduinoUnoParamsVer5.Text.Split('-');

            foreach (string param in args)
            {
                if (param.Length > 0)
                {
                    if (param[0] == 'b')
                    {
                        cmbSerialUploadSpeed.Text = param.Substring(1).Trim();
                        if (cmbSerialUploadSpeed.Text != param.Substring(1).Trim())
                        {
                            cmbSerialUploadSpeed.Text = "";
                        }

                    }
                }
            }
        }

        private void cmbSerialSpeedCfg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(parentInterface is IRS232Data )
            {
                IRS232Data parentIRS232DataInterface= parentInterface as IRS232Data; 
                if (parentIRS232DataInterface != null)
                    parentIRS232DataInterface.BaudRate = Convert.ToInt32(this.cmbSerialSpeedCfg.Text);
            
            }
        }

        #region IRS232Data Members

        public event EventHandler OnDataRecieved=null;

        private Iparent parentInterface = null;
        public IRS232Data iRS232Data
        {
            set
            {
                parentInterface = value as Iparent;
            }
        }

        public int BaudRate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                cmbSerialSpeedCfg.Text = value.ToString();
            }
        }

        #endregion

        private void btConfigSave_Click(object sender, EventArgs e)
        {
            if (this.parentInterface is IWriteConfig)
            {

                //Update parameter list before sending
                foreach (ConfigStorage config in lstConfigStorage)
                {
                    if (config.Section.ToLower().CompareTo("config") == 0)
                    {
                        if (config.Parameter.ToLower().CompareTo("arduinounoparamsver5") == 0)
                            config.Value = textBoxArduinoUnoParamsVer5.Text;

                        if (config.Parameter.ToLower().CompareTo("buseusbnotifycations") == 0)
                            config.Value = chkUSBNotify.Checked.ToString();

                        if (config.Parameter.ToLower().CompareTo("serialterminalspeed") == 0)
                            config.Value = cmbSerialSpeedCfg.Text;

                    }
                }

                IWriteConfig wConfig = parentInterface as IWriteConfig;
                wConfig.WriteConfig();
            }            
        }


        private void restoreDefaultConfigParams()
        {
            //Update parameter list width default params
            foreach (ConfigStorage config in lstConfigStorage)
            {
                if (config.Section.ToLower().CompareTo("config") == 0)
                {
                    if (config.Parameter.ToLower().CompareTo("arduinounoparamsver5") == 0)
                        config.Value = "-F -v -pm328p -c arduino -b 115200";

                    if (config.Parameter.ToLower().CompareTo("buseusbnotifycations") == 0)
                        config.Value = "true";

                    if (config.Parameter.ToLower().CompareTo("serialterminalspeed") == 0)
                        config.Value = "19200";
                }
            }

            //Update display
            UpdateConfig();
        }


        private void btCinfigDefault_Click(object sender, EventArgs e)
        {
            restoreDefaultConfigParams();
        }
    }
}
