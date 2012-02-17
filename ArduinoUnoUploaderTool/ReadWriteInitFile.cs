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
using System.Runtime.InteropServices;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    /*
     http://midnightprogrammer.net/post/ReadWrite-settings-to-INI-File-using-C.aspx
     Read/Write settings to INI File using C#
     by Prashant 22. October 2009 03:12

     When we design application we always face problems to save settings for the application and to achieve that we use different options available to us. A very common method to use in accordance of complexity XML files, Registry, Application.config or other/normal files. Best option is to use application configuration file but it seems that most of the people are not fully aware with the usage of the application configuration file. I will discuss late on the application configuration file a.k.a. app.config, but here is the way to use the INI files to save application settings.
     Here I am using a simple class which has two methods Write & Read methods which internally calls the functions inside the Kernel32.dll which are WritePrivateProfileString and ReadPrivateProfileString. Both methods take parameters and write it to the INI file. Here is the complete listing of the class which can be use to read and write settings to the INI file.
     INI files have sections and keys from where the data can be read on the combination of the sections and keys. As there can be a common key in different sections of the INI file. A section is defined in [SECTION NAME] and then it have a Key and its KeyValue.
     */

    class ReadWriteInitFile
    {

        private string filePath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
        string key,
        string val,
        string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
        string key,
        string def,
        StringBuilder retVal,
        int size,
        string filePath);

        private List<ConfigStorage> lstConfigStorage;

        public ReadWriteInitFile(string filePath, List<ConfigStorage> lstConfigStorage)
        {
            this.filePath = filePath;
            this.lstConfigStorage = lstConfigStorage;
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.filePath);            
        }

        public string Read(string section, string key)
        {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
            lstConfigStorage.Add(new ConfigStorage() { Section = section, Parameter = key, Value = SB.ToString() });
            return SB.ToString();
        }

        public string FilePath
        {
            get { return this.filePath; }
            set { this.filePath = value; }
        }
    }


}
