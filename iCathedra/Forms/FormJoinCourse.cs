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
    public partial class FormJoinCourse : Form
    {
        private CourseInWork courseInWork;
        private BindingSource destinationBindingSource;

        public FormJoinCourse(CourseInWork ACourseInWork, BindingSource ADestinationBindingSource)
        {
            InitializeComponent();

            courseInWork = ACourseInWork;
            destinationBindingSource = ADestinationBindingSource;
        }

        private void FormJoinCourse_Load(object sender, EventArgs e)
        {
            this.labelComment.Text = "Выполняется объединение курса " + courseInWork.FullName;

            var q = (from ciw in destinationBindingSource.OfType<CourseInWork>()
                    where ciw.Course.ID == courseInWork.Course.ID &&
                          ciw.SchoolYear.ID == courseInWork.SchoolYear.ID &&
                          ciw.Semestr == courseInWork.Semestr &&
                          ciw.Group.Group1 == courseInWork.Group.Group1
                    select ciw).ToList<CourseInWork>();

            foreach (CourseInWork ciw in q)
            {
                if (ciw.ID != courseInWork.ID)
                {
                    RadioButton rb = new RadioButton();
                    rb.AutoSize = true;
                    rb.Tag = ciw;
                    rb.Text = ciw.ShortName;
                    tableLayoutPanel1.Controls.Add(rb);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
