using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using CSCore.DSP;
using WinformsVisualization.Visualization;

namespace LedsGUI
{
    public partial class LedController : Form
    {

        ComponentResourceManager resources = new ComponentResourceManager(typeof(LedController));
        ComponentResourceManager myres = new ComponentResourceManager(typeof(Resource));

        private FirmataModule firmata;
        private CsCoreModule cscore;

        

        private int _xpos;

        private string[] Ports = SerialPort.GetPortNames();
        private String SelectedComPort;

        private readonly Bitmap _bitmap = new Bitmap(350, 92);

        private Timer[] timers = new Timer[7];
        private Timer ActivatedTimer;

        private FixedSizedQueue<Color> CustomColors = new FixedSizedQueue<Color>(16);
        private Button[] CustomButtons = new Button[16];

        //Fade Mode
        private int RealHSVangle = 0, PowerHSVAngle = 0, SineWaveAngle = 0;

        //breath Mode
        private float BreathPercent = 1.0f, unidade = 0.01f;

        //Save and Restore Methods
        private void LoadConfigs()
        {
            try
            {
                Settings s = Settings.Load();
                if (s == null) return;
                foreach (Control item in CustomButtons)
                {
                    if (s.BackColors[item.Name].Equals(Color.Transparent) == false)
                        CustomColors.Enqueue(s.BackColors[item.Name]);  
                }
                CustomPrincipal.BackColor = s.FixedCustomColor;
                SelectedComPort = s.SelectedArduinoPort;
                //speeds
                TrueHSVtrackBar.Value = s.True_HSV_Speed;
                PowerHSVtrackbar.Value = s.Power_HSV_Speed;
                SineWave_trackBar.Value = s.Sine_Speed;

                FlashSpeedScroll.Value = s.Flash_Speed;
                SmoothSpeedScroll.Value = s.Smooth_Speed;

                BreathScroll.Value = s.Breath_Speed;
                //checks
                TrueHSV.Checked = s.True_HSV_Checked;
                PowerHSV.Checked = s.Power_HSV_Checked;
                SineWave.Checked = s.Sine_Checked;

                Flash_RB.Checked = s.Flash_Checked;
                Smooth_RB.Checked = s.Smooth_Checked;

                Breath.Checked = s.Breath;
                //tabcontrol
                tabControl1.SelectTab(s.SelectedTabIndex);

                //load Tick intervals
                FadeTrueHSVTimer.Interval = TrueHSVtrackBar.Value;
                FadePowerHSVTimer.Interval = PowerHSVtrackbar.Value;
                SineWaveTimer.Interval = SineWave_trackBar.Value;
                FlashTimer.Interval = FlashSpeedScroll.Value * 10;
                SmoothTimer.Interval = SmoothSpeedScroll.Value * 10;
                BreathTimer.Interval = BreathScroll.Value;

                //TraycontextMenu
                StartUpWithWindows.Checked = s.StartWithWindows;

                UpdateCustomButtons();
                UpdateTabControlSelected();
            }
            catch (Exception)
            {
                Console.WriteLine("Ërro ao carregar configs");
            } 
        }

        private void SaveConfigs()
        {
            try
            {
                Settings s = new Settings();
                foreach (Control item in CustomButtons)
                {
                    //s.ForeColors.Add(item.Name, item.ForeColor);
                    
                    s.BackColors.Add(item.Name, item.BackColor);
                }

                s.FixedCustomColor = CustomPrincipal.BackColor;
                s.SelectedArduinoPort = SelectedComPort;

                //speeds
                s.True_HSV_Speed = TrueHSVtrackBar.Value;
                s.Power_HSV_Speed = PowerHSVtrackbar.Value;
                s.Sine_Speed = SineWave_trackBar.Value;

                s.Flash_Speed = FlashSpeedScroll.Value;
                s.Smooth_Speed = SmoothSpeedScroll.Value;

                s.Breath_Speed = BreathScroll.Value;
                //checks
                s.True_HSV_Checked = TrueHSV.Checked;
                s.Power_HSV_Checked = PowerHSV.Checked;
                s.Sine_Checked = SineWave.Checked;

                s.Flash_Checked = Flash_RB.Checked;
                s.Smooth_Checked = Smooth_RB.Checked;

                s.Breath = Breath.Checked;
                //tabcontrol
                s.SelectedTabIndex = tabControl1.SelectedIndex;

                //TraycontextMenu
                s.StartWithWindows = StartUpWithWindows.Checked;

                s.Save();
            }
            catch (Exception)
            {

                Console.WriteLine("Ërro ao Salvar configs");
            }
        }

        //form Principal
        public LedController()
        {
            InitializeComponent();
        }

        private void LedController_Load(object sender, EventArgs e)
        {
            timers[0] = FadeTrueHSVTimer;
            timers[1] = FadePowerHSVTimer;
            timers[2] = SineWaveTimer;
            timers[3] = SoundSpectrumTimer;
            timers[4] = FlashTimer;
            timers[5] = SmoothTimer;
            timers[6] = BreathTimer;

            CustomButtons[0] = Custom1;
            CustomButtons[1] = Custom2;
            CustomButtons[2] = Custom3;
            CustomButtons[3] = Custom4;

            CustomButtons[4] = Custom5;
            CustomButtons[5] = Custom6;
            CustomButtons[6] = Custom7;
            CustomButtons[7] = Custom8;

            CustomButtons[8] = Custom9;
            CustomButtons[9] = Custom10;
            CustomButtons[10] = Custom11;
            CustomButtons[11] = Custom12;

            CustomButtons[12] = Custom13;
            CustomButtons[13] = Custom14;
            CustomButtons[14] = Custom15;
            CustomButtons[15] = Custom16;

            cscore = new CsCoreModule();
            cscore.FromDefaultDevice();

            LoadConfigs(); 

            firmata = new FirmataModule();
            if(SelectedComPort != null)
                firmata.FirmataSetup(SelectedComPort);

            foreach (String port in Ports)
            {
                ToolStripMenuItem portOption = new ToolStripMenuItem(port);
                portOption.Click += new System.EventHandler(this.ContextMenuItemPort_Click);
                arduinoToolStripMenuItem.DropDown.Items.Add(portOption);
            }

            this.WindowState = FormWindowState.Minimized;
        }

        private void LedController_FormClosed(object sender, FormClosedEventArgs e)
        {
            firmata.Stop();
            cscore.Stop();
        }

        private void LedController_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfigs();

            TrayIcon.Visible = false;
            TrayIcon.Dispose();
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
        }

        private void desativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlTimers(null);
            firmata.Desactivated();
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
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveConfigs();

            TrayIcon.Visible = false;
            TrayIcon.Dispose();

            firmata.Stop();
            cscore.Stop();

            Application.Exit();
        }

        private void StartUpWithWindows_CheckStateChanged(object sender, EventArgs e)
        {
            if (!StartupManager.IsUserAdministrator())
                return;

            if (StartUpWithWindows.Checked == true)
                StartupManager.AddApplicationToCurrentUserStartup();
            else if (StartUpWithWindows.Checked == false)
                StartupManager.RemoveApplicationFromCurrentUserStartup();
        }

        //TabControl
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            switch (current.Text)
            {
                case "Fade":
                    if (TrueHSV.Checked)
                        TrueHSV_CheckedChanged(TrueHSV, EventArgs.Empty);
                    else if (PowerHSV.Checked)
                        PowerHSV_CheckedChanged(PowerHSV, EventArgs.Empty);
                    else if (SineWave.Checked)
                        SineWave_CheckedChanged(SineWave, EventArgs.Empty);
                    break;
                case "Random":
                    if (Flash_RB.Checked)
                        Flash_RB_CheckedChanged(Flash_RB, EventArgs.Empty);
                    else if (Smooth_RB.Checked)
                        Smooth_RB_CheckedChanged(Smooth_RB, EventArgs.Empty);
                    break;
                case "Fixed Colors":
                    CustomPrincipal_Click(CustomPrincipal, EventArgs.Empty);
                    break;
                case "Rhythmic Led":
                    ControlTimers(SoundSpectrumTimer);
                    cscore.Listen(true);
                    break;
            }
        }

        private void UpdateTabControlSelected()
        {
            TabPage current = tabControl1.SelectedTab;

            switch (current.Text)
            {
                case "Fade":
                    if (TrueHSV.Checked)
                        TrueHSV_CheckedChanged(TrueHSV, EventArgs.Empty);
                    else if (PowerHSV.Checked)
                        PowerHSV_CheckedChanged(PowerHSV, EventArgs.Empty);
                    else if (SineWave.Checked)
                        SineWave_CheckedChanged(SineWave, EventArgs.Empty);
                    break;
                case "Random":
                    if (Flash_RB.Checked)
                        Flash_RB_CheckedChanged(Flash_RB, EventArgs.Empty);
                    else if (Smooth_RB.Checked)
                        Smooth_RB_CheckedChanged(Smooth_RB, EventArgs.Empty);
                    break;
                case "Fixed Colors":
                    CustomPrincipal_Click(CustomPrincipal, EventArgs.Empty);
                    break;
                case "Rhythmic Led":
                    ControlTimers(SoundSpectrumTimer);
                    cscore.Listen(true);
                    break;
            }
        }

        //cscore inicio
        public void GenerateLineSpectrum()
        {
            Image image = SoundBars.Image;
            var newImage = cscore._lineSpectrum.CreateSpectrumLine(SoundBars.Size, Color.Green, Color.Red, Color.Black, true);
            if (newImage != null)
            {
                SoundBars.Image = newImage;
                if (image != null)
                    image.Dispose();
            }
        }

        private void GenerateVoice3DPrintSpectrum()
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {

                VoiceSpectrum.Image = null;
                
                if (cscore._voicePrint3DSpectrum.CreateVoicePrint3D(g, new RectangleF(0, 0, _bitmap.Width, _bitmap.Height),
                    _xpos, Color.Black, 3))
                {
                    _xpos += 1;
                    if (_xpos >= _bitmap.Width)
                        _xpos = 0;
                }
                VoiceSpectrum.Image = _bitmap;
                
            }
        }

        //cscore fim

        void ControlTimers(Timer timer)
        {
            
            if (timer == null)
            {
                foreach (Timer t in timers)
                {
                    t.Stop();
                }
                TrayIcon.Icon = ((System.Drawing.Icon)(myres.GetObject("Disabled")));
            }
            else
            {
                foreach (Timer t in timers)
                {
                    if (t.Equals(timer))
                    {
                        t.Start();
                        ActivatedTimer = t;
                    }
                    else
                        t.Stop();
                }
                TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            }
            if(ActivatedTimer != null)
            {
                if (ActivatedTimer.Equals(SoundSpectrumTimer) == false)
                    cscore.Listen(false);
            }
        }

        //fixed Color Handlers
        private void CustomPrincipal_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CustomPrincipal.BackColor = btn.BackColor;
            if (btn.BackColor.Equals(Color.Transparent) == false)
            {
                ControlTimers(null);
                if (Breath.Checked == true)
                    ControlTimers(BreathTimer);
                else
                    firmata.StaticSingleColor(btn.BackColor.R, btn.BackColor.G, btn.BackColor.B);
            }
        }

        private void CustomPrincipal_DoubleClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CustomPrincipal.BackColor = colorDialog1.Color;
                CustomColors.Enqueue(colorDialog1.Color);
                UpdateCustomButtons();

                ControlTimers(null);
                if (Breath.Checked == true)
                    ControlTimers(BreathTimer);
                else
                    firmata.StaticSingleColor(colorDialog1.Color);

            }
        }

        private void UpdateCustomButtons()
        {
            int i = 0;
            foreach (Color c in CustomColors)
            {
                CustomButtons[i].BackColor = c;
                i++;
            }
        }

        private void LastCustomColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor.Equals(Color.Transparent) == false)
            {
                CustomPrincipal.BackColor = btn.BackColor;
                ControlTimers(null);
                if (Breath.Checked == true)
                    ControlTimers(BreathTimer);
                else
                    firmata.StaticSingleColor(CustomPrincipal.BackColor);
            }

        }

        //Check Box event Handlers
        private void TrueHSV_CheckedChanged(object sender, EventArgs e)
        {
            TrueHSVtrackBar.Visible = true;
            PowerHSVtrackbar.Visible = false;
            SineWave_trackBar.Visible = false;

            ControlTimers(FadeTrueHSVTimer);
        }

        private void PowerHSV_CheckedChanged(object sender, EventArgs e)
        {
            TrueHSVtrackBar.Visible = false;
            PowerHSVtrackbar.Visible = true;
            SineWave_trackBar.Visible = false;

            ControlTimers(FadePowerHSVTimer);
        }

        private void SineWave_CheckedChanged(object sender, EventArgs e)
        {
            TrueHSVtrackBar.Visible = false;
            PowerHSVtrackbar.Visible = false;
            SineWave_trackBar.Visible = true;

            ControlTimers(SineWaveTimer);
        }

        private void Flash_RB_CheckedChanged(object sender, EventArgs e)
        {
            SmoothSpeedScroll.Visible = false;
            FlashSpeedScroll.Visible = true;

            ControlTimers(FlashTimer);
        }

        private void Smooth_RB_CheckedChanged(object sender, EventArgs e)
        {
            SmoothSpeedScroll.Visible = true;
            FlashSpeedScroll.Visible = false;

            ControlTimers(SmoothTimer);
        }

        private void Breath_CheckedChanged(object sender, EventArgs e)
        {
            if (Breath.Checked == true)
                ControlTimers(BreathTimer);
            else
            {
                ControlTimers(null);
                firmata.StaticSingleColor(CustomPrincipal.BackColor);
            }

        }

        private void TrueHSV_Click(object sender, EventArgs e)
        {
            TrueHSV_CheckedChanged(sender, e);
        }

        private void PowerHSV_Click(object sender, EventArgs e)
        {
            PowerHSV_CheckedChanged(sender, e);
        }

        private void SineWave_Click(object sender, EventArgs e)
        {
            SineWave_CheckedChanged(sender, e);
        }

        private void Flash_RB_Click(object sender, EventArgs e)
        {
            Flash_RB_CheckedChanged(sender, e);
        }

        private void Smooth_RB_Click(object sender, EventArgs e)
        {
            Smooth_RB_CheckedChanged(sender, e);
        }

        //trackBar controls
        private void TrueHSV_Speed_Scroll(object sender, EventArgs e)
        {
            FadeTrueHSVTimer.Interval = TrueHSVtrackBar.Value;
        }

        private void PowerHSV_Speed_scroll(object sender, EventArgs e)
        {
            FadePowerHSVTimer.Interval = PowerHSVtrackbar.Value;
        }

        private void SineWave_Speed_scroll(object sender, EventArgs e)
        {
            SineWaveTimer.Interval = SineWave_trackBar.Value;
        }

        private void FlashSpeedScroll_Scroll(object sender, EventArgs e)
        {
            FlashTimer.Interval = FlashSpeedScroll.Value * 10;
        }

        private void SmoothSpeedScroll_Scroll(object sender, EventArgs e)
        {
            SmoothTimer.Interval = SmoothSpeedScroll.Value * 10;
        }

        private void BreathScroll_Scroll(object sender, EventArgs e)
        {
            BreathTimer.Interval = BreathScroll.Value;
        }

        //Timers Tick Event Methods
        private void SoundSpectrum_Tick(object sender, EventArgs e)
        {
            //render the spectrum
            GenerateLineSpectrum();
            GenerateVoice3DPrintSpectrum();

            firmata.SoundSpectrumTick();
        }

        private void FadeTrueHSVTimer_Tick(object sender, EventArgs e)
        {
            firmata.RealHSVTick(RealHSVangle);
            RealHSVangle = (RealHSVangle + 1) % 360;
        }

        private void FadePowerHSVTimer_Tick(object sender, EventArgs e)
        {
            firmata.PowerHSVTick(PowerHSVAngle);
            PowerHSVAngle = (PowerHSVAngle + 1) % 360;
        }

        private void SineWaveTimer_Tick(object sender, EventArgs e)
        {
            firmata.SineWaveTick(SineWaveAngle);
            SineWaveAngle = (SineWaveAngle + 1) % 360;
        }

        private void BreathTimer_Tick(object sender, EventArgs e)
        {

            if (BreathPercent > 0.95f)
                unidade = -0.01f;
            else if (BreathPercent < 0.05f)
                unidade = 0.01f;

            BreathPercent += unidade;
            firmata.BreathTick(CustomPrincipal.BackColor, BreathPercent);
        }

        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            firmata.FlashTimerTick();
        }

        private void SmoothTimer_Tick(object sender, EventArgs e)
        {
            firmata.SmoothRandomTick();
        }
        
    }
}
