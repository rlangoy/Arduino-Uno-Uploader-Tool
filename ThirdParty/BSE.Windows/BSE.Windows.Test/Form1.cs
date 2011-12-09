using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BSE.Windows.Test
{
    public partial class Form1 : Form
    {
        private ToolStripRenderer m_currentToolStripRenderer;
        private BSE.Windows.Forms.ProfessionalColorTable m_currentProfessionalColorTable;
        
        public Form1()
        {
            InitializeComponent();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom("BSE.Windows.Forms.dll");
            Type[] types = assembly.GetTypes();
            Type typeOfClass = null;

            typeOfClass = typeof(System.Windows.Forms.ToolStripProfessionalRenderer);
            foreach (Type type in types)
            {
                if ((type.IsClass == true) &&
                    (typeOfClass.IsAssignableFrom(type) == true))
                {
                    this.m_cboToolStripRenderer.Items.Add(type);
                }
            }

            this.m_cboToolStripRenderer.Items.Add(typeof(ToolStripProfessionalRenderer));
            this.m_cboToolStripRenderer.SelectedItem = typeof(BSE.Windows.Forms.Office2007Renderer);

            this.treeView1.ExpandAll();
            SetViewMenuItems();
        }

        private void m_mnuFile_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExpandXPander_Click(object sender, EventArgs e)
        {
            if (xPanderPanel10 != null)
            {
                BSE.Windows.Forms.XPanderPanelList panelList = xPanderPanel10.Parent as BSE.Windows.Forms.XPanderPanelList;
                if (panelList != null)
                {
                    panelList.Expand(xPanderPanel10);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (xPanderPanel3 != null)
            {
                xPanderPanel3.Visible = !xPanderPanel3.Visible;
            }
        }

        private void btnAddXPanderPanel_Click(object sender, EventArgs e)
        {
            if (xPanderPanelList3 != null)
            {
                BSE.Windows.Forms.XPanderPanel xpanderPanel = new BSE.Windows.Forms.XPanderPanel();
                xpanderPanel.Text = "new XPanderPanel";
                xPanderPanelList3.XPanderPanels.Add(xpanderPanel);
            }
        }

        private void SetViewMenuItems()
        {
            this.m_mnuView.DropDownItems.Clear();
            ArrayList basePanels = BSE.Windows.Forms.PanelSettingsManager.FindPanels(true, this.Controls);
            foreach (BSE.Windows.Forms.BasePanel basePanel in basePanels)
            {
                BSE.Windows.Forms.Panel panel = basePanel as BSE.Windows.Forms.Panel;
                if ((panel != null) && ((panel.Dock != DockStyle.Fill) || (panel.Dock != DockStyle.None)) && (panel.ShowCloseIcon == true))
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = panel.Text;
                    menuItem.Image = panel.Image;
                    menuItem.Tag = panel;
                    menuItem.Click += new EventHandler(ViewMenuItemsClick);
                    if (panel.Visible == true)
                    {
                        menuItem.Checked = true;
                    }
                    this.m_mnuView.DropDownItems.Add(menuItem);
                }
            }
        }

        private void ViewMenuItemsClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem != null)
            {
                BSE.Windows.Forms.Panel panel = menuItem.Tag as BSE.Windows.Forms.Panel;
                if (panel != null)
                {
                    panel.Visible = !panel.Visible;
                }
            }
        }

        private void PanelsCloseClick(object sender, EventArgs e)
        {
            BSE.Windows.Forms.Panel panel = sender as BSE.Windows.Forms.Panel;
            if (panel != null)
            {
                panel.Visible = false;
                SetViewMenuItems();
            }
        }

        private void PanelsVisibleChanged(object sender, EventArgs e)
        {
            BSE.Windows.Forms.Panel panel = sender as BSE.Windows.Forms.Panel;
            if (panel != null)
            {
                SetViewMenuItems();
            }
        }

        private void m_cboToolStripRenderer_SelectedValueChanged(object sender, EventArgs e)
        {
            Type type = m_cboToolStripRenderer.SelectedItem as Type;
            if (type != null)
            {
                ToolStripProfessionalRenderer toolStripRenderer = Activator.CreateInstance(type) as ToolStripProfessionalRenderer;
                if (toolStripRenderer != null)
                {
                    if (toolStripRenderer.Equals(this.m_currentToolStripRenderer) == false)
                    {
                        this.m_cboProfessionalColorTable.Items.Clear();
                        Type baseType = toolStripRenderer.ColorTable.GetType().BaseType;
                        if (baseType != null)
                        {
                            System.Reflection.Assembly assembly = toolStripRenderer.ColorTable.GetType().Assembly;
                            if (assembly != null)
                            {
                                Type[] types = assembly.GetTypes();

                                foreach (Type colorTableType in types)
                                {
                                    if ((colorTableType.IsClass == true) &&
                                        (baseType.IsAssignableFrom(colorTableType) == true) &&
                                        (baseType != colorTableType) &&
                                        (baseType.BaseType == typeof(BSE.Windows.Forms.ProfessionalColorTable)))
                                    {
                                        this.m_cboProfessionalColorTable.Items.Add(colorTableType);
                                    }
                                }
                            }
                        }

                        BSE.Windows.Forms.ProfessionalColorTable colorTable = toolStripRenderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
                        if (colorTable != null)
                        {
                            BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
                            if (panelColorTable != null)
                            {
                                BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                                    this.Controls,
                                    panelColorTable);
                            }
                        }
                        else
                        {
                            BSE.Windows.Forms.PanelColors panelColorTable = new BSE.Windows.Forms.PanelColors();
                            BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                                    this.Controls,
                                    panelColorTable);
                        }

                        this.m_currentToolStripRenderer = toolStripRenderer;
                        ToolStripManager.Renderer = this.m_currentToolStripRenderer;
                    }
                }
            }
        }

        private void m_cboProfessionalColorTable_SelectedValueChanged(object sender, EventArgs e)
        {
            Type type = m_cboProfessionalColorTable.SelectedItem as Type;
            if (type != null)
            {
                BSE.Windows.Forms.ProfessionalColorTable colorTable = Activator.CreateInstance(type) as BSE.Windows.Forms.ProfessionalColorTable;
                if (colorTable != null)
                {
                    if (colorTable.Equals(this.m_currentProfessionalColorTable) == false)
                    {
                        BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
                        if (panelColorTable != null)
                        {
                            BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                                this.Controls,
                                panelColorTable);
                        }

                        this.m_currentProfessionalColorTable = colorTable;
                        this.m_currentToolStripRenderer = Activator.CreateInstance(this.m_currentToolStripRenderer.GetType(), new object[] { colorTable }) as ToolStripProfessionalRenderer;
                        ToolStripManager.Renderer = this.m_currentToolStripRenderer;
                    }
                }
            }
        }

        private void m_btnToggleColors_Click(object sender, EventArgs e)
        {
            ToolStripProfessionalRenderer renderer = ToolStripManager.Renderer as ToolStripProfessionalRenderer;
            if (renderer != null)
            {
                BSE.Windows.Forms.ProfessionalColorTable colorTable = renderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
                if (colorTable != null)
                {
                    colorTable.UseSystemColors = !colorTable.UseSystemColors;
                    renderer = Activator.CreateInstance(renderer.GetType(), new object[] { colorTable }) as ToolStripProfessionalRenderer;

                    BSE.Windows.Forms.PanelColors panelColors = colorTable.PanelColorTable;
                    if (panelColors != null)
                    {
                        panelColors.UseSystemColors = colorTable.UseSystemColors;
                        BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(
                            this.Controls,
                            panelColors);
                    }

                    ToolStripManager.Renderer = renderer;
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            toolStripProgressBar1.Value = toolStripProgressBar2.Value = trackBar1.Value;
            toolStripProgressBar1.Text = toolStripProgressBar2.Text = string.Format("{0}%", trackBar1.Value);
            toolStripProgressBar1.ToolTipText = toolStripProgressBar2.ToolTipText = string.Format("Free space: {0}%", trackBar1.Value);
        }

        private void XPanderPanelListControlRemoved(object sender, ControlEventArgs e)
        {
            BSE.Windows.Forms.XPanderPanelList xpanderPanelList = sender as BSE.Windows.Forms.XPanderPanelList;
            BSE.Windows.Forms.XPanderPanel xpanderPanel = e.Control as BSE.Windows.Forms.XPanderPanel;
            if ((xpanderPanel != null) && (xpanderPanelList != null))
            {
                MessageBox.Show(string.Format("'{0}' removed from '{1}'", xpanderPanel.Text, xpanderPanelList.Name));
            }
        }

        private void btnShowHideCaptionbar_Click(object sender, EventArgs e)
        {
            //displaye or hides the captionbar at the top of the panel
            panel6.ShowCaptionbar = !panel6.ShowCaptionbar;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}
