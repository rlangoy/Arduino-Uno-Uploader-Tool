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
using System.Management;

namespace HIVE.TEKMAR.ITEK.ArduinoUnoToolGui
{
    //Interface for handling usb change notifycation
    public interface IUSBAddedOrRemoved
    {
        void USBNotifyRemoved();
        void USBNotifyInserted();
    }
        
    public class USBAddedOrRemovedEventWatcher : ManagementEventWatcher
    {

        private  IUSBAddedOrRemoved parent;
        public   IUSBAddedOrRemoved Parent
        {
            get {return parent;}
        }

        public USBAddedOrRemovedEventWatcher(IUSBAddedOrRemoved parent, ManagementScope scope, EventQuery query)
            : base(scope, query)
        {
            this.parent = parent;
        }
    }

    /* 
       * Besed upon Code from: 
       *   http://dotnetslackers.com/Community/blogs/basharkokash/archive/2008/03/15/USB-Detection-source-code.aspx
     */
    public class USBWatcher 
    {

        private static USBAddedOrRemovedEventWatcher wRemoveUSBHandler = null;
        private static USBAddedOrRemovedEventWatcher wAddedUSBHandler = null;

        private IUSBAddedOrRemoved parent = null;
        public IUSBAddedOrRemoved Parent
        {
            get { return parent; }
        }

        public USBWatcher(IUSBAddedOrRemoved parent)
        {
            this.parent = parent;
            AddInsetUSBHandler();
            AddRemoveUSBHandler();
        }

        public void ReleaseHanlders()
        {
            ReleaseAddRemoveUSBHandler();
            ReleaseAddInsetUSBHandler();
        }


        private void ReleaseAddRemoveUSBHandler()
        {
            wRemoveUSBHandler.Stop();
            wRemoveUSBHandler.EventArrived -= new EventArrivedEventHandler(USBRemoved);
            wRemoveUSBHandler.Dispose();
            wRemoveUSBHandler = null;
        }

        private void ReleaseAddInsetUSBHandler()
        {
            wAddedUSBHandler.Stop();
            wAddedUSBHandler.EventArrived -= new EventArrivedEventHandler(USBAdded);
            wAddedUSBHandler.Dispose();
            wAddedUSBHandler = null;
        }
        

        private void AddRemoveUSBHandler()
        {
            WqlEventQuery q;
            ManagementScope scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceDeletionEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = @"TargetInstance ISA 'Win32_USBControllerdevice'";
                wRemoveUSBHandler = new USBAddedOrRemovedEventWatcher( Parent, scope, q);
                wRemoveUSBHandler.EventArrived += new EventArrivedEventHandler(USBRemoved);
                wRemoveUSBHandler.Start();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (wRemoveUSBHandler != null)
                    wRemoveUSBHandler.Stop();
            }

        }

        private void AddInsetUSBHandler()
        {            
            WqlEventQuery q;
            ManagementScope scope = new ManagementScope("root\\CIMV2");
            scope.Options.EnablePrivileges = true;

            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "__InstanceCreationEvent";
                q.WithinInterval = new TimeSpan(0, 0, 3);
                q.Condition = @"TargetInstance ISA 'Win32_USBControllerdevice'";
                wAddedUSBHandler = new USBAddedOrRemovedEventWatcher(Parent, scope, q);
                wAddedUSBHandler.EventArrived += new EventArrivedEventHandler(USBAdded);
                wAddedUSBHandler.Start();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (wAddedUSBHandler != null)
                    wAddedUSBHandler.Stop();
            }

        }
        
        //Send notify back to parent
        public static void USBAdded(object sender, EventArgs e)
        {
            if (sender is USBAddedOrRemovedEventWatcher)
            {
                USBAddedOrRemovedEventWatcher watcher = sender as USBAddedOrRemovedEventWatcher;
                watcher.Parent.USBNotifyInserted();
            }
        }

        //Send notify back to parent
        public static void USBRemoved(object sender, EventArgs e)
        {
            if (sender is USBAddedOrRemovedEventWatcher)
            {
                USBAddedOrRemovedEventWatcher watcher = sender as USBAddedOrRemovedEventWatcher;
                watcher.Parent.USBNotifyRemoved();             
            }
        }        
    
    }

}
