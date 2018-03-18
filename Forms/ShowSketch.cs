using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedsGUI
{
    public partial class ShowSketch : Form
    {
        public ShowSketch()
        {
            InitializeComponent();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            CodeRichTextBox.SelectAll();
            CodeRichTextBox.Copy();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ShowSketch_Load(object sender, EventArgs e)
        {
            string sketchText = File.ReadAllText("sketch.ino");
            CodeRichTextBox.Text = sketchText;
        }
    }
}
