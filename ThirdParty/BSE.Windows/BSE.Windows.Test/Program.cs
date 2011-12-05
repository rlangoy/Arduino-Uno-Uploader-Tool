using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace BSE.Windows.Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ////if you want to use the RightToLeft demo, please remove this comments
            //CultureInfo currentCulture = new CultureInfo(BSE.Windows.Test.Properties.Settings.Default.Language);
            //Thread.CurrentThread.CurrentCulture = currentCulture;
            //Thread.CurrentThread.CurrentUICulture = currentCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ////if you want to use the RightToLeft demo, please remove this comments
            //using (CCountrySelectionForm form = new CCountrySelectionForm())
            //{
            //    form.ShowDialog();
            //}

            Application.Run(new Form1());
        }
    }
}