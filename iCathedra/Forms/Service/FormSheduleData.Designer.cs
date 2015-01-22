namespace iCathedra.Forms.Service
{
    partial class FormSheduleData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxSchoolYear = new System.Windows.Forms.ComboBox();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelSchoolYear = new System.Windows.Forms.Label();
            this.labelSemestr = new System.Windows.Forms.Label();
            this.comboBoxSemestr = new System.Windows.Forms.ComboBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxWorkloadType = new System.Windows.Forms.GroupBox();
            this.radioButtonOchniki = new System.Windows.Forms.RadioButton();
            this.radioButtonZaochniki = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            this.groupBoxWorkloadType.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSchoolYear
            // 
            this.comboBoxSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSchoolYear.DataSource = this.schoolYearBindingSource;
            this.comboBoxSchoolYear.FormattingEnabled = true;
            this.comboBoxSchoolYear.Location = new System.Drawing.Point(182, 6);
            this.comboBoxSchoolYear.Name = "comboBoxSchoolYear";
            this.comboBoxSchoolYear.Size = new System.Drawing.Size(251, 21);
            this.comboBoxSchoolYear.TabIndex = 5;
            // 
            // schoolYearBindingSource
            // 
            this.schoolYearBindingSource.DataSource = typeof(iCathedra.SchoolYear);
            // 
            // labelSchoolYear
            // 
            this.labelSchoolYear.AutoSize = true;
            this.labelSchoolYear.Location = new System.Drawing.Point(12, 9);
            this.labelSchoolYear.Name = "labelSchoolYear";
            this.labelSchoolYear.Size = new System.Drawing.Size(75, 13);
            this.labelSchoolYear.TabIndex = 4;
            this.labelSchoolYear.Text = "Учебный год:";
            // 
            // labelSemestr
            // 
            this.labelSemestr.AutoSize = true;
            this.labelSemestr.Location = new System.Drawing.Point(12, 33);
            this.labelSemestr.Name = "labelSemestr";
            this.labelSemestr.Size = new System.Drawing.Size(54, 13);
            this.labelSemestr.TabIndex = 6;
            this.labelSemestr.Text = "Семестр:";
            // 
            // comboBoxSemestr
            // 
            this.comboBoxSemestr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSemestr.FormattingEnabled = true;
            this.comboBoxSemestr.Location = new System.Drawing.Point(182, 33);
            this.comboBoxSemestr.Name = "comboBoxSemestr";
            this.comboBoxSemestr.Size = new System.Drawing.Size(251, 21);
            this.comboBoxSemestr.TabIndex = 5;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreate.Location = new System.Drawing.Point(246, 112);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(106, 23);
            this.buttonCreate.TabIndex = 7;
            this.buttonCreate.Text = "Сформировать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(358, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Выход";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxWorkloadType
            // 
            this.groupBoxWorkloadType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWorkloadType.Controls.Add(this.radioButtonZaochniki);
            this.groupBoxWorkloadType.Controls.Add(this.radioButtonOchniki);
            this.groupBoxWorkloadType.Location = new System.Drawing.Point(12, 60);
            this.groupBoxWorkloadType.Name = "groupBoxWorkloadType";
            this.groupBoxWorkloadType.Size = new System.Drawing.Size(421, 37);
            this.groupBoxWorkloadType.TabIndex = 9;
            this.groupBoxWorkloadType.TabStop = false;
            this.groupBoxWorkloadType.Text = "Тип нагрузки";
            // 
            // radioButtonOchniki
            // 
            this.radioButtonOchniki.AutoSize = true;
            this.radioButtonOchniki.Checked = true;
            this.radioButtonOchniki.Location = new System.Drawing.Point(17, 14);
            this.radioButtonOchniki.Name = "radioButtonOchniki";
            this.radioButtonOchniki.Size = new System.Drawing.Size(62, 17);
            this.radioButtonOchniki.TabIndex = 0;
            this.radioButtonOchniki.TabStop = true;
            this.radioButtonOchniki.Text = "Очники";
            this.radioButtonOchniki.UseVisualStyleBackColor = true;
            // 
            // radioButtonZaochniki
            // 
            this.radioButtonZaochniki.AutoSize = true;
            this.radioButtonZaochniki.Location = new System.Drawing.Point(170, 14);
            this.radioButtonZaochniki.Name = "radioButtonZaochniki";
            this.radioButtonZaochniki.Size = new System.Drawing.Size(73, 17);
            this.radioButtonZaochniki.TabIndex = 0;
            this.radioButtonZaochniki.Text = "Заочники";
            this.radioButtonZaochniki.UseVisualStyleBackColor = true;
            // 
            // FormSheduleData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 147);
            this.Controls.Add(this.groupBoxWorkloadType);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelSemestr);
            this.Controls.Add(this.comboBoxSemestr);
            this.Controls.Add(this.comboBoxSchoolYear);
            this.Controls.Add(this.labelSchoolYear);
            this.Name = "FormSheduleData";
            this.Text = "Данные для расписаний";
            this.Load += new System.EventHandler(this.FormSheduleData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            this.groupBoxWorkloadType.ResumeLayout(false);
            this.groupBoxWorkloadType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSchoolYear;
        private System.Windows.Forms.Label labelSchoolYear;
        private System.Windows.Forms.Label labelSemestr;
        private System.Windows.Forms.ComboBox comboBoxSemestr;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private System.Windows.Forms.GroupBox groupBoxWorkloadType;
        private System.Windows.Forms.RadioButton radioButtonZaochniki;
        private System.Windows.Forms.RadioButton radioButtonOchniki;
    }
}