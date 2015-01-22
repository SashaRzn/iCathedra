namespace iCathedra.Forms
{
    partial class FormSelectSchoolYear
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSchoolYear
            // 
            this.comboBoxSchoolYear.DataSource = this.schoolYearBindingSource;
            this.comboBoxSchoolYear.FormattingEnabled = true;
            this.comboBoxSchoolYear.Location = new System.Drawing.Point(12, 35);
            this.comboBoxSchoolYear.Name = "comboBoxSchoolYear";
            this.comboBoxSchoolYear.Size = new System.Drawing.Size(268, 21);
            this.comboBoxSchoolYear.TabIndex = 0;
            // 
            // schoolYearBindingSource
            // 
            this.schoolYearBindingSource.DataSource = typeof(iCathedra.SchoolYear);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите учебный год:";
            // 
            // FormSelectSchoolYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 115);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxSchoolYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSelectSchoolYear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите учебный год";
            this.Load += new System.EventHandler(this.FormSelectSchoolYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schoolYearBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSchoolYear;
        private System.Windows.Forms.BindingSource schoolYearBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}