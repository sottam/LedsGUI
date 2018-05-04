using LedsGUI.CustomComponents;
using System;
using System.ComponentModel;

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
            _bitmap.Dispose();
            _bitmap_dt.Dispose();
            _bitmap_dm.Dispose();
            _bitmap_db.Dispose();

            _bitmap_g.Dispose();

            firmata.Dispose();
            cscore.Dispose();

            TrayIcon.Dispose();

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
            this.showSketchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.StartUpWithWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desativarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SoundSpectrumTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AnalogMoreButton = new System.Windows.Forms.Button();
            this.AnalogLastGroupCustomColors = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.AnalogLastCustom4 = new System.Windows.Forms.Button();
            this.AnalogLastCustom1 = new System.Windows.Forms.Button();
            this.AnalogLastCustom3 = new System.Windows.Forms.Button();
            this.AnalogLastCustom2 = new System.Windows.Forms.Button();
            this.AnalogLastCustom5 = new System.Windows.Forms.Button();
            this.AnalogLastCustom6 = new System.Windows.Forms.Button();
            this.AnalogBrightScroll = new System.Windows.Forms.TrackBar();
            this.AnalogSpeedScroll = new System.Windows.Forms.TrackBar();
            this.Analog = new System.Windows.Forms.Label();
            this.AnalogCustomPrincipal = new LedsGUI.CustomComponents.DoubleClickButton();
            this.AnalogComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DigitalMoreButton = new System.Windows.Forms.Button();
            this.DigitalLastGroupCustomColors = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.DigitalLastCustom4 = new System.Windows.Forms.Button();
            this.DigitalLastCustom1 = new System.Windows.Forms.Button();
            this.DigitalLastCustom3 = new System.Windows.Forms.Button();
            this.DigitalLastCustom2 = new System.Windows.Forms.Button();
            this.DigitalLastCustom5 = new System.Windows.Forms.Button();
            this.DigitalLastCustom6 = new System.Windows.Forms.Button();
            this.DigitalBrightScroll = new System.Windows.Forms.TrackBar();
            this.DigitalSpeedScroll = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.DigitalCustomPrincipal = new LedsGUI.CustomComponents.DoubleClickButton();
            this.DigitalComboBox = new System.Windows.Forms.ComboBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.ComPortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MessageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MusicalRealSamplingToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.VisualizationTimer = new System.Windows.Forms.Timer(this.components);
            this.StartUpWorker = new System.ComponentModel.BackgroundWorker();
            TempWorker = new System.ComponentModel.BackgroundWorker();
            this.TrayContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.AnalogLastGroupCustomColors.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogBrightScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogSpeedScroll)).BeginInit();
            this.DigitalLastGroupCustomColors.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DigitalBrightScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DigitalSpeedScroll)).BeginInit();
            this.statusBar.SuspendLayout();
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
            this.showSketchToolStripMenuItem,
            this.toolStripSeparator1,
            this.visualizationToolStripMenuItem,
            this.toolStripSeparator2,
            this.StartUpWithWindows,
            this.maximizarToolStripMenuItem,
            this.desativarToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.TrayContextMenu.Name = "contextMenuStrip1";
            this.TrayContextMenu.Size = new System.Drawing.Size(166, 170);
            this.TrayContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TrayContextMenu_Opening);
            // 
            // arduinoToolStripMenuItem
            // 
            this.arduinoToolStripMenuItem.Name = "arduinoToolStripMenuItem";
            this.arduinoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.arduinoToolStripMenuItem.Text = "Arduino";
            // 
            // showSketchToolStripMenuItem
            // 
            this.showSketchToolStripMenuItem.Name = "showSketchToolStripMenuItem";
            this.showSketchToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showSketchToolStripMenuItem.Text = "Show Sketch";
            this.showSketchToolStripMenuItem.Click += new System.EventHandler(this.showSketchToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.visualizationToolStripMenuItem.Text = "Visualization";
            this.visualizationToolStripMenuItem.Click += new System.EventHandler(this.visualizationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // StartUpWithWindows
            // 
            this.StartUpWithWindows.Checked = true;
            this.StartUpWithWindows.CheckOnClick = true;
            this.StartUpWithWindows.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.StartUpWithWindows.Name = "StartUpWithWindows";
            this.StartUpWithWindows.Size = new System.Drawing.Size(165, 22);
            this.StartUpWithWindows.Text = "Windows StartUp";
            this.StartUpWithWindows.Click += new System.EventHandler(this.StartUpWithWindows_Click);
            // 
            // maximizarToolStripMenuItem
            // 
            this.maximizarToolStripMenuItem.Name = "maximizarToolStripMenuItem";
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.maximizarToolStripMenuItem.Text = "Show";
            this.maximizarToolStripMenuItem.Click += new System.EventHandler(this.maximizarToolStripMenuItem_Click);
            // 
            // desativarToolStripMenuItem
            // 
            this.desativarToolStripMenuItem.Name = "desativarToolStripMenuItem";
            this.desativarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.desativarToolStripMenuItem.Text = "Disable";
            this.desativarToolStripMenuItem.Click += new System.EventHandler(this.desativarToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.fecharToolStripMenuItem.Text = "Close";
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
            this.SoundSpectrumTimer.Interval = 17;
            this.SoundSpectrumTimer.Tick += new System.EventHandler(this.SoundSpectrum_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.AnalogMoreButton);
            this.splitContainer2.Panel1.Controls.Add(this.AnalogLastGroupCustomColors);
            this.splitContainer2.Panel1.Controls.Add(this.AnalogBrightScroll);
            this.splitContainer2.Panel1.Controls.Add(this.AnalogSpeedScroll);
            this.splitContainer2.Panel1.Controls.Add(this.Analog);
            this.splitContainer2.Panel1.Controls.Add(this.AnalogCustomPrincipal);
            this.splitContainer2.Panel1.Controls.Add(this.AnalogComboBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.DigitalMoreButton);
            this.splitContainer2.Panel2.Controls.Add(this.DigitalLastGroupCustomColors);
            this.splitContainer2.Panel2.Controls.Add(this.DigitalBrightScroll);
            this.splitContainer2.Panel2.Controls.Add(this.DigitalSpeedScroll);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.DigitalCustomPrincipal);
            this.splitContainer2.Panel2.Controls.Add(this.DigitalComboBox);
            this.splitContainer2.Size = new System.Drawing.Size(517, 227);
            this.splitContainer2.SplitterDistance = 259;
            this.splitContainer2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(11, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Brightness";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Speed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnalogMoreButton
            // 
            this.AnalogMoreButton.Location = new System.Drawing.Point(219, 36);
            this.AnalogMoreButton.Name = "AnalogMoreButton";
            this.AnalogMoreButton.Size = new System.Drawing.Size(32, 21);
            this.AnalogMoreButton.TabIndex = 5;
            this.AnalogMoreButton.Text = "...";
            this.AnalogMoreButton.UseVisualStyleBackColor = true;
            this.AnalogMoreButton.Click += new System.EventHandler(this.AnalogMoreButton_Click);
            // 
            // AnalogLastGroupCustomColors
            // 
            this.AnalogLastGroupCustomColors.Controls.Add(this.tableLayoutPanel3);
            this.AnalogLastGroupCustomColors.Location = new System.Drawing.Point(53, 63);
            this.AnalogLastGroupCustomColors.Name = "AnalogLastGroupCustomColors";
            this.AnalogLastGroupCustomColors.Size = new System.Drawing.Size(198, 52);
            this.AnalogLastGroupCustomColors.TabIndex = 4;
            this.AnalogLastGroupCustomColors.TabStop = false;
            this.AnalogLastGroupCustomColors.Text = "Last Custom Colors";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.AnalogLastCustom4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.AnalogLastCustom1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.AnalogLastCustom3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.AnalogLastCustom2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.AnalogLastCustom5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.AnalogLastCustom6, 5, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(192, 32);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // AnalogLastCustom4
            // 
            this.AnalogLastCustom4.AutoSize = true;
            this.AnalogLastCustom4.BackColor = global::LedsGUI.Properties.Settings.Default.analogLastColor4;
            this.AnalogLastCustom4.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "analogLastColor4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogLastCustom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalogLastCustom4.Location = new System.Drawing.Point(96, 3);
            this.AnalogLastCustom4.MaximumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom4.MinimumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom4.Name = "AnalogLastCustom4";
            this.AnalogLastCustom4.Size = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom4.TabIndex = 3;
            this.AnalogLastCustom4.UseVisualStyleBackColor = false;
            this.AnalogLastCustom4.Click += new System.EventHandler(this.AnalogLastCustomColor);
            // 
            // AnalogLastCustom1
            // 
            this.AnalogLastCustom1.AutoSize = true;
            this.AnalogLastCustom1.BackColor = global::LedsGUI.Properties.Settings.Default.analogLastColor1;
            this.AnalogLastCustom1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "analogLastColor1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogLastCustom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalogLastCustom1.Location = new System.Drawing.Point(3, 3);
            this.AnalogLastCustom1.MaximumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom1.MinimumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom1.Name = "AnalogLastCustom1";
            this.AnalogLastCustom1.Size = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom1.TabIndex = 0;
            this.AnalogLastCustom1.UseVisualStyleBackColor = false;
            this.AnalogLastCustom1.Click += new System.EventHandler(this.AnalogLastCustomColor);
            // 
            // AnalogLastCustom3
            // 
            this.AnalogLastCustom3.AutoSize = true;
            this.AnalogLastCustom3.BackColor = global::LedsGUI.Properties.Settings.Default.analogLastColor3;
            this.AnalogLastCustom3.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "analogLastColor3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogLastCustom3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalogLastCustom3.Location = new System.Drawing.Point(65, 3);
            this.AnalogLastCustom3.MaximumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom3.MinimumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom3.Name = "AnalogLastCustom3";
            this.AnalogLastCustom3.Size = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom3.TabIndex = 2;
            this.AnalogLastCustom3.UseVisualStyleBackColor = false;
            this.AnalogLastCustom3.Click += new System.EventHandler(this.AnalogLastCustomColor);
            // 
            // AnalogLastCustom2
            // 
            this.AnalogLastCustom2.AutoSize = true;
            this.AnalogLastCustom2.BackColor = global::LedsGUI.Properties.Settings.Default.analogLastColor2;
            this.AnalogLastCustom2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "analogLastColor2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogLastCustom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalogLastCustom2.Location = new System.Drawing.Point(34, 3);
            this.AnalogLastCustom2.MaximumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom2.MinimumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom2.Name = "AnalogLastCustom2";
            this.AnalogLastCustom2.Size = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom2.TabIndex = 1;
            this.AnalogLastCustom2.UseVisualStyleBackColor = false;
            this.AnalogLastCustom2.Click += new System.EventHandler(this.AnalogLastCustomColor);
            // 
            // AnalogLastCustom5
            // 
            this.AnalogLastCustom5.BackColor = global::LedsGUI.Properties.Settings.Default.analogLastColor5;
            this.AnalogLastCustom5.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "analogLastColor5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogLastCustom5.Location = new System.Drawing.Point(127, 3);
            this.AnalogLastCustom5.MaximumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom5.MinimumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom5.Name = "AnalogLastCustom5";
            this.AnalogLastCustom5.Size = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom5.TabIndex = 4;
            this.AnalogLastCustom5.UseVisualStyleBackColor = false;
            this.AnalogLastCustom5.Click += new System.EventHandler(this.AnalogLastCustomColor);
            // 
            // AnalogLastCustom6
            // 
            this.AnalogLastCustom6.BackColor = global::LedsGUI.Properties.Settings.Default.analogLastColor6;
            this.AnalogLastCustom6.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "analogLastColor6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogLastCustom6.Location = new System.Drawing.Point(158, 3);
            this.AnalogLastCustom6.MaximumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom6.MinimumSize = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom6.Name = "AnalogLastCustom6";
            this.AnalogLastCustom6.Size = new System.Drawing.Size(26, 26);
            this.AnalogLastCustom6.TabIndex = 5;
            this.AnalogLastCustom6.UseVisualStyleBackColor = false;
            this.AnalogLastCustom6.Click += new System.EventHandler(this.AnalogLastCustomColor);
            // 
            // AnalogBrightScroll
            // 
            this.AnalogBrightScroll.Location = new System.Drawing.Point(11, 163);
            this.AnalogBrightScroll.Maximum = 255;
            this.AnalogBrightScroll.Minimum = 10;
            this.AnalogBrightScroll.Name = "AnalogBrightScroll";
            this.AnalogBrightScroll.Size = new System.Drawing.Size(240, 45);
            this.AnalogBrightScroll.TabIndex = 3;
            this.AnalogBrightScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AnalogBrightScroll.Value = 10;
            this.AnalogBrightScroll.Scroll += new System.EventHandler(this.AnalogBrightScroll_Scroll);
            // 
            // AnalogSpeedScroll
            // 
            this.AnalogSpeedScroll.Location = new System.Drawing.Point(11, 121);
            this.AnalogSpeedScroll.Maximum = 100;
            this.AnalogSpeedScroll.Minimum = 1;
            this.AnalogSpeedScroll.Name = "AnalogSpeedScroll";
            this.AnalogSpeedScroll.Size = new System.Drawing.Size(240, 45);
            this.AnalogSpeedScroll.TabIndex = 2;
            this.AnalogSpeedScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.AnalogSpeedScroll.Value = 1;
            this.AnalogSpeedScroll.Scroll += new System.EventHandler(this.AnalogSpeedScroll_Scroll);
            // 
            // Analog
            // 
            this.Analog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analog.Location = new System.Drawing.Point(7, 8);
            this.Analog.Name = "Analog";
            this.Analog.Size = new System.Drawing.Size(244, 23);
            this.Analog.TabIndex = 1;
            this.Analog.Text = "Analog Strip";
            this.Analog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnalogCustomPrincipal
            // 
            this.AnalogCustomPrincipal.BackColor = global::LedsGUI.Properties.Settings.Default.AnalogLastCustomColorPrincipal;
            this.AnalogCustomPrincipal.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "AnalogLastCustomColorPrincipal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.AnalogCustomPrincipal.Location = new System.Drawing.Point(12, 76);
            this.AnalogCustomPrincipal.MaximumSize = new System.Drawing.Size(35, 35);
            this.AnalogCustomPrincipal.MinimumSize = new System.Drawing.Size(35, 35);
            this.AnalogCustomPrincipal.Name = "AnalogCustomPrincipal";
            this.AnalogCustomPrincipal.Size = new System.Drawing.Size(35, 35);
            this.AnalogCustomPrincipal.TabIndex = 0;
            this.AnalogCustomPrincipal.UseVisualStyleBackColor = false;
            this.AnalogCustomPrincipal.DoubleClick += new System.EventHandler(this.AnalogCustomPrincipal_DoubleClick);
            this.AnalogCustomPrincipal.Click += new System.EventHandler(this.AnalogCustomPrincipal_Click);
            // 
            // AnalogComboBox
            // 
            this.AnalogComboBox.FormattingEnabled = true;
            this.AnalogComboBox.Location = new System.Drawing.Point(12, 36);
            this.AnalogComboBox.MaxDropDownItems = 10;
            this.AnalogComboBox.Name = "AnalogComboBox";
            this.AnalogComboBox.Size = new System.Drawing.Size(201, 21);
            this.AnalogComboBox.TabIndex = 0;
            this.AnalogComboBox.SelectedIndexChanged += new System.EventHandler(this.AnalogComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(240, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Brightness";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(7, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(240, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Speed";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DigitalMoreButton
            // 
            this.DigitalMoreButton.Location = new System.Drawing.Point(215, 36);
            this.DigitalMoreButton.Name = "DigitalMoreButton";
            this.DigitalMoreButton.Size = new System.Drawing.Size(32, 21);
            this.DigitalMoreButton.TabIndex = 14;
            this.DigitalMoreButton.Text = "...";
            this.DigitalMoreButton.UseVisualStyleBackColor = true;
            this.DigitalMoreButton.Click += new System.EventHandler(this.DigitalMoreButton_Click);
            // 
            // DigitalLastGroupCustomColors
            // 
            this.DigitalLastGroupCustomColors.Controls.Add(this.tableLayoutPanel4);
            this.DigitalLastGroupCustomColors.Location = new System.Drawing.Point(49, 63);
            this.DigitalLastGroupCustomColors.Name = "DigitalLastGroupCustomColors";
            this.DigitalLastGroupCustomColors.Size = new System.Drawing.Size(198, 52);
            this.DigitalLastGroupCustomColors.TabIndex = 13;
            this.DigitalLastGroupCustomColors.TabStop = false;
            this.DigitalLastGroupCustomColors.Text = "Last Custom Colors";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.Controls.Add(this.DigitalLastCustom4, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.DigitalLastCustom1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.DigitalLastCustom3, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.DigitalLastCustom2, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.DigitalLastCustom5, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.DigitalLastCustom6, 5, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(192, 32);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // DigitalLastCustom4
            // 
            this.DigitalLastCustom4.AutoSize = true;
            this.DigitalLastCustom4.BackColor = global::LedsGUI.Properties.Settings.Default.digitalLastColor4;
            this.DigitalLastCustom4.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "digitalLastColor4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalLastCustom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigitalLastCustom4.Location = new System.Drawing.Point(96, 3);
            this.DigitalLastCustom4.MaximumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom4.MinimumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom4.Name = "DigitalLastCustom4";
            this.DigitalLastCustom4.Size = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom4.TabIndex = 3;
            this.DigitalLastCustom4.UseVisualStyleBackColor = false;
            this.DigitalLastCustom4.Click += new System.EventHandler(this.DigitalLastCustomColor);
            // 
            // DigitalLastCustom1
            // 
            this.DigitalLastCustom1.AutoSize = true;
            this.DigitalLastCustom1.BackColor = global::LedsGUI.Properties.Settings.Default.digitalLastColor1;
            this.DigitalLastCustom1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "digitalLastColor1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalLastCustom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigitalLastCustom1.Location = new System.Drawing.Point(3, 3);
            this.DigitalLastCustom1.MaximumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom1.MinimumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom1.Name = "DigitalLastCustom1";
            this.DigitalLastCustom1.Size = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom1.TabIndex = 0;
            this.DigitalLastCustom1.UseVisualStyleBackColor = false;
            this.DigitalLastCustom1.Click += new System.EventHandler(this.DigitalLastCustomColor);
            // 
            // DigitalLastCustom3
            // 
            this.DigitalLastCustom3.AutoSize = true;
            this.DigitalLastCustom3.BackColor = global::LedsGUI.Properties.Settings.Default.digitalLastColor3;
            this.DigitalLastCustom3.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "digitalLastColor3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalLastCustom3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigitalLastCustom3.Location = new System.Drawing.Point(65, 3);
            this.DigitalLastCustom3.MaximumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom3.MinimumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom3.Name = "DigitalLastCustom3";
            this.DigitalLastCustom3.Size = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom3.TabIndex = 2;
            this.DigitalLastCustom3.UseVisualStyleBackColor = false;
            this.DigitalLastCustom3.Click += new System.EventHandler(this.DigitalLastCustomColor);
            // 
            // DigitalLastCustom2
            // 
            this.DigitalLastCustom2.AutoSize = true;
            this.DigitalLastCustom2.BackColor = global::LedsGUI.Properties.Settings.Default.digitalLastColor2;
            this.DigitalLastCustom2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "digitalLastColor2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalLastCustom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigitalLastCustom2.Location = new System.Drawing.Point(34, 3);
            this.DigitalLastCustom2.MaximumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom2.MinimumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom2.Name = "DigitalLastCustom2";
            this.DigitalLastCustom2.Size = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom2.TabIndex = 1;
            this.DigitalLastCustom2.UseVisualStyleBackColor = false;
            this.DigitalLastCustom2.Click += new System.EventHandler(this.DigitalLastCustomColor);
            // 
            // DigitalLastCustom5
            // 
            this.DigitalLastCustom5.BackColor = global::LedsGUI.Properties.Settings.Default.digitalLastColor5;
            this.DigitalLastCustom5.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "digitalLastColor5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalLastCustom5.Location = new System.Drawing.Point(127, 3);
            this.DigitalLastCustom5.MaximumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom5.MinimumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom5.Name = "DigitalLastCustom5";
            this.DigitalLastCustom5.Size = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom5.TabIndex = 4;
            this.DigitalLastCustom5.UseVisualStyleBackColor = false;
            this.DigitalLastCustom5.Click += new System.EventHandler(this.DigitalLastCustomColor);
            // 
            // DigitalLastCustom6
            // 
            this.DigitalLastCustom6.BackColor = global::LedsGUI.Properties.Settings.Default.digitalLastColor6;
            this.DigitalLastCustom6.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "digitalLastColor6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalLastCustom6.Location = new System.Drawing.Point(158, 3);
            this.DigitalLastCustom6.MaximumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom6.MinimumSize = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom6.Name = "DigitalLastCustom6";
            this.DigitalLastCustom6.Size = new System.Drawing.Size(26, 26);
            this.DigitalLastCustom6.TabIndex = 5;
            this.DigitalLastCustom6.UseVisualStyleBackColor = false;
            this.DigitalLastCustom6.Click += new System.EventHandler(this.DigitalLastCustomColor);
            // 
            // DigitalBrightScroll
            // 
            this.DigitalBrightScroll.Location = new System.Drawing.Point(7, 163);
            this.DigitalBrightScroll.Maximum = 255;
            this.DigitalBrightScroll.Minimum = 10;
            this.DigitalBrightScroll.Name = "DigitalBrightScroll";
            this.DigitalBrightScroll.Size = new System.Drawing.Size(240, 45);
            this.DigitalBrightScroll.TabIndex = 12;
            this.DigitalBrightScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DigitalBrightScroll.Value = 10;
            this.DigitalBrightScroll.Scroll += new System.EventHandler(this.DigitalBrightScroll_Scroll);
            // 
            // DigitalSpeedScroll
            // 
            this.DigitalSpeedScroll.Location = new System.Drawing.Point(7, 121);
            this.DigitalSpeedScroll.Maximum = 100;
            this.DigitalSpeedScroll.Minimum = 1;
            this.DigitalSpeedScroll.Name = "DigitalSpeedScroll";
            this.DigitalSpeedScroll.Size = new System.Drawing.Size(240, 45);
            this.DigitalSpeedScroll.TabIndex = 11;
            this.DigitalSpeedScroll.TickStyle = System.Windows.Forms.TickStyle.None;
            this.DigitalSpeedScroll.Value = 1;
            this.DigitalSpeedScroll.Scroll += new System.EventHandler(this.DigitalSpeedScroll_Scroll);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(244, 23);
            this.label11.TabIndex = 10;
            this.label11.Text = "Digital Strip";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DigitalCustomPrincipal
            // 
            this.DigitalCustomPrincipal.BackColor = global::LedsGUI.Properties.Settings.Default.DigitalLastCustomColorPrincipal;
            this.DigitalCustomPrincipal.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::LedsGUI.Properties.Settings.Default, "DigitalLastCustomColorPrincipal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DigitalCustomPrincipal.Location = new System.Drawing.Point(8, 76);
            this.DigitalCustomPrincipal.MaximumSize = new System.Drawing.Size(35, 35);
            this.DigitalCustomPrincipal.MinimumSize = new System.Drawing.Size(35, 35);
            this.DigitalCustomPrincipal.Name = "DigitalCustomPrincipal";
            this.DigitalCustomPrincipal.Size = new System.Drawing.Size(35, 35);
            this.DigitalCustomPrincipal.TabIndex = 8;
            this.DigitalCustomPrincipal.UseVisualStyleBackColor = false;
            this.DigitalCustomPrincipal.DoubleClick += new System.EventHandler(this.DigitalCustomPrincipal_DoubleClick);
            this.DigitalCustomPrincipal.Click += new System.EventHandler(this.DigitalCustomPrincipal_Click);
            // 
            // DigitalComboBox
            // 
            this.DigitalComboBox.FormattingEnabled = true;
            this.DigitalComboBox.Location = new System.Drawing.Point(8, 36);
            this.DigitalComboBox.Name = "DigitalComboBox";
            this.DigitalComboBox.Size = new System.Drawing.Size(201, 21);
            this.DigitalComboBox.TabIndex = 9;
            this.DigitalComboBox.SelectedIndexChanged += new System.EventHandler(this.DigitalComboBox_SelectedIndexChanged);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComPortStatusLabel,
            this.MessageStatusLabel,
            this.MusicalRealSamplingToolStripStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 205);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(517, 22);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusBar";
            // 
            // ComPortStatusLabel
            // 
            this.ComPortStatusLabel.Name = "ComPortStatusLabel";
            this.ComPortStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.ComPortStatusLabel.Text = "COM#";
            // 
            // MessageStatusLabel
            // 
            this.MessageStatusLabel.Name = "MessageStatusLabel";
            this.MessageStatusLabel.Size = new System.Drawing.Size(53, 17);
            this.MessageStatusLabel.Text = "Message";
            // 
            // MusicalRealSamplingToolStripStatusLabel
            // 
            this.MusicalRealSamplingToolStripStatusLabel.Name = "MusicalRealSamplingToolStripStatusLabel";
            this.MusicalRealSamplingToolStripStatusLabel.Size = new System.Drawing.Size(120, 17);
            this.MusicalRealSamplingToolStripStatusLabel.Text = "MusicalRealSampling";
            // 
            // VisualizationTimer
            // 
            this.VisualizationTimer.Interval = 1;
            this.VisualizationTimer.Tick += new System.EventHandler(this.VisualizationTimer_Tick);
            // 
            // StartUpWorker
            // 
            this.StartUpWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.StartUpWorker_DoWork);
            this.StartUpWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SetStartUpWorker_RunWorkerCompleted);
            // 
            // LedController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 227);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.splitContainer2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LedController";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Led Controller";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LedController_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LedController_FormClosed);
            this.Load += new System.EventHandler(this.LedController_Load);
            this.Resize += new System.EventHandler(this.LedController_Resize);
            this.TrayContextMenu.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.AnalogLastGroupCustomColors.ResumeLayout(false);
            this.AnalogLastGroupCustomColors.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogBrightScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogSpeedScroll)).EndInit();
            this.DigitalLastGroupCustomColors.ResumeLayout(false);
            this.DigitalLastGroupCustomColors.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DigitalBrightScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DigitalSpeedScroll)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ContextMenuStrip TrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem maximizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desativarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.Timer SoundSpectrumTimer;
        private LedsGUI.CustomComponents.DoubleClickButton AnalogCustomPrincipal;
        private System.Windows.Forms.ToolStripMenuItem arduinoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem StartUpWithWindows;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox AnalogLastGroupCustomColors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button AnalogLastCustom4;
        private System.Windows.Forms.Button AnalogLastCustom1;
        private System.Windows.Forms.Button AnalogLastCustom3;
        private System.Windows.Forms.Button AnalogLastCustom2;
        private System.Windows.Forms.TrackBar AnalogBrightScroll;
        private System.Windows.Forms.TrackBar AnalogSpeedScroll;
        private System.Windows.Forms.Label Analog;
        private System.Windows.Forms.ComboBox AnalogComboBox;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button AnalogMoreButton;
        private System.Windows.Forms.Button AnalogLastCustom5;
        private System.Windows.Forms.Button AnalogLastCustom6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button DigitalMoreButton;
        private System.Windows.Forms.GroupBox DigitalLastGroupCustomColors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button DigitalLastCustom4;
        private System.Windows.Forms.Button DigitalLastCustom1;
        private System.Windows.Forms.Button DigitalLastCustom3;
        private System.Windows.Forms.Button DigitalLastCustom2;
        private System.Windows.Forms.Button DigitalLastCustom5;
        private System.Windows.Forms.Button DigitalLastCustom6;
        private System.Windows.Forms.TrackBar DigitalBrightScroll;
        private System.Windows.Forms.TrackBar DigitalSpeedScroll;
        private System.Windows.Forms.Label label11;
        private DoubleClickButton DigitalCustomPrincipal;
        private System.Windows.Forms.ComboBox DigitalComboBox;
        private System.Windows.Forms.ToolStripMenuItem visualizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer VisualizationTimer;
        private System.ComponentModel.BackgroundWorker StartUpWorker;
        private System.Windows.Forms.ToolStripMenuItem showSketchToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ComPortStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MessageStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel MusicalRealSamplingToolStripStatusLabel;
        public static BackgroundWorker TempWorker;
    }
}

