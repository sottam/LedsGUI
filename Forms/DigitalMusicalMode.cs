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

        private PictureBox LastPictureBoxClicked;

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
            
            ContextMenuStrip cms = sender as ContextMenuStrip;
            PictureBox clickedImage = cms.SourceControl as PictureBox;
            LastPictureBoxClicked = clickedImage;
            NameToolStripTextBox.Text = clickedImage.Tag.ToString();

            if (clickedImage.Equals(TreblePictureBox))
            {
                if (CsCoreMod._DigitaltreblePrint3DSpectrum.IsXLogScale == true)
                    useXLogScaleToolStripMenuItem.Checked = true;
                else
                    useXLogScaleToolStripMenuItem.Checked = false;

                if (CsCoreMod._DigitaltreblePrint3DSpectrum.UseAverage == true)
                    useAverageToolStripMenuItem.Checked = true;
                else
                    useAverageToolStripMenuItem.Checked = false;

                switch (CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy)
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
            else if (clickedImage.Equals(MedioPictureBox))
            {
                if (CsCoreMod._DigitalMedioPrint3DSpectrum.IsXLogScale == true)
                    useXLogScaleToolStripMenuItem.Checked = true;
                else
                    useXLogScaleToolStripMenuItem.Checked = false;

                if (CsCoreMod._DigitalMedioPrint3DSpectrum.UseAverage == true)
                    useAverageToolStripMenuItem.Checked = true;
                else
                    useAverageToolStripMenuItem.Checked = false;

                switch (CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy)
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
            else if (clickedImage.Equals(BassPictureBox))
            {
                if (CsCoreMod._DigitalBassPrint3DSpectrum.IsXLogScale == true)
                    useXLogScaleToolStripMenuItem.Checked = true;
                else
                    useXLogScaleToolStripMenuItem.Checked = false;

                if (CsCoreMod._DigitalBassPrint3DSpectrum.UseAverage == true)
                    useAverageToolStripMenuItem.Checked = true;
                else
                    useAverageToolStripMenuItem.Checked = false;

                switch (CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy)
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
            else if (clickedImage.Equals(DigitalSoundBars))
            {
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

            if (this.TopMost == true)
                alwaysOnTopToolStripMenuItem.Checked = true;
            else
                alwaysOnTopToolStripMenuItem.Checked = false;
        }

        private void useXLogScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (LastPictureBoxClicked.Equals(TreblePictureBox))
            {
                if (CsCoreMod._DigitaltreblePrint3DSpectrum.IsXLogScale == true)
                    CsCoreMod._DigitaltreblePrint3DSpectrum.IsXLogScale = false;
                else
                    CsCoreMod._DigitaltreblePrint3DSpectrum.IsXLogScale = true;
            }
            else if (LastPictureBoxClicked.Equals(MedioPictureBox))
            {
                if (CsCoreMod._DigitalMedioPrint3DSpectrum.IsXLogScale == true)
                    CsCoreMod._DigitalMedioPrint3DSpectrum.IsXLogScale = false;
                else
                    CsCoreMod._DigitalMedioPrint3DSpectrum.IsXLogScale = true;
            }
            else if (LastPictureBoxClicked.Equals(BassPictureBox))
            {
                if (CsCoreMod._DigitalBassPrint3DSpectrum.IsXLogScale == true)
                    CsCoreMod._DigitalBassPrint3DSpectrum.IsXLogScale = false;
                else
                    CsCoreMod._DigitalBassPrint3DSpectrum.IsXLogScale = true;
            }
            else if (LastPictureBoxClicked.Equals(DigitalSoundBars))
            {
                if (CsCoreMod._DigitallineSpectrum.IsXLogScale == true)
                    CsCoreMod._DigitallineSpectrum.IsXLogScale = false;
                else
                    CsCoreMod._DigitallineSpectrum.IsXLogScale = true;
            }

        }

        private void useAverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastPictureBoxClicked.Equals(TreblePictureBox))
            {
                if (CsCoreMod._DigitaltreblePrint3DSpectrum.UseAverage == true)
                    CsCoreMod._DigitaltreblePrint3DSpectrum.UseAverage = false;
                else
                    CsCoreMod._DigitaltreblePrint3DSpectrum.UseAverage = true;
            }
            else if (LastPictureBoxClicked.Equals(MedioPictureBox))
            {
                if (CsCoreMod._DigitalMedioPrint3DSpectrum.UseAverage == true)
                    CsCoreMod._DigitalMedioPrint3DSpectrum.UseAverage = false;
                else
                    CsCoreMod._DigitalMedioPrint3DSpectrum.UseAverage = true;
            }
            else if (LastPictureBoxClicked.Equals(BassPictureBox))
            {
                if (CsCoreMod._DigitalBassPrint3DSpectrum.UseAverage == true)
                    CsCoreMod._DigitalBassPrint3DSpectrum.UseAverage = false;
                else
                    CsCoreMod._DigitalBassPrint3DSpectrum.UseAverage = true;
            }
            else if (LastPictureBoxClicked.Equals(DigitalSoundBars))
            {
                if (CsCoreMod._DigitallineSpectrum.UseAverage == true)
                    CsCoreMod._DigitallineSpectrum.UseAverage = false;
                else
                    CsCoreMod._DigitallineSpectrum.UseAverage = true;
            }
        }

        private void squareRootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastPictureBoxClicked.Equals(TreblePictureBox))
            {
                CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
            }
            else if (LastPictureBoxClicked.Equals(MedioPictureBox))
            {
                CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
            }
            else if (LastPictureBoxClicked.Equals(BassPictureBox))
            {
                CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
            }
            else if (LastPictureBoxClicked.Equals(DigitalSoundBars))
            {
                CsCoreMod._DigitallineSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
            }
        }

        private void decibelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastPictureBoxClicked.Equals(TreblePictureBox))
            {
                CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
            }
            else if (LastPictureBoxClicked.Equals(MedioPictureBox))
            {
                CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
            }
            else if (LastPictureBoxClicked.Equals(BassPictureBox))
            {
                CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
            }
            else if (LastPictureBoxClicked.Equals(DigitalSoundBars))
            {
                CsCoreMod._DigitallineSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
            }
        }

        private void linearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LastPictureBoxClicked.Equals(TreblePictureBox))
            {
                CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
            }
            else if (LastPictureBoxClicked.Equals(MedioPictureBox))
            {
                CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
            }
            else if (LastPictureBoxClicked.Equals(BassPictureBox))
            {
                CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
            }
            else if (LastPictureBoxClicked.Equals(DigitalSoundBars))
            {
                CsCoreMod._DigitallineSpectrum.ScalingStrategy = ScalingStrategy.Linear;
            }
        }
    }
}
