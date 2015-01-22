using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iCathedra.Forms
{
    public partial class FormSelectWorkloadHourType : Form
    {
        private CourseInWork _ciw;
        public WorkloadHourType SelectedWorkloadHourType;
        
        public decimal NewLabHours = 0;
        public decimal OldLabHours = 0;

        public decimal NewProchHours = 0;
        public decimal OldProchHours = 0;

        public FormSelectWorkloadHourType(CourseInWork Aciw)
        {
            InitializeComponent();
            _ciw = Aciw;
        }

        private void FormSelectWorkloadHourType_Load(object sender, EventArgs e)
        {
            foreach(WorkloadHourType wht in Enum.GetValues(typeof(WorkloadHourType)))
            {
                var cb = new CheckBox {Text = wht.ToString().Replace('_', ' '), AutoSize = true, Tag = wht};
                var tb = new TextBox {ReadOnly = true, AutoSize = false};

                if (wht == WorkloadHourType.None)
                {
                    continue;
                }
                else if (wht == WorkloadHourType.Все_виды)
                {
                    cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
                    cb.Checked = true;
                }
                else
                {
                    decimal hours = _ciw.GetHours(wht);
                    if (hours > 0)
                    {
                        cb.Checked = true;
                        cb.Enabled = true;
                        tb.Text = hours.ToString(CultureInfo.InvariantCulture);
                        if (wht == WorkloadHourType.Лабораторные)
                        {
                            tb.ReadOnly = false;
                            tb.Leave += tb_LeaveLab;
                            OldLabHours = hours;
                        }
                        if (wht == WorkloadHourType.Прочее)
                        {
                            tb.ReadOnly = false;
                            tb.Leave += tb_LeaveProch;
                            OldProchHours = hours;
                        }
                    }
                    else
                    {
                        cb.Checked = false;
                        cb.Enabled = false;
                    }
                }

                tableLayoutPanelCheckBoxes.Controls.Add(cb);
                tableLayoutPanelCheckBoxes.Controls.Add(tb);
            }
        }

        private void tb_LeaveProch(object sender, EventArgs eventArgs)
        {
            TextBox tb = sender as TextBox;
            try
            {
                decimal newProchHours = Convert.ToDecimal(tb.Text);
                if (newProchHours > OldProchHours)
                {
                    MessageBox.Show(String.Format("Выделяемое количество часов не может превышать выделенного на данный вид нагрузки ({0})",
                        OldLabHours), @"Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    tb.Focus();
                }
                else
                {
                    NewProchHours = newProchHours;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Некорректное значение количества часов", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tb.Focus();
            } 
        }

        private void tb_LeaveLab(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            try
            {
                decimal newLabHours = Convert.ToDecimal(tb.Text);
                if (newLabHours > OldLabHours)
                {
                    MessageBox.Show(String.Format("Выделяемое количество часов не может превышать выделенного на данный вид нагрузки ({0})",
                        OldLabHours), @"Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    tb.Focus();
                }
                else
                {
                    NewLabHours = newLabHours;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Некорректное значение количества часов", @"Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tb.Focus();
            }
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.tableLayoutPanelCheckBoxes.Controls)
            {
                var box = c as CheckBox;
                if (box != null)
                {
                    CheckBox cb = box;
                    if (cb.Enabled) cb.Checked = (sender as CheckBox).Checked;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SelectedWorkloadHourType = WorkloadHourType.None;
            foreach (Control c in this.tableLayoutPanelCheckBoxes.Controls)
            {
                var box = c as CheckBox;
                if (box != null)
                {
                    var cb = (CheckBox) c;
                    WorkloadHourType currentWorkloadHourType = (WorkloadHourType) cb.Tag;
                    if (cb.Checked && (WorkloadHourType) cb.Tag != WorkloadHourType.Все_виды)
                        SelectedWorkloadHourType = SelectedWorkloadHourType | currentWorkloadHourType;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
