﻿using System;
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

    public interface IRS232Data
    {
        // Raise this event before drawing
        // the object.
        event EventHandler OnDataRecieved;        
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
