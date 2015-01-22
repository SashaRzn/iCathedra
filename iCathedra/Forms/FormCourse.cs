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
    public partial class FormCourse : Form
    {
        private Database myDatabase = new Database("Database.sdf");

        public FormCourse()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myDatabase.SubmitChanges();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myDatabase.SubmitChanges();
        }

        private void FormCourse_Load(object sender, EventArgs e)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<Course>(c => c.CourseInWork);
            myDatabase.LoadOptions = dlo;

            bindingSource1.DataSource = myDatabase.Course;
            employeeBindingSource.DataSource = myDatabase.GetTable<Employee>();

            bindingSource2.DataSource = bindingSource1;
            bindingSource2.DataMember = "CourseInWork";

            #region Группы
            bindingSourceGroup.DataSource = myDatabase.Group;
            //List<Group> lg = new List<Group>();
            //Group newGroup = new Group();
            //newGroup.Group1 = "----";
            //newGroup.ID = 0;
            //lg.Add(newGroup);

            //var q = from g1 in myDatabase.Group
            //             orderby g1.Group1
            //             select g1;

            //foreach (Group g in q) lg.Add(g);

            //this.group1IDDataGridViewTextBoxColumn.DataSource = lg;
            //this.group1IDDataGridViewTextBoxColumn.DisplayMember = "Group1";
            //this.group1IDDataGridViewTextBoxColumn.ValueMember = "ID";

            //this.group2IDDataGridViewTextBoxColumn.DataSource = lg;
            //this.group2IDDataGridViewTextBoxColumn.DisplayMember = "Group1";
            //this.group2IDDataGridViewTextBoxColumn.ValueMember = "ID";
            #endregion

            #region Учебный год
            schoolYearBindingSource.DataSource = myDatabase.GetTable<SchoolYear>();
            #endregion

            #region Семестр
            Dictionary<System.Nullable<short>, string> semestr = new Dictionary<System.Nullable<short>, string>();
            foreach (Semestr s in  Enum.GetValues(typeof(Semestr)))
            {

                semestr.Add((System.Nullable<short>)s, s.ToString());
            }

            this.semestrBindingSource.DataSource = semestr;

            this.semestrDataGridViewComboBoxColumn.DataSource = this.semestrBindingSource;
            this.semestrDataGridViewComboBoxColumn.DisplayMember = "Value";
            this.semestrDataGridViewComboBoxColumn.ValueMember = "Key";
            #endregion

            #region Преподаватель
            //employeeIDDataGridViewTextBoxColumn1.DataSource = myDatabase.GetTable<Employee>();
            //employeeIDDataGridViewTextBoxColumn1.DisplayMember = "ShortName";
            //employeeIDDataGridViewTextBoxColumn1.ValueMember = "ID";
            #endregion

            #region Вид нагрузки
            Dictionary<System.Nullable<short>, string> workload = new Dictionary<System.Nullable<short>, string>();
            foreach (WorkloadType wt in Enum.GetValues(typeof(WorkloadType)))
            {
                workload.Add((System.Nullable<short>)wt, wt.ToString().Replace('_',' '));
            }

            BindingSource workloadBindingSource = new BindingSource();
            workloadBindingSource.DataSource = workload;

            this.factDataGridViewTextBoxColumn.DataSource = workloadBindingSource;
            this.factDataGridViewTextBoxColumn.DisplayMember = "Value";
            this.factDataGridViewTextBoxColumn.ValueMember = "Key";
            #endregion

            //#region Раскрашиваем строки
            //foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            //{
            //    paintRow(dgvr);
            //}
            //#endregion

            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            string s = e.Value as string;

            //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
            Employee em = (from employee in this.employeeBindingSource.OfType<Employee>()
                      where employee.ToString() == s
                      select employee).FirstOrDefault();

            e.Value = em;
            e.ParsingApplied = true;
        }

        private void dataGridView2_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType.FullName.ToString() == "iCathedra.SchoolYear")
            {
                string s = e.Value as string;

                //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
                SchoolYear sy = (from schoolYear in this.schoolYearBindingSource.OfType<SchoolYear>()
                                 where schoolYear.ToString() == s
                                 select schoolYear).FirstOrDefault();

                e.Value = sy;
                e.ParsingApplied = true;
            }
            else if (e.DesiredType.FullName.ToString() == "iCathedra.Employee")
            {
                string s = e.Value as string;

                //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
                Employee em = (from employee in this.employeeBindingSource.OfType<Employee>()
                               where employee.ToString() == s
                               select employee).FirstOrDefault();

                e.Value = em;
                e.ParsingApplied = true;
            }
            else if (e.DesiredType.FullName.ToString() == "iCathedra.Group")
            {
                string s = e.Value as string;

                //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
                Group g = (from group1 in this.bindingSourceGroup.OfType<Group>()
                               where group1.ToString() == s
                               select group1).FirstOrDefault();

                e.Value = g;
                e.ParsingApplied = true;
            }
        }

        private void bindingSource2_CurrentItemChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null) paintRow(dataGridView1.CurrentRow);
            dataGridView1.Refresh();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemDeleted)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows) paintRow(r);
            }
        }

        private void paintRow(DataGridViewRow ADataGridViewRow)
        {
            if (ADataGridViewRow != null)
            {
                // Получаем строку в первом наборе данных
                Course c = (Course)ADataGridViewRow.DataBoundItem;
                if (c != null)
                {
                    DataGridViewCellStyle newStyle = dataGridView1.DefaultCellStyle.Clone();
                    if (c.WorkloadFact != c.WorkloadNorm)
                        newStyle.BackColor = Color.LightCoral;
                    else if (c.WorkloadFact == c.WorkloadNorm && c.WorkloadFact > 0)
                    {
                        newStyle.BackColor = Color.LightGreen;
                    }
                    ADataGridViewRow.DefaultCellStyle = newStyle;
                    decimal _AllHours = 0;
                    foreach (CourseInWork ciw in c.CourseInWork)
                    {
                        if (ciw.SchoolYearID == iCathedra_Settings.SchoolYearId)
                        {
                            if (ciw.Fact == (short)WorkloadType.Формальная ||
                                ciw.Fact == (short)WorkloadType.Фактическая_и_формальная)
                            {
                                _AllHours += ciw.AllHours;
                            }
                        }
                    }
                    foreach (DataGridViewCell dgvc in ADataGridViewRow.Cells)
                    {
                        if (dgvc.OwningColumn.Name == "Calculated")
                        {
                            dgvc.Value = _AllHours.ToString();
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSource2.Current;
            bindingSource2.AddNew();
            CourseInWork emptyciw = (CourseInWork)bindingSource2.Current;
            ciw.Clone(ref emptyciw, WorkloadHourType.Все_виды);
            bindingSource2.EndEdit();
            dataGridView2.Refresh();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Forms.FormSelectSchoolYear fssy = new Forms.FormSelectSchoolYear();
            fssy.ShowDialog();
            SchoolYear selectedSchoolYear = fssy.SelectedSchoolYear;

            decimal totalFact = 0;
            decimal totalForm = 0;
            foreach(Course c in bindingSource1)
            {
                foreach (CourseInWork ciw in c.CourseInWork)
                {
                    if (ciw.SchoolYear.ID == selectedSchoolYear.ID)
                    {
                        if (ciw.Fact == (short)WorkloadType.Формальная || ciw.Fact == (short)WorkloadType.Фактическая_и_формальная)
                        {
                            totalForm += (decimal)ciw.AllHours;
                        }
                        if (ciw.Fact == (short)WorkloadType.Фактическая || ciw.Fact == (short)WorkloadType.Фактическая_и_формальная)
                        {
                            totalFact += (decimal)ciw.AllHours;
                        }
                    }
                }
            }
            MessageBox.Show(String.Format("Общая нагрузка:\n" +
                "формальная - {0},\n" +
                "фактическая - {1}.", totalForm, totalFact));
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    Course c = (Course)dataGridView1.CurrentRow.DataBoundItem;
                    MessageBox.Show(c.GetStatistic());
                }
            }
        }

        private void dataGridView1_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Course c = (Course)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                //string statistic = c.GetStatistic();
                // e.ToolTipText = statistic;
                //MessageBox.Show(statistic);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSource2.Current;
            ciw.Group = null;
            ciw.Group2 = null;
            ciw.Group3 = null;
            ciw.Group4 = null;
            dataGridView2.Refresh();
        }
    }
}
