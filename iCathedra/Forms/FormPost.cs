using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCathedra
{
    public partial class FormPost : Form
    {
        Database myDatabase = new Database("Database.sdf");

        public FormPost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myDatabase.SubmitChanges();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myDatabase.SubmitChanges();
        }

        private void FormPost_Load(object sender, EventArgs e)
        {
            bindingSourcePost.DataSource = myDatabase.Post;
            bindingSourcePostSalary.DataSource = bindingSourcePost;
            bindingSourcePostSalary.DataMember = "PostSalary";

            bindingSourceSchoolYear.DataSource = myDatabase.SchoolYear;

            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridViewPostSalary_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType.FullName.ToString() == "iCathedra.SchoolYear")
            {
                string s = e.Value as string;

                //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
                SchoolYear sy = (from schoolYear in this.bindingSourceSchoolYear.OfType<SchoolYear>()
                                 where schoolYear.ToString() == s
                                 select schoolYear).FirstOrDefault();

                e.Value = sy;
                e.ParsingApplied = true;
            }
        }
    }
}
