namespace iCathedra.Forms
{
    partial class FormDiplomWorkload
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxGroups = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCheckBoxes = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxGroups.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(439, 403);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // groupBoxGroups
            // 
            this.groupBoxGroups.AutoSize = true;
            this.groupBoxGroups.Controls.Add(this.tableLayoutPanelCheckBoxes);
            this.groupBoxGroups.Location = new System.Drawing.Point(457, 12);
            this.groupBoxGroups.Name = "groupBoxGroups";
            this.groupBoxGroups.Size = new System.Drawing.Size(377, 203);
            this.groupBoxGroups.TabIndex = 1;
            this.groupBoxGroups.TabStop = false;
            this.groupBoxGroups.Text = "Дипломники по группам";
            // 
            // tableLayoutPanelCheckBoxes
            // 
            this.tableLayoutPanelCheckBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelCheckBoxes.AutoSize = true;
            this.tableLayoutPanelCheckBoxes.ColumnCount = 1;
            this.tableLayoutPanelCheckBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCheckBoxes.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanelCheckBoxes.Name = "tableLayoutPanelCheckBoxes";
            this.tableLayoutPanelCheckBoxes.RowCount = 1;
            this.tableLayoutPanelCheckBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCheckBoxes.Size = new System.Drawing.Size(365, 21);
            this.tableLayoutPanelCheckBoxes.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormDiplomWorkload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 513);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxGroups);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDiplomWorkload";
            this.Text = "Распределение нагрузки по дипломникам";
            this.Load += new System.EventHandler(this.FormDiplomWorkload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxGroups.ResumeLayout(false);
            this.groupBoxGroups.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.GroupBox groupBoxGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCheckBoxes;
        private System.Windows.Forms.Button button1;
    }
}