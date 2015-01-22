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
    public partial class FormRate : Form
    {
        private Database myDatabase = new Database("Database.sdf");

        public FormRate()
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

        private void FormRate_Load(object sender, EventArgs e)
        {
            foreach(SchoolYear sy in myDatabase.SchoolYear)
            {
                toolStripComboBox1.Items.Add(sy);
            }
            toolStripComboBox1.SelectedIndex = 0;
            updateBindingSourceRate((SchoolYear)toolStripComboBox1.Items[0]);

            bindingSourceEmployee.DataSource = myDatabase.Employee;
            bindingSourcePost.DataSource = myDatabase.Post;

            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridViewRate_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.DesiredType.FullName.ToString() == "iCathedra.Employee")
            {
                string s = e.Value as string;
                Employee em = (from employee in this.bindingSourceEmployee.OfType<Employee>()
                               where employee.ToString() == s
                               select employee).FirstOrDefault();
                e.Value = em;
            }
            else if (e.DesiredType.FullName.ToString() == "iCathedra.Post")
            {
                string s = e.Value as string;
                Post p = (from post in this.bindingSourcePost.OfType<Post>()
                               where post.ToString() == s
                               select post).FirstOrDefault();
                e.Value = p;
            }
            e.ParsingApplied = true;
        }

        private void updateBindingSourceRate(SchoolYear ASchoolYear)
        {
            bindingSourceRate.DataSource = from rate in myDatabase.Rate
                                           where rate.SchoolYearID == ASchoolYear.ID
                                           select rate;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBindingSourceRate((SchoolYear)toolStripComboBox1.SelectedItem);
        }

        private void dataGridViewRate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridViewRate.Rows[e.RowIndex].Cells["SchoolYear"].Value = (SchoolYear)toolStripComboBox1.SelectedItem;
            }
        }

        private void dataGridViewRate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewRate.Refresh();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string result = "";
            int count = 0;
            decimal totalRate = 0;
            decimal totalBaseSalary = 0;
            decimal totalPostSalary = 0;
            decimal totalGradeSurcharge = 0;
            decimal totalPostSurcharge = 0;
            int totalPochFondLimit = 0; 
            foreach (Rate r in this.bindingSourceRate)
            {
                count++;
                totalRate += Utils.SafeDecimal(r.Rate1);
                totalBaseSalary += r.BaseSalary;
                totalPostSalary += r.PostSalary;
                totalGradeSurcharge += r.GradeSurcharge;
                totalPostSurcharge += r.PostSurcharge;
                totalPochFondLimit += r.PochFondLimit;
            }

            result = String.Format("Количество записей - {0},\n" +
                "ставка итого - {1},\n" +
                "базовый оклад итого - {2},\n" +
                "должностной оклад итого - {3},\n" +
                "доплата за степень итого - {4},\n" +
                "доплата за должность итого - {5},\n" +
                "оклад итого - {6},\n" +
                "лимит почасового фонда - {7}.",
                count, totalRate, totalBaseSalary, totalPostSalary, totalGradeSurcharge, totalPostSurcharge,
                totalBaseSalary + totalPostSalary + totalGradeSurcharge + totalPostSurcharge, totalPochFondLimit);

            MessageBox.Show(result);
        }
    }
}
