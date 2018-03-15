namespace LedsGUI
{
    partial class IntegratedVisualization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntegratedVisualization));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SoundBarsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hidePropertiesSoundBarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenericSoundBars = new System.Windows.Forms.PictureBox();
            this.GenericSoundBarPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.SoundSpectrumMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hidePropertiesSoundSpectrumMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GenericSoundSpectrum = new System.Windows.Forms.PictureBox();
            this.GenericSoundSpectrumPropertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SoundBarsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GenericSoundBars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SoundSpectrumMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GenericSoundSpectrum)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(958, 571);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.ContextMenuStrip = this.SoundBarsMenu;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GenericSoundBars);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.GenericSoundBarPropertyGrid);
            this.splitContainer2.Size = new System.Drawing.Size(958, 297);
            this.splitContainer2.SplitterDistance = 724;
            this.splitContainer2.TabIndex = 0;
            // 
            // SoundBarsMenu
            // 
            this.SoundBarsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hidePropertiesSoundBarMenuItem,
            this.alwaysOnTopToolStripMenuItem});
            this.SoundBarsMenu.Name = "SoundBarsMenu";
            this.SoundBarsMenu.Size = new System.Drawing.Size(156, 48);
            this.SoundBarsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.SoundBarsMenu_Opening);
            // 
            // hidePropertiesSoundBarMenuItem
            // 
            this.hidePropertiesSoundBarMenuItem.Name = "hidePropertiesSoundBarMenuItem";
            this.hidePropertiesSoundBarMenuItem.Size = new System.Drawing.Size(155, 22);
            this.hidePropertiesSoundBarMenuItem.Text = "Hide properties";
            this.hidePropertiesSoundBarMenuItem.Click += new System.EventHandler(this.hidePropertiesSoundBarMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem1_Click);
            // 
            // GenericSoundBars
            // 
            this.GenericSoundBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenericSoundBars.Location = new System.Drawing.Point(0, 0);
            this.GenericSoundBars.Name = "GenericSoundBars";
            this.GenericSoundBars.Size = new System.Drawing.Size(724, 297);
            this.GenericSoundBars.TabIndex = 0;
            this.GenericSoundBars.TabStop = false;
            // 
            // GenericSoundBarPropertyGrid
            // 
            this.GenericSoundBarPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenericSoundBarPropertyGrid.HelpVisible = false;
            this.GenericSoundBarPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.GenericSoundBarPropertyGrid.Name = "GenericSoundBarPropertyGrid";
            this.GenericSoundBarPropertyGrid.Size = new System.Drawing.Size(230, 297);
            this.GenericSoundBarPropertyGrid.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.ContextMenuStrip = this.SoundSpectrumMenu;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.GenericSoundSpectrum);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.GenericSoundSpectrumPropertyGrid);
            this.splitContainer3.Size = new System.Drawing.Size(958, 270);
            this.splitContainer3.SplitterDistance = 724;
            this.splitContainer3.TabIndex = 0;
            // 
            // SoundSpectrumMenu
            // 
            this.SoundSpectrumMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hidePropertiesSoundSpectrumMenuItem1,
            this.alwaysOnTopToolStripMenuItem1});
            this.SoundSpectrumMenu.Name = "SoundSpectrumMenu";
            this.SoundSpectrumMenu.Size = new System.Drawing.Size(156, 48);
            this.SoundSpectrumMenu.Opening += new System.ComponentModel.CancelEventHandler(this.SoundSpectrumMenu_Opening);
            // 
            // hidePropertiesSoundSpectrumMenuItem1
            // 
            this.hidePropertiesSoundSpectrumMenuItem1.Name = "hidePropertiesSoundSpectrumMenuItem1";
            this.hidePropertiesSoundSpectrumMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.hidePropertiesSoundSpectrumMenuItem1.Text = "Hide properties";
            this.hidePropertiesSoundSpectrumMenuItem1.Click += new System.EventHandler(this.hidePropertiesSoundSpectrumMenuItem1_Click);
            // 
            // alwaysOnTopToolStripMenuItem1
            // 
            this.alwaysOnTopToolStripMenuItem1.Name = "alwaysOnTopToolStripMenuItem1";
            this.alwaysOnTopToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.alwaysOnTopToolStripMenuItem1.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem1.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem1_Click);
            // 
            // GenericSoundSpectrum
            // 
            this.GenericSoundSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenericSoundSpectrum.Location = new System.Drawing.Point(0, 0);
            this.GenericSoundSpectrum.Name = "GenericSoundSpectrum";
            this.GenericSoundSpectrum.Size = new System.Drawing.Size(724, 270);
            this.GenericSoundSpectrum.TabIndex = 0;
            this.GenericSoundSpectrum.TabStop = false;
            // 
            // GenericSoundSpectrumPropertyGrid
            // 
            this.GenericSoundSpectrumPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GenericSoundSpectrumPropertyGrid.HelpVisible = false;
            this.GenericSoundSpectrumPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.GenericSoundSpectrumPropertyGrid.Name = "GenericSoundSpectrumPropertyGrid";
            this.GenericSoundSpectrumPropertyGrid.Size = new System.Drawing.Size(230, 270);
            this.GenericSoundSpectrumPropertyGrid.TabIndex = 0;
            // 
            // IntegratedVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 571);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IntegratedVisualization";
            this.Text = "Integrated Visualization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntegratedVisualization_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.SoundBarsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GenericSoundBars)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.SoundSpectrumMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GenericSoundSpectrum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.PictureBox GenericSoundBars;
        public System.Windows.Forms.PropertyGrid GenericSoundBarPropertyGrid;
        public System.Windows.Forms.PictureBox GenericSoundSpectrum;
        public System.Windows.Forms.PropertyGrid GenericSoundSpectrumPropertyGrid;
        private System.Windows.Forms.ContextMenuStrip SoundBarsMenu;
        private System.Windows.Forms.ToolStripMenuItem hidePropertiesSoundBarMenuItem;
        private System.Windows.Forms.ContextMenuStrip SoundSpectrumMenu;
        private System.Windows.Forms.ToolStripMenuItem hidePropertiesSoundSpectrumMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem1;
    }
}