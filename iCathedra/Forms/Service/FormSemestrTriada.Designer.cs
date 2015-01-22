namespace iCathedra.Forms.Service
{
    partial class FormSemestrTriada
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.comboBoxSchoolYear = new System.Windows.Forms.ComboBox();
            this.schoolYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelSchoolYear = new System.Windows.Forms.Label();
            this.groupBoxTriada = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            this.groupBoxTriada.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(592, 133);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(480, 133);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(106, 23);
            this.buttonOk.TabIndex = 11;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // comboBoxSchoolYear
            // 
            this.comboBoxSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSchoolYear.DataSource = this.schoolYearBindingSource;
            this.comboBoxSchoolYear.FormattingEnabled = true;
            this.comboBoxSchoolYear.Location = new System.Drawing.Point(182, 6);
            this.comboBoxSchoolYear.Name = "comboBoxSchoolYear";
            this.comboBoxSchoolYear.Size = new System.Drawing.Size(480, 21);
            this.comboBoxSchoolYear.TabIndex = 10;
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
            this.labelSchoolYear.TabIndex = 9;
            this.labelSchoolYear.Text = "Учебный год:";
            // 
            // groupBoxTriada
            // 
            this.groupBoxTriada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTriada.Controls.Add(this.checkBox3);
            this.groupBoxTriada.Controls.Add(this.checkBox2);
            this.groupBoxTriada.Controls.Add(this.checkBox1);
            this.groupBoxTriada.Location = new System.Drawing.Point(12, 33);
            this.groupBoxTriada.Name = "groupBoxTriada";
            this.groupBoxTriada.Size = new System.Drawing.Size(647, 94);
            this.groupBoxTriada.TabIndex = 13;
            this.groupBoxTriada.TabStop = false;
            this.groupBoxTriada.Text = "Триада семестра";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(17, 65);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(339, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Третья триада (КП, КР, зачеты, экзамены второго семестра)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(17, 42);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(623, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Вторая триада (КП, КР, зачеты, экзамены первого семестра; лабораторные, лекции, у" +
    "пражнения второго семестра)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(17, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(389, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Первая триада (лабораторные, лекции, упражнения первого семестра)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormSemestrTriada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 168);
            this.Controls.Add(this.groupBoxTriada);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.comboBoxSchoolYear);
            this.Controls.Add(this.labelSchoolYear);
            this.Name = "FormSemestrTriada";
            this.Text = "Выбор триады";
            this.Load += new System.EventHandler(this.FormSemestrTriada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            this.groupBoxTriada.ResumeLayout(false);
            this.groupBoxTriada.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ComboBox comboBoxSchoolYear;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private System.Windows.Forms.Label labelSchoolYear;
        private System.Windows.Forms.GroupBox groupBoxTriada;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}