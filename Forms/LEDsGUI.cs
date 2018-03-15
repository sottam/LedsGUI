using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace LedsGUI
{
    public partial class LedController : Form
    {

        ComponentResourceManager resources = new ComponentResourceManager(typeof(LedController));

        private FirmataModule firmata;
        private CsCoreModule cscore;

        private Bitmap _bitmap = new Bitmap(360, 60);
        private int _xpos;

        private Bitmap _bitmap_g = new Bitmap(360, 60);
        private int _xpos_g;

        private Bitmap _bitmap_d = new Bitmap(360, 60);
        private int _xpos_d;

        private List<String> AvailableSerialPorts;
        private String SelectedComPort;

        private FixedSizedQueue<Color> AnalogCustomColors = new FixedSizedQueue<Color>(6);
        private Button[] AnalogCustomButtons = new Button[6];

        private FixedSizedQueue<Color> DigitalCustomColors = new FixedSizedQueue<Color>(6);
        private Button[] DigitalCustomButtons = new Button[6];

        private MusicalMode MusicalModeForm = new MusicalMode();
        private IntegratedVisualization visualization = new IntegratedVisualization();
        private DigitalMusicalMode DigitalMusicalModeForm = new DigitalMusicalMode();
        private DigitalCustomPaletteMode DigitalCustomPaletteMode = new DigitalCustomPaletteMode();

        //Save and Restore Methods
        private void LoadConfigs()
        {
            try
            {
                Settings s = Settings.Load();
                if (s == null) return;
                foreach (Control item in AnalogCustomButtons)
                {
                    if (s.AnalogBackColors[item.Name].Equals(Color.Transparent) == false)
                        AnalogCustomColors.Enqueue(s.AnalogBackColors[item.Name]);  
                }

                foreach (Control item in DigitalCustomButtons)
                {
                    if (s.DigitalBackColors[item.Name].Equals(Color.Transparent) == false)
                        DigitalCustomColors.Enqueue(s.DigitalBackColors[item.Name]);
                }

                AnalogCustomPrincipal.BackColor = s.AnalogFixedCustomColor;
                DigitalCustomPrincipal.BackColor = s.DigitalFixedCustomColor;

                SelectedComPort = s.SelectedArduinoPort;

                AnalogComboBox.SelectedIndex = s.AnalogSelectedModeIndex;
                DigitalComboBox.SelectedIndex = s.DigitalSelectedModeIndex;

                UpdateAnalogCustomButtons();
                UpdateDigitalCustomButtons();

                UpdateAnalogButtons(AnalogComboBox.SelectedItem as FirmataMode);
                UpdateDigitalButtons(DigitalComboBox.SelectedItem as FirmataMode);

                for (int i=0; i < s.AnalogModesAvailable.Count; i++)
                {
                    firmata.AnalogModesAvailable[i].Speed = s.AnalogModesAvailable[i].Speed;
                    firmata.AnalogModesAvailable[i].Bright = s.AnalogModesAvailable[i].Bright;
                }

                for (int i = 0; i < s.DigitalModesAvailable.Count; i++)
                {
                    firmata.DigitalModesAvailable[i].Speed = s.DigitalModesAvailable[i].Speed;
                    firmata.DigitalModesAvailable[i].Bright = s.DigitalModesAvailable[i].Bright;
                }
            }
            catch (Exception e )
            {
                Console.WriteLine("Ërro ao carregar configs: " + e.Message);
            } 
        }

        private void SaveConfigs()
        {
            try
            {
                Settings s = new Settings();
                foreach (Control item in AnalogCustomButtons)
                {              
                    s.AnalogBackColors.Add(item.Name, item.BackColor);
                }
                foreach (Control item in DigitalCustomButtons)
                {
                    s.DigitalBackColors.Add(item.Name, item.BackColor);
                }

                s.AnalogModesAvailable = firmata.AnalogModesAvailable;
                s.DigitalModesAvailable = firmata.DigitalModesAvailable;

                s.AnalogFixedCustomColor = AnalogCustomPrincipal.BackColor;
                s.DigitalFixedCustomColor = DigitalCustomPrincipal.BackColor ;

                s.SelectedArduinoPort = SelectedComPort;

                s.AnalogSelectedModeIndex = AnalogComboBox.SelectedIndex;
                s.DigitalSelectedModeIndex = DigitalComboBox.SelectedIndex;

                s.Save();
            }
            catch (Exception e )
            {

                Console.WriteLine("Ërro ao Salvar configs: " + e.Message);
            }
        }

        //form Principal
        public LedController()
        {
            InitializeComponent();
        }

        private void LedController_Load(object sender, EventArgs e)
        {
            AnalogCustomButtons[0] = AnalogLastCustom1;
            AnalogCustomButtons[1] = AnalogLastCustom2;
            AnalogCustomButtons[2] = AnalogLastCustom3;
            AnalogCustomButtons[3] = AnalogLastCustom4;

            AnalogCustomButtons[4] = AnalogLastCustom5;
            AnalogCustomButtons[5] = AnalogLastCustom6;

            DigitalCustomButtons[0] = DigitalLastCustom1;
            DigitalCustomButtons[1] = DigitalLastCustom2;
            DigitalCustomButtons[2] = DigitalLastCustom3;
            DigitalCustomButtons[3] = DigitalLastCustom4;

            DigitalCustomButtons[4] = DigitalLastCustom5;
            DigitalCustomButtons[5] = DigitalLastCustom6;

            cscore = new CsCoreModule();
            cscore.FromDefaultDevice();

            visualization.GenericSoundBarPropertyGrid.SelectedObject = cscore._GenericlineSpectrum;
            visualization.GenericSoundSpectrumPropertyGrid.SelectedObject = cscore._GenericvoicePrint3DSpectrum;

            MusicalModeForm.CsCoreMod = cscore;
            DigitalMusicalModeForm.CsCoreMod = cscore;

            visualization.VisibleChanged += Visualization_VisibleChanged;

            AvailableSerialPorts = new List<string>(SerialPort.GetPortNames());

            firmata = new FirmataModule();
            DigitalCustomPaletteMode.SetFirmata(firmata);

            foreach (FirmataMode mode in firmata.AnalogModesAvailable)
                AnalogComboBox.Items.Add(mode);

            foreach (FirmataMode mode in firmata.DigitalModesAvailable)
                DigitalComboBox.Items.Add(mode);

            AnalogComboBox.SelectedIndex = 0;
            DigitalComboBox.SelectedIndex = 0;

            //only load config after instatiate firmata and add modes
            LoadConfigs();
            
            foreach (String port in AvailableSerialPorts)
            {
                ToolStripMenuItem portOption = new ToolStripMenuItem(port);
                portOption.Click += new System.EventHandler(this.ContextMenuItemPort_Click);
                arduinoToolStripMenuItem.DropDown.Items.Add(portOption);
            }

            if (SelectedComPort != null && AvailableSerialPorts.IndexOf(SelectedComPort) != -1)
            {
                firmata.FirmataSetup(SelectedComPort);
                AnalogComboBox_SelectedIndexChanged(AnalogComboBox, EventArgs.Empty);
                DigitalComboBox_SelectedIndexChanged(DigitalComboBox, EventArgs.Empty);
            }
        }

        private void Visualization_VisibleChanged(object sender, EventArgs e)
        {
            if(visualization.Visible == true)
            {
                cscore.Listen(true);
                VisualizationTimer.Start();
            }
            else
            {
                if (AnalogComboBox.SelectedIndex != 5 && DigitalComboBox.SelectedIndex != 6) cscore.Listen(false);
          
                VisualizationTimer.Stop();
            }
        }

        private void LedController_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string message = "Are you sure to exit?";
            const string caption = "Confirm exit";
            var result = MessageBox.Show(this, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (result == DialogResult.No);
        }

        private void LedController_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveConfigs();

            firmata.Stop();
            cscore.Stop();
        }

        private void LedController_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        //tray icon and Context
        private void ContextMenuItemPort_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SelectedComPort = item.Text;
            firmata.FirmataSetup(SelectedComPort);

            AnalogComboBox_SelectedIndexChanged(AnalogComboBox, EventArgs.Empty);
            DigitalComboBox_SelectedIndexChanged(DigitalComboBox, EventArgs.Empty);
        }

        private void TrayContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (StartupManager.CheckIfOnStartUp())
                StartUpWithWindows.CheckState = CheckState.Checked;
            else
                StartUpWithWindows.CheckState = CheckState.Unchecked; 

            AvailableSerialPorts = new List<string>(SerialPort.GetPortNames());
            arduinoToolStripMenuItem.DropDown.Items.Clear();
            foreach (String port in AvailableSerialPorts)
            {
                ToolStripMenuItem portOption = new ToolStripMenuItem(port);
                portOption.Click += new System.EventHandler(this.ContextMenuItemPort_Click);
                arduinoToolStripMenuItem.DropDown.Items.Add(portOption);
            }
        }

        private void desativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //disable modes of analog and digital
            AnalogComboBox.SelectedIndex = 7;
            DigitalComboBox.SelectedIndex = 7;

            
        }

        private void maximizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            //positions the window above the tray icon
            this.Left = Cursor.Position.X - this.Width/2;
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            
            this.ShowInTaskbar = true;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            //positions the window above the tray icon
            this.Left = Cursor.Position.X - this.Width / 2;
            this.Top = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;

            this.ShowInTaskbar = true;

            this.Activate();
        }

        private void visualizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualization.Show();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveConfigs();

            firmata.Stop();
            cscore.Stop();

            Dispose();
        }

        //cscore inicio
        public void GenerateLineSpectrum()
        {
            Image image = MusicalModeForm.SoundBars.Image;
            var newImage = cscore._lineSpectrum.CreateSpectrumLine(MusicalModeForm.SoundBars.Size, Color.Green, Color.Red, Color.Black, true);
            if (newImage != null)
            {
                MusicalModeForm.SoundBars.Image = newImage;
                if (image != null)
                    image.Dispose();
            }
        }

        private void GenerateVoice3DPrintSpectrum()
        {
            PictureBox BufferImageBox = MusicalModeForm.VoiceSpectrum;

            if(BufferImageBox != null && BufferImageBox.Size.Equals(_bitmap.Size) == false)
            {
                _bitmap = new Bitmap(BufferImageBox.Width, BufferImageBox.Height);
                _xpos = 0;
            }

            using (Graphics g = Graphics.FromImage(_bitmap))
            { 
                MusicalModeForm.VoiceSpectrum.Image = null;
                
                if (cscore._voicePrint3DSpectrum.CreateVoicePrint3D(g, new RectangleF(0, 0, _bitmap.Width, _bitmap.Height), _xpos, Color.Black, Cscore.VoicePrint3DSpectrum.DrawPurpose.ForAnalog,3))
                {
                    _xpos += 1;
                    if (_xpos >= _bitmap.Width)
                        _xpos = 0;
                }
                MusicalModeForm.VoiceSpectrum.Image = _bitmap;
            }
        }
        //generic visualization
        public void generic_GenerateLineSpectrum()
        {
            Image image = visualization.GenericSoundBars.Image;//MusicalModeForm.SoundBars.Image;
            var newImage = cscore._GenericlineSpectrum.CreateSpectrumLine(visualization.GenericSoundBars.Size, 
                                                                          Color.Green, Color.Red, Color.Black, true);
            if (newImage != null)
            {
                visualization.GenericSoundBars.Image = newImage;
                if (image != null)
                    image.Dispose();
            }
        }

        private void generic_GenerateVoice3DPrintSpectrum()
        {
            PictureBox BufferImageBox = visualization.GenericSoundSpectrum;

            if (BufferImageBox != null && BufferImageBox.Size.Equals(_bitmap_g.Size) == false)
            {
                _bitmap_g = new Bitmap(BufferImageBox.Width, BufferImageBox.Height);
                _xpos_g = 0;
            }

            using (Graphics g = Graphics.FromImage(_bitmap_g))
            {
                visualization.GenericSoundSpectrum.Image = null;

                if (cscore._GenericvoicePrint3DSpectrum.CreateVoicePrint3D(g, new RectangleF(0, 0, _bitmap_g.Width, _bitmap_g.Height), _xpos_g, Color.Black, Cscore.VoicePrint3DSpectrum.DrawPurpose.ForGeneric, 3))
                {
                    _xpos_g += 1;
                    if (_xpos_g >= _bitmap_g.Width)
                        _xpos_g = 0;
                }
                visualization.GenericSoundSpectrum.Image = _bitmap_g;
            }
        }

        //digital visualization
        public void digital_GenerateLineSpectrum()
        {
            Image image = DigitalMusicalModeForm.DigitalSoundBars.Image;//MusicalModeForm.SoundBars.Image;
            var newImage = cscore._DigitallineSpectrum.CreateSpectrumLine(DigitalMusicalModeForm.DigitalSoundBars.Size,
                                                                          Color.Green, Color.Red, Color.Black, true);
            if (newImage != null)
            {
                DigitalMusicalModeForm.DigitalSoundBars.Image = newImage;
                if (image != null)
                    image.Dispose();
            }
        }

        private void digital_GenerateVoice3DPrintSpectrum()
        {
            PictureBox BufferImageBox = DigitalMusicalModeForm.DigitalSoundSpectrum;

            if (BufferImageBox != null && BufferImageBox.Size.Equals(_bitmap_d.Size) == false)
            {
                _bitmap_d = new Bitmap(BufferImageBox.Width, BufferImageBox.Height);
                _xpos_d = 0;
            }

            using (Graphics g = Graphics.FromImage(_bitmap_d))
            {
                DigitalMusicalModeForm.DigitalSoundSpectrum.Image = null;

                if (cscore._DigitalvoicePrint3DSpectrum.CreateVoicePrint3D(g, new RectangleF(0, 0, _bitmap_d.Width, _bitmap_d.Height), _xpos_d, Color.Black, Cscore.VoicePrint3DSpectrum.DrawPurpose.ForDigital, 3))
                {
                    _xpos_d += 1;
                    if (_xpos_d >= _bitmap_d.Width)
                        _xpos_d = 0;
                }
                DigitalMusicalModeForm.DigitalSoundSpectrum.Image = _bitmap_d;
            }
        }

        //cscore fim

        private void UpdateAnalogCustomButtons()
        {
            int i = 0;
            foreach (Color c in AnalogCustomColors)
            {
                AnalogCustomButtons[i].BackColor = c;
                i++;
            }
        }

        private void UpdateDigitalCustomButtons()
        {
            int i = 0;
            foreach (Color c in DigitalCustomColors)
            {
                DigitalCustomButtons[i].BackColor = c;
                i++;
            }
        }

        //Timers Tick Event Methods
        private void SoundSpectrum_Tick(object sender, EventArgs e)
        {
            if(AnalogComboBox.SelectedIndex != 5 && DigitalComboBox.SelectedIndex != 6)
            {
                SoundSpectrumTimer.Stop();
                if(visualization.Visible == false) cscore.Listen(false);
                return;
            }
            if (AnalogComboBox.SelectedIndex == 5) //musical mode analog
            {   
                //render
                GenerateLineSpectrum();
                GenerateVoice3DPrintSpectrum();
                //send Result
                firmata.SoundSpectrumTick();
            }

            if (DigitalComboBox.SelectedIndex == 6) //musical mode digital
            {
                //render
                digital_GenerateLineSpectrum();
                digital_GenerateVoice3DPrintSpectrum();
                //send result
                firmata.DigitalSoundSpectrumTick();
            }
        }

        private void VisualizationTimer_Tick(object sender, EventArgs e)
        {
            generic_GenerateLineSpectrum();
            generic_GenerateVoice3DPrintSpectrum();
        }

        //combobox handlers aka change mode handlers
        private void AnalogComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirmataMode AnalogMode = AnalogComboBox.SelectedItem as FirmataMode;
            FirmataMode DigitalMode = DigitalComboBox.SelectedItem as FirmataMode;

            UpdateAnalogButtons(AnalogMode);

            firmata.SendAnalogMode((byte)AnalogMode.ModeNumber);
            firmata.SendAnalogSpeed((byte)AnalogMode.Speed);
            firmata.SendAnalogBright((byte)AnalogMode.Bright);
            firmata.SendAnalogColor(AnalogCustomPrincipal.BackColor);

            if(AnalogMode.Name == "Musical")
            {
                cscore.Listen(true);
                SoundSpectrumTimer.Start();
            }
        }

        private void DigitalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirmataMode AnalogMode = AnalogComboBox.SelectedItem as FirmataMode;
            FirmataMode DigitalMode = DigitalComboBox.SelectedItem as FirmataMode;

            UpdateDigitalButtons(DigitalMode);

            firmata.SendDigitalMode((byte)DigitalMode.ModeNumber);
            firmata.SendDigitalSpeed((byte)DigitalMode.Speed);
            firmata.SendDigitalBright((byte)DigitalMode.Bright);
            firmata.SendDigitalColor(DigitalCustomPrincipal.BackColor);


            if (DigitalMode.Name == "Musical")
            {
                cscore.Listen(true);
                SoundSpectrumTimer.Start();
            }
        }
        //More button Handlers
        private void AnalogMoreButton_Click(object sender, EventArgs e)
        {
            if((AnalogComboBox.SelectedItem as FirmataMode).moreMode == FirmataMode.MoreMode.analogMusical)
            {
                MusicalModeForm.Left = this.Location.X ; 
                MusicalModeForm.Top = this.Location.Y - this.Height / 3; 
                MusicalModeForm.Show();
                MusicalModeForm.Activate();
            }

        }

        private void DigitalMoreButton_Click(object sender, EventArgs e)
        {
            if ((DigitalComboBox.SelectedItem as FirmataMode).moreMode == FirmataMode.MoreMode.digitalMusical)
            {
                DigitalMusicalModeForm.Left = this.Location.X;
                DigitalMusicalModeForm.Top = this.Location.Y - this.Height / 3;
                DigitalMusicalModeForm.Show();
                DigitalMusicalModeForm.Activate();
            }
            else if((DigitalComboBox.SelectedItem as FirmataMode).moreMode == FirmataMode.MoreMode.digitalCustomPattern)
            {
                DigitalCustomPaletteMode.Show();
                DigitalCustomPaletteMode.Activate();
            }
        }
        //Custom Color Handlers
        private void AnalogCustomPrincipal_Click(object sender, EventArgs e)
        {
            if (AnalogCustomPrincipal.BackColor.Equals(Color.Transparent) == false)
            {
                firmata.SendAnalogColor(AnalogCustomPrincipal.BackColor);
            }
        }

        private void AnalogCustomPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                AnalogCustomPrincipal.BackColor = colorDialog1.Color;
                AnalogCustomColors.Enqueue(colorDialog1.Color);
                UpdateAnalogCustomButtons();

                firmata.SendAnalogColor(colorDialog1.Color);
            }
        }

        private void AnalogLastCustomColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor.Equals(Color.Transparent) == false)
            {
                AnalogCustomPrincipal.BackColor = btn.BackColor;
                firmata.SendAnalogColor(btn.BackColor);
            }
        }

        private void DigitalCustomPrincipal_Click(object sender, EventArgs e)
        { 
           
            if (DigitalCustomPrincipal.BackColor.Equals(Color.Transparent) == false)
                firmata.SendDigitalColor(DigitalCustomPrincipal.BackColor);
        }

        private void DigitalCustomPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                DigitalCustomPrincipal.BackColor = colorDialog1.Color;
                DigitalCustomColors.Enqueue(colorDialog1.Color);
                UpdateDigitalCustomButtons();

                firmata.SendDigitalColor(colorDialog1.Color);
            }
        }

        private void DigitalLastCustomColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor.Equals(Color.Transparent) == false)
            {
                DigitalCustomPrincipal.BackColor = btn.BackColor;
                firmata.SendDigitalColor(btn.BackColor);
            }
        }

        private void DigitalSpeedScroll_Scroll(object sender, EventArgs e)
        {
            TrackBar current = sender as TrackBar;
            FirmataMode mode = DigitalComboBox.SelectedItem as FirmataMode;
            mode.Speed = (byte)current.Value;
            firmata.SendDigitalSpeed((byte)current.Value);
        }

        private void DigitalBrightScroll_Scroll(object sender, EventArgs e)
        {
            TrackBar current = sender as TrackBar;
            FirmataMode mode = DigitalComboBox.SelectedItem as FirmataMode;
            mode.Bright = (byte)current.Value;
            firmata.SendDigitalBright((byte)current.Value);
        }

        private void AnalogSpeedScroll_Scroll(object sender, EventArgs e)
        {
            TrackBar current = sender as TrackBar;
            FirmataMode mode = AnalogComboBox.SelectedItem as FirmataMode;
            mode.Speed = (byte)current.Value;
            firmata.SendAnalogSpeed((Byte)current.Value);
        }

        private void AnalogBrightScroll_Scroll(object sender, EventArgs e)
        {
            TrackBar current = sender as TrackBar;
            FirmataMode mode = AnalogComboBox.SelectedItem as FirmataMode;
            mode.Bright = (byte)current.Value;
            firmata.SendAnalogBright((Byte)current.Value);
        }

        private void UpdateAnalogButtons(FirmataMode mode)
        {
            if (mode.moreMode == FirmataMode.MoreMode.none)
                AnalogMoreButton.Enabled = false;
            else
                AnalogMoreButton.Enabled = true;

            if(mode.UseColor)
            {
                AnalogCustomPrincipal.Enabled = true;
                AnalogLastGroupCustomColors.Enabled = true;
            }
            else
            {
                AnalogCustomPrincipal.Enabled = false;
                AnalogLastGroupCustomColors.Enabled = false;
            }

            if (mode.UseSpeed)
                AnalogSpeedScroll.Enabled = true;
            else
                AnalogSpeedScroll.Enabled = false;

            if (mode.UseBright)
                AnalogBrightScroll.Enabled = true;
            else
                AnalogBrightScroll.Enabled = false;

            //update values
            AnalogSpeedScroll.Value = mode.Speed;
            AnalogBrightScroll.Value = mode.Bright;
        }

        private void UpdateDigitalButtons(FirmataMode mode)
        {
            if (mode.moreMode == FirmataMode.MoreMode.none)
                DigitalMoreButton.Enabled = false;
            else
                DigitalMoreButton.Enabled = true;

            if (mode.UseColor)
            {
                DigitalCustomPrincipal.Enabled = true;
                DigitalLastGroupCustomColors.Enabled = true;
            }
            else
            {
                DigitalCustomPrincipal.Enabled = false;
                DigitalLastGroupCustomColors.Enabled = false;
            }

            if (mode.UseSpeed)
                DigitalSpeedScroll.Enabled = true;
            else
                DigitalSpeedScroll.Enabled = false;

            if (mode.UseBright)
                DigitalBrightScroll.Enabled = true;
            else
                DigitalBrightScroll.Enabled = false;

            //update values
            DigitalSpeedScroll.Value = mode.Speed;
            DigitalBrightScroll.Value = mode.Bright;
        }

        private void StartUpWithWindows_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting;
            if(StartUpWorker.IsBusy == false)
                StartUpWorker.RunWorkerAsync();
        }

        private void SetStartUpWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void StartUpWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //if it is checked before click, 
            //it will return unchecked
            //when handling this event
            if (!StartUpWithWindows.Checked)
                StartupManager.RemoveApplicationFromStartup();
            else
                StartupManager.AddApplicationToStartup();
        }
    }
}
