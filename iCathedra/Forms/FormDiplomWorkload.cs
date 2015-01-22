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
    public partial class FormDiplomWorkload : Form
    {
        private Database _myDatabase = new Database("Database.sdf");

        public FormDiplomWorkload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           CheckBox cb = new CheckBox();
            cb.Text = "ЧекБокс, звцоаж, выфлао";
           tableLayoutPanelCheckBoxes.Controls.Add(cb);
        }

        private void updateTableLayoutPanelCheckBoxes()
        {
            foreach (DiplomSettings ds in _myDatabase.DiplomSettings)
            {
                int courseId = ds.DiplomCourseId;
                int consCourseId = ds.ConsCourseId;

                var q = from ciw in _myDatabase.CourseInWork
                    where ciw.CourseID == courseId && ciw.SchoolYearID == iCathedra_Settings.SchoolYearId
                    select ciw;

                foreach (CourseInWork ciw in q)
                {
                    #region Ищем "смежную нагрузку" в консультациях
                    CourseInWork ciw2 = (from c in _myDatabase.CourseInWork
                        where c.CourseID == consCourseId && 
                            c.SchoolYearID == iCathedra_Settings.SchoolYearId &&
                            c.Group1ID == ciw.Group1ID
                        select c).First();

                    string error = null;
                    if (ciw2 == null)
                        error = " (НЕ НАЙДЕНЫ КОНСУЛЬТАЦИИ)";
                    #endregion

                    int studentCount = (int) (ciw.ProchHours/ds.DiplomHoursPerStudent);
                    int studentCountPerCons = 0;
                    if (ciw2 != null)
                        studentCountPerCons = (int) (ciw2.ProchHours/ds.ConsHoursPerStudent);
                    if (studentCount != studentCountPerCons)
                        error = " (НЕ СОВПАДАЕТ КОЛИЧЕСТВО СТУДЕНТОВ ПО РУКОВОДСТВУ И КОНСУЛЬТАЦИЯМ)";
                    CheckBox cb = new CheckBox();
                    cb.Text = String.Format(@"{0}, {1}, {2} студ.{3}",
                        ciw.Groups, ds.CourseName, studentCount, error);
                    tableLayoutPanelCheckBoxes.Controls.Add(cb);
                }

            }
        }

        private void FormDiplomWorkload_Load(object sender, EventArgs e)
        {
            updateTableLayoutPanelCheckBoxes();
        }
    }
}
