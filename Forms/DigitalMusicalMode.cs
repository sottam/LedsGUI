using LedsGUI.Cscore;
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

        public DigitalMusicalMode(CsCoreModule cscore)
        {
            InitializeComponent();

            CsCoreMod = cscore;

            CsCoreMod._DigitaltreblePrint3DSpectrum.UseAverage = Properties.Settings.Default.TrebleUseAverage;
            CsCoreMod._DigitaltreblePrint3DSpectrum.IsXLogScale = Properties.Settings.Default.TrebleIsXLogScale;
            CsCoreMod._DigitaltreblePrint3DSpectrum.MinimumFrequency = Properties.Settings.Default.TrebleMinFreq;
            CsCoreMod._DigitaltreblePrint3DSpectrum.MaximumFrequency = Properties.Settings.Default.TrebleMaxFreq;
            switch (Properties.Settings.Default.TrebleScaling)
            {
                case 0:
                    CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
                    break;
                case 1:
                    CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
                    break;
                case 2:
                    CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
                    break;
                default:
                    CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
                    break;
            }
            
            CsCoreMod._DigitalMedioPrint3DSpectrum.UseAverage = Properties.Settings.Default.MediumUseAverage;
            CsCoreMod._DigitalMedioPrint3DSpectrum.IsXLogScale = Properties.Settings.Default.MediumIsXLogScale;
            CsCoreMod._DigitalMedioPrint3DSpectrum.MinimumFrequency = Properties.Settings.Default.MediumMinFreq;
            CsCoreMod._DigitalMedioPrint3DSpectrum.MaximumFrequency = Properties.Settings.Default.MediumMaxFreq;
            switch (Properties.Settings.Default.MediumScaling)
            {
                case 0:
                    CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
                    break;
                case 1:
                    CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
                    break;
                case 2:
                    CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
                    break;
                default:
                    CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
                    break;
            }
            CsCoreMod._DigitalBassPrint3DSpectrum.UseAverage = Properties.Settings.Default.BassUseAverage;
            CsCoreMod._DigitalBassPrint3DSpectrum.IsXLogScale = Properties.Settings.Default.BassIsXLogScale;
            CsCoreMod._DigitalBassPrint3DSpectrum.MinimumFrequency = Properties.Settings.Default.BassMinFreq;
            CsCoreMod._DigitalBassPrint3DSpectrum.MaximumFrequency = Properties.Settings.Default.BassMaxFreq;
            switch (Properties.Settings.Default.BassScaling)
            {
                case 0:
                    CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Decibel;
                    break;
                case 1:
                    CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
                    break;
                case 2:
                    CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Sqrt;
                    break;
                default:
                    CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy = ScalingStrategy.Linear;
                    break;
            }
        }

        private void DigitalMusicalMode_Load(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.trebleFactor = TrebleNumericUpDown.Value;
            VoicePrint3DSpectrum.medioFactor = MedioNumericUpDown.Value;
            VoicePrint3DSpectrum.bassFactor = BassNumericUpDown.Value;

            VoicePrint3DSpectrum.trebleFactorSqrt = TrebleSqrtNumericUpDown.Value;
            VoicePrint3DSpectrum.MedioFactorSqrt = MedioSqrtNumericUpDown.Value;
            VoicePrint3DSpectrum.BassFactorSqrt = BassSqrtNumericUpDown.Value;

            TreblePropertyGrid.SelectedObject = CsCoreMod._DigitaltreblePrint3DSpectrum;
            MedioPropertyGrid.SelectedObject = CsCoreMod._DigitalMedioPrint3DSpectrum;
            BassPropertyGrid.SelectedObject = CsCoreMod._DigitalBassPrint3DSpectrum;
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
            if (splitContainer2.Panel2Collapsed)
                hidePropertiesToolStripMenuItem.CheckState = CheckState.Checked;
            else
                hidePropertiesToolStripMenuItem.CheckState = CheckState.Unchecked;


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

        private void hidePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(hidePropertiesToolStripMenuItem.CheckState == CheckState.Checked)
            {
                splitContainer2.Panel2Collapsed = false;
                splitContainer3.Panel2Collapsed = false;
                splitContainer4.Panel2Collapsed = false;

            }
            else
            {
                splitContainer2.Panel2Collapsed = true;
                splitContainer3.Panel2Collapsed = true;
                splitContainer4.Panel2Collapsed = true;
            }
        }

        private void TrebleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.trebleFactor = TrebleNumericUpDown.Value;
        }

        private void MedioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.medioFactor = MedioNumericUpDown.Value;
        }

        private void BassNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.bassFactor = BassNumericUpDown.Value;
        }

        private void TreblePropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Properties.Settings.Default.TrebleUseAverage = CsCoreMod._DigitaltreblePrint3DSpectrum.UseAverage;
            Properties.Settings.Default.TrebleIsXLogScale = CsCoreMod._DigitaltreblePrint3DSpectrum.IsXLogScale;
            Properties.Settings.Default.TrebleMinFreq = CsCoreMod._DigitaltreblePrint3DSpectrum.MinimumFrequency;
            Properties.Settings.Default.TrebleMaxFreq = CsCoreMod._DigitaltreblePrint3DSpectrum.MaximumFrequency;
            Properties.Settings.Default.TrebleScaling = (int)CsCoreMod._DigitaltreblePrint3DSpectrum.ScalingStrategy;
        }

        private void MedioPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Properties.Settings.Default.MediumUseAverage = CsCoreMod._DigitalMedioPrint3DSpectrum.UseAverage;
            Properties.Settings.Default.MediumIsXLogScale = CsCoreMod._DigitalMedioPrint3DSpectrum.IsXLogScale;
            Properties.Settings.Default.MediumMinFreq = CsCoreMod._DigitalMedioPrint3DSpectrum.MinimumFrequency;
            Properties.Settings.Default.MediumMaxFreq = CsCoreMod._DigitalMedioPrint3DSpectrum.MaximumFrequency;
            Properties.Settings.Default.MediumScaling = (int)CsCoreMod._DigitalMedioPrint3DSpectrum.ScalingStrategy;
        }

        private void BassPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Properties.Settings.Default.BassUseAverage = CsCoreMod._DigitalBassPrint3DSpectrum.UseAverage;
            Properties.Settings.Default.BassIsXLogScale = CsCoreMod._DigitalBassPrint3DSpectrum.IsXLogScale;
            Properties.Settings.Default.BassMinFreq = CsCoreMod._DigitalBassPrint3DSpectrum.MinimumFrequency;
            Properties.Settings.Default.BassMaxFreq = CsCoreMod._DigitalBassPrint3DSpectrum.MaximumFrequency;
            Properties.Settings.Default.BassScaling = (int)CsCoreMod._DigitalBassPrint3DSpectrum.ScalingStrategy;
        }

        private void TrebleSqrtNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.trebleFactorSqrt = TrebleSqrtNumericUpDown.Value;
        }

        private void MedioSqrtNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.MedioFactorSqrt = MedioSqrtNumericUpDown.Value;
        }

        private void BassSqrtNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            VoicePrint3DSpectrum.BassFactorSqrt = BassSqrtNumericUpDown.Value;
        }
    }
}
