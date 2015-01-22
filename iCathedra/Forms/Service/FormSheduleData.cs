using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace iCathedra.Forms.Service
{
    public partial class FormSheduleData : Form
    {
        private Database myDatabase = new Database("Database.sdf");

        public FormSheduleData()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSheduleData_Load(object sender, EventArgs e)
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

            string[] semestrNames = Enum.GetNames(typeof(Semestr));
            foreach (string s in semestrNames) comboBoxSemestr.Items.Add(s);
            comboBoxSemestr.Text = semestrNames[1]; // Весенний
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SchoolYear sy = (SchoolYear)schoolYearBindingSource.Current;
            Semestr semestr = (Semestr)Enum.Parse(typeof(Semestr), comboBoxSemestr.Text);

            List<string> ls = new List<string>();

            var q = from ciw in myDatabase.CourseInWork
                    where ciw.SchoolYear.ID == sy.ID && (ciw.Fact == (short?)WorkloadType.Формальная || ciw.Fact == (short?)WorkloadType.Фактическая_и_формальная) && ciw.Semestr == (short?)semestr &&
                      ciw.Group.IsOchniki == radioButtonOchniki.Checked
                    orderby ciw.Course.ID, ciw.Group.Group1, ciw.LectHours descending, ciw.LabHours descending, ciw.UprHours descending
                    select ciw;
            ls.Add("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">");
            ls.Add("<html>");
            ls.Add(" <head>");
            ls.Add("  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1251\">");
            ls.Add("  <title>Распределение учебной нагрузки</title>");
            ls.Add(" </head>");
            ls.Add(" <body>");
            ls.Add("<p align=\"center\">Для составления расписания занятий со студентами представить в учебный отдел к _______________ 20 __ г.</p>");
            ls.Add("<p align=\"right\"><b>Кафедра АСУ</b></p>");
            ls.Add("<h1 align=\"center\">РАСПРЕДЕЛЕНИЕ</h1>");
            string s = String.Format("учебной нагрузки для заочников на {0} семестр {1} учебного года", semestr.ToString().ToLower(), sy.Years);
            ls.Add("<p align=\"center\">" + s + "</p>");
            ls.Add("<table border=\"1\">");
            ls.Add("<thead>");
            ls.Add("<tr>");
            ls.Add("<td><b>Дисциплина</b></td>");
            ls.Add("<td><b>Вид занятий</b></td>");
            ls.Add("<td><b>Номера учебных групп</b></td>");
            ls.Add("<td><b>Ученое звание, должность, фамилия и инициалы преподавателя</b></td>");
            ls.Add("<td><b>Номера лабораторий</b></td>");
            ls.Add("<td><b>Примечание</b></td>");
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
            int counter = 1;
            HtmlTableRow oldhtr = new HtmlTableRow();
            List<HtmlTableRow> lhtr = new List<HtmlTableRow>();
            foreach (CourseInWork ciw in q)
            {
                HtmlTableRow htr = new HtmlTableRow(ciw.Course.Name,
                ciw.LectHours, ciw.LabHours, ciw.UprHours, 
                ciw.Groups,
                ciw.Employee.ShortName,
                ciw.Room);

                if (lhtr.Count > 0 && oldhtr.Course != "" && (oldhtr.Course != htr.Course || oldhtr.Groups != htr.Groups))
                {
                    lhtr[0].Course = counter + ". " + lhtr[0].Course;
                    counter++;
                    for (int i = 0; i < lhtr.Count; i++)
                    {
                        HtmlTableRow r = lhtr[i];
                        if (i == 0)
                            ls.Add(r.TableRow(lhtr.Count));
                        else
                            ls.Add(r.TableRow(0));
                    }
                    lhtr.Clear();
                }
                if ((ciw.LabHours > 0) || (ciw.LectHours > 0) || (ciw.UprHours > 0))
                {
                    if (oldhtr.Course == htr.Course &&
                        oldhtr.Groups == htr.Groups &&
                        (oldhtr.LectHours == 0 || oldhtr.LectHours == null) &&
                        (htr.LectHours == 0 || htr.LectHours == null) &&
                        oldhtr.LabHours > 0 &&
                        htr.LabHours > 0)
                    {
                        oldhtr.Employee += ", " + htr.Employee;
                    }
                    else
                        lhtr.Add(htr);
                    oldhtr = htr;
                }
            }
            if (oldhtr.Course != "")
            {
                if (lhtr.Count > 0)
                {
                    lhtr[0].Course = counter + ". " + lhtr[0].Course;
                    for (int i = 0; i < lhtr.Count; i++)
                    {
                        HtmlTableRow r = lhtr[i];
                        if (i == 0)
                            ls.Add(r.TableRow(lhtr.Count));
                        else
                            ls.Add(r.TableRow(0));
                    }
                }
            }

            ls.Add("</tbody>");
            ls.Add("</table>");
            ls.Add(" </body>");
            ls.Add("</html>");

            File.WriteAllLines("Shedule.html", ls.ToArray(), Encoding.GetEncoding(1251));
            Process.Start("Shedule.html");

            Close();
            
            // MessageBox.Show("Формирование завершено!");

        }
    }

    public class HtmlTableRow
    {
        public string Course = "";
        public decimal? LectHours;
        public decimal? LabHours;
        public decimal? UprHours;
        public string Groups;
        public string Employee;
        public string Room;

        public HtmlTableRow()
        {
        }

        public HtmlTableRow(string ACourse, decimal? ALectHours, decimal? ALabHours, decimal? AUprHours, string AGroups, string AEmployee, string ARoom)
        {
            Course = ACourse;
            LectHours = ALectHours;
            LabHours = ALabHours;
            UprHours = AUprHours;
            Groups = AGroups;
            Employee = AEmployee;
            Room = ARoom;
        }

        public string VidNagruzki
        {
            get
            {
                string vz = "";
                if (LectHours > 0) vz = "лекции";
                if (LabHours > 0) vz = vz + (String.IsNullOrEmpty(vz) ? " " : ", ") + "лаб.раб.";
                if (UprHours > 0) vz = vz + (String.IsNullOrEmpty(vz) ? " " : ", ") + "упражнения";
                return vz;
            }
        }

        public string TableRow(int RowSpan)
        {
            string rs = "";
            rs += "<tr id=\"datarow\">";

            if (RowSpan > 0)
                rs += String.Format("<td rowspan=\"{0}\">{1}</td>", RowSpan, Course);

            rs += "<td>" + VidNagruzki + "</td>";

            rs += "<td>" + Groups + "</td>";

            rs += "<td>" + Employee + "</td>";

            rs += "<td>" + Room + "</td>";

            rs += "<td></td>";

            rs += "</tr>";

            return rs;
        }
    }
}
