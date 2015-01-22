using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCathedra.Forms
{
    public partial class FormEditor : Form
    {
        public FormEditor(string AText)
        {
            InitializeComponent();
            richTextBoxMain.Text = AText;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
