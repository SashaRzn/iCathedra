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
    public partial class FormBreakCourse : Form
    {
        Database myDatabase;

        public Employee Employee;
        private CourseInWork courseInWork;

        public FormBreakCourse(Database Database, CourseInWork ACourseInWork )
        {
            InitializeComponent();
            this.myDatabase = Database;
            this.courseInWork = ACourseInWork;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FormBreakCourse_Load(object sender, EventArgs e)
        {
            this.bindingSourceEmployee.DataSource = myDatabase.Employee;
            this.Employee = (Employee)this.bindingSourceEmployee.Current;

            this.labelComment.Text = "Выполняется разбиение курса " + courseInWork.FullName;
        }

        private void bindingSourceEmployee_CurrentItemChanged(object sender, EventArgs e)
        {
            this.Employee = (Employee)this.bindingSourceEmployee.Current;
        }
    }
}
