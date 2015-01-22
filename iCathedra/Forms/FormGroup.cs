using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace iCathedra
{
    public partial class FormGroup : Form
    {
        private Database myDatabase = new Database("Database.sdf");

        public FormGroup()
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

        private void FormGroup_Load(object sender, EventArgs e)
        {
            bindingSourceGroup.DataSource = myDatabase.GetTable<Group>();
            bindingSourceGroupInSemestr.DataSource = bindingSourceGroup;
            bindingSourceGroupInSemestr.DataMember = "GroupInSemestr";

            bindingSourceSchoolYear.DataSource = myDatabase.GetTable<SchoolYear>();

            #region Семестр
            Dictionary<System.Nullable<short>, string> semestr = new Dictionary<System.Nullable<short>, string>();
            foreach (Semestr s in Enum.GetValues(typeof(Semestr)))
            {

                semestr.Add((System.Nullable<short>)s, s.ToString());
            }

            this.bindingSourceSemestr.DataSource = semestr;

            this.semestrDataGridViewTextBoxColumn.DataSource = this.bindingSourceSemestr;
            this.semestrDataGridViewTextBoxColumn.DisplayMember = "Value";
            this.semestrDataGridViewTextBoxColumn.ValueMember = "Key";
            #endregion

            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView2_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType.FullName.ToString() == "iCathedra.SchoolYear")
            {
                string s = e.Value as string;

                //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
                SchoolYear sy = (from schoolYear in this.bindingSourceSchoolYear.OfType<SchoolYear>()
                                 where schoolYear.ToString() == s
                                 select schoolYear).FirstOrDefault();

                e.Value = sy;
            }
            e.ParsingApplied = true;
        }
    }
}
