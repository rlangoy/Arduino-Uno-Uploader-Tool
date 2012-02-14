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
    public partial class FormSerialTerminal : Form
    {
        public FormSerialTerminal()
        {
            InitializeComponent();
        }

        private void chkSreialEcho_CheckedChanged(object sender, EventArgs e)
        {
            txtSerialTerminal.Focus();
        }

        private void chkWrapSerialData_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSerialTerminal.WrapText = chkWrapSerialData.Checked;
        }

        private void btCelarSerialTerminalWindow_Click(object sender, EventArgs e)
        {
            txtSerialTerminal.Clear();
        }

        private void cmbSerialTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            this.baudRate = Convert.ToInt32(cmbSerialTerm.Text);
            this.updateParams();
            if (serialPort1 != null)
                if (serialPort1.IsOpen)
                    startSerialPort();
            */

         }
    }
}
