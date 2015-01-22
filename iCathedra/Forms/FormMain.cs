using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iCathedra.Forms;
using iCathedra.Forms.Service;
using System.IO;
using System.Diagnostics;

namespace iCathedra
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void спискомПреподавателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployee _fe = new FormEmployee();
            _fe.MdiParent = this;
            _fe.Show();
        }

        private void спискомКурсовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCourse _fc = new FormCourse();
            _fc.MdiParent = this;
            _fc.Show();
        }

        private void спискомГруппToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGroup _fg = new FormGroup();
            _fg.MdiParent = this;
            _fg.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void спискомОплатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRate _fr = new FormRate();
            _fr.MdiParent = this;
            _fr.Show();
        }

        private void нагрузкойПреподавателейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployeeInSchoolYear feiw = new FormEmployeeInSchoolYear();
            feiw.MdiParent = this;
            feiw.Show();
        }

        private void спискомДолжностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPost fp = new FormPost();
            fp.MdiParent = this;
            fp.Show();
        }

        private void установкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPreferences fp = new FormPreferences();
            fp.ShowDialog();
        }

        private void очисткаCourseInWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database myDatabase = new Database("Database.sdf");
            int counter = 0;
            foreach (CourseInWork ciw in myDatabase.CourseInWork)
            {
                if (ciw.CourseID == null)
                {
                    counter++;
                }
            }
            if (counter > 0)
            {
                DialogResult dr = MessageBox.Show(String.Format("Найдено {0} записей. Удалить?", counter),
                    "Внимание!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (CourseInWork ciw in myDatabase.CourseInWork)
                    {
                        if (ciw.CourseID == null)
                        {
                            myDatabase.CourseInWork.DeleteOnSubmit(ciw);
                        }
                    }
                    myDatabase.SubmitChanges();
                }
            }
            else
                MessageBox.Show("Дефектных записей не найдено.");
        }

        private void данныеДляРасписанияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSheduleData fsd = new FormSheduleData();
            fsd.ShowDialog();
        }

        private void данныеДляЗаявленийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database myDatabase = new Database("Database.sdf");
            FormSemestrTriada fst = new FormSemestrTriada();
            fst.ShowDialog();
            if (fst.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                List<CourseInWork> lciw = new List<CourseInWork>();
                var q1 = from ciw in myDatabase.CourseInWork
                        where ciw.SchoolYearID == fst.SelectedSchoolYear.ID
                        orderby ciw.EmployeeID, ciw.CourseID
                        select ciw;
                List<CourseInWork> q = q1.ToList<CourseInWork>();
                List<string> ls = new List<string>();
                ls.Add("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">");
                ls.Add("<html>");
                ls.Add(" <head>");
                ls.Add("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">");
                ls.Add("  <title>Данные для заявлений на оплату из почасового фонда</title>");
                ls.Add(" </head>");
                ls.Add(" <body>");
                ls.Add("<h1 align=\"center\">Для заявлений на оплату из почасового фонда</h1>");
                string season = "";
                if (fst.Triada1) season += "осень";
                if (fst.Triada2) season += (!String.IsNullOrEmpty(season) ? ", " : "") + "зиму";
                if (fst.Triada3) season += (!String.IsNullOrEmpty(season) ? ", " : "") + "весну";
                string s = String.Format("учебной нагрузки для заочников на {0} {1} учебного года", season, fst.SelectedSchoolYear.Years);
                ls.Add("<p align=\"center\">" + s + "</p>");
                ls.Add("<table border=\"1\">");
                ls.Add("<tbody>");

                List<CourseInWork> twinCourses = new List<CourseInWork>();

                foreach (CourseInWork ciw in q)
                {
                    if (ciw.Fact == (short)WorkloadType.Фактическая && ciw.Employee.PostID != 5)
                    {
                        // CourseInWork ciwTwin = ciw.GetTwin(q);
                        CourseInWork ciwTwin = ciw.GetTwin();
                        if (ciwTwin == null)
                            throw new Exception("У курса " + ciw.FullName + " не может отсутствовать двойник.");
                        if (ciwTwin.Employee.PostID == 5)
                            twinCourses.Add(ciw);
                    }
                }

                var q2 = from twins in twinCourses 
                         orderby twins.EmployeeID, twins.CourseID, twins.Semestr, twins.Group1ID, twins.Group2ID, twins.Group3ID, twins.Group4ID
                         select twins;

                string oldCourseInWorkName = "-1";
                foreach(CourseInWork ciwTwin in q2)
                {
                    Dictionary<string, decimal> d = ciwTwin.GetHours(fst.Triada1, fst.Triada2, fst.Triada3);
                    if (oldCourseInWorkName != ciwTwin.FullName)
                    {
                        if (d.Count > 0)
                            ls.Add("<tr><td colspan=\"3\">" + ciwTwin.FullName + "</td></tr>");
                        oldCourseInWorkName = ciwTwin.FullName;
                    }
                    foreach (KeyValuePair<string, decimal> kvp in d)
                    {
                        ls.Add("<tr>");
                        ls.Add(String.Format("<td>{0}</td><td>{1}</td><td>-</td>", kvp.Key, kvp.Value));
                        ls.Add("</tr>");
                    }
                }
                ls.Add("</tbody>");
                ls.Add("</table>");
                ls.Add("</body>");
                File.WriteAllLines("PochFond.html", ls.ToArray(), Encoding.GetEncoding(1251));
                Process.Start("PochFond.html"); 
            }
        }

        private void данныеДляРасчетаВыплатМеждуПреподавателямиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database myDatabase = new Database("Database.sdf");
            FormSelectSchoolYear fssy = new FormSelectSchoolYear();
            fssy.ShowDialog();
            if (fssy.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                List<string> ls = new List<string>();
                ls.Add("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">");
                ls.Add("<html>");
                ls.Add(" <head>");
                ls.Add("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">");
                ls.Add("  <title>Данные для выплат компенсаций</title>");
                ls.Add(" </head>");
                ls.Add(" <body>");
                ls.Add("<h1 align=\"center\">Данные для выплат компенсаций</h1>");
                string s = String.Format("учебной нагрузки для заочников на {0} учебного года", fssy.SelectedSchoolYear.Years);
                ls.Add("<p align=\"center\">" + s + "</p>");
                ls.Add("<table border=\"1\">");
                ls.Add("<thead>");
                ls.Add("<tr>");
                ls.Add("<td><b>Преподаватель</b></td>");
                ls.Add("<td><b>Объем формальной нагрузки</b></td>");
                ls.Add("<td><b>Нагрузка всего</b></td>");
                ls.Add("<td><b>Доля формальной нагрузки (%)</b></td>");
                ls.Add("<td><b>Ежемесячные выплаты чистыми</b></td>");
                ls.Add("<td><b>Сумма ежемесячной компенсации</b></td>");
                ls.Add("</tr>");
                ls.Add("<tr>");
                ls.Add("<td align=\"center\">1</td>");
                ls.Add("<td align=\"center\">2</td>");
                ls.Add("<td align=\"center\">3</td>");
                ls.Add("<td align=\"center\">4</td>");
                ls.Add("<td align=\"center\">5</td>");
                ls.Add("<td align=\"center\">6</td>");
                ls.Add("</tr>");
                ls.Add("</thead>");
                ls.Add("<tbody>");                
                foreach (Employee ee in myDatabase.Employee)
                {
                    EmployeeInSchoolYear eisy = new EmployeeInSchoolYear(ee, fssy.SelectedSchoolYear);
                    Dictionary<Employee, decimal> d = eisy.SplitByFormalEmployee(myDatabase.CourseInWork.ToList<CourseInWork>());
                    if (d.Count > 0)
                    {
                        ls.Add("<tr><td colspan=\"6\"><h3>" + ee.ToString() + "</h3></td></tr>");
                        foreach (KeyValuePair<Employee, decimal> kvp in d)
                        {
                            EmployeeInSchoolYear associtedEmployee = new EmployeeInSchoolYear(kvp.Key, fssy.SelectedSchoolYear);
                            decimal totalformworkload = associtedEmployee.WorkloadForm;

                            ls.Add("<tr align=\"center\">");
                            ls.Add(String.Format("<td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", 
                                kvp.Key.ToString(), 
                                kvp.Value,
                                totalformworkload,
                                Math.Round(kvp.Value * 100 / totalformworkload,2),
                                associtedEmployee.Salary,
                                Math.Round(kvp.Value * associtedEmployee.Salary / totalformworkload, 2)
                                ));
                            ls.Add("</tr>");
                        }
                    }
                }
                ls.Add("</tbody>");
                ls.Add("</table>");
                ls.Add("</body>");
                File.WriteAllLines("CrossPay.html", ls.ToArray(), Encoding.GetEncoding(1251));
                Process.Start("CrossPay.html"); 

                //var q = from ciw in myDatabase.CourseInWork
                //        where ciw.SchoolYearID == fssy.SelectedSchoolYear.ID
                //        orderby ciw.EmployeeID, ciw.CourseID
                //        select ciw;
                //List<CourseInWork> lci = new List<CourseInWork>();
                //foreach (CourseInWork ciw in q)
                //{
                //    if (ciw.Fact == (short)WorkloadType.Фактическая && ciw.Employee.PostID != 5)
                //    {
                //        CourseInWork ciwTwin = ciw.GetTwin(q);
                //        if (ciwTwin == null)
                //            throw new Exception("У курса " + ciw.FullName + " не может отсутствовать двойник.");
                //        if (ciwTwin.Employee.PostID == 5)
                //            twinCourses.Add(ciw);
                //    }
                //}
            }

        }

        private void распределениемДипломниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormDiplomWorkload();
            form.ShowDialog();
        }
    }
}
