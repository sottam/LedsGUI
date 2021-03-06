﻿namespace LedsGUI
{
    partial class MusicalMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicalMode));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SoundBars = new System.Windows.Forms.PictureBox();
            this.VoiceSpectrum = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.useXLogScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingStrategyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decibelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SoundBars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceSpectrum)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.SoundBars);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.VoiceSpectrum);
            this.splitContainer1.Size = new System.Drawing.Size(446, 261);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 0;
            // 
            // SoundBars
            // 
            this.SoundBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SoundBars.Location = new System.Drawing.Point(0, 0);
            this.SoundBars.Name = "SoundBars";
            this.SoundBars.Size = new System.Drawing.Size(446, 204);
            this.SoundBars.TabIndex = 1;
            this.SoundBars.TabStop = false;
            // 
            // VoiceSpectrum
            // 
            this.VoiceSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VoiceSpectrum.Location = new System.Drawing.Point(0, 0);
            this.VoiceSpectrum.Name = "VoiceSpectrum";
            this.VoiceSpectrum.Size = new System.Drawing.Size(446, 53);
            this.VoiceSpectrum.TabIndex = 1;
            this.VoiceSpectrum.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator1,
            this.useXLogScaleToolStripMenuItem,
            this.scalingStrategyToolStripMenuItem,
            this.useAverageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 98);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // useXLogScaleToolStripMenuItem
            // 
            this.useXLogScaleToolStripMenuItem.Name = "useXLogScaleToolStripMenuItem";
            this.useXLogScaleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
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
            this.scalingStrategyToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.scalingStrategyToolStripMenuItem.Text = "Scaling Strategy";
            // 
            // squareRootToolStripMenuItem
            // 
            this.squareRootToolStripMenuItem.Name = "squareRootToolStripMenuItem";
            this.squareRootToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.squareRootToolStripMenuItem.Text = "Square root";
            this.squareRootToolStripMenuItem.Click += new System.EventHandler(this.squareRootToolStripMenuItem_Click);
            // 
            // decibelToolStripMenuItem
            // 
            this.decibelToolStripMenuItem.Name = "decibelToolStripMenuItem";
            this.decibelToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.decibelToolStripMenuItem.Text = "Decibel";
            this.decibelToolStripMenuItem.Click += new System.EventHandler(this.decibelToolStripMenuItem_Click);
            // 
            // linearToolStripMenuItem
            // 
            this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            this.linearToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.linearToolStripMenuItem.Text = "Linear";
            this.linearToolStripMenuItem.Click += new System.EventHandler(this.linearToolStripMenuItem_Click);
            // 
            // useAverageToolStripMenuItem
            // 
            this.useAverageToolStripMenuItem.Name = "useAverageToolStripMenuItem";
            this.useAverageToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.useAverageToolStripMenuItem.Text = "Use Average";
            this.useAverageToolStripMenuItem.Click += new System.EventHandler(this.useAverageToolStripMenuItem_Click);
            // 
            // MusicalMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 261);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "MusicalMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Analog Musical Mode Visualization";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicalMode_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SoundBars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VoiceSpectrum)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PictureBox SoundBars;
        public System.Windows.Forms.PictureBox VoiceSpectrum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem useXLogScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scalingStrategyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decibelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem useAverageToolStripMenuItem;
    }
}