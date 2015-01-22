namespace iCathedra
{
    partial class FormRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRate));
            this.dataGridViewRate = new System.Windows.Forms.DataGridView();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSourceEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.SchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bindingSourcePost = new System.Windows.Forms.BindingSource(this.components);
            this.IsTradeUnionMember = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rate1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrectedRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeSurcharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostSurcharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PochFondLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceRate = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorRate = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorRate)).BeginInit();
            this.bindingNavigatorRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRate
            // 
            this.dataGridViewRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRate.AutoGenerateColumns = false;
            this.dataGridViewRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeDataGridViewTextBoxColumn,
            this.SchoolYear,
            this.postDataGridViewTextBoxColumn,
            this.IsTradeUnionMember,
            this.rate1DataGridViewTextBoxColumn,
            this.CorrectedRate,
            this.BaseSalary,
            this.PostSalary,
            this.GradeSurcharge,
            this.PostSurcharge,
            this.PochFondLimit});
            this.dataGridViewRate.DataSource = this.bindingSourceRate;
            this.dataGridViewRate.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewRate.Name = "dataGridViewRate";
            this.dataGridViewRate.Size = new System.Drawing.Size(665, 367);
            this.dataGridViewRate.TabIndex = 0;
            this.dataGridViewRate.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRate_CellEndEdit);
            this.dataGridViewRate.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridViewRate_CellParsing);
            this.dataGridViewRate.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRate_CellValueChanged);
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.DataSource = this.bindingSourceEmployee;
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.employeeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bindingSourceEmployee
            // 
            this.bindingSourceEmployee.DataSource = typeof(iCathedra.Employee);
            // 
            // SchoolYear
            // 
            this.SchoolYear.DataPropertyName = "SchoolYear";
            this.SchoolYear.HeaderText = "Учебный год";
            this.SchoolYear.Name = "SchoolYear";
            this.SchoolYear.ReadOnly = true;
            this.SchoolYear.Visible = false;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.DataSource = this.bindingSourcePost;
            this.postDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.postDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bindingSourcePost
            // 
            this.bindingSourcePost.DataSource = typeof(iCathedra.Post);
            // 
            // IsTradeUnionMember
            // 
            this.IsTradeUnionMember.DataPropertyName = "IsTradeUnionMember";
            this.IsTradeUnionMember.HeaderText = "Член профсоюза";
            this.IsTradeUnionMember.Name = "IsTradeUnionMember";
            this.IsTradeUnionMember.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsTradeUnionMember.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsTradeUnionMember.Width = 80;
            // 
            // rate1DataGridViewTextBoxColumn
            // 
            this.rate1DataGridViewTextBoxColumn.DataPropertyName = "Rate1";
            this.rate1DataGridViewTextBoxColumn.HeaderText = "Ставка";
            this.rate1DataGridViewTextBoxColumn.Name = "rate1DataGridViewTextBoxColumn";
            this.rate1DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CorrectedRate
            // 
            this.CorrectedRate.DataPropertyName = "CorrectedRate";
            this.CorrectedRate.HeaderText = "Приведенная ставка";
            this.CorrectedRate.Name = "CorrectedRate";
            this.CorrectedRate.ReadOnly = true;
            // 
            // BaseSalary
            // 
            this.BaseSalary.DataPropertyName = "BaseSalary";
            this.BaseSalary.HeaderText = "Базовый оклад";
            this.BaseSalary.Name = "BaseSalary";
            this.BaseSalary.ReadOnly = true;
            // 
            // PostSalary
            // 
            this.PostSalary.DataPropertyName = "PostSalary";
            this.PostSalary.HeaderText = "Должностной оклад";
            this.PostSalary.Name = "PostSalary";
            this.PostSalary.ReadOnly = true;
            // 
            // GradeSurcharge
            // 
            this.GradeSurcharge.DataPropertyName = "GradeSurcharge";
            this.GradeSurcharge.HeaderText = "Доплата за степень";
            this.GradeSurcharge.Name = "GradeSurcharge";
            this.GradeSurcharge.ReadOnly = true;
            // 
            // PostSurcharge
            // 
            this.PostSurcharge.DataPropertyName = "PostSurcharge";
            this.PostSurcharge.HeaderText = "Доплата за должность";
            this.PostSurcharge.Name = "PostSurcharge";
            this.PostSurcharge.ReadOnly = true;
            // 
            // PochFondLimit
            // 
            this.PochFondLimit.DataPropertyName = "PochFondLimit";
            this.PochFondLimit.HeaderText = "Лимит почасового фонда";
            this.PochFondLimit.Name = "PochFondLimit";
            // 
            // bindingSourceRate
            // 
            this.bindingSourceRate.DataSource = typeof(iCathedra.Rate);
            // 
            // bindingNavigatorRate
            // 
            this.bindingNavigatorRate.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorRate.BindingSource = this.bindingSourceRate;
            this.bindingNavigatorRate.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorRate.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigatorRate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripComboBox1,
            this.toolStripButton1});
            this.bindingNavigatorRate.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorRate.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorRate.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorRate.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorRate.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorRate.Name = "bindingNavigatorRate";
            this.bindingNavigatorRate.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorRate.Size = new System.Drawing.Size(665, 25);
            this.bindingNavigatorRate.TabIndex = 1;
            this.bindingNavigatorRate.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
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
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Статистика";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(377, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Сохранить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(458, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Сохранить и выйти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(586, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SchoolYear";
            this.dataGridViewTextBoxColumn1.HeaderText = "Учебный год";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // FormRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 443);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bindingNavigatorRate);
            this.Controls.Add(this.dataGridViewRate);
            this.Name = "FormRate";
            this.ShowIcon = false;
            this.Text = "Управление списком окладов";
            this.Load += new System.EventHandler(this.FormRate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorRate)).EndInit();
            this.bindingNavigatorRate.ResumeLayout(false);
            this.bindingNavigatorRate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRate;
        private System.Windows.Forms.BindingNavigator bindingNavigatorRate;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSourceRate;
        private System.Windows.Forms.BindingSource bindingSourceEmployee;
        private System.Windows.Forms.BindingSource bindingSourcePost;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn innerSuperpositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCommercialSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn improveCoefficientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseSalaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postSalaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeSurchargeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postSurchargeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anotherSurchargeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewComboBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsTradeUnionMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrectedRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeSurcharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostSurcharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn PochFondLimit;
    }
}