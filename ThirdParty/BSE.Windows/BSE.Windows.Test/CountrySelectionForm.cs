using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace BSE.Windows.Test
{
	public partial class CCountrySelectionForm : Form
	{
		public CCountrySelectionForm()
		{
			InitializeComponent();

			m_cboCountryList.SelectedItem = BSE.Windows.Test.Properties.Settings.Default.Language;
		}

		private void CboCountryListSelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_cboCountryList.SelectedIndex != -1)
			{
				string strCulture = m_cboCountryList.SelectedItem as string;

				CultureInfo selectedCulture = new CultureInfo(strCulture);
                Thread.CurrentThread.CurrentCulture = selectedCulture;
                Thread.CurrentThread.CurrentUICulture = selectedCulture;
			}
		}
	}
}