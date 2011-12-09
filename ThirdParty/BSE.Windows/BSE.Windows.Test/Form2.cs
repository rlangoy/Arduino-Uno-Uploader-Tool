using System;
using System.Text;
using System.Windows.Forms;

namespace BSE.Windows.Test
{
    public class Form2 : Form
    {
        private BSE.Windows.Forms.Panel panel1;
        
        public Form2()
        {
            // Create and initialize a Panel.
            this.panel1 = new BSE.Windows.Forms.Panel();
            this.panel1.Text = "panel1";
            // Set the panel background.
            this.panel1.ShowTransparentBackground = false;
            // Set the panel's DockStyle to DockStyle.Fill
            this.panel1.Dock = DockStyle.Fill;
            // Add the panel to the form
            this.Controls.Add(this.panel1);

            // Create and initialize a ToolStripProfessionalRenderer.
            ToolStripProfessionalRenderer renderer = new BSE.Windows.Forms.Office2007Renderer();
            // Add it to the ToolStripManager.Renderer
            ToolStripManager.Renderer = renderer;

            // Get the ProfessionalColorTable colorTable for the current renderer.
            BSE.Windows.Forms.ProfessionalColorTable colorTable = renderer.ColorTable as BSE.Windows.Forms.ProfessionalColorTable;
            if (colorTable != null)
            {
                // Get the PanelColors panelColorTable for the current  colortable.
                BSE.Windows.Forms.PanelColors panelColorTable = colorTable.PanelColorTable;
                if (panelColorTable != null)
                {
                    // Set the panel properties for the form controls collection
                    BSE.Windows.Forms.PanelSettingsManager.SetPanelProperties(this.Controls, panelColorTable);
                }
            }
        }
    }
}
