using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace iCathedra
{
    public partial class FormEmployee : Form
    {
        private Database myDatabase = new Database("Database.sdf");

        public FormEmployee()
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

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = myDatabase.GetTable<Employee>();
            postBindingSource.DataSource = myDatabase.GetTable<Post>();

            this.WindowState = FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myDatabase.SubmitChanges();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            string s = e.Value as string;

            //Требуется OfType, так как postBindingSource возвращает экземпляры объекта типа.
            Post p = (from post in this.postBindingSource.OfType<Post>()
                      where post.ToString() == s
                      select post).FirstOrDefault();

            e.Value = p;
            e.ParsingApplied = true;
        }
    }
}
