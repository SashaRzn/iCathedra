namespace iCathedra.Forms
{
    partial class FormSelectCourseInWork
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
            this.bindingSourceCourseInWork = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewCourseInWork = new System.Windows.Forms.DataGridView();
            this.Groups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemestrString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Workload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCourseInWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourseInWork)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(1005, 380);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(924, 380);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // bindingSourceCourseInWork
            // 
            this.bindingSourceCourseInWork.DataSource = typeof(iCathedra.CourseInWork);
            // 
            // dataGridViewCourseInWork
            // 
            this.dataGridViewCourseInWork.AllowUserToAddRows = false;
            this.dataGridViewCourseInWork.AllowUserToDeleteRows = false;
            this.dataGridViewCourseInWork.AllowUserToResizeColumns = false;
            this.dataGridViewCourseInWork.AllowUserToResizeRows = false;
            this.dataGridViewCourseInWork.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCourseInWork.AutoGenerateColumns = false;
            this.dataGridViewCourseInWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourseInWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Groups,
            this.ShortName,
            this.SemestrString,
            this.Workload,
            this.Employee});
            this.dataGridViewCourseInWork.DataSource = this.bindingSourceCourseInWork;
            this.dataGridViewCourseInWork.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCourseInWork.Name = "dataGridViewCourseInWork";
            this.dataGridViewCourseInWork.RowHeadersVisible = false;
            this.dataGridViewCourseInWork.Size = new System.Drawing.Size(1068, 362);
            this.dataGridViewCourseInWork.TabIndex = 2;
            this.dataGridViewCourseInWork.DoubleClick += new System.EventHandler(this.dataGridViewCourseInWork_DoubleClick);
            // 
            // Groups
            // 
            this.Groups.DataPropertyName = "Groups";
            this.Groups.HeaderText = "Группы";
            this.Groups.Name = "Groups";
            // 
            // ShortName
            // 
            this.ShortName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ShortName.DataPropertyName = "Course";
            this.ShortName.HeaderText = "Намиенование курса";
            this.ShortName.Name = "ShortName";
            // 
            // SemestrString
            // 
            this.SemestrString.DataPropertyName = "SemestrString";
            this.SemestrString.HeaderText = "Семестр";
            this.SemestrString.Name = "SemestrString";
            // 
            // Workload
            // 
            this.Workload.DataPropertyName = "Workload";
            this.Workload.FillWeight = 250F;
            this.Workload.HeaderText = "Нагрузка";
            this.Workload.Name = "Workload";
            this.Workload.Width = 250;
            // 
            // Employee
            // 
            this.Employee.DataPropertyName = "Employee";
            this.Employee.FillWeight = 200F;
            this.Employee.HeaderText = "Ведет";
            this.Employee.Name = "Employee";
            this.Employee.Width = 200;
            // 
            // FormSelectCourseInWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 415);
            this.Controls.Add(this.dataGridViewCourseInWork);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormSelectCourseInWork";
            this.Text = "Выберите нагрузку";
            this.Load += new System.EventHandler(this.FormSelectCourseInWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCourseInWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourseInWork)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.BindingSource bindingSourceCourseInWork;
        private System.Windows.Forms.DataGridView dataGridViewCourseInWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn Groups;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemestrString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Workload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
    }
}