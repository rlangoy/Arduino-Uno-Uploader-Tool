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
    public partial class FormSerialTerminal : Form, IRS232Data
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

        #region IRS232Data Members

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

        public void sendRS232Data(string data)
        {
            // Raise IDrawingObject's event before the object is drawn.
            EventHandler handler = dataRecievedEvent;
            if (handler != null)
            {                
                handler(this, new RS232DataEventArgs(){RS232String=data});
            }
        }

        #endregion
    }
}
