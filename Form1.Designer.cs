namespace Students
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSaveToExel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmBYear3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmBSubj2 = new System.Windows.Forms.ComboBox();
            this.tBWorkName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddRow_Work = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmBYear2 = new System.Windows.Forms.ComboBox();
            this.tBSubjName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAddRow_Subj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelFilters = new System.Windows.Forms.Button();
            this.btnUseFiltrs = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmBWork1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmBYear1 = new System.Windows.Forms.ComboBox();
            this.cmBFIO1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmBTableChoice = new System.Windows.Forms.ComboBox();
            this.cmBGroup1 = new System.Windows.Forms.ComboBox();
            this.cmBSubj1 = new System.Windows.Forms.ComboBox();
            this.loadExelBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.mainDGV = new System.Windows.Forms.DataGridView();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainDGV);
            this.splitContainer1.Panel2MinSize = 600;
            this.splitContainer1.Size = new System.Drawing.Size(1008, 546);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnHelp);
            this.groupBox4.Controls.Add(this.btnSaveToExel);
            this.groupBox4.Location = new System.Drawing.Point(12, 475);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 65);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сохранение данных";
            // 
            // btnSaveToExel
            // 
            this.btnSaveToExel.Location = new System.Drawing.Point(9, 19);
            this.btnSaveToExel.Name = "btnSaveToExel";
            this.btnSaveToExel.Size = new System.Drawing.Size(150, 35);
            this.btnSaveToExel.TabIndex = 0;
            this.btnSaveToExel.Text = "Сохранить в Exel выведенные данные";
            this.btnSaveToExel.UseVisualStyleBackColor = true;
            this.btnSaveToExel.Click += new System.EventHandler(this.btnSaveToExel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmBYear3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmBSubj2);
            this.groupBox3.Controls.Add(this.tBWorkName);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnAddRow_Work);
            this.groupBox3.Location = new System.Drawing.Point(12, 364);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 105);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Добавление записей ЛР";
            // 
            // cmBYear3
            // 
            this.cmBYear3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBYear3.FormattingEnabled = true;
            this.cmBYear3.Location = new System.Drawing.Point(168, 33);
            this.cmBYear3.Name = "cmBYear3";
            this.cmBYear3.Size = new System.Drawing.Size(150, 21);
            this.cmBYear3.TabIndex = 15;
            this.cmBYear3.SelectedIndexChanged += new System.EventHandler(this.cmBYear3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Год";
            // 
            // cmBSubj2
            // 
            this.cmBSubj2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBSubj2.FormattingEnabled = true;
            this.cmBSubj2.Location = new System.Drawing.Point(168, 72);
            this.cmBSubj2.Name = "cmBSubj2";
            this.cmBSubj2.Size = new System.Drawing.Size(150, 21);
            this.cmBSubj2.TabIndex = 13;
            // 
            // tBWorkName
            // 
            this.tBWorkName.Location = new System.Drawing.Point(9, 73);
            this.tBWorkName.Name = "tBWorkName";
            this.tBWorkName.Size = new System.Drawing.Size(150, 20);
            this.tBWorkName.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Название работы";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Предмет";
            // 
            // btnAddRow_Work
            // 
            this.btnAddRow_Work.Location = new System.Drawing.Point(8, 19);
            this.btnAddRow_Work.Name = "btnAddRow_Work";
            this.btnAddRow_Work.Size = new System.Drawing.Size(150, 35);
            this.btnAddRow_Work.TabIndex = 7;
            this.btnAddRow_Work.Text = "Добавить запись работы";
            this.btnAddRow_Work.UseVisualStyleBackColor = true;
            this.btnAddRow_Work.Click += new System.EventHandler(this.btnAddRow_Work_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmBYear2);
            this.groupBox2.Controls.Add(this.tBSubjName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnAddRow_Subj);
            this.groupBox2.Location = new System.Drawing.Point(12, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 105);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавление запись предмета";
            // 
            // cmBYear2
            // 
            this.cmBYear2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBYear2.FormattingEnabled = true;
            this.cmBYear2.Location = new System.Drawing.Point(167, 33);
            this.cmBYear2.Name = "cmBYear2";
            this.cmBYear2.Size = new System.Drawing.Size(150, 21);
            this.cmBYear2.TabIndex = 16;
            // 
            // tBSubjName
            // 
            this.tBSubjName.Location = new System.Drawing.Point(9, 73);
            this.tBSubjName.Name = "tBSubjName";
            this.tBSubjName.Size = new System.Drawing.Size(150, 20);
            this.tBSubjName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Название предмета";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(164, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Год";
            // 
            // btnAddRow_Subj
            // 
            this.btnAddRow_Subj.Location = new System.Drawing.Point(8, 19);
            this.btnAddRow_Subj.Name = "btnAddRow_Subj";
            this.btnAddRow_Subj.Size = new System.Drawing.Size(150, 35);
            this.btnAddRow_Subj.TabIndex = 1;
            this.btnAddRow_Subj.Text = "Добавить запись предмета";
            this.btnAddRow_Subj.UseVisualStyleBackColor = true;
            this.btnAddRow_Subj.Click += new System.EventHandler(this.btnAddRow_Subj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelFilters);
            this.groupBox1.Controls.Add(this.btnUseFiltrs);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmBWork1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmBYear1);
            this.groupBox1.Controls.Add(this.cmBFIO1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmBTableChoice);
            this.groupBox1.Controls.Add(this.cmBGroup1);
            this.groupBox1.Controls.Add(this.cmBSubj1);
            this.groupBox1.Controls.Add(this.loadExelBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 235);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Загрузка и вывод данных";
            // 
            // btnCancelFilters
            // 
            this.btnCancelFilters.Location = new System.Drawing.Point(9, 182);
            this.btnCancelFilters.Name = "btnCancelFilters";
            this.btnCancelFilters.Size = new System.Drawing.Size(150, 35);
            this.btnCancelFilters.TabIndex = 15;
            this.btnCancelFilters.Text = "Сбросить фильтры";
            this.btnCancelFilters.UseVisualStyleBackColor = true;
            this.btnCancelFilters.Click += new System.EventHandler(this.btnCancelFilters_Click);
            // 
            // btnUseFiltrs
            // 
            this.btnUseFiltrs.Location = new System.Drawing.Point(168, 182);
            this.btnUseFiltrs.Name = "btnUseFiltrs";
            this.btnUseFiltrs.Size = new System.Drawing.Size(150, 35);
            this.btnUseFiltrs.TabIndex = 14;
            this.btnUseFiltrs.Text = "Применить фильтры";
            this.btnUseFiltrs.UseVisualStyleBackColor = true;
            this.btnUseFiltrs.Click += new System.EventHandler(this.btnUseFiltrs_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Работа";
            // 
            // cmBWork1
            // 
            this.cmBWork1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBWork1.Enabled = false;
            this.cmBWork1.FormattingEnabled = true;
            this.cmBWork1.Location = new System.Drawing.Point(168, 155);
            this.cmBWork1.Name = "cmBWork1";
            this.cmBWork1.Size = new System.Drawing.Size(150, 21);
            this.cmBWork1.Sorted = true;
            this.cmBWork1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ФИО";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Год";
            // 
            // cmBYear1
            // 
            this.cmBYear1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBYear1.Enabled = false;
            this.cmBYear1.FormattingEnabled = true;
            this.cmBYear1.Location = new System.Drawing.Point(9, 74);
            this.cmBYear1.Name = "cmBYear1";
            this.cmBYear1.Size = new System.Drawing.Size(150, 21);
            this.cmBYear1.Sorted = true;
            this.cmBYear1.TabIndex = 8;
            this.cmBYear1.SelectedIndexChanged += new System.EventHandler(this.cmBYear1_SelectedIndexChanged);
            // 
            // cmBFIO1
            // 
            this.cmBFIO1.Enabled = false;
            this.cmBFIO1.FormattingEnabled = true;
            this.cmBFIO1.Location = new System.Drawing.Point(9, 115);
            this.cmBFIO1.Name = "cmBFIO1";
            this.cmBFIO1.Size = new System.Drawing.Size(309, 21);
            this.cmBFIO1.Sorted = true;
            this.cmBFIO1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Группа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выбор таблицы для показа";
            // 
            // cmBTableChoice
            // 
            this.cmBTableChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBTableChoice.Enabled = false;
            this.cmBTableChoice.FormattingEnabled = true;
            this.cmBTableChoice.Items.AddRange(new object[] {
            "Группы",
            "Студенты",
            "Предметы",
            "Работы",
            "Оценки"});
            this.cmBTableChoice.Location = new System.Drawing.Point(168, 32);
            this.cmBTableChoice.Name = "cmBTableChoice";
            this.cmBTableChoice.Size = new System.Drawing.Size(150, 21);
            this.cmBTableChoice.TabIndex = 1;
            this.cmBTableChoice.SelectedIndexChanged += new System.EventHandler(this.cmBTableChoice_SelectedIndexChanged);
            // 
            // cmBGroup1
            // 
            this.cmBGroup1.BackColor = System.Drawing.SystemColors.Window;
            this.cmBGroup1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBGroup1.Enabled = false;
            this.cmBGroup1.FormattingEnabled = true;
            this.cmBGroup1.Location = new System.Drawing.Point(168, 75);
            this.cmBGroup1.Name = "cmBGroup1";
            this.cmBGroup1.Size = new System.Drawing.Size(150, 21);
            this.cmBGroup1.Sorted = true;
            this.cmBGroup1.TabIndex = 4;
            this.cmBGroup1.SelectedIndexChanged += new System.EventHandler(this.cmBGroup1_SelectedIndexChanged);
            // 
            // cmBSubj1
            // 
            this.cmBSubj1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBSubj1.Enabled = false;
            this.cmBSubj1.FormattingEnabled = true;
            this.cmBSubj1.Location = new System.Drawing.Point(9, 155);
            this.cmBSubj1.Name = "cmBSubj1";
            this.cmBSubj1.Size = new System.Drawing.Size(150, 21);
            this.cmBSubj1.Sorted = true;
            this.cmBSubj1.TabIndex = 6;
            this.cmBSubj1.SelectedIndexChanged += new System.EventHandler(this.cmBSubj1_SelectedIndexChanged);
            // 
            // loadExelBtn
            // 
            this.loadExelBtn.Location = new System.Drawing.Point(9, 19);
            this.loadExelBtn.Name = "loadExelBtn";
            this.loadExelBtn.Size = new System.Drawing.Size(150, 35);
            this.loadExelBtn.TabIndex = 0;
            this.loadExelBtn.Text = "Загрузить Exel";
            this.loadExelBtn.UseVisualStyleBackColor = true;
            this.loadExelBtn.Click += new System.EventHandler(this.LoadExelClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Предмет";
            // 
            // mainDGV
            // 
            this.mainDGV.AllowUserToAddRows = false;
            this.mainDGV.AllowUserToDeleteRows = false;
            this.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDGV.Location = new System.Drawing.Point(0, 0);
            this.mainDGV.Name = "mainDGV";
            this.mainDGV.Size = new System.Drawing.Size(654, 546);
            this.mainDGV.TabIndex = 0;
            this.mainDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDGV_CellContentClick);
            this.mainDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDGV_CellValueChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(168, 19);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(150, 35);
            this.btnHelp.TabIndex = 1;
            this.btnHelp.Text = "Помощь";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1008, 546);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 585);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет успиваемости студентов ВУЗа СГУГиТ 2023";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button loadExelBtn;
        private System.Windows.Forms.DataGridView mainDGV;
        private System.Windows.Forms.ComboBox cmBTableChoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmBSubj1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBGroup1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmBYear1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmBFIO1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddRow_Subj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBSubjName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmBSubj2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBWorkName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAddRow_Work;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmBWork1;
        private System.Windows.Forms.Button btnUseFiltrs;
        private System.Windows.Forms.ComboBox cmBYear3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmBYear2;
        private System.Windows.Forms.Button btnCancelFilters;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSaveToExel;
        private System.Windows.Forms.Button btnHelp;
    }
}

