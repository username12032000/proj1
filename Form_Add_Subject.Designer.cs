namespace Students
{
    partial class Form_Add_Subject
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
            this.cmBYear = new System.Windows.Forms.ComboBox();
            this.tBSubjName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddRow_Subj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmBYear
            // 
            this.cmBYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBYear.FormattingEnabled = true;
            this.cmBYear.Location = new System.Drawing.Point(171, 24);
            this.cmBYear.Name = "cmBYear";
            this.cmBYear.Size = new System.Drawing.Size(150, 21);
            this.cmBYear.Sorted = true;
            this.cmBYear.TabIndex = 21;
            // 
            // tBSubjName
            // 
            this.tBSubjName.Location = new System.Drawing.Point(15, 25);
            this.tBSubjName.Name = "tBSubjName";
            this.tBSubjName.Size = new System.Drawing.Size(150, 20);
            this.tBSubjName.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Дисциплина\n";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(168, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Год";
            // 
            // btnAddRow_Subj
            // 
            this.btnAddRow_Subj.Location = new System.Drawing.Point(171, 51);
            this.btnAddRow_Subj.Name = "btnAddRow_Subj";
            this.btnAddRow_Subj.Size = new System.Drawing.Size(150, 35);
            this.btnAddRow_Subj.TabIndex = 17;
            this.btnAddRow_Subj.Text = "Добавить запись дисциплины";
            this.btnAddRow_Subj.UseVisualStyleBackColor = true;
            this.btnAddRow_Subj.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // Form_Add_Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 96);
            this.Controls.Add(this.cmBYear);
            this.Controls.Add(this.tBSubjName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAddRow_Subj);
            this.MaximumSize = new System.Drawing.Size(350, 135);
            this.MinimumSize = new System.Drawing.Size(350, 135);
            this.Name = "Form_Add_Subject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление Дисциплины";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmBYear;
        private System.Windows.Forms.TextBox tBSubjName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAddRow_Subj;
    }
}