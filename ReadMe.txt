Tools for uploading .hex 
Displaying serial mesages. 

3rd Party contributing to the project:
   http://www.codeproject.com/KB/miscctrl/XPanderControls.aspx
   XPanderControls
   By Uwe Eichkorn | 27 Nov 2008 
   License:
   This article, along with any associated source code and files, is licensed under The Code Project Open License (CPOL

DESCRIPTION:
    Arduino Uno Uloader Tool is a easy to use windows tool for uploading .hex file to 
    an Arduino Uno Board (http://arduino.cc/en/Main/ArduinoBoardUno)        

SITE: 
    http://rlangoy.github.com/Arduino-Uno-Uploader-Tool/

FEATURES:

    Easy to use gui.

    Automaticaly detects and select if a new USB/Serial port is connected to the PC.

    Allsettings is restored when the program is restarted.

    Easy to use RS323 terminal

SYNOPSIS:

    When the program starts it creates a configuration file (config.ini) and the file
    is updated width changes when the program exites
         
     Example content of a config.ini file (stored in the User's Application Data Folder)
       [Config]
       comPort=COM35
       fileName=C:\work\test.hex
       arduinoUnoParamsVer5=-F -v -pm328p -c arduino -b 115200
       bUseUsbNotifycations=True

       When the user pushed the upload button avrdude is started width the folowing parameters:
           -F -v -pm328p -c arduino -b 115200 -P\\.\COM35 -D -Uflash:w:"c:\work\test.hex":i

       The config.ini file can be modifyed so that the Arduino Uploader Tool could 
       be used to program other Arduino / AVR boards


      config.ini parameters:
          
	[Config]  comPort              - serial port that is used to program the Arduino borad
	[Config]  fileName             - the name and location of the intel .hex file to upload 
	[Config]  arduinoUnoParamsVer5 - additional params used by avrdude to program the Arduino borad
	[Config]  bUseUsbNotifycations - Detect / not detect if a new USB to RS232 device was insertet to the system
				         (a Arduino Board)

INSTALL:

    run setup.exe


LICENSE:

 Copyright (c) 2011 Rune Langøy
 All rights reserved.

 Permission to use, copy, modify, and distribute this software for any
 purpose with or without fee is hereby granted, provided that the above
 copyright notice and this permission notice appear in all copies.

 THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
 WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
 MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
 ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
 WHATSOEVER RESULTING FROM LOSS OF MIND, USE, DATA OR PROFITS, WHETHER IN
 AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT
 OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
