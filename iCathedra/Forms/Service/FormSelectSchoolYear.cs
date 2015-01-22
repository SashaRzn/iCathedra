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
    public partial class FormSelectSchoolYear : Form
    {
        private Database myDatabase = new Database("Database.sdf");

        public SchoolYear SelectedSchoolYear;

        public FormSelectSchoolYear()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedSchoolYear = schoolYearBindingSource.Current as SchoolYear;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void FormSelectSchoolYear_Load(object sender, EventArgs e)
        {
            schoolYearBindingSource.DataSource = myDatabase.SchoolYear;
            int position = 0;
            foreach (SchoolYear sy in myDatabase.SchoolYear)
            {
                if (sy.ID == iCathedra_Settings.SchoolYearId)
                {
                    schoolYearBindingSource.Position = position;
                    break;
                }
                position++;
            }
        }
    }
}
