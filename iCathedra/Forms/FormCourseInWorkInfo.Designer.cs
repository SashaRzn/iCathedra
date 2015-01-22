namespace iCathedra.Forms
{
    partial class FormCourseInWorkInfo
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
            this.labelCourseName = new System.Windows.Forms.Label();
            this.textBoxCourseName = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelFullNagruz = new System.Windows.Forms.Label();
            this.bindingSourceFullLoad = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewFullLoad = new System.Windows.Forms.DataGridView();
            this.labelWorkloadTotalValue = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkloadTypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Workload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFullLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFullLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCourseName
            // 
            this.labelCourseName.AutoSize = true;
            this.labelCourseName.Location = new System.Drawing.Point(12, 9);
            this.labelCourseName.Name = "labelCourseName";
            this.labelCourseName.Size = new System.Drawing.Size(118, 13);
            this.labelCourseName.TabIndex = 0;
            this.labelCourseName.Text = "Наименование курса:";
            // 
            // textBoxCourseName
            // 
            this.textBoxCourseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCourseName.Location = new System.Drawing.Point(15, 25);
            this.textBoxCourseName.Multiline = true;
            this.textBoxCourseName.Name = "textBoxCourseName";
            this.textBoxCourseName.ReadOnly = true;
            this.textBoxCourseName.Size = new System.Drawing.Size(906, 54);
            this.textBoxCourseName.TabIndex = 1;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(846, 546);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelFullNagruz
            // 
            this.labelFullNagruz.AutoSize = true;
            this.labelFullNagruz.Location = new System.Drawing.Point(12, 93);
            this.labelFullNagruz.Name = "labelFullNagruz";
            this.labelFullNagruz.Size = new System.Drawing.Size(104, 13);
            this.labelFullNagruz.TabIndex = 3;
            this.labelFullNagruz.Text = "Нагрузка по курсу:";
            // 
            // bindingSourceFullLoad
            // 
            this.bindingSourceFullLoad.DataSource = typeof(iCathedra.CourseInWork);
            // 
            // dataGridViewFullLoad
            // 
            this.dataGridViewFullLoad.AllowUserToAddRows = false;
            this.dataGridViewFullLoad.AllowUserToDeleteRows = false;
            this.dataGridViewFullLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFullLoad.AutoGenerateColumns = false;
            this.dataGridViewFullLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFullLoad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.Employee,
            this.WorkloadTypeString,
            this.Workload});
            this.dataGridViewFullLoad.DataSource = this.bindingSourceFullLoad;
            this.dataGridViewFullLoad.Location = new System.Drawing.Point(15, 109);
            this.dataGridViewFullLoad.Name = "dataGridViewFullLoad";
            this.dataGridViewFullLoad.ReadOnly = true;
            this.dataGridViewFullLoad.RowHeadersVisible = false;
            this.dataGridViewFullLoad.Size = new System.Drawing.Size(906, 388);
            this.dataGridViewFullLoad.TabIndex = 4;
            // 
            // labelWorkloadTotalValue
            // 
            this.labelWorkloadTotalValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelWorkloadTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWorkloadTotalValue.Location = new System.Drawing.Point(12, 510);
            this.labelWorkloadTotalValue.Name = "labelWorkloadTotalValue";
            this.labelWorkloadTotalValue.Size = new System.Drawing.Size(909, 23);
            this.labelWorkloadTotalValue.TabIndex = 5;
            this.labelWorkloadTotalValue.Text = "0";
            this.labelWorkloadTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Преподаватель";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            // 
            // WorkloadTypeString
            // 
            this.WorkloadTypeString.DataPropertyName = "WorkloadTypeString";
            this.WorkloadTypeString.FillWeight = 200F;
            this.WorkloadTypeString.HeaderText = "Тип нагрузки";
            this.WorkloadTypeString.Name = "WorkloadTypeString";
            this.WorkloadTypeString.ReadOnly = true;
            this.WorkloadTypeString.Width = 200;
            // 
            // Workload
            // 
            this.Workload.DataPropertyName = "Workload";
            this.Workload.FillWeight = 400F;
            this.Workload.HeaderText = "Нагрузка";
            this.Workload.Name = "Workload";
            this.Workload.ReadOnly = true;
            this.Workload.Width = 400;
            // 
            // FormCourseInWorkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 581);
            this.Controls.Add(this.labelWorkloadTotalValue);
            this.Controls.Add(this.dataGridViewFullLoad);
            this.Controls.Add(this.labelFullNagruz);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxCourseName);
            this.Controls.Add(this.labelCourseName);
            this.Name = "FormCourseInWorkInfo";
            this.Text = "Информация о курсе";
            this.Load += new System.EventHandler(this.FormCourseInWorkInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFullLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFullLoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCourseName;
        private System.Windows.Forms.TextBox textBoxCourseName;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelFullNagruz;
        private System.Windows.Forms.BindingSource bindingSourceFullLoad;
        private System.Windows.Forms.DataGridView dataGridViewFullLoad;
        private System.Windows.Forms.Label labelWorkloadTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkloadTypeString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Workload;
    }
}