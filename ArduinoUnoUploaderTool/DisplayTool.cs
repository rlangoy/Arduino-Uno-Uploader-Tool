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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Reflection;

namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    class cmbSerial : System.Windows.Forms.ComboBox
    {

        private Int32 dwSettableBaud = 0;


        public void UpdateSerialSpeeds(System.IO.Ports.SerialPort sp)
        {
        
            // Getting COMMPROP structure, and its property dwSettableBaud.
            object p = sp.BaseStream.GetType().GetField("commProp",
               BindingFlags.Instance | BindingFlags.NonPublic).GetValue(sp.BaseStream);
            dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud",
               BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

        
            this.Items.Clear();
            this.Items.Add(dwSettableBaud.ToString());
        }

        public cmbSerial()
        {

        }



    }

    class textHexView : System.Windows.Forms.TextBox
    {
        
        public void AddString(string strInput)
        {
            
        }
    
    }

    public class RS232DataEventArgs : EventArgs
    {
        public string RS232String;
    }

    /*
                 inifile.Write("Config", "bUseUsbNotifycations", bUseUsbNotifycations.ToString());
            inifile.Write("Config", "comPort", comPort);
            inifile.Write("Config", "fileName", fileName);
            inifile.Write("Config", "arduinoUnoParamsVer5", arduinoUnoParams);
            inifile.Write("Config", "SerialTerminalSpeed", baudRate.ToString());

     */

    public class ConfigStorage
    {
        public string Section;
        public string Parameter;
        public string Value;
    }

    public interface IWriteConfig
    {
        List<ConfigStorage> LstConfigStorage{ set; }
        void WriteConfig();
        void UpdateConfig();
    }

    public interface IRS232Data
    {
        // Raise this event before drawing
        // the object.
        event EventHandler OnDataRecieved;
        IRS232Data iRS232Data { set; }
        int BaudRate { set; get; }
    }


    class textNormalView : System.Windows.Forms.TextBox
    {

        private int linesShown;
        public textNormalView()
        {
            linesShown=this.Height / this.Font.Height;
            this.SizeChanged += new EventHandler(textNormalView_SizeChanged);
            
        }

        void textNormalView_SizeChanged(object sender, EventArgs e)
        {
            linesShown = this.Height / this.Font.Height;
        }

        private bool wrapText;        
        public  bool WrapText
        {
            get { return wrapText; }
            set { 
                    wrapText=value;                            
                }
        }
        
        public void AddString(string strInput)
        {

            if (this.Text.Length > 64000)
                this.Text = "";            
            
            if (wrapText)
            {
                if (this.Lines.Length >= linesShown) 
                    this.Text = Lines[Lines.Length - 1];
               
            }

            this.AppendText( strInput );
           

        }


    }
}
