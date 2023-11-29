namespace Students
{
    partial class Form_Add_Work
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
            this.cmBSubj = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBWorkName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAddRow_Work = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmBYear
            // 
            this.cmBYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBYear.FormattingEnabled = true;
            this.cmBYear.Location = new System.Drawing.Point(17, 25);
            this.cmBYear.Name = "cmBYear";
            this.cmBYear.Size = new System.Drawing.Size(150, 21);
            this.cmBYear.Sorted = true;
            this.cmBYear.TabIndex = 22;
            this.cmBYear.SelectedIndexChanged += new System.EventHandler(this.cmBYear_SelectedIndexChanged);
            // 
            // cmBSubj
            // 
            this.cmBSubj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBSubj.FormattingEnabled = true;
            this.cmBSubj.Location = new System.Drawing.Point(173, 23);
            this.cmBSubj.Name = "cmBSubj";
            this.cmBSubj.Size = new System.Drawing.Size(150, 21);
            this.cmBSubj.Sorted = true;
            this.cmBSubj.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Год";
            // 
            // tBWorkName
            // 
            this.tBWorkName.Location = new System.Drawing.Point(17, 65);
            this.tBWorkName.Name = "tBWorkName";
            this.tBWorkName.Size = new System.Drawing.Size(150, 20);
            this.tBWorkName.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Название работы";
            // 
            // btnAddRow_Work
            // 
            this.btnAddRow_Work.Location = new System.Drawing.Point(173, 50);
            this.btnAddRow_Work.Name = "btnAddRow_Work";
            this.btnAddRow_Work.Size = new System.Drawing.Size(150, 35);
            this.btnAddRow_Work.TabIndex = 16;
            this.btnAddRow_Work.Text = "Добавить запись работы";
            this.btnAddRow_Work.UseVisualStyleBackColor = true;
            this.btnAddRow_Work.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Дисциплина";
            // 
            // Form_Add_Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 96);
            this.Controls.Add(this.cmBYear);
            this.Controls.Add(this.cmBSubj);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tBWorkName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAddRow_Work);
            this.Controls.Add(this.label10);
            this.MaximumSize = new System.Drawing.Size(350, 135);
            this.MinimumSize = new System.Drawing.Size(350, 135);
            this.Name = "Form_Add_Work";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление Работы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmBYear;
        private System.Windows.Forms.ComboBox cmBSubj;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tBWorkName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAddRow_Work;
        private System.Windows.Forms.Label label10;
    }
}