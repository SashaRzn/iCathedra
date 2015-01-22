namespace iCathedra.Forms
{
    partial class FormPreferences
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelSchoolYear = new System.Windows.Forms.Label();
            this.comboBoxSchoolYear = new System.Windows.Forms.ComboBox();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelLoadPercent = new System.Windows.Forms.Label();
            this.textBoxLoadPercent = new System.Windows.Forms.TextBox();
            this.labelPochFondKodText = new System.Windows.Forms.Label();
            this.textBoxPochFondKodValue = new System.Windows.Forms.TextBox();
            this.labelFreeHoursEmployeeId = new System.Windows.Forms.Label();
            this.textBoxFreeHoursEmployeeId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(384, 154);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(465, 154);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelSchoolYear
            // 
            this.labelSchoolYear.AutoSize = true;
            this.labelSchoolYear.Location = new System.Drawing.Point(14, 19);
            this.labelSchoolYear.Name = "labelSchoolYear";
            this.labelSchoolYear.Size = new System.Drawing.Size(75, 13);
            this.labelSchoolYear.TabIndex = 2;
            this.labelSchoolYear.Text = "Учебный год:";
            // 
            // comboBoxSchoolYear
            // 
            this.comboBoxSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSchoolYear.DataSource = this.schoolYearBindingSource;
            this.comboBoxSchoolYear.FormattingEnabled = true;
            this.comboBoxSchoolYear.Location = new System.Drawing.Point(267, 19);
            this.comboBoxSchoolYear.Name = "comboBoxSchoolYear";
            this.comboBoxSchoolYear.Size = new System.Drawing.Size(266, 21);
            this.comboBoxSchoolYear.TabIndex = 3;
            // 
            // schoolYearBindingSource
            // 
            this.schoolYearBindingSource.DataSource = typeof(iCathedra.SchoolYear);
            // 
            // labelLoadPercent
            // 
            this.labelLoadPercent.AutoSize = true;
            this.labelLoadPercent.Location = new System.Drawing.Point(14, 46);
            this.labelLoadPercent.Name = "labelLoadPercent";
            this.labelLoadPercent.Size = new System.Drawing.Size(164, 13);
            this.labelLoadPercent.TabIndex = 4;
            this.labelLoadPercent.Text = "Процент отклонения нагрузки:";
            // 
            // textBoxLoadPercent
            // 
            this.textBoxLoadPercent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLoadPercent.Location = new System.Drawing.Point(267, 46);
            this.textBoxLoadPercent.Name = "textBoxLoadPercent";
            this.textBoxLoadPercent.Size = new System.Drawing.Size(266, 20);
            this.textBoxLoadPercent.TabIndex = 5;
            // 
            // labelPochFondKodText
            // 
            this.labelPochFondKodText.AutoSize = true;
            this.labelPochFondKodText.Location = new System.Drawing.Point(14, 72);
            this.labelPochFondKodText.Name = "labelPochFondKodText";
            this.labelPochFondKodText.Size = new System.Drawing.Size(187, 13);
            this.labelPochFondKodText.TabIndex = 6;
            this.labelPochFondKodText.Text = "Код сотрудника \"Почасовой фонд\":";
            // 
            // textBoxPochFondKodValue
            // 
            this.textBoxPochFondKodValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPochFondKodValue.Location = new System.Drawing.Point(267, 72);
            this.textBoxPochFondKodValue.Name = "textBoxPochFondKodValue";
            this.textBoxPochFondKodValue.Size = new System.Drawing.Size(266, 20);
            this.textBoxPochFondKodValue.TabIndex = 7;
            // 
            // labelFreeHoursEmployeeId
            // 
            this.labelFreeHoursEmployeeId.AutoSize = true;
            this.labelFreeHoursEmployeeId.Location = new System.Drawing.Point(14, 100);
            this.labelFreeHoursEmployeeId.Name = "labelFreeHoursEmployeeId";
            this.labelFreeHoursEmployeeId.Size = new System.Drawing.Size(250, 13);
            this.labelFreeHoursEmployeeId.TabIndex = 6;
            this.labelFreeHoursEmployeeId.Text = "Код сотрудника \"Нераспределенная нагрузка\":";
            // 
            // textBoxFreeHoursEmployeeId
            // 
            this.textBoxFreeHoursEmployeeId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFreeHoursEmployeeId.Location = new System.Drawing.Point(267, 97);
            this.textBoxFreeHoursEmployeeId.Name = "textBoxFreeHoursEmployeeId";
            this.textBoxFreeHoursEmployeeId.Size = new System.Drawing.Size(266, 20);
            this.textBoxFreeHoursEmployeeId.TabIndex = 7;
            // 
            // FormPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 189);
            this.Controls.Add(this.textBoxFreeHoursEmployeeId);
            this.Controls.Add(this.textBoxPochFondKodValue);
            this.Controls.Add(this.labelFreeHoursEmployeeId);
            this.Controls.Add(this.labelPochFondKodText);
            this.Controls.Add(this.textBoxLoadPercent);
            this.Controls.Add(this.labelLoadPercent);
            this.Controls.Add(this.comboBoxSchoolYear);
            this.Controls.Add(this.labelSchoolYear);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "FormPreferences";
            this.Text = "Установки";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelSchoolYear;
        private System.Windows.Forms.ComboBox comboBoxSchoolYear;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private System.Windows.Forms.Label labelLoadPercent;
        private System.Windows.Forms.TextBox textBoxLoadPercent;
        private System.Windows.Forms.Label labelPochFondKodText;
        private System.Windows.Forms.TextBox textBoxPochFondKodValue;
        private System.Windows.Forms.Label labelFreeHoursEmployeeId;
        private System.Windows.Forms.TextBox textBoxFreeHoursEmployeeId;
    }
}