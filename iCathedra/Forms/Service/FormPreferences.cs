using System;
using System.Globalization;
using System.Windows.Forms;

namespace iCathedra.Forms
{
    public partial class FormPreferences : Form
    {
        private readonly Database _myDatabase = new Database("Database.sdf");

        public FormPreferences()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (schoolYearBindingSource.Current != null)
            {
                SchoolYear sy = (SchoolYear)schoolYearBindingSource.Current;
                iCathedra_Settings.SchoolYearId = sy.ID;
               
            }
            else
            {
                MessageBox.Show(@"Не задан элемент в выпадающем списке!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxSchoolYear.Focus();
                return;
            }
            decimal percent;
            if (!Decimal.TryParse(textBoxLoadPercent.Text, out percent))
            {
                MessageBox.Show(@"Ошибочное значение процента!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLoadPercent.Focus();
                return;
            }
            if (percent < 0 || percent > 100)
            {
                MessageBox.Show(@"Значение процента может находиться только в диапазоне от 0 до 100!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLoadPercent.Focus();
                return;
            }
            iCathedra_Settings.LoadPercent = percent;
            int pochFondKod;
            if (!Int32.TryParse(textBoxPochFondKodValue.Text, out pochFondKod))
            {
                MessageBox.Show(@"Ошибочное значение кода сотрудника!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPochFondKodValue.Focus();
                return;
            }
            iCathedra_Settings.PochFondKod = pochFondKod;

            int freeHoursEmployeeId;
            if (!Int32.TryParse(textBoxFreeHoursEmployeeId.Text, out freeHoursEmployeeId))
            {
                MessageBox.Show(@"Ошибочное значение кода сотрудника!", @"Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxFreeHoursEmployeeId.Focus();
                return;
            }
            iCathedra_Settings.FreeHoursEmployeeId = freeHoursEmployeeId;
            Close();
        }

        private void FormPreferences_Load(object sender, EventArgs e)
        {
            schoolYearBindingSource.DataSource = _myDatabase.SchoolYear;
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
            textBoxLoadPercent.Text = iCathedra_Settings.LoadPercent.ToString(CultureInfo.InvariantCulture);
            textBoxPochFondKodValue.Text = iCathedra_Settings.PochFondKod.ToString(CultureInfo.InvariantCulture);
            textBoxFreeHoursEmployeeId.Text =
                iCathedra_Settings.FreeHoursEmployeeId.ToString(CultureInfo.InvariantCulture);
        }
    }
}
