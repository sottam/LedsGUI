using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsVisualization.Visualization;

namespace LedsGUI
{
    public partial class DigitalMusicalMode : Form
    {
        public CsCoreModule CsCoreMod { get; set; }

        public DigitalMusicalMode()
        {
            InitializeComponent();
        }

        private void DigitalMusicalMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
                this.TopMost = false;
            else
                this.TopMost = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.TopMost == true)
                alwaysOnTopToolStripMenuItem.Checked = true;
            else
                alwaysOnTopToolStripMenuItem.Checked = false;

            if (CsCoreMod._DigitallineSpectrum.IsXLogScale == true)
                useXLogScaleToolStripMenuItem.Checked = true;
            else
                useXLogScaleToolStripMenuItem.Checked = false;

            if (CsCoreMod._DigitallineSpectrum.UseAverage == true)
                useAverageToolStripMenuItem.Checked = true;
            else
                useAverageToolStripMenuItem.Checked = false;

            switch (CsCoreMod._DigitallineSpectrum.ScalingStrategy)
            {
                case ScalingStrategy.Sqrt:
                    squareRootToolStripMenuItem.Checked = true;
                    decibelToolStripMenuItem.Checked = false;
                    linearToolStripMenuItem.Checked = false;
                    break;
                case ScalingStrategy.Decibel:
                    squareRootToolStripMenuItem.Checked = false;
                    decibelToolStripMenuItem.Checked = true;
                    linearToolStripMenuItem.Checked = false;
                    break;
                case ScalingStrategy.Linear:
                    squareRootToolStripMenuItem.Checked = false;
                    decibelToolStripMenuItem.Checked = false;
                    linearToolStripMenuItem.Checked = true;
                    break;

            }
        }

        private void useXLogScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CsCoreMod._DigitallineSpectrum.IsXLogScale == true)
            {
                CsCoreMod._DigitallineSpectrum.IsXLogScale = false;
                CsCoreMod._DigitalvoicePrint3DSpectrum.IsXLogScale = false;
            }

            else
            {
                CsCoreMod._DigitallineSpectrum.IsXLogScale = true;
                CsCoreMod._DigitalvoicePrint3DSpectrum.IsXLogScale = true;
            }

        }

        private void useAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CsCoreMod._DigitallineSpectrum.UseAverage == true)
            {
                CsCoreMod._DigitallineSpectrum.UseAverage = false;
                CsCoreMod._DigitalvoicePrint3DSpectrum.UseAverage = false;
            }
            else
            {
                CsCoreMod._DigitallineSpectrum.UseAverage = true;
                CsCoreMod._DigitalvoicePrint3DSpectrum.UseAverage = true;
            }
        }

        private void squareRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsCoreMod._DigitallineSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
            CsCoreMod._DigitalvoicePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
        }

        private void decibelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsCoreMod._DigitallineSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
            CsCoreMod._DigitalvoicePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
        }

        private void linearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsCoreMod._DigitallineSpectrum.ScalingStrategy = ScalingStrategy.Linear;
            CsCoreMod._DigitalvoicePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
        }
    }
}
