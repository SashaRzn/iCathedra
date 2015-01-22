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
    public partial class FormSelectEmployee : Form
    {
        public Employee SelectedEmployee = null;
        private Database myDatabase;

        public FormSelectEmployee(Database AMyDatabase)
        {
            InitializeComponent();
            myDatabase = AMyDatabase;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            SelectedEmployee = (Employee)bindingSourceEmployee.Current;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void FormChoiceEmployee_Load(object sender, EventArgs e)
        {
            List<Employee> le = (from em in myDatabase.Employee
                                    where !em.NonActive
                                    orderby em.Fio
                                    select em).ToList<Employee>();
            bindingSourceEmployee.DataSource = le;
        }
    }
}
