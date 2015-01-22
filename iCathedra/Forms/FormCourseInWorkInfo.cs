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
    public partial class FormCourseInWorkInfo : Form
    {
        private CourseInWork localCourseInWork;
        private Database myDatabase;

        public FormCourseInWorkInfo(CourseInWork ACourseInWork, Database AMyDatabase)
        {
            InitializeComponent();
            localCourseInWork = ACourseInWork;
            myDatabase = AMyDatabase;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCourseInWorkInfo_Load(object sender, EventArgs e)
        {
            textBoxCourseName.Text = localCourseInWork.FullName;

            List<CourseInWork> lciw = (from ciw in myDatabase.CourseInWork
                                      where ciw.CourseID == localCourseInWork.CourseID &&
                                         ciw.Group1ID == localCourseInWork.Group1ID &&
                                         ciw.Semestr == localCourseInWork.Semestr &&
                                         ciw.SchoolYearID == localCourseInWork.SchoolYearID
                                      orderby ciw.CourseID, ciw.Group1ID, ciw.Semestr
                                      select ciw).ToList<CourseInWork>();
            bindingSourceFullLoad.DataSource = lciw;
            decimal workload = 0;
            foreach (CourseInWork ciw in lciw)
            {
                if (ciw.Fact == (short)WorkloadType.Фактическая_и_формальная ||
                    ciw.Fact == (short)WorkloadType.Формальная)
                workload += ciw.AllHours;
            }
            labelWorkloadTotalValue.Text = "Всего нагрузки по курсу - " + workload.ToString();

        }
    }
}

