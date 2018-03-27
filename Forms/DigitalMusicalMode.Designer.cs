namespace LedsGUI
{
    partial class DigitalMusicalMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalMusicalMode));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DigitalSoundBars = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NameToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.useXLogScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingStrategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decibelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TreblePictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MedioPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.BassPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TreblePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.MedioPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BassPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.TrebleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MedioNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.BassNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hidePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DigitalSoundBars)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreblePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MedioPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BassPictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrebleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedioNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BassNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DigitalSoundBars);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(448, 500);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 0;
            // 
            // DigitalSoundBars
            // 
            this.DigitalSoundBars.ContextMenuStrip = this.contextMenuStrip1;
            this.DigitalSoundBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigitalSoundBars.Location = new System.Drawing.Point(0, 0);
            this.DigitalSoundBars.Name = "DigitalSoundBars";
            this.DigitalSoundBars.Size = new System.Drawing.Size(448, 155);
            this.DigitalSoundBars.TabIndex = 0;
            this.DigitalSoundBars.TabStop = false;
            this.DigitalSoundBars.Tag = "Sound Bars";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NameToolStripTextBox,
            this.toolStripSeparator2,
            this.useXLogScaleToolStripMenuItem,
            this.scalingStrategyToolStripMenuItem,
            this.useAverageToolStripMenuItem,
            this.toolStripSeparator1,
            this.alwaysOnTopToolStripMenuItem,
            this.hidePropertiesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 151);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // NameToolStripTextBox
            // 
            this.NameToolStripTextBox.Name = "NameToolStripTextBox";
            this.NameToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // useXLogScaleToolStripMenuItem
            // 
            this.useXLogScaleToolStripMenuItem.Name = "useXLogScaleToolStripMenuItem";
            this.useXLogScaleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.useXLogScaleToolStripMenuItem.Text = "Use X Log Scale";
            this.useXLogScaleToolStripMenuItem.Click += new System.EventHandler(this.useXLogScaleToolStripMenuItem_Click);
            // 
            // scalingStrategyToolStripMenuItem
            // 
            this.scalingStrategyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.squareRootToolStripMenuItem,
            this.decibelToolStripMenuItem,
            this.linearToolStripMenuItem});
            this.scalingStrategyToolStripMenuItem.Name = "scalingStrategyToolStripMenuItem";
            this.scalingStrategyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.scalingStrategyToolStripMenuItem.Text = "Scaling Strategy";
            // 
            // squareRootToolStripMenuItem
            // 
            this.squareRootToolStripMenuItem.Name = "squareRootToolStripMenuItem";
            this.squareRootToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.squareRootToolStripMenuItem.Text = "Square Root";
            this.squareRootToolStripMenuItem.Click += new System.EventHandler(this.squareRootToolStripMenuItem_Click);
            // 
            // decibelToolStripMenuItem
            // 
            this.decibelToolStripMenuItem.Name = "decibelToolStripMenuItem";
            this.decibelToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.decibelToolStripMenuItem.Text = "Decibel";
            this.decibelToolStripMenuItem.Click += new System.EventHandler(this.decibelToolStripMenuItem_Click);
            // 
            // linearToolStripMenuItem
            // 
            this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            this.linearToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.linearToolStripMenuItem.Text = "Linear";
            this.linearToolStripMenuItem.Click += new System.EventHandler(this.linearToolStripMenuItem_Click);
            // 
            // useAverageToolStripMenuItem
            // 
            this.useAverageToolStripMenuItem.Name = "useAverageToolStripMenuItem";
            this.useAverageToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.useAverageToolStripMenuItem.Text = "Use Average";
            this.useAverageToolStripMenuItem.Click += new System.EventHandler(this.useAverageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TreblePictureBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2Collapsed = true;
            this.splitContainer2.Size = new System.Drawing.Size(442, 107);
            this.splitContainer2.SplitterDistance = 275;
            this.splitContainer2.TabIndex = 3;
            // 
            // TreblePictureBox
            // 
            this.TreblePictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.TreblePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreblePictureBox.Location = new System.Drawing.Point(0, 0);
            this.TreblePictureBox.Name = "TreblePictureBox";
            this.TreblePictureBox.Size = new System.Drawing.Size(442, 107);
            this.TreblePictureBox.TabIndex = 1;
            this.TreblePictureBox.TabStop = false;
            this.TreblePictureBox.Tag = "Treble";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(3, 116);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.MedioPictureBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer3.Size = new System.Drawing.Size(442, 107);
            this.splitContainer3.SplitterDistance = 275;
            this.splitContainer3.TabIndex = 4;
            // 
            // MedioPictureBox
            // 
            this.MedioPictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.MedioPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MedioPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MedioPictureBox.Name = "MedioPictureBox";
            this.MedioPictureBox.Size = new System.Drawing.Size(442, 107);
            this.MedioPictureBox.TabIndex = 2;
            this.MedioPictureBox.TabStop = false;
            this.MedioPictureBox.Tag = "Medio";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(3, 229);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.BassPictureBox);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer4.Panel2Collapsed = true;
            this.splitContainer4.Size = new System.Drawing.Size(442, 109);
            this.splitContainer4.SplitterDistance = 275;
            this.splitContainer4.TabIndex = 5;
            // 
            // BassPictureBox
            // 
            this.BassPictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.BassPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BassPictureBox.Location = new System.Drawing.Point(0, 0);
            this.BassPictureBox.Name = "BassPictureBox";
            this.BassPictureBox.Size = new System.Drawing.Size(442, 109);
            this.BassPictureBox.TabIndex = 3;
            this.BassPictureBox.TabStop = false;
            this.BassPictureBox.Tag = "Bass";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.TreblePropertyGrid, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TrebleNumericUpDown, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(163, 107);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // TreblePropertyGrid
            // 
            this.TreblePropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreblePropertyGrid.HelpForeColor = System.Drawing.Color.DarkMagenta;
            this.TreblePropertyGrid.HelpVisible = false;
            this.TreblePropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.TreblePropertyGrid.Name = "TreblePropertyGrid";
            this.TreblePropertyGrid.Size = new System.Drawing.Size(157, 76);
            this.TreblePropertyGrid.TabIndex = 2;
            this.TreblePropertyGrid.ToolbarVisible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.MedioPropertyGrid, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.MedioNumericUpDown, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(163, 107);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // MedioPropertyGrid
            // 
            this.MedioPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MedioPropertyGrid.HelpVisible = false;
            this.MedioPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.MedioPropertyGrid.Name = "MedioPropertyGrid";
            this.MedioPropertyGrid.Size = new System.Drawing.Size(157, 76);
            this.MedioPropertyGrid.TabIndex = 1;
            this.MedioPropertyGrid.ToolbarVisible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.BassPropertyGrid, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BassNumericUpDown, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(163, 109);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // BassPropertyGrid
            // 
            this.BassPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BassPropertyGrid.HelpVisible = false;
            this.BassPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.BassPropertyGrid.Name = "BassPropertyGrid";
            this.BassPropertyGrid.Size = new System.Drawing.Size(157, 78);
            this.BassPropertyGrid.TabIndex = 1;
            this.BassPropertyGrid.ToolbarVisible = false;
            // 
            // TrebleNumericUpDown
            // 
            this.TrebleNumericUpDown.DecimalPlaces = 2;
            this.TrebleNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrebleNumericUpDown.Location = new System.Drawing.Point(3, 85);
            this.TrebleNumericUpDown.Name = "TrebleNumericUpDown";
            this.TrebleNumericUpDown.Size = new System.Drawing.Size(157, 20);
            this.TrebleNumericUpDown.TabIndex = 3;
            this.TrebleNumericUpDown.ValueChanged += new System.EventHandler(this.TrebleNumericUpDown_ValueChanged);
            // 
            // MedioNumericUpDown
            // 
            this.MedioNumericUpDown.DecimalPlaces = 2;
            this.MedioNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MedioNumericUpDown.Location = new System.Drawing.Point(3, 85);
            this.MedioNumericUpDown.Name = "MedioNumericUpDown";
            this.MedioNumericUpDown.Size = new System.Drawing.Size(157, 20);
            this.MedioNumericUpDown.TabIndex = 2;
            this.MedioNumericUpDown.ValueChanged += new System.EventHandler(this.MedioNumericUpDown_ValueChanged);
            // 
            // BassNumericUpDown
            // 
            this.BassNumericUpDown.DecimalPlaces = 2;
            this.BassNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BassNumericUpDown.Location = new System.Drawing.Point(3, 87);
            this.BassNumericUpDown.Name = "BassNumericUpDown";
            this.BassNumericUpDown.Size = new System.Drawing.Size(157, 20);
            this.BassNumericUpDown.TabIndex = 2;
            this.BassNumericUpDown.ValueChanged += new System.EventHandler(this.BassNumericUpDown_ValueChanged);
            // 
            // hidePropertiesToolStripMenuItem
            // 
            this.hidePropertiesToolStripMenuItem.Name = "hidePropertiesToolStripMenuItem";
            this.hidePropertiesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.hidePropertiesToolStripMenuItem.Text = "Hide Properties";
            this.hidePropertiesToolStripMenuItem.Click += new System.EventHandler(this.hidePropertiesToolStripMenuItem_Click);
            // 
            // DigitalMusicalMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 500);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DigitalMusicalMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Digital Musical Mode Visualization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DigitalMusicalMode_FormClosing);
            this.Load += new System.EventHandler(this.DigitalMusicalMode_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DigitalSoundBars)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreblePictureBox)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MedioPictureBox)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BassPictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TrebleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedioNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BassNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox DigitalSoundBars;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem useXLogScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scalingStrategyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decibelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useAverageToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripTextBox NameToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.PictureBox TreblePictureBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.PictureBox MedioPictureBox;
        private System.Windows.Forms.SplitContainer splitContainer4;
        public System.Windows.Forms.PictureBox BassPictureBox;
        private System.Windows.Forms.ToolStripMenuItem hidePropertiesToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PropertyGrid TreblePropertyGrid;
        private System.Windows.Forms.NumericUpDown TrebleNumericUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PropertyGrid MedioPropertyGrid;
        private System.Windows.Forms.NumericUpDown MedioNumericUpDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PropertyGrid BassPropertyGrid;
        private System.Windows.Forms.NumericUpDown BassNumericUpDown;
    }
}