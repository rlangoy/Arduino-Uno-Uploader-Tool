using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BSE.Windows.Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            BSE.Windows.Forms.CustomColors panelColors = new BSE.Windows.Forms.CustomXPanderPanelColors();
            propertyGrid1.SelectedObject = xPanderPanel9.CustomColors;

            propertyGrid2.SelectedObject = new CPanelStyle();
        }

        private class CPanelStyle
        {
            private BSE.Windows.Forms.PanelStyle m_panelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            [Description("Style of the panel")]
            [DefaultValue(BSE.Windows.Forms.PanelStyle.Office2007)]
            public BSE.Windows.Forms.PanelStyle PanelStyle
            {
                get { return this.m_panelStyle; }
                set { this.m_panelStyle = value; }
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            PropertyGrid propertyGrid = s as PropertyGrid;
            if (propertyGrid != null)
            {
                BSE.Windows.Forms.XPanderPanel xpanderPanel = propertyGrid.Tag as BSE.Windows.Forms.XPanderPanel;
                if (xpanderPanel != null)
                {
                    PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(xpanderPanel.CustomColors)[e.ChangedItem.Label];
                    if (propertyDescriptor != null)
                    {
                        propertyDescriptor.SetValue(xpanderPanel.CustomColors, e.ChangedItem.Value);
                    }
                }
            }
        }

        private void propertyGrid2_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            foreach (BSE.Windows.Forms.XPanderPanel xpanderPanel in this.xPanderPanelList3.XPanderPanels)
            {
                PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(xpanderPanel)[typeof(BSE.Windows.Forms.PanelStyle).Name];
                if (propertyDescriptor != null)
                {
                    propertyDescriptor.SetValue(xpanderPanel, e.ChangedItem.Value);
                }
            }
        }

        private void xPanderPanelExpandClick(object sender, EventArgs e)
        {
            BSE.Windows.Forms.XPanderPanel xpanderPanel = sender as BSE.Windows.Forms.XPanderPanel;
            if (xpanderPanel != null)
            {
                propertyGrid1.Tag = xpanderPanel;
                propertyGrid1.SelectedObject = xpanderPanel.CustomColors;
            }
        }
    }
}
