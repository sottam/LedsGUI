namespace LedsGUI
{
    partial class LedController
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LedController));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.arduinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.StartUpWithWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desativarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SoundSpectrumTimer = new System.Windows.Forms.Timer(this.components);
            this.FadeTrueHSVTimer = new System.Windows.Forms.Timer(this.components);
            this.FadePowerHSVTimer = new System.Windows.Forms.Timer(this.components);
            this.SineWaveTimer = new System.Windows.Forms.Timer(this.components);
            this.FlashTimer = new System.Windows.Forms.Timer(this.components);
            this.SmoothTimer = new System.Windows.Forms.Timer(this.components);
            this.rhythmicLed = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SoundBars = new System.Windows.Forms.PictureBox();
            this.VoiceSpectrum = new System.Windows.Forms.PictureBox();
            this.FixedColors = new System.Windows.Forms.TabPage();
            this.Breath = new System.Windows.Forms.CheckBox();
            this.BreathScroll = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.DefinedColorsGroup = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Custom6 = new System.Windows.Forms.Button();
            this.Custom4 = new System.Windows.Forms.Button();
            this.Custom1 = new System.Windows.Forms.Button();
            this.Custom3 = new System.Windows.Forms.Button();
            this.Custom2 = new System.Windows.Forms.Button();
            this.Custom9 = new System.Windows.Forms.Button();
            this.Custom10 = new System.Windows.Forms.Button();
            this.Custom11 = new System.Windows.Forms.Button();
            this.Custom12 = new System.Windows.Forms.Button();
            this.Custom14 = new System.Windows.Forms.Button();
            this.Custom8 = new System.Windows.Forms.Button();
            this.Custom16 = new System.Windows.Forms.Button();
            this.Custom5 = new System.Windows.Forms.Button();
            this.Custom7 = new System.Windows.Forms.Button();
            this.Custom13 = new System.Windows.Forms.Button();
            this.Custom15 = new System.Windows.Forms.Button();
            this.Random = new System.Windows.Forms.TabPage();
            this.SmoothSpeedScroll = new System.Windows.Forms.TrackBar();
            this.Function = new System.Windows.Forms.GroupBox();
            this.Smooth_RB = new System.Windows.Forms.RadioButton();
            this.Flash_RB = new System.Windows.Forms.RadioButton();
            this.FlashSpeedScroll = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.Fade = new System.Windows.Forms.TabPage();
            this.SineWave_trackBar = new System.Windows.Forms.TrackBar();
            this.PowerHSVtrackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TrueHSV = new System.Windows.Forms.RadioButton();
            this.SineWave = new System.Windows.Forms.RadioButton();
            this.PowerHSV = new System.Windows.Forms.RadioButton();
            this.TrueHSVtrackBar = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.BreathTimer = new System.Windows.Forms.Timer(this.components);
            this.CustomPrincipal = new LedsGUI.DoubleClickButton();
            this.TrayContextMenu.SuspendLayout();
            this.rhythmicLed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundBars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceSpectrum)).BeginInit();
            this.FixedColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BreathScroll)).BeginInit();
            this.DefinedColorsGroup.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Random.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothSpeedScroll)).BeginInit();
            this.Function.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlashSpeedScroll)).BeginInit();
            this.Fade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SineWave_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerHSVtrackbar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrueHSVtrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.ContextMenuStrip = this.TrayContextMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Led Controller";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            // 
            // TrayContextMenu
            // 
            this.TrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arduinoToolStripMenuItem,
            this.toolStripSeparator1,
            this.StartUpWithWindows,
            this.maximizarToolStripMenuItem,
            this.desativarToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.TrayContextMenu.Name = "contextMenuStrip1";
            this.TrayContextMenu.Size = new System.Drawing.Size(186, 120);
            // 
            // arduinoToolStripMenuItem
            // 
            this.arduinoToolStripMenuItem.Name = "arduinoToolStripMenuItem";
            this.arduinoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.arduinoToolStripMenuItem.Text = "Arduino";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // StartUpWithWindows
            // 
            this.StartUpWithWindows.CheckOnClick = true;
            this.StartUpWithWindows.Name = "StartUpWithWindows";
            this.StartUpWithWindows.Size = new System.Drawing.Size(185, 22);
            this.StartUpWithWindows.Text = "Iniciar com Windows";
            this.StartUpWithWindows.CheckStateChanged += new System.EventHandler(this.StartUpWithWindows_CheckStateChanged);
            // 
            // maximizarToolStripMenuItem
            // 
            this.maximizarToolStripMenuItem.Name = "maximizarToolStripMenuItem";
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.maximizarToolStripMenuItem.Text = "Mostrar";
            this.maximizarToolStripMenuItem.Click += new System.EventHandler(this.maximizarToolStripMenuItem_Click);
            // 
            // desativarToolStripMenuItem
            // 
            this.desativarToolStripMenuItem.Name = "desativarToolStripMenuItem";
            this.desativarToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.desativarToolStripMenuItem.Text = "Desativar";
            this.desativarToolStripMenuItem.Click += new System.EventHandler(this.desativarToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // SoundSpectrumTimer
            // 
            this.SoundSpectrumTimer.Interval = 5;
            this.SoundSpectrumTimer.Tick += new System.EventHandler(this.SoundSpectrum_Tick);
            // 
            // FadeTrueHSVTimer
            // 
            this.FadeTrueHSVTimer.Interval = 1;
            this.FadeTrueHSVTimer.Tick += new System.EventHandler(this.FadeTrueHSVTimer_Tick);
            // 
            // FadePowerHSVTimer
            // 
            this.FadePowerHSVTimer.Interval = 1;
            this.FadePowerHSVTimer.Tick += new System.EventHandler(this.FadePowerHSVTimer_Tick);
            // 
            // SineWaveTimer
            // 
            this.SineWaveTimer.Interval = 1;
            this.SineWaveTimer.Tick += new System.EventHandler(this.SineWaveTimer_Tick);
            // 
            // FlashTimer
            // 
            this.FlashTimer.Interval = 1;
            this.FlashTimer.Tick += new System.EventHandler(this.FlashTimer_Tick);
            // 
            // SmoothTimer
            // 
            this.SmoothTimer.Interval = 1;
            this.SmoothTimer.Tick += new System.EventHandler(this.SmoothTimer_Tick);
            // 
            // rhythmicLed
            // 
            this.rhythmicLed.Controls.Add(this.splitContainer1);
            this.rhythmicLed.Location = new System.Drawing.Point(4, 22);
            this.rhythmicLed.Name = "rhythmicLed";
            this.rhythmicLed.Padding = new System.Windows.Forms.Padding(3);
            this.rhythmicLed.Size = new System.Drawing.Size(356, 197);
            this.rhythmicLed.TabIndex = 4;
            this.rhythmicLed.Text = "Rhythmic Led";
            this.rhythmicLed.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SoundBars);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VoiceSpectrum);
            this.splitContainer1.Size = new System.Drawing.Size(350, 191);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 1;
            // 
            // SoundBars
            // 
            this.SoundBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoundBars.Location = new System.Drawing.Point(0, 0);
            this.SoundBars.Name = "SoundBars";
            this.SoundBars.Size = new System.Drawing.Size(350, 151);
            this.SoundBars.TabIndex = 0;
            this.SoundBars.TabStop = false;
            // 
            // VoiceSpectrum
            // 
            this.VoiceSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoiceSpectrum.Location = new System.Drawing.Point(0, 0);
            this.VoiceSpectrum.Name = "VoiceSpectrum";
            this.VoiceSpectrum.Size = new System.Drawing.Size(350, 36);
            this.VoiceSpectrum.TabIndex = 0;
            this.VoiceSpectrum.TabStop = false;
            // 
            // FixedColors
            // 
            this.FixedColors.Controls.Add(this.Breath);
            this.FixedColors.Controls.Add(this.BreathScroll);
            this.FixedColors.Controls.Add(this.label5);
            this.FixedColors.Controls.Add(this.DefinedColorsGroup);
            this.FixedColors.Controls.Add(this.CustomPrincipal);
            this.FixedColors.Location = new System.Drawing.Point(4, 22);
            this.FixedColors.Name = "FixedColors";
            this.FixedColors.Padding = new System.Windows.Forms.Padding(3);
            this.FixedColors.Size = new System.Drawing.Size(356, 197);
            this.FixedColors.TabIndex = 3;
            this.FixedColors.Text = "Fixed Colors";
            this.FixedColors.UseVisualStyleBackColor = true;
            // 
            // Breath
            // 
            this.Breath.AutoSize = true;
            this.Breath.Location = new System.Drawing.Point(127, 21);
            this.Breath.Name = "Breath";
            this.Breath.Size = new System.Drawing.Size(57, 17);
            this.Breath.TabIndex = 13;
            this.Breath.Text = "Breath";
            this.Breath.UseVisualStyleBackColor = true;
            this.Breath.CheckedChanged += new System.EventHandler(this.Breath_CheckedChanged);
            // 
            // BreathScroll
            // 
            this.BreathScroll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BreathScroll.Location = new System.Drawing.Point(118, 49);
            this.BreathScroll.Maximum = 100;
            this.BreathScroll.Minimum = 1;
            this.BreathScroll.Name = "BreathScroll";
            this.BreathScroll.Size = new System.Drawing.Size(217, 45);
            this.BreathScroll.TabIndex = 12;
            this.BreathScroll.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.BreathScroll.Value = 1;
            this.BreathScroll.Scroll += new System.EventHandler(this.BreathScroll_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Speed";
            // 
            // DefinedColorsGroup
            // 
            this.DefinedColorsGroup.AutoSize = true;
            this.DefinedColorsGroup.Controls.Add(this.tableLayoutPanel1);
            this.DefinedColorsGroup.Location = new System.Drawing.Point(8, 96);
            this.DefinedColorsGroup.Name = "DefinedColorsGroup";
            this.DefinedColorsGroup.Size = new System.Drawing.Size(342, 97);
            this.DefinedColorsGroup.TabIndex = 1;
            this.DefinedColorsGroup.TabStop = false;
            this.DefinedColorsGroup.Text = "Last Custom Colors";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.Custom6, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom10, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom11, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom12, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom14, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom8, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom16, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom5, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom7, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.Custom13, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.Custom15, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 78);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Custom6
            // 
            this.Custom6.AutoSize = true;
            this.Custom6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom6.Location = new System.Drawing.Point(213, 3);
            this.Custom6.Name = "Custom6";
            this.Custom6.Size = new System.Drawing.Size(36, 33);
            this.Custom6.TabIndex = 4;
            this.Custom6.UseVisualStyleBackColor = true;
            this.Custom6.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom4
            // 
            this.Custom4.AutoSize = true;
            this.Custom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom4.Location = new System.Drawing.Point(129, 3);
            this.Custom4.Name = "Custom4";
            this.Custom4.Size = new System.Drawing.Size(36, 33);
            this.Custom4.TabIndex = 3;
            this.Custom4.UseVisualStyleBackColor = true;
            this.Custom4.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom1
            // 
            this.Custom1.AutoSize = true;
            this.Custom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom1.Location = new System.Drawing.Point(3, 3);
            this.Custom1.Name = "Custom1";
            this.Custom1.Size = new System.Drawing.Size(36, 33);
            this.Custom1.TabIndex = 0;
            this.Custom1.UseVisualStyleBackColor = true;
            this.Custom1.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom3
            // 
            this.Custom3.AutoSize = true;
            this.Custom3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom3.Location = new System.Drawing.Point(87, 3);
            this.Custom3.Name = "Custom3";
            this.Custom3.Size = new System.Drawing.Size(36, 33);
            this.Custom3.TabIndex = 2;
            this.Custom3.UseVisualStyleBackColor = true;
            this.Custom3.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom2
            // 
            this.Custom2.AutoSize = true;
            this.Custom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom2.Location = new System.Drawing.Point(45, 3);
            this.Custom2.Name = "Custom2";
            this.Custom2.Size = new System.Drawing.Size(36, 33);
            this.Custom2.TabIndex = 1;
            this.Custom2.UseVisualStyleBackColor = true;
            this.Custom2.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom9
            // 
            this.Custom9.AutoSize = true;
            this.Custom9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom9.Location = new System.Drawing.Point(3, 42);
            this.Custom9.Name = "Custom9";
            this.Custom9.Size = new System.Drawing.Size(36, 33);
            this.Custom9.TabIndex = 5;
            this.Custom9.UseVisualStyleBackColor = true;
            this.Custom9.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom10
            // 
            this.Custom10.AutoSize = true;
            this.Custom10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom10.Location = new System.Drawing.Point(45, 42);
            this.Custom10.Name = "Custom10";
            this.Custom10.Size = new System.Drawing.Size(36, 33);
            this.Custom10.TabIndex = 6;
            this.Custom10.UseVisualStyleBackColor = true;
            this.Custom10.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom11
            // 
            this.Custom11.AutoSize = true;
            this.Custom11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom11.Location = new System.Drawing.Point(87, 42);
            this.Custom11.Name = "Custom11";
            this.Custom11.Size = new System.Drawing.Size(36, 33);
            this.Custom11.TabIndex = 7;
            this.Custom11.UseVisualStyleBackColor = true;
            this.Custom11.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom12
            // 
            this.Custom12.AutoSize = true;
            this.Custom12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom12.Location = new System.Drawing.Point(129, 42);
            this.Custom12.Name = "Custom12";
            this.Custom12.Size = new System.Drawing.Size(36, 33);
            this.Custom12.TabIndex = 8;
            this.Custom12.UseVisualStyleBackColor = true;
            this.Custom12.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom14
            // 
            this.Custom14.AutoSize = true;
            this.Custom14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom14.Location = new System.Drawing.Point(213, 42);
            this.Custom14.Name = "Custom14";
            this.Custom14.Size = new System.Drawing.Size(36, 33);
            this.Custom14.TabIndex = 9;
            this.Custom14.UseVisualStyleBackColor = true;
            this.Custom14.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom8
            // 
            this.Custom8.AutoSize = true;
            this.Custom8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom8.Location = new System.Drawing.Point(297, 3);
            this.Custom8.Name = "Custom8";
            this.Custom8.Size = new System.Drawing.Size(36, 33);
            this.Custom8.TabIndex = 10;
            this.Custom8.UseVisualStyleBackColor = true;
            this.Custom8.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom16
            // 
            this.Custom16.AutoSize = true;
            this.Custom16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom16.Location = new System.Drawing.Point(297, 42);
            this.Custom16.Name = "Custom16";
            this.Custom16.Size = new System.Drawing.Size(36, 33);
            this.Custom16.TabIndex = 11;
            this.Custom16.UseVisualStyleBackColor = true;
            this.Custom16.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom5
            // 
            this.Custom5.AutoSize = true;
            this.Custom5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom5.Location = new System.Drawing.Point(171, 3);
            this.Custom5.Name = "Custom5";
            this.Custom5.Size = new System.Drawing.Size(36, 33);
            this.Custom5.TabIndex = 12;
            this.Custom5.UseVisualStyleBackColor = true;
            this.Custom5.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom7
            // 
            this.Custom7.AutoSize = true;
            this.Custom7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom7.Location = new System.Drawing.Point(255, 3);
            this.Custom7.Name = "Custom7";
            this.Custom7.Size = new System.Drawing.Size(36, 33);
            this.Custom7.TabIndex = 13;
            this.Custom7.UseVisualStyleBackColor = true;
            this.Custom7.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom13
            // 
            this.Custom13.AutoSize = true;
            this.Custom13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom13.Location = new System.Drawing.Point(171, 42);
            this.Custom13.Name = "Custom13";
            this.Custom13.Size = new System.Drawing.Size(36, 33);
            this.Custom13.TabIndex = 14;
            this.Custom13.UseVisualStyleBackColor = true;
            this.Custom13.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Custom15
            // 
            this.Custom15.AutoSize = true;
            this.Custom15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Custom15.Location = new System.Drawing.Point(255, 42);
            this.Custom15.Name = "Custom15";
            this.Custom15.Size = new System.Drawing.Size(36, 33);
            this.Custom15.TabIndex = 15;
            this.Custom15.UseVisualStyleBackColor = true;
            this.Custom15.Click += new System.EventHandler(this.LastCustomColor);
            // 
            // Random
            // 
            this.Random.Controls.Add(this.SmoothSpeedScroll);
            this.Random.Controls.Add(this.Function);
            this.Random.Controls.Add(this.FlashSpeedScroll);
            this.Random.Controls.Add(this.label4);
            this.Random.Location = new System.Drawing.Point(4, 22);
            this.Random.Name = "Random";
            this.Random.Padding = new System.Windows.Forms.Padding(3);
            this.Random.Size = new System.Drawing.Size(356, 197);
            this.Random.TabIndex = 2;
            this.Random.Text = "Random";
            this.Random.UseVisualStyleBackColor = true;
            // 
            // SmoothSpeedScroll
            // 
            this.SmoothSpeedScroll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SmoothSpeedScroll.Location = new System.Drawing.Point(123, 80);
            this.SmoothSpeedScroll.Maximum = 100;
            this.SmoothSpeedScroll.Minimum = 1;
            this.SmoothSpeedScroll.Name = "SmoothSpeedScroll";
            this.SmoothSpeedScroll.Size = new System.Drawing.Size(217, 45);
            this.SmoothSpeedScroll.TabIndex = 19;
            this.SmoothSpeedScroll.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.SmoothSpeedScroll.Value = 1;
            this.SmoothSpeedScroll.Scroll += new System.EventHandler(this.SmoothSpeedScroll_Scroll);
            // 
            // Function
            // 
            this.Function.Controls.Add(this.Smooth_RB);
            this.Function.Controls.Add(this.Flash_RB);
            this.Function.Location = new System.Drawing.Point(8, 65);
            this.Function.Name = "Function";
            this.Function.Size = new System.Drawing.Size(98, 67);
            this.Function.TabIndex = 18;
            this.Function.TabStop = false;
            this.Function.Text = "Function";
            // 
            // Smooth_RB
            // 
            this.Smooth_RB.AutoSize = true;
            this.Smooth_RB.Location = new System.Drawing.Point(6, 42);
            this.Smooth_RB.Name = "Smooth_RB";
            this.Smooth_RB.Size = new System.Drawing.Size(61, 17);
            this.Smooth_RB.TabIndex = 1;
            this.Smooth_RB.TabStop = true;
            this.Smooth_RB.Text = "Smooth";
            this.Smooth_RB.UseVisualStyleBackColor = true;
            this.Smooth_RB.CheckedChanged += new System.EventHandler(this.Smooth_RB_CheckedChanged);
            this.Smooth_RB.Click += new System.EventHandler(this.Smooth_RB_Click);
            // 
            // Flash_RB
            // 
            this.Flash_RB.AutoSize = true;
            this.Flash_RB.Checked = true;
            this.Flash_RB.Location = new System.Drawing.Point(6, 19);
            this.Flash_RB.Name = "Flash_RB";
            this.Flash_RB.Size = new System.Drawing.Size(50, 17);
            this.Flash_RB.TabIndex = 0;
            this.Flash_RB.TabStop = true;
            this.Flash_RB.Text = "Flash";
            this.Flash_RB.UseVisualStyleBackColor = true;
            this.Flash_RB.CheckedChanged += new System.EventHandler(this.Flash_RB_CheckedChanged);
            this.Flash_RB.Click += new System.EventHandler(this.Flash_RB_Click);
            // 
            // FlashSpeedScroll
            // 
            this.FlashSpeedScroll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FlashSpeedScroll.Location = new System.Drawing.Point(123, 80);
            this.FlashSpeedScroll.Maximum = 100;
            this.FlashSpeedScroll.Minimum = 1;
            this.FlashSpeedScroll.Name = "FlashSpeedScroll";
            this.FlashSpeedScroll.Size = new System.Drawing.Size(217, 45);
            this.FlashSpeedScroll.TabIndex = 15;
            this.FlashSpeedScroll.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FlashSpeedScroll.Value = 1;
            this.FlashSpeedScroll.Scroll += new System.EventHandler(this.FlashSpeedScroll_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Speed";
            // 
            // Fade
            // 
            this.Fade.Controls.Add(this.SineWave_trackBar);
            this.Fade.Controls.Add(this.PowerHSVtrackbar);
            this.Fade.Controls.Add(this.label1);
            this.Fade.Controls.Add(this.groupBox1);
            this.Fade.Controls.Add(this.TrueHSVtrackBar);
            this.Fade.Location = new System.Drawing.Point(4, 22);
            this.Fade.Name = "Fade";
            this.Fade.Padding = new System.Windows.Forms.Padding(3);
            this.Fade.Size = new System.Drawing.Size(356, 197);
            this.Fade.TabIndex = 1;
            this.Fade.Text = "Fade";
            this.Fade.UseVisualStyleBackColor = true;
            // 
            // SineWave_trackBar
            // 
            this.SineWave_trackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SineWave_trackBar.Location = new System.Drawing.Point(121, 78);
            this.SineWave_trackBar.Maximum = 100;
            this.SineWave_trackBar.Minimum = 1;
            this.SineWave_trackBar.Name = "SineWave_trackBar";
            this.SineWave_trackBar.Size = new System.Drawing.Size(217, 45);
            this.SineWave_trackBar.TabIndex = 10;
            this.SineWave_trackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.SineWave_trackBar.Value = 1;
            this.SineWave_trackBar.Scroll += new System.EventHandler(this.SineWave_Speed_scroll);
            // 
            // PowerHSVtrackbar
            // 
            this.PowerHSVtrackbar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PowerHSVtrackbar.Location = new System.Drawing.Point(121, 78);
            this.PowerHSVtrackbar.Maximum = 100;
            this.PowerHSVtrackbar.Minimum = 1;
            this.PowerHSVtrackbar.Name = "PowerHSVtrackbar";
            this.PowerHSVtrackbar.Size = new System.Drawing.Size(217, 45);
            this.PowerHSVtrackbar.TabIndex = 9;
            this.PowerHSVtrackbar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.PowerHSVtrackbar.Value = 1;
            this.PowerHSVtrackbar.Scroll += new System.EventHandler(this.PowerHSV_Speed_scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Speed";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TrueHSV);
            this.groupBox1.Controls.Add(this.SineWave);
            this.groupBox1.Controls.Add(this.PowerHSV);
            this.groupBox1.Location = new System.Drawing.Point(11, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function";
            // 
            // TrueHSV
            // 
            this.TrueHSV.AutoSize = true;
            this.TrueHSV.Checked = true;
            this.TrueHSV.Location = new System.Drawing.Point(6, 19);
            this.TrueHSV.Name = "TrueHSV";
            this.TrueHSV.Size = new System.Drawing.Size(72, 17);
            this.TrueHSV.TabIndex = 0;
            this.TrueHSV.TabStop = true;
            this.TrueHSV.Text = "True HSV";
            this.TrueHSV.UseVisualStyleBackColor = true;
            this.TrueHSV.CheckedChanged += new System.EventHandler(this.TrueHSV_CheckedChanged);
            this.TrueHSV.Click += new System.EventHandler(this.TrueHSV_Click);
            // 
            // SineWave
            // 
            this.SineWave.AutoSize = true;
            this.SineWave.Location = new System.Drawing.Point(6, 65);
            this.SineWave.Name = "SineWave";
            this.SineWave.Size = new System.Drawing.Size(78, 17);
            this.SineWave.TabIndex = 3;
            this.SineWave.Text = "Sine Wave";
            this.SineWave.UseVisualStyleBackColor = true;
            this.SineWave.CheckedChanged += new System.EventHandler(this.SineWave_CheckedChanged);
            this.SineWave.Click += new System.EventHandler(this.SineWave_Click);
            // 
            // PowerHSV
            // 
            this.PowerHSV.AutoSize = true;
            this.PowerHSV.Location = new System.Drawing.Point(6, 42);
            this.PowerHSV.Name = "PowerHSV";
            this.PowerHSV.Size = new System.Drawing.Size(80, 17);
            this.PowerHSV.TabIndex = 2;
            this.PowerHSV.TabStop = true;
            this.PowerHSV.Text = "Power HSV";
            this.PowerHSV.UseVisualStyleBackColor = true;
            this.PowerHSV.CheckedChanged += new System.EventHandler(this.PowerHSV_CheckedChanged);
            this.PowerHSV.Click += new System.EventHandler(this.PowerHSV_Click);
            // 
            // TrueHSVtrackBar
            // 
            this.TrueHSVtrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TrueHSVtrackBar.Location = new System.Drawing.Point(121, 78);
            this.TrueHSVtrackBar.Maximum = 100;
            this.TrueHSVtrackBar.Minimum = 1;
            this.TrueHSVtrackBar.Name = "TrueHSVtrackBar";
            this.TrueHSVtrackBar.Size = new System.Drawing.Size(217, 45);
            this.TrueHSVtrackBar.TabIndex = 1;
            this.TrueHSVtrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TrueHSVtrackBar.Value = 1;
            this.TrueHSVtrackBar.Scroll += new System.EventHandler(this.TrueHSV_Speed_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Fade);
            this.tabControl1.Controls.Add(this.Random);
            this.tabControl1.Controls.Add(this.FixedColors);
            this.tabControl1.Controls.Add(this.rhythmicLed);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(364, 223);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // BreathTimer
            // 
            this.BreathTimer.Interval = 1;
            this.BreathTimer.Tick += new System.EventHandler(this.BreathTimer_Tick);
            // 
            // CustomPrincipal
            // 
            this.CustomPrincipal.Location = new System.Drawing.Point(14, 21);
            this.CustomPrincipal.Name = "CustomPrincipal";
            this.CustomPrincipal.Size = new System.Drawing.Size(87, 73);
            this.CustomPrincipal.TabIndex = 0;
            this.CustomPrincipal.UseVisualStyleBackColor = true;
            this.CustomPrincipal.DoubleClick += new System.EventHandler(this.CustomPrincipal_DoubleClick);
            this.CustomPrincipal.Click += new System.EventHandler(this.CustomPrincipal_Click);
            // 
            // LedController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 223);
            this.Controls.Add(this.tabControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LedController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Led Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LedController_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LedController_FormClosed);
            this.Load += new System.EventHandler(this.LedController_Load);
            this.Resize += new System.EventHandler(this.LedController_Resize);
            this.TrayContextMenu.ResumeLayout(false);
            this.rhythmicLed.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SoundBars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceSpectrum)).EndInit();
            this.FixedColors.ResumeLayout(false);
            this.FixedColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BreathScroll)).EndInit();
            this.DefinedColorsGroup.ResumeLayout(false);
            this.DefinedColorsGroup.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Random.ResumeLayout(false);
            this.Random.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SmoothSpeedScroll)).EndInit();
            this.Function.ResumeLayout(false);
            this.Function.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlashSpeedScroll)).EndInit();
            this.Fade.ResumeLayout(false);
            this.Fade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SineWave_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PowerHSVtrackbar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrueHSVtrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip TrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem maximizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desativarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.Timer SoundSpectrumTimer;
        private System.Windows.Forms.Timer FadeTrueHSVTimer;
        private System.Windows.Forms.Timer FadePowerHSVTimer;
        private System.Windows.Forms.Timer SineWaveTimer;
        private System.Windows.Forms.Timer FlashTimer;
        private System.Windows.Forms.Timer SmoothTimer;
        private System.Windows.Forms.TabPage rhythmicLed;
        private System.Windows.Forms.PictureBox SoundBars;
        private System.Windows.Forms.TabPage FixedColors;
        private System.Windows.Forms.CheckBox Breath;
        private System.Windows.Forms.TrackBar BreathScroll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox DefinedColorsGroup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Custom6;
        private System.Windows.Forms.Button Custom4;
        private System.Windows.Forms.Button Custom1;
        private System.Windows.Forms.Button Custom3;
        private System.Windows.Forms.Button Custom2;
        private System.Windows.Forms.Button Custom9;
        private System.Windows.Forms.Button Custom10;
        private System.Windows.Forms.Button Custom11;
        private System.Windows.Forms.Button Custom12;
        private System.Windows.Forms.Button Custom14;
        private System.Windows.Forms.Button Custom8;
        private System.Windows.Forms.Button Custom16;
        private System.Windows.Forms.Button Custom5;
        private System.Windows.Forms.Button Custom7;
        private System.Windows.Forms.Button Custom13;
        private System.Windows.Forms.Button Custom15;
        private              LedsGUI.DoubleClickButton CustomPrincipal;
        private System.Windows.Forms.TabPage Random;
        private System.Windows.Forms.TrackBar FlashSpeedScroll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage Fade;
        private System.Windows.Forms.TrackBar SineWave_trackBar;
        private System.Windows.Forms.TrackBar PowerHSVtrackbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton TrueHSV;
        private System.Windows.Forms.RadioButton SineWave;
        private System.Windows.Forms.RadioButton PowerHSV;
        private System.Windows.Forms.TrackBar TrueHSVtrackBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox Function;
        private System.Windows.Forms.RadioButton Smooth_RB;
        private System.Windows.Forms.RadioButton Flash_RB;
        private System.Windows.Forms.TrackBar SmoothSpeedScroll;
        private System.Windows.Forms.Timer BreathTimer;
        private System.Windows.Forms.ToolStripMenuItem arduinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem StartUpWithWindows;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox VoiceSpectrum;
    }
}

