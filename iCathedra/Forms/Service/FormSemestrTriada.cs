using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCathedra.Forms.Service
{
    public partial class FormSemestrTriada : Form
    {
        public SchoolYear SelectedSchoolYear;

        public bool Triada1;
        public bool Triada2;
        public bool Triada3;

        private Database myDatabase = new Database("Database.sdf");

        public FormSemestrTriada()
        {
            InitializeComponent();
        }

        private void FormSemestrTriada_Load(object sender, EventArgs e)
        {
            schoolYearBindingSource.DataSource = myDatabase.SchoolYear;
            int i = 0;
            foreach (SchoolYear sy in schoolYearBindingSource)
            {
                if (sy.ID == iCathedra_Settings.SchoolYearId)
                {
                    schoolYearBindingSource.Position = i;
                    break;
                }
                i++;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.SelectedSchoolYear = (SchoolYear)schoolYearBindingSource.Current;
            
            Triada1 = checkBox1.Checked;
            Triada2 = checkBox2.Checked;
            Triada3 = checkBox3.Checked;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            Close();
        }
    }
}
