namespace Students
{
    partial class Form_Edit_Subject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Edit_Subject));
            this.label6 = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tBYearNew = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBSubjNew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBYearOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBSubjOld = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Новое название";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(224, 74);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(125, 36);
            this.btnChange.TabIndex = 20;
            this.btnChange.Text = "Подтвердить изменение";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Год";
            // 
            // tBYearNew
            // 
            this.tBYearNew.Location = new System.Drawing.Point(118, 90);
            this.tBYearNew.Name = "tBYearNew";
            this.tBYearNew.Size = new System.Drawing.Size(100, 20);
            this.tBYearNew.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Предмет";
            // 
            // tBSubjNew
            // 
            this.tBSubjNew.Location = new System.Drawing.Point(12, 90);
            this.tBSubjNew.Name = "tBSubjNew";
            this.tBSubjNew.Size = new System.Drawing.Size(100, 20);
            this.tBSubjNew.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Год";
            // 
            // tBYearOld
            // 
            this.tBYearOld.Enabled = false;
            this.tBYearOld.Location = new System.Drawing.Point(118, 38);
            this.tBYearOld.Name = "tBYearOld";
            this.tBYearOld.Size = new System.Drawing.Size(100, 20);
            this.tBYearOld.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Предмет";
            // 
            // tBSubjOld
            // 
            this.tBSubjOld.Enabled = false;
            this.tBSubjOld.Location = new System.Drawing.Point(12, 38);
            this.tBSubjOld.Name = "tBSubjOld";
            this.tBSubjOld.Size = new System.Drawing.Size(100, 20);
            this.tBSubjOld.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Старое название";
            // 
            // Form_Edit_Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 121);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBYearNew);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tBSubjNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBYearOld);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBSubjOld);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(370, 160);
            this.MaximumSize = new System.Drawing.Size(370, 160);
            this.Name = "Form_Edit_Subject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование Предметов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBYearNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBSubjNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBYearOld;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBSubjOld;
        private System.Windows.Forms.Label label1;
    }
}