namespace Students
{
    partial class Form_Add_Student
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddRow_Student = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmBGroup = new System.Windows.Forms.ComboBox();
            this.cmBYear = new System.Windows.Forms.ComboBox();
            this.tBName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "ФИО";
            // 
            // btnAddRow_Student
            // 
            this.btnAddRow_Student.Location = new System.Drawing.Point(355, 48);
            this.btnAddRow_Student.Name = "btnAddRow_Student";
            this.btnAddRow_Student.Size = new System.Drawing.Size(125, 36);
            this.btnAddRow_Student.TabIndex = 31;
            this.btnAddRow_Student.Text = "Добавить запись студента";
            this.btnAddRow_Student.UseVisualStyleBackColor = true;
            this.btnAddRow_Student.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Группа";
            // 
            // cmBGroup
            // 
            this.cmBGroup.FormattingEnabled = true;
            this.cmBGroup.Location = new System.Drawing.Point(168, 24);
            this.cmBGroup.Name = "cmBGroup";
            this.cmBGroup.Size = new System.Drawing.Size(150, 21);
            this.cmBGroup.Sorted = true;
            this.cmBGroup.TabIndex = 35;
            // 
            // cmBYear
            // 
            this.cmBYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBYear.FormattingEnabled = true;
            this.cmBYear.Location = new System.Drawing.Point(12, 24);
            this.cmBYear.Name = "cmBYear";
            this.cmBYear.Size = new System.Drawing.Size(150, 21);
            this.cmBYear.Sorted = true;
            this.cmBYear.TabIndex = 36;
            this.cmBYear.SelectedIndexChanged += new System.EventHandler(this.cmBYear_SelectedIndexChanged);
            // 
            // tBName
            // 
            this.tBName.Location = new System.Drawing.Point(12, 64);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(337, 20);
            this.tBName.TabIndex = 37;
            // 
            // Form_Add_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 91);
            this.Controls.Add(this.tBName);
            this.Controls.Add(this.cmBYear);
            this.Controls.Add(this.cmBGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddRow_Student);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(500, 130);
            this.MinimumSize = new System.Drawing.Size(500, 130);
            this.Name = "Form_Add_Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление студентов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddRow_Student;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBGroup;
        private System.Windows.Forms.ComboBox cmBYear;
        private System.Windows.Forms.TextBox tBName;
    }
}