using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedsGUI
{
    public partial class IntegratedVisualization : Form
    {

        public IntegratedVisualization()
        {
            InitializeComponent();
        }

        private void IntegratedVisualization_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void hidePropertiesSoundBarMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed)
                splitContainer2.Panel2Collapsed = false;
            else
                splitContainer2.Panel2Collapsed = true;
        }

        private void hidePropertiesSoundSpectrumMenuItem1_Click(object sender, EventArgs e)
        {
            if (splitContainer3.Panel2Collapsed)
                splitContainer3.Panel2Collapsed = false;
            else
                splitContainer3.Panel2Collapsed = true;
        }

        private void SoundBarsMenu_Opening(object sender, CancelEventArgs e)
        {
            if (splitContainer2.Panel2Collapsed)
                hidePropertiesSoundBarMenuItem.Checked = true;
            else
                hidePropertiesSoundBarMenuItem.Checked = false;

            if (this.TopMost == true)
                alwaysOnTopToolStripMenuItem.Checked = true;
            else
                alwaysOnTopToolStripMenuItem.Checked = false;
        }

        private void SoundSpectrumMenu_Opening(object sender, CancelEventArgs e)
        {
            if (splitContainer3.Panel2Collapsed)
                hidePropertiesSoundSpectrumMenuItem1.Checked = true;
            else
                hidePropertiesSoundSpectrumMenuItem1.Checked = false;

            if (this.TopMost == true)
                alwaysOnTopToolStripMenuItem1.Checked = true;
            else
                alwaysOnTopToolStripMenuItem1.Checked = false;
        }

        private void alwaysOnTopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
                this.TopMost = false;
            else
                this.TopMost = true;
        }
    }
}
