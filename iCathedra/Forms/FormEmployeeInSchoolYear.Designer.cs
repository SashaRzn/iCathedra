namespace iCathedra
{
    partial class FormEmployeeInSchoolYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeInSchoolYear));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewEmployeeInSchoolYear = new System.Windows.Forms.DataGridView();
            this.WorkloadNorm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Underload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateFormByHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkloadFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorEmployeeInSchoolYear = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.bindingSourceEmployeeInSchoolYear = new System.Windows.Forms.BindingSource(this.components);
            this.fioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeInSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorEmployeeInSchoolYear)).BeginInit();
            this.bindingNavigatorEmployeeInSchoolYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployeeInSchoolYear)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(567, 510);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Сохранить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(648, 510);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сохранить и выйти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(777, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewEmployeeInSchoolYear
            // 
            this.dataGridViewEmployeeInSchoolYear.AllowUserToAddRows = false;
            this.dataGridViewEmployeeInSchoolYear.AllowUserToDeleteRows = false;
            this.dataGridViewEmployeeInSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEmployeeInSchoolYear.AutoGenerateColumns = false;
            this.dataGridViewEmployeeInSchoolYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeInSchoolYear.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fioDataGridViewTextBoxColumn,
            this.postDataGridViewTextBoxColumn,
            this.WorkloadNorm,
            this.Overload,
            this.Underload,
            this.RateFormByHours,
            this.RateForm,
            this.WorkloadFact,
            this.RateFact});
            this.dataGridViewEmployeeInSchoolYear.DataSource = this.bindingSourceEmployeeInSchoolYear;
            this.dataGridViewEmployeeInSchoolYear.Location = new System.Drawing.Point(1, 28);
            this.dataGridViewEmployeeInSchoolYear.MultiSelect = false;
            this.dataGridViewEmployeeInSchoolYear.Name = "dataGridViewEmployeeInSchoolYear";
            this.dataGridViewEmployeeInSchoolYear.ReadOnly = true;
            this.dataGridViewEmployeeInSchoolYear.Size = new System.Drawing.Size(861, 467);
            this.dataGridViewEmployeeInSchoolYear.TabIndex = 9;
            this.dataGridViewEmployeeInSchoolYear.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployeeInSchoolYear_CellClick);
            this.dataGridViewEmployeeInSchoolYear.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewEmployeeInSchoolYear_DataBindingComplete);
            // 
            // WorkloadNorm
            // 
            this.WorkloadNorm.DataPropertyName = "WorkloadForm";
            this.WorkloadNorm.HeaderText = "Формальная нагрузка";
            this.WorkloadNorm.Name = "WorkloadNorm";
            this.WorkloadNorm.ReadOnly = true;
            // 
            // Overload
            // 
            this.Overload.DataPropertyName = "Overload";
            this.Overload.HeaderText = "Перегрузка";
            this.Overload.Name = "Overload";
            this.Overload.ReadOnly = true;
            // 
            // Underload
            // 
            this.Underload.DataPropertyName = "Underload";
            this.Underload.HeaderText = "Недогрузка";
            this.Underload.Name = "Underload";
            this.Underload.ReadOnly = true;
            // 
            // RateFormByHours
            // 
            this.RateFormByHours.DataPropertyName = "RateFormByHours";
            this.RateFormByHours.HeaderText = "Формальная нагрузка по часам";
            this.RateFormByHours.Name = "RateFormByHours";
            this.RateFormByHours.ReadOnly = true;
            // 
            // RateForm
            // 
            this.RateForm.DataPropertyName = "RateForm";
            this.RateForm.HeaderText = "Формальная ставка";
            this.RateForm.Name = "RateForm";
            this.RateForm.ReadOnly = true;
            // 
            // WorkloadFact
            // 
            this.WorkloadFact.DataPropertyName = "WorkloadFact";
            this.WorkloadFact.HeaderText = "Фактическая нагрузка";
            this.WorkloadFact.Name = "WorkloadFact";
            this.WorkloadFact.ReadOnly = true;
            // 
            // RateFact
            // 
            this.RateFact.DataPropertyName = "RateFact";
            this.RateFact.HeaderText = "Фактическая ставка";
            this.RateFact.Name = "RateFact";
            this.RateFact.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Post";
            this.dataGridViewTextBoxColumn1.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // bindingSourceEmployee
            // 
            this.bindingSourceEmployee.DataSource = typeof(iCathedra.Employee);
            // 
            // bindingNavigatorEmployeeInSchoolYear
            // 
            this.bindingNavigatorEmployeeInSchoolYear.AddNewItem = null;
            this.bindingNavigatorEmployeeInSchoolYear.BindingSource = this.bindingSourceEmployeeInSchoolYear;
            this.bindingNavigatorEmployeeInSchoolYear.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorEmployeeInSchoolYear.DeleteItem = null;
            this.bindingNavigatorEmployeeInSchoolYear.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.bindingNavigatorEmployeeInSchoolYear.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorEmployeeInSchoolYear.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorEmployeeInSchoolYear.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorEmployeeInSchoolYear.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorEmployeeInSchoolYear.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorEmployeeInSchoolYear.Name = "bindingNavigatorEmployeeInSchoolYear";
            this.bindingNavigatorEmployeeInSchoolYear.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorEmployeeInSchoolYear.Size = new System.Drawing.Size(862, 25);
            this.bindingNavigatorEmployeeInSchoolYear.TabIndex = 11;
            this.bindingNavigatorEmployeeInSchoolYear.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Расшифровка по одному преподавателю";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Расшифровка по всем (в файл Employee.txt)";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Сводная таблица";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // bindingSourceEmployeeInSchoolYear
            // 
            this.bindingSourceEmployeeInSchoolYear.AllowNew = false;
            this.bindingSourceEmployeeInSchoolYear.DataSource = typeof(iCathedra.EmployeeInSchoolYear);
            // 
            // fioDataGridViewTextBoxColumn
            // 
            this.fioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fioDataGridViewTextBoxColumn.DataPropertyName = "Fio";
            this.fioDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.fioDataGridViewTextBoxColumn.Name = "fioDataGridViewTextBoxColumn";
            this.fioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.ReadOnly = true;
            this.postDataGridViewTextBoxColumn.Width = 150;
            // 
            // FormEmployeeInSchoolYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 545);
            this.Controls.Add(this.bindingNavigatorEmployeeInSchoolYear);
            this.Controls.Add(this.dataGridViewEmployeeInSchoolYear);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FormEmployeeInSchoolYear";
            this.ShowIcon = false;
            this.Text = "Нагрузкой преподавателей";
            this.Load += new System.EventHandler(this.FormEmployeeInSchoolYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeInSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorEmployeeInSchoolYear)).EndInit();
            this.bindingNavigatorEmployeeInSchoolYear.ResumeLayout(false);
            this.bindingNavigatorEmployeeInSchoolYear.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployeeInSchoolYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSourceEmployeeInSchoolYear;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeInSchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource bindingSourceEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn allHoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkloadNorm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Overload;
        private System.Windows.Forms.DataGridViewTextBoxColumn Underload;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateFormByHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkloadFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateFact;
        private System.Windows.Forms.BindingNavigator bindingNavigatorEmployeeInSchoolYear;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}