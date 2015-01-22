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
    public partial class FormSelectCourseInWork : Form
    {
        private Employee _filterEmployee;
        private Group _filterGroup;
        private Semestr _filterSemestr;
        private SchoolYear _filterSchoolYear;
        private WorkloadType _filterWorkloadType;
        private CourseInWork _exceptCourseInWork;
        private Database myDatabase;

        public CourseInWork SelectedCourseInWork;

        public FormSelectCourseInWork(Database AmyDatabase, Employee filterEmployee, Group filterGroup, 
            Semestr filterSemestr, SchoolYear filterSchoolYear, WorkloadType filterWorkloadType,
            CourseInWork exceptCourseInWork)
        {
            InitializeComponent();
            myDatabase = AmyDatabase;
            _filterEmployee = filterEmployee;
            _filterGroup = filterGroup;
            _filterSemestr = filterSemestr;
            _filterSchoolYear = filterSchoolYear;
            _filterWorkloadType = filterWorkloadType;
            _exceptCourseInWork = exceptCourseInWork;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelectedCourseInWork = (CourseInWork)bindingSourceCourseInWork.Current;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void FormSelectCourseInWork_Load(object sender, EventArgs e)
        {
            var q = from ciw in myDatabase.CourseInWork
                    where ciw.EmployeeID == _filterEmployee.Id &&
                        ciw.Group1ID == _filterGroup.ID &&
                        ciw.Semestr == (short)_filterSemestr &&
                        ciw.SchoolYearID == _filterSchoolYear.ID &&
                        ciw.Fact == (short)_filterWorkloadType &&
                        ciw.ID != _exceptCourseInWork.ID
                    select ciw;
            bindingSourceCourseInWork.DataSource = q;


        }

        private void dataGridViewCourseInWork_DoubleClick(object sender, EventArgs e)
        {
            SelectedCourseInWork = (CourseInWork)bindingSourceCourseInWork.Current;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
