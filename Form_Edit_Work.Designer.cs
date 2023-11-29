namespace Students
{
    partial class Form_Edit_Work
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Edit_Work));
            this.label5 = new System.Windows.Forms.Label();
            this.tBWorkNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBWorkOld = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tBYearOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBSubjOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Дисциплина";
            // 
            // tBWorkNew
            // 
            this.tBWorkNew.Location = new System.Drawing.Point(12, 90);
            this.tBWorkNew.Name = "tBWorkNew";
            this.tBWorkNew.Size = new System.Drawing.Size(100, 20);
            this.tBWorkNew.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Работа";
            // 
            // tBWorkOld
            // 
            this.tBWorkOld.Enabled = false;
            this.tBWorkOld.Location = new System.Drawing.Point(224, 38);
            this.tBWorkOld.Name = "tBWorkOld";
            this.tBWorkOld.Size = new System.Drawing.Size(100, 20);
            this.tBWorkOld.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Новое название";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(199, 74);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(125, 36);
            this.btnChange.TabIndex = 31;
            this.btnChange.Text = "Подтвердить изменение";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Год";
            // 
            // tBYearOld
            // 
            this.tBYearOld.Enabled = false;
            this.tBYearOld.Location = new System.Drawing.Point(118, 38);
            this.tBYearOld.Name = "tBYearOld";
            this.tBYearOld.Size = new System.Drawing.Size(100, 20);
            this.tBYearOld.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Дисциплина";
            // 
            // tBSubjOld
            // 
            this.tBSubjOld.Enabled = false;
            this.tBSubjOld.Location = new System.Drawing.Point(12, 38);
            this.tBSubjOld.Name = "tBSubjOld";
            this.tBSubjOld.Size = new System.Drawing.Size(100, 20);
            this.tBSubjOld.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Старое название";
            // 
            // Form_Edit_Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 121);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBWorkNew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBWorkOld);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBYearOld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBSubjOld);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(350, 160);
            this.MinimumSize = new System.Drawing.Size(350, 160);
            this.Name = "Form_Edit_Work";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование Работ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBWorkNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBWorkOld;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBYearOld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBSubjOld;
        private System.Windows.Forms.Label label1;
    }
}