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
    public partial class FormSelectSemestr : Form
    {
        public Semestr SelectedSemestr;

        public FormSelectSemestr()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            SelectedSemestr = (Semestr)comboBoxSemestr.SelectedItem;
            Close();
        }

        private void FormSelectSemestr_Load(object sender, EventArgs e)
        {
            foreach(Semestr s in Enum.GetValues(typeof(Semestr)))
            {
                comboBoxSemestr.Items.Add(s);
            }
        }
    }
}
