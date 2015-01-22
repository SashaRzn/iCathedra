using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.IO;
using iCathedra.Forms;

namespace iCathedra
{
    public partial class FormEmployeeInSchoolYear : Form
    {
        Database myDatabase = new Database("Database.sdf");
        EntitySet<EmployeeInSchoolYear> entitySetEmployeeInSchoolYear = new EntitySet<EmployeeInSchoolYear>();

        public FormEmployeeInSchoolYear()
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

        private void FormEmployeeInSchoolYear_Load(object sender, EventArgs e)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<CourseInWork>(ciw => ciw.Employee);
            dlo.LoadWith<CourseInWork>(ciw => ciw.SchoolYear);
            myDatabase.LoadOptions = dlo;

            SchoolYear firstSchoolYear = myDatabase.SchoolYear.FirstOrDefault(sy => sy.ID == iCathedra_Settings.SchoolYearId);

            #region Заполняем список dataGridViewEmployeeInSchoolYear
            foreach (Employee em in myDatabase.Employee)
            {
                if (!em.NonActive)
                {
                    EmployeeInSchoolYear eiw = new EmployeeInSchoolYear(em, firstSchoolYear);
                    entitySetEmployeeInSchoolYear.Add(eiw);
                }
            }
            bindingSourceEmployeeInSchoolYear.DataSource = entitySetEmployeeInSchoolYear;
            #endregion

            bindingSourceEmployee.DataSource = myDatabase.Employee;

            #region Вид нагрузки
            Dictionary<System.Nullable<short>, string> workload = new Dictionary<System.Nullable<short>, string>();
            foreach (WorkloadType wt in Enum.GetValues(typeof(WorkloadType)))
            {
                workload.Add((System.Nullable<short>)wt, wt.ToString().Replace('_', ' '));
            }

            BindingSource workloadBindingSource = new BindingSource();
            workloadBindingSource.DataSource = workload;
            #endregion


            updatedataGridViewEmployeeInSchoolYear();

            this.WindowState = FormWindowState.Maximized;
        }


        private void paintRow(DataGridViewRow ADataGridViewRow)
        {
            if (ADataGridViewRow != null)
            {
                // Получаем строку в первом наборе данных
                EmployeeInSchoolYear eiw = (EmployeeInSchoolYear)ADataGridViewRow.DataBoundItem;
                if (eiw != null)
                {
                    DataGridViewCellStyle newStyle = dataGridViewEmployeeInSchoolYear.DefaultCellStyle.Clone();
                    if (eiw.IsOverload)
                        newStyle.BackColor = Color.LightCoral;
                    else if (eiw.IsUnderload)
                        newStyle.BackColor = Color.LightGray;
                    else if (eiw.IsPochFondOverload)
                        newStyle.BackColor = Color.Red;
                    else
                        newStyle.BackColor = Color.White;
                    ADataGridViewRow.DefaultCellStyle = newStyle;
                }
            }
        }

        private void dataGridViewEmployeeInSchoolYear_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemDeleted)
            {
                updatedataGridViewEmployeeInSchoolYear();
            }
        }

        private void updatedataGridViewEmployeeInSchoolYear()
        {
            foreach (DataGridViewRow r in dataGridViewEmployeeInSchoolYear.Rows) paintRow(r);
            dataGridViewEmployeeInSchoolYear.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EmployeeInSchoolYear eisy = (EmployeeInSchoolYear)bindingSourceEmployeeInSchoolYear.Current;
            if (eisy != null)
            {
                File.WriteAllText("Employee.txt",
                    eisy.GetEmployeeInfo(myDatabase.CourseInWork.ToList<CourseInWork>()),
                    Encoding.Default);
                // MessageBox.Show(eisy.GetEmployeeInfo());
                FormEditor fe = new FormEditor(eisy.GetEmployeeInfo(myDatabase.CourseInWork.ToList<CourseInWork>()));
                fe.ShowDialog();
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (File.Exists("Employee.txt")) File.Delete("Employee.txt");
            foreach (EmployeeInSchoolYear eisy in bindingSourceEmployeeInSchoolYear)
            {
                File.AppendAllText("Employee.txt",
                    eisy.GetEmployeeInfo(myDatabase.CourseInWork.ToList<CourseInWork>()),
                    Encoding.Default);
            }
            MessageBox.Show("Формирование успешно завершено!");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string returnString = "Фамилия".PadRight(30) + "|" +
                "Должность".PadRight(20) + "|" +
                "Форм. нагрузка".PadRight(15) + "|" +
                "Перегрузка".PadRight(10) + "|" +
                "Недогрузка".PadRight(10) + "|" +
                "Форм. нагр. по часам".PadRight(20) + "|" +
                "Форм. ставка".PadRight(12) + "|" +
                "Факт. нагрузка".PadRight(14) + "|" +
                "Факт. ставка".PadRight(12) + "|" + "\n";

            decimal workloadForm = 0;
            decimal overload = 0;
            decimal underload = 0;
            decimal rateFormByHours = 0;
            decimal rateForm = 0;
            decimal workloadFact = 0;
            decimal rateFact = 0;

            var q = from eisy in this.bindingSourceEmployeeInSchoolYear.OfType<EmployeeInSchoolYear>()
                    orderby eisy.Post.Id descending
                    select eisy;

            foreach (EmployeeInSchoolYear eisy in q)
            {
                if (eisy.WorkloadForm != 0 ||
                    eisy.Overload != 0 ||
                    eisy.Underload != 0 ||
                    (decimal)eisy.RateFormByHours != 0 ||
                    eisy.RateForm != 0 ||
                    eisy.WorkloadFact != 0 ||
                    (decimal)eisy.RateFact != 0)
                {
                    returnString += eisy.Fio.PadRight(30) + "|" +
                        eisy.Post.ToString().PadRight(20) + "|" +
                        eisy.WorkloadForm.ToString().PadLeft(15) + "|" +
                        eisy.Overload.ToString().PadLeft(10) + "|" +
                        eisy.Underload.ToString().PadLeft(10) + "|" +
                        eisy.RateFormByHours.ToString().PadLeft(20) + "|" +
                        eisy.RateForm.ToString().PadLeft(12) + "|" +
                        eisy.WorkloadFact.ToString().PadLeft(14) + "|" +
                        eisy.RateFact.ToString().PadLeft(12) + "|" + "\n";

                    workloadForm += eisy.WorkloadForm;
                    overload += eisy.Overload;
                    underload += eisy.Underload;
                    rateFormByHours += (decimal)eisy.RateFormByHours;
                    rateForm += eisy.RateForm;
                    workloadFact += eisy.WorkloadFact;
                    rateFact += (decimal)eisy.RateFact;
                }
            }
            returnString += "\n";
            returnString += "ИТОГО: ".PadRight(30) + "|" +
                    "".PadRight(20) + "|" +
                    workloadForm.ToString().PadLeft(15) + "|" +
                    overload.ToString().PadLeft(10) + "|" +
                    underload.ToString().PadLeft(10) + "|" +
                    rateFormByHours.ToString().PadLeft(20) + "|" +
                    rateForm.ToString().PadLeft(12) + "|" +
                    workloadFact.ToString().PadLeft(14) + "|" +
                    rateFact.ToString().PadLeft(12) + "|" + "\n";
            
            FormEditor fe = new FormEditor(returnString);
            fe.ShowDialog();
        }

        private void dataGridViewEmployeeInSchoolYear_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeInSchoolYear eisy = (EmployeeInSchoolYear)bindingSourceEmployeeInSchoolYear.Current;
            FormEmployeeInSchoolYearEdit feisye = new FormEmployeeInSchoolYearEdit(eisy, myDatabase);
            feisye.ShowDialog();
            updatedataGridViewEmployeeInSchoolYear();
        }
    }

}
