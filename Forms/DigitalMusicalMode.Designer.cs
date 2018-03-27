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
            this.TreblePictureBox = new System.Windows.Forms.PictureBox();
            this.MedioPictureBox = new System.Windows.Forms.PictureBox();
            this.BassPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DigitalSoundBars)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TreblePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedioPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BassPictureBox)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(448, 331);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // DigitalSoundBars
            // 
            this.DigitalSoundBars.ContextMenuStrip = this.contextMenuStrip1;
            this.DigitalSoundBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DigitalSoundBars.Location = new System.Drawing.Point(0, 0);
            this.DigitalSoundBars.Name = "DigitalSoundBars";
            this.DigitalSoundBars.Size = new System.Drawing.Size(448, 180);
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
            this.alwaysOnTopToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 129);
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
            this.squareRootToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.squareRootToolStripMenuItem.Text = "Square Root";
            this.squareRootToolStripMenuItem.Click += new System.EventHandler(this.squareRootToolStripMenuItem_Click);
            // 
            // decibelToolStripMenuItem
            // 
            this.decibelToolStripMenuItem.Name = "decibelToolStripMenuItem";
            this.decibelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.decibelToolStripMenuItem.Text = "Decibel";
            this.decibelToolStripMenuItem.Click += new System.EventHandler(this.decibelToolStripMenuItem_Click);
            // 
            // linearToolStripMenuItem
            // 
            this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            this.linearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.tableLayoutPanel1.Controls.Add(this.TreblePictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MedioPictureBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BassPictureBox, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TreblePictureBox
            // 
            this.TreblePictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.TreblePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreblePictureBox.Location = new System.Drawing.Point(3, 3);
            this.TreblePictureBox.Name = "TreblePictureBox";
            this.TreblePictureBox.Size = new System.Drawing.Size(442, 43);
            this.TreblePictureBox.TabIndex = 0;
            this.TreblePictureBox.TabStop = false;
            this.TreblePictureBox.Tag = "Treble";
            // 
            // MedioPictureBox
            // 
            this.MedioPictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.MedioPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MedioPictureBox.Location = new System.Drawing.Point(3, 52);
            this.MedioPictureBox.Name = "MedioPictureBox";
            this.MedioPictureBox.Size = new System.Drawing.Size(442, 43);
            this.MedioPictureBox.TabIndex = 1;
            this.MedioPictureBox.TabStop = false;
            this.MedioPictureBox.Tag = "Medio";
            // 
            // BassPictureBox
            // 
            this.BassPictureBox.ContextMenuStrip = this.contextMenuStrip1;
            this.BassPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BassPictureBox.Location = new System.Drawing.Point(3, 101);
            this.BassPictureBox.Name = "BassPictureBox";
            this.BassPictureBox.Size = new System.Drawing.Size(442, 43);
            this.BassPictureBox.TabIndex = 2;
            this.BassPictureBox.TabStop = false;
            this.BassPictureBox.Tag = "Bass";
            // 
            // DigitalMusicalMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 331);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DigitalMusicalMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Digital Musical Mode Visualization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DigitalMusicalMode_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DigitalSoundBars)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreblePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedioPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BassPictureBox)).EndInit();
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
        public System.Windows.Forms.PictureBox TreblePictureBox;
        public System.Windows.Forms.PictureBox MedioPictureBox;
        public System.Windows.Forms.PictureBox BassPictureBox;
        private System.Windows.Forms.ToolStripTextBox NameToolStripTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}