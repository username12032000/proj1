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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainDGV);
            this.splitContainer1.Panel2MinSize = 600;
            this.splitContainer1.Size = new System.Drawing.Size(1008, 262);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
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
            "Дисциплины",
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
            this.loadExelBtn.Text = "Загрузить Exсel";
            this.loadExelBtn.UseVisualStyleBackColor = true;
            this.loadExelBtn.Click += new System.EventHandler(this.LoadExelClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дисциплина";
            // 
            // mainDGV
            // 
            this.mainDGV.AllowUserToAddRows = false;
            this.mainDGV.AllowUserToDeleteRows = false;
            this.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDGV.Location = new System.Drawing.Point(0, 0);
            this.mainDGV.Name = "mainDGV";
            this.mainDGV.Size = new System.Drawing.Size(654, 262);
            this.mainDGV.TabIndex = 0;
            this.mainDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDGV_CellContentClick);
            this.mainDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDGV_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem1,
            this.toolStripMenuItem7});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripSeparator1,
            this.toolStripMenuItem9});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem6.Text = "Главная";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem8.Text = "Загрузить Excel";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.LoadExelClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItem9.Text = "Сохранить в Excel";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.btnSaveToExel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem1.Text = "Добавление";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem3.Text = "Добавить Студента";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.btnAddRow_Student_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem4.Text = "Добавить Дисциплину";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.btnAddRow_Subj_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(198, 22);
            this.toolStripMenuItem5.Text = "Добавить Работу";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.btnAddRow_Work_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.помощьToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem10});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItem7.Text = "О программе";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.помощьToolStripMenuItem.Text = "Помощь";
            this.помощьToolStripMenuItem.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem10.Text = "Версия: 1.0.1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1008, 286);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 325);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учет успеваемости студентов ВУЗа СГУГиТ 2023";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmBWork1;
        private System.Windows.Forms.Button btnUseFiltrs;
        private System.Windows.Forms.Button btnCancelFilters;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.Button loadExelBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
    }
}

