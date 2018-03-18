using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedsGUI
{
    public partial class DigitalCustomPaletteMode : Form
    {
        XMLCustomPalettes xmlHandler;

        private FirmataModule _firmata { get; set; }
        private CustomPalette _LastActivePalette { get; set; }

        private Button[] ColorsButtons = new Button[16];
        private TextBox[] RedTextBoxes = new TextBox[16];
        private TextBox[] GreenTextBoxes = new TextBox[16];
        private TextBox[] BlueTextBoxes = new TextBox[16];

        private bool hasChanged = false;

        #region Form Frame Stuff

        public DigitalCustomPaletteMode()
        {
            InitializeComponent();
        }

        public void SetFirmata(FirmataModule firmata)
        {
            this._firmata = firmata;
        }

        public void SetLastActivatePalette(CustomPalette customPalette)
        {
            if (customPalette == null) return;
            this._LastActivePalette = customPalette;
        }

        private void DigitalCustomPaletteMode_Load(object sender, EventArgs e)
        {
            Palette16radioButton.Checked = true;

            xmlHandler = new XMLCustomPalettes();

            comboBoxSavedPalettes.Items.AddRange(xmlHandler.LoadSavedPalettes().ToArray());
            if (comboBoxSavedPalettes.Items.Count > 0) comboBoxSavedPalettes.SelectedIndex = 0;

            ColorsButtons = new Button[16] {    ColorButton0,  ColorButton1,
                                                ColorButton2,  ColorButton3,
                                                ColorButton4,  ColorButton5,
                                                ColorButton6,  ColorButton7,
                                                ColorButton8,  ColorButton9,
                                                ColorButton10, ColorButton11,
                                                ColorButton12, ColorButton13,
                                                ColorButton14, ColorButton15};

            RedTextBoxes = new TextBox[16] {    TextBoxRedColor0,  TextBoxRedColor1,
                                                TextBoxRedColor2,  TextBoxRedColor3,
                                                TextBoxRedColor4,  TextBoxRedColor5,
                                                TextBoxRedColor6,  TextBoxRedColor7,
                                                TextBoxRedColor8,  TextBoxRedColor9,
                                                TextBoxRedColor10, TextBoxRedColor11,
                                                TextBoxRedColor12, TextBoxRedColor13,
                                                TextBoxRedColor14, TextBoxRedColor15};

            GreenTextBoxes = new TextBox[16] {  TextBoxGreenColor0,  TextBoxGreenColor1,
                                                TextBoxGreenColor2,  TextBoxGreenColor3,
                                                TextBoxGreenColor4,  TextBoxGreenColor5,
                                                TextBoxGreenColor6,  TextBoxGreenColor7,
                                                TextBoxGreenColor8,  TextBoxGreenColor9,
                                                TextBoxGreenColor10, TextBoxGreenColor11,
                                                TextBoxGreenColor12, TextBoxGreenColor13,
                                                TextBoxGreenColor14, TextBoxGreenColor15};

            BlueTextBoxes = new TextBox[16] {   TextBoxBlueColor0,  TextBoxBlueColor1,
                                                TextBoxBlueColor2,  TextBoxBlueColor3,
                                                TextBoxBlueColor4,  TextBoxBlueColor5,
                                                TextBoxBlueColor6,  TextBoxBlueColor7,
                                                TextBoxBlueColor8,  TextBoxBlueColor9,
                                                TextBoxBlueColor10, TextBoxBlueColor11,
                                                TextBoxBlueColor12, TextBoxBlueColor13,
                                                TextBoxBlueColor14, TextBoxBlueColor15};
            //define tag to sync color buttons with text boxes and everything else
            for (int i = 0; i < 16; i++)
            {
                ColorsButtons[i].Tag = i;

                RedTextBoxes[i].Tag = i;
                RedTextBoxes[i].MaxLength = 3;
                //RedTextBoxes[i].TextChanged     += TextBoxColor_TextChanged;

                GreenTextBoxes[i].Tag = i;
                GreenTextBoxes[i].MaxLength = 3;
                //GreenTextBoxes[i].TextChanged   += TextBoxColor_TextChanged;

                BlueTextBoxes[i].Tag = i;
                BlueTextBoxes[i].MaxLength = 3;
                //BlueTextBoxes[i].TextChanged    += TextBoxColor_TextChanged;
            }


            UpdatePalettePreview();
        }

        private void DigitalCustomPaletteMode_Resize(object sender, EventArgs e)
        {
            UpdatePalettePreview();
        }

        private void DigitalCustomPaletteMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        #endregion

        #region Color buttons

        private void Color_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                if (control.Size.Height > control.Size.Width)
                    control.Size = new Size(control.Size.Width, control.Size.Width);
                else if (control.Size.Height < control.Size.Width)
                    control.Size = new Size(control.Size.Height, control.Size.Height);

            }
        }

        private void Color_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = colorDialog1.Color;
                hasChanged = true;
            }
        }

        private void ColorButton_BackColorChanged(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            int btnNum = (int)btn.Tag;
            RedTextBoxes[btnNum].Text = btn.BackColor.R.ToString();
            GreenTextBoxes[btnNum].Text = btn.BackColor.G.ToString();
            BlueTextBoxes[btnNum].Text = btn.BackColor.B.ToString();

            UpdatePalettePreview();
        }

        private void UpdatePalettePreview()
        {
            PalettePreviewerPictureBox.Image = new Bitmap(PalettePreviewerPictureBox.Width, PalettePreviewerPictureBox.Height);

            if (BlendCheckBox.Checked)
            {
                Image NewGradient = PalettePreviewerPictureBox.Image;
                Graphics graphics = Graphics.FromImage(NewGradient);

                LinearGradientBrush br = new LinearGradientBrush(new Rectangle(0, 0, NewGradient.Width, NewGradient.Height), Color.Black, Color.Black, 0, false);
                ColorBlend cb = new ColorBlend();
                cb.Positions = new[] {         0,     1 / 15f,    2 / 15f,    3 / 15f,
                                         4 / 15f,     5 / 15f,    6 / 15f,    7 / 15f,
                                         8 / 15f,     9 / 15f,   10 / 15f,   11 / 15f,
                                        12 / 15f,    13 / 15f,   14 / 15f,           1 };
                //cb.Colors = new[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
                cb.Colors = new Color[16];
                for (int i = 0; i < 16; i++)
                    cb.Colors[i] = ColorsButtons[i].BackColor;

                br.InterpolationColors = cb;
                // paint
                graphics.FillRectangle(br, new Rectangle(0, 0, NewGradient.Width, NewGradient.Height));
            }
            else
            {
                Image NewSimplePreview = PalettePreviewerPictureBox.Image;
                Graphics graphics = Graphics.FromImage(NewSimplePreview);

                Brush brush = new SolidBrush(Color.Black);

                for (int i = 0; i < 16; i++)
                {
                    brush = new SolidBrush(ColorsButtons[i].BackColor);
                    graphics.FillRectangle(brush, new RectangleF(i * (NewSimplePreview.Width / 16), 0, NewSimplePreview.Width / 16, NewSimplePreview.Height));
                }

                brush.Dispose();
            }
        }

        #endregion

        #region Buttons Save Load Delete Send

        private void SendToArduinoButton_Click(object sender, EventArgs e)
        {
            Color[] BackColors = new Color[16];
            for (int i = 0; i < 16; i++)
            {
                BackColors[i] = ColorsButtons[i].BackColor;
            }

            CustomPalette PaletteToSend = new CustomPalette("SentPalette", BackColors,
                                                            AnimateCheckBox.Checked, BlendCheckBox.Checked,
                                                            (byte)numericUpDown.Value, GetPaletteSize());
            _LastActivePalette = PaletteToSend;
            _firmata.SendDigitalCustomPalette(PaletteToSend);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = comboBoxSavedPalettes.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter a valid name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Color[] BackColors = new Color[16];
            for (int i = 0; i < 16; i++)
            {
                BackColors[i] = ColorsButtons[i].BackColor;
            }

            CustomPalette PaletteToSave = new CustomPalette(name, BackColors,
                                                            AnimateCheckBox.Checked, BlendCheckBox.Checked,
                                                            (byte)numericUpDown.Value, GetPaletteSize());

            foreach (CustomPalette cp in comboBoxSavedPalettes.Items)
            {
                if (cp.Equals(PaletteToSave))
                {
                    var result = MessageBox.Show("There is already a custom palette named " 
                                                + comboBoxSavedPalettes.SelectedItem.ToString() 
                                                + ". Are you sure to overwrite?", 
                                                 "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No) return;
                    else
                    {
                        xmlHandler.ModifySavedPalette(PaletteToSave);
                        MessageBox.Show("Save success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hasChanged = false;
                        return;
                    }
                }

            }

            xmlHandler.AddPalette(PaletteToSave);
            UpdateSavedCombobox();

            MessageBox.Show("Save success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            hasChanged = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            if (String.IsNullOrEmpty(comboBoxSavedPalettes.Text)) return;
            xmlHandler.RemovePalette(comboBoxSavedPalettes.Text);
            comboBoxSavedPalettes.Text = "";
            UpdateSavedCombobox();

            hasChanged = false;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (hasChanged)
            {
                var result = MessageBox.Show("Are you sure?", "Confirm Load", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            CustomPalette customPalette = comboBoxSavedPalettes.SelectedItem as CustomPalette;
            if (customPalette == null) return;
            BlendCheckBox.Checked = customPalette.Blend;
            AnimateCheckBox.Checked = customPalette.Animate;
            numericUpDown.Value = customPalette.increment;
            SelectSize(customPalette.paletteSize);
            for (int i = 0; i < 16; i++)
            {
                ColorsButtons[i].BackColor = customPalette.PatternColors[i];
            }

            hasChanged = false;

            UpdatePalettePreview();
        }

        #endregion

        #region Palette Size, Blend, animate

        private void SelectSize(CustomPalette.PaletteSize paletteSize)
        {
            switch (paletteSize)
            {
                case CustomPalette.PaletteSize.P16:
                    Palette16radioButton.Checked = true;
                    break;
                case CustomPalette.PaletteSize.P32:
                    Palette32radioButton.Checked = true;
                    break;
                case CustomPalette.PaletteSize.P256:
                    Palette256radioButton.Checked = true;
                    break;
                default:
                    Palette16radioButton.Checked = true;
                    break;
            }
        }

        private CustomPalette.PaletteSize GetPaletteSize()
        {
            if (Palette16radioButton.Checked)
                return CustomPalette.PaletteSize.P16;
            else if (Palette32radioButton.Checked)
                return CustomPalette.PaletteSize.P32;
            else if (Palette256radioButton.Checked)
                return CustomPalette.PaletteSize.P256;
            else
                return CustomPalette.PaletteSize.P16;
        }

        private void BlendCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            hasChanged = true;
            UpdatePalettePreview();
        }

        private void AnimateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            hasChanged = true;
        }


        #endregion

        #region ComboBox Saved Palettes

        private void UpdateSavedCombobox()
        {
            comboBoxSavedPalettes.Items.Clear();
            comboBoxSavedPalettes.Items.AddRange(xmlHandler.LoadSavedPalettes().ToArray());
        }

        #endregion

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            hasChanged = true;
        }

        private void BlendCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (BlendCheckBox.CheckState == CheckState.Checked)
                Palette256radioButton.Enabled = true;
            else
                Palette256radioButton.Enabled = false;
        }

        private void Palette256radioButton_EnabledChanged(object sender, EventArgs e)
        {
            if (Palette256radioButton.Enabled == false && 
                Palette256radioButton.Checked == true)
                Palette32radioButton.Checked = true;
        }
    }

}
