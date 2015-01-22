using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iCathedra.Forms.Service;

namespace iCathedra.Forms
{
    public partial class FormEmployeeInSchoolYearEdit : Form
    {
        private EmployeeInSchoolYear eisy;
        private Database myDatabase;

        public FormEmployeeInSchoolYearEdit(EmployeeInSchoolYear Aeisy, Database AmyDatabase)
        {
            InitializeComponent();
            eisy = Aeisy;
            myDatabase = AmyDatabase;
        }


        private void FormEmployeeInSchoolYearEdit_Load(object sender, EventArgs e)
        {
            textBoxInfo.Text = eisy.Employee.Fio + ", " + eisy.Post.Name.ToLower();
            if (!String.IsNullOrEmpty(eisy.Employee.Phone))
                textBoxInfo.Text += ", " + eisy.Employee.Phone;
            if (!String.IsNullOrEmpty(eisy.Employee.E_Mail))
                textBoxInfo.Text += ", e-mail: " + eisy.Employee.E_Mail;
            textBoxComment.Text = eisy.Employee.Comment;
            updateParameters();
            updateDataGridViews();
            this.WindowState = FormWindowState.Maximized;
        }

        private void updateParameters()
        {
            //labelTotalFormalWorkloadValue.Text = (eisy.Post.RateInHoursInSchoolYear(eisy.SchoolYear)*
            //    eisy.RateForm).ToString();
            labelTotalFormalWorkloadValue.Text = eisy.RateInHours.ToString();

            labelFactPochFondText.Text = " - в т.ч. почасовой фонд (лимит " + eisy.PochFondLimit.ToString() + "):";

            Employee pf = myDatabase.Employee.FirstOrDefault(p => p.Id == iCathedra_Settings.PochFondKod);
            EmployeeInSchoolYear eisypf = new EmployeeInSchoolYear(pf, eisy.SchoolYear);
            labelPochNagruzValue.Text = String.Format("{0}/{1}/{2}",
                eisypf.Post.RateInHoursInSchoolYear(eisypf.SchoolYear),
                eisypf.WorkloadForm,
                eisypf.Post.RateInHoursInSchoolYear(eisypf.SchoolYear) - eisypf.WorkloadForm);
            
            labelFormalWorkloadValue.Text = eisy.WorkloadForm.ToString();
            if (eisy.IsOverload || eisy.IsUnderload)
                labelFormalWorkloadValue.BackColor = Color.LightCoral;
            else
                labelFormalWorkloadValue.BackColor = Color.LightGreen;

            labelUnderloadValue.Text = eisy.Underload.ToString();
            if (eisy.IsUnderload)
                labelUnderloadValue.BackColor = Color.LightCoral;
            else if (eisy.Underload == 0)
                labelUnderloadValue.BackColor = this.BackColor;
            else
                labelUnderloadValue.BackColor = Color.LightGreen;

            labelOverloadValue.Text = eisy.Overload.ToString();
            if (eisy.IsOverload)
                labelOverloadValue.BackColor = Color.LightCoral;
            else if (eisy.Overload == 0)
                labelOverloadValue.BackColor = this.BackColor;
            else
                labelOverloadValue.BackColor = Color.LightGreen;

            labelFactValue.Text = eisy.WorkloadFact.ToString();

            labelFactOtherTutorValue.Text = eisy.WorkloadFactTutor.ToString();

            labelFactPochFondValue.Text = eisy.WorkloadFactPochFond.ToString();
            if (eisy.IsPochFondOverload)
                labelFactPochFondValue.BackColor = Color.LightCoral;

        }

        private void updateDataGridViews()
        {
            #region Блока формальной и фактической нагрузки
            List<CourseInWork> lciw1 = (from ciw in myDatabase.CourseInWork
                                                     where ciw.EmployeeID == eisy.Employee.Id &&
                                                        ciw.SchoolYear.ID == iCathedra_Settings.SchoolYearId &&
                                                        ciw.Fact == (int)WorkloadType.Фактическая_и_формальная
                                                     orderby ciw.CourseID, ciw.Group1ID, ciw.Semestr
                                                     select ciw).ToList<CourseInWork>();
            bindingSourceFormalAndFact.DataSource = lciw1;
            dataGridViewFormalAndFact.DataSource = bindingSourceFormalAndFact;
            decimal formalAndFact = 0;
            foreach(CourseInWork ciw in lciw1) formalAndFact += ciw.AllHours;
            labelFormalAndFactValue.Text = "Итого фактической и формальной нагрузки - " + formalAndFact.ToString();
            dataGridViewFormalAndFact.Refresh();
            #endregion

            #region Блок формальной нагрузки
            List<CourseInWork> lciw2 = (from ciw in myDatabase.CourseInWork
                                        where ciw.EmployeeID == eisy.Employee.Id &&
                                           ciw.SchoolYear.ID == iCathedra_Settings.SchoolYearId &&
                                           ciw.Fact == (int)WorkloadType.Формальная
                                        orderby ciw.CourseID, ciw.Group1ID, ciw.Semestr
                                        select ciw).ToList<CourseInWork>();
            bindingSourceFormal.DataSource = lciw2;
            dataGridViewFormal.DataSource = bindingSourceFormal;
            decimal formal = 0;
            foreach (CourseInWork ciw in lciw2) formal += ciw.AllHours;
            labelFormalValue.Text = "Итого формальной нагрузки - " + formal.ToString();
            #endregion

            #region Блок фактической нагрузки
            List<CourseInWork> lciw3 = (from ciw in myDatabase.CourseInWork
                                        where ciw.EmployeeID == eisy.Employee.Id &&
                                           ciw.SchoolYear.ID == iCathedra_Settings.SchoolYearId &&
                                           ciw.Fact == (int)WorkloadType.Фактическая &&
                                           ciw.Twin != null &&
                                           ciw.Twin.EmployeeID != iCathedra_Settings.PochFondKod
                                        orderby ciw.CourseID, ciw.Group1ID, ciw.Semestr
                                        select ciw).ToList<CourseInWork>();
            bindingSourceFact.DataSource = lciw3;
            dataGridViewFact.DataSource = bindingSourceFact;
            decimal fact = 0;
            foreach (CourseInWork ciw in lciw3) fact += ciw.AllHours;
            labelFactValue2.Text = "Итого фактической нагрузки - " + fact.ToString();
            #endregion

            #region Блок фактической нагрузки, оплачиваемой через почасовой фонд
            List<CourseInWork> lciw4 = (from ciw in myDatabase.CourseInWork
                                        where ciw.EmployeeID == eisy.Employee.Id &&
                                           ciw.SchoolYear.ID == iCathedra_Settings.SchoolYearId &&
                                           ciw.Fact == (int)WorkloadType.Фактическая &&
                                           ciw.Twin != null &&
                                           ciw.Twin.EmployeeID == iCathedra_Settings.PochFondKod
                                        orderby ciw.CourseID, ciw.Group1ID, ciw.Semestr
                                        select ciw).ToList<CourseInWork>();
            bindingSourceFactPochFond.DataSource = lciw4;
            dataGridViewFactPochFond.DataSource = bindingSourceFactPochFond;
            decimal factPochFond = 0;
            foreach (CourseInWork ciw in lciw4) factPochFond += ciw.AllHours;
            labelFactPochFondValue2.Text = "Итого фактической нагрузки, оплачиваемой через почасовой фонд - " + factPochFond.ToString();
            #endregion

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSaveAndClose_Click(object sender, EventArgs e)
        {
            eisy.Employee.Comment = textBoxComment.Text;
            myDatabase.SubmitChanges();
            Close();
        }

        private void dataGridViewFormalAndFact_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CourseInWork ciw = (CourseInWork)(bindingSourceFormalAndFact.Current);
            FormCourseInWorkInfo fciwi = new FormCourseInWorkInfo(ciw, myDatabase);
            fciwi.ShowDialog();
        }

        private void dataGridViewFormal_DoubleClick(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)(bindingSourceFormal.Current);
            FormCourseInWorkInfo fciwi = new FormCourseInWorkInfo(ciw, myDatabase);
            fciwi.ShowDialog();
        }

        private void dataGridViewFact_DoubleClick(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)(bindingSourceFact.Current);
            FormCourseInWorkInfo fciwi = new FormCourseInWorkInfo(ciw, myDatabase);
            fciwi.ShowDialog();
        }

        private void dataGridViewFactPochFond_DoubleClick(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)(bindingSourceFactPochFond.Current);
            FormCourseInWorkInfo fciwi = new FormCourseInWorkInfo(ciw, myDatabase);
            fciwi.ShowDialog();
        }

        private void buttonMoveFormalPart_Click(object sender, EventArgs e)
        {
            FormSelectEmployee fse = new FormSelectEmployee(myDatabase);
            fse.ShowDialog();
            if (fse.DialogResult == System.Windows.Forms.DialogResult.OK && fse.SelectedEmployee != null)
            {
                CourseInWork ciw = (CourseInWork)bindingSourceFormalAndFact.Current;
                if (fse.SelectedEmployee.Id != iCathedra_Settings.PochFondKod)
                {
                    FormSelectWorkloadHourType fswht = new FormSelectWorkloadHourType(ciw);
                    fswht.ShowDialog();
                    if (fswht.DialogResult == System.Windows.Forms.DialogResult.OK && fswht.SelectedWorkloadHourType != WorkloadHourType.None)
                    {
                        CourseInWork newCiw1 = ciw.Split((WorkloadType)ciw.Fact, (WorkloadType)ciw.Fact,
                            ciw.Employee, ciw.Employee,
                            fswht.SelectedWorkloadHourType, 
                            WorkloadMoveType.Переносится);
                        myDatabase.CourseInWork.InsertOnSubmit(newCiw1);
                        myDatabase.SubmitChanges();

                        CourseInWork newCiw2 = newCiw1.Split(WorkloadType.Фактическая, WorkloadType.Формальная,
                            newCiw1.Employee, fse.SelectedEmployee,
                            fswht.SelectedWorkloadHourType,
                            WorkloadMoveType.Копируется);
                        CourseInWork.MakeTwins(ref newCiw1, ref newCiw2);
                        myDatabase.CourseInWork.InsertOnSubmit(newCiw2);
                        myDatabase.SubmitChanges();

                        if (ciw.AllHours == 0)
                        {
                            myDatabase.CourseInWork.DeleteOnSubmit(ciw);
                            myDatabase.SubmitChanges();
                        }

                        updateParameters();
                        updateDataGridViews();
                    }
                    else
                        MessageBox.Show("Не задана нагрузка для переноса!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Для переноски в почасовой фонд есть отдельная кнопка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Преподаватель не выбран!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            
            //myDatabase.CourseInWork.InsertOnSubmit
        }

        private void buttonMoveToAnotherEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormalAndFact.Current;
            changeEmployee(ciw);
        }

        private void buttonMoveFactPart_Click(object sender, EventArgs e)
        {
            FormSelectEmployee fse = new FormSelectEmployee(myDatabase);
            fse.ShowDialog();
            if (fse.DialogResult == System.Windows.Forms.DialogResult.OK && fse.SelectedEmployee != null)
            {
                CourseInWork ciw = (CourseInWork)bindingSourceFormalAndFact.Current;
                if (fse.SelectedEmployee.Id != iCathedra_Settings.PochFondKod)
                {
                    FormSelectWorkloadHourType fswht = new FormSelectWorkloadHourType(ciw);
                    fswht.ShowDialog();
                    if (fswht.DialogResult == System.Windows.Forms.DialogResult.OK && fswht.SelectedWorkloadHourType != WorkloadHourType.None)
                    {
                        CourseInWork newCiw1 = ciw.Split((WorkloadType)ciw.Fact, (WorkloadType)ciw.Fact,
                            ciw.Employee, ciw.Employee,
                            fswht.SelectedWorkloadHourType,
                            WorkloadMoveType.Переносится);
                        myDatabase.CourseInWork.InsertOnSubmit(newCiw1);
                        myDatabase.SubmitChanges();

                        CourseInWork newCiw2 = newCiw1.Split(WorkloadType.Формальная, WorkloadType.Фактическая,
                            newCiw1.Employee, fse.SelectedEmployee,
                            fswht.SelectedWorkloadHourType,
                            WorkloadMoveType.Копируется);
                        CourseInWork.MakeTwins(ref newCiw1, ref newCiw2);
                        myDatabase.CourseInWork.InsertOnSubmit(newCiw2);
                        myDatabase.SubmitChanges();

                        if (ciw.AllHours == 0)
                        {
                            myDatabase.CourseInWork.DeleteOnSubmit(ciw);
                            myDatabase.SubmitChanges();
                        }

                        updateParameters();
                        updateDataGridViews();
                    }
                    else
                        MessageBox.Show("Не задана нагрузка для переноса!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Для переноски в почасовой фонд есть отдельная кнопка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Преподаватель не выбран!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonMoveToPochFond_Click(object sender, EventArgs e)
        {
            Employee pochFond = myDatabase.Employee.First<Employee>(em => em.Id == iCathedra_Settings.PochFondKod);
            CourseInWork ciw = (CourseInWork)bindingSourceFormalAndFact.Current;

            FormSelectWorkloadHourType fswht = new FormSelectWorkloadHourType(ciw);
            fswht.ShowDialog();
            if (fswht.DialogResult == System.Windows.Forms.DialogResult.OK && fswht.SelectedWorkloadHourType != WorkloadHourType.None)
            {
                CourseInWork newCiw1 = ciw.Split((WorkloadType)ciw.Fact, (WorkloadType)ciw.Fact,
                    ciw.Employee, ciw.Employee,
                    fswht.SelectedWorkloadHourType,
                    WorkloadMoveType.Переносится);
                myDatabase.CourseInWork.InsertOnSubmit(newCiw1);
                myDatabase.SubmitChanges();

                CourseInWork newCiw2 = newCiw1.Split(WorkloadType.Фактическая, WorkloadType.Формальная,
                    newCiw1.Employee, pochFond,
                    fswht.SelectedWorkloadHourType,
                    WorkloadMoveType.Копируется);
                CourseInWork.MakeTwins(ref newCiw1, ref newCiw2);
                myDatabase.CourseInWork.InsertOnSubmit(newCiw2);
                myDatabase.SubmitChanges();

                if (ciw.AllHours == 0)
                {
                    myDatabase.CourseInWork.DeleteOnSubmit(ciw);
                    myDatabase.SubmitChanges();
                }

                updateParameters();
                updateDataGridViews();
            }
            else
                MessageBox.Show("Не задана нагрузка для переноса!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonShowLinkedWorkload_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormalAndFact.Current;
            FormSelectCourseInWork fsciw = new FormSelectCourseInWork(myDatabase,
                ciw.Employee, ciw.Group, (Semestr)ciw.Semestr, ciw.SchoolYear, (WorkloadType)ciw.Fact, ciw);
            fsciw.ShowDialog();
            if (fsciw.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                CourseInWork destCourseInWork = fsciw.SelectedCourseInWork;
                destCourseInWork.Join(ciw, WorkloadHourType.Все_виды);
                myDatabase.CourseInWork.DeleteOnSubmit(ciw);
                myDatabase.SubmitChanges();

                if (ciw.AllHours == 0)
                {
                    myDatabase.CourseInWork.DeleteOnSubmit(ciw);
                    myDatabase.SubmitChanges();
                }

                updateParameters();
                updateDataGridViews();
            }
        }

        private void buttonSplit_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormalAndFact.Current;
            FormSelectWorkloadHourType fswht = new FormSelectWorkloadHourType(ciw);
            fswht.ShowDialog();
            if (fswht.DialogResult == System.Windows.Forms.DialogResult.OK && fswht.SelectedWorkloadHourType != WorkloadHourType.None)
            {
                CourseInWork newCiw1 = ciw.Split((WorkloadType)ciw.Fact, (WorkloadType)ciw.Fact,
                    ciw.Employee, ciw.Employee,
                    fswht.SelectedWorkloadHourType,
                    WorkloadMoveType.Переносится);
                if (((fswht.SelectedWorkloadHourType & WorkloadHourType.Лабораторные) != 0) &&
                    fswht.NewLabHours > 0)
                {
                    ciw.LabHours = fswht.OldLabHours - fswht.NewLabHours;
                    newCiw1.LabHours = fswht.NewLabHours;
                }
                if (((fswht.SelectedWorkloadHourType & WorkloadHourType.Прочее) != 0) &&
                    fswht.NewProchHours > 0)
                {
                    ciw.ProchHours = fswht.OldProchHours - fswht.NewProchHours;
                    newCiw1.ProchHours = fswht.NewProchHours;
                }
                myDatabase.CourseInWork.InsertOnSubmit(newCiw1);
                myDatabase.SubmitChanges();
                updateParameters();
                updateDataGridViews();
            }
            else
                MessageBox.Show("Не задана нагрузка для переноса!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void buttonGoToFactEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormal.Current;
            EmployeeInSchoolYear eisy = new EmployeeInSchoolYear(ciw.Twin.Employee, ciw.SchoolYear);
            FormEmployeeInSchoolYearEdit feisye = new FormEmployeeInSchoolYearEdit(eisy, myDatabase);
            feisye.ShowDialog();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonFormalMakeFact_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormal.Current;
            ciw.Fact = (short)WorkloadType.Фактическая_и_формальная;
            myDatabase.CourseInWork.DeleteOnSubmit(ciw.Twin);
            ciw.Twin = null;
            myDatabase.SubmitChanges();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonMoveToFactEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormal.Current;
            CourseInWork ciwTwin = ciw.Twin;
            ciwTwin.Fact = (short)WorkloadType.Фактическая_и_формальная;
            ciwTwin.Twin = null;
            myDatabase.CourseInWork.DeleteOnSubmit(ciw);
            myDatabase.SubmitChanges();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonFormalChangeEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFormal.Current;
            changeEmployee(ciw);
        }

        private void changeEmployee(CourseInWork ciw)
        {
            FormSelectEmployee fse = new FormSelectEmployee(myDatabase);
            fse.ShowDialog();
            if (fse.DialogResult == System.Windows.Forms.DialogResult.OK && fse.SelectedEmployee != null)
            {
                if (fse.SelectedEmployee.Id != iCathedra_Settings.PochFondKod)
                {
                    ciw.Employee = fse.SelectedEmployee;
                    myDatabase.SubmitChanges();
                    updateParameters();
                    updateDataGridViews();
                }
                else
                    MessageBox.Show("Нельзя перенести фактическую нагрузку на почасовой фонд!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Преподаватель не выбран!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonFactMakeFormal_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFact.Current;
            ciw.Fact = (short)WorkloadType.Фактическая_и_формальная;
            myDatabase.CourseInWork.DeleteOnSubmit(ciw.Twin);
            ciw.Twin = null;
            myDatabase.SubmitChanges();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonMoveToFormalEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFact.Current;
            CourseInWork ciwTwin = ciw.Twin;
            ciwTwin.Fact = (short)WorkloadType.Фактическая_и_формальная;
            ciwTwin.Twin = null;
            myDatabase.CourseInWork.DeleteOnSubmit(ciw);
            myDatabase.SubmitChanges();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonGoToFormalEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFact.Current;
            EmployeeInSchoolYear eisy = new EmployeeInSchoolYear(ciw.Twin.Employee, ciw.SchoolYear);
            FormEmployeeInSchoolYearEdit feisye = new FormEmployeeInSchoolYearEdit(eisy, myDatabase);
            feisye.ShowDialog();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonFactChangeEmployee_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFact.Current;
            changeEmployee(ciw);
        }

        private void buttonPochFondMakeFormal_Click(object sender, EventArgs e)
        {
            CourseInWork ciw = (CourseInWork)bindingSourceFactPochFond.Current;
            ciw.Fact = (short)WorkloadType.Фактическая_и_формальная;
            myDatabase.CourseInWork.DeleteOnSubmit(ciw.Twin);
            ciw.Twin = null;
            myDatabase.SubmitChanges();
            updateParameters();
            updateDataGridViews();
        }

        private void buttonPochFondGoToEmployee_Click(object sender, EventArgs e)
        {
            var ciw = (CourseInWork)bindingSourceFactPochFond.Current;
            changeEmployee(ciw);
        }

        private void buttonSetRoom_Click(object sender, EventArgs e)
        {
            var ciw = (CourseInWork)bindingSourceFormalAndFact.Current;
            var fsr = new FormSetRoom();
            if (ciw.Room != null)
                fsr.Room = ciw.Room;
            fsr.ShowDialog();
            ciw.Room = fsr.Room;
            myDatabase.SubmitChanges();
        }
    }
}
