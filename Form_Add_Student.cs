using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class Form_Add_Student : Form
    {
        DataGridView mainDGV;
        Database database;
        ComboBox cmBTableChoice;

        public Form_Add_Student()
        {
            InitializeComponent();
        }

        public Form_Add_Student(Database database, DataGridView mainDGV, ComboBox cmBTableChoice)
        {
            InitializeComponent();
            this.database = database;
            this.mainDGV = mainDGV;
            this.cmBTableChoice = cmBTableChoice;
            UpdateYear();
            UpdateGroup();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (sender == btnAddRow_Student && cmBTableChoice.Enabled == true)
            {
                if (cmBGroup.Text != "" && cmBYear.Text != "" && tBName.Text != "")
                {
                    if (database.CheckRecordExistStudent(cmBGroup.Text, cmBYear.Text, tBName.Text) == false)
                    {
                        database.InsertRowToDBUseBtn(mainDGV, cmBGroup.Text, Convert.ToInt32(cmBYear.Text), tBName.Text);
                        UpdateGroup();

                        if (cmBTableChoice.SelectedIndex == 1)
                            database.ShowTable(mainDGV, 1);
                        else
                            cmBTableChoice.SelectedIndex = 1;
                    }
                    else
                    {
                        MessageBox.Show("Данная запись уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Поля не могут быть путыми", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void UpdateGroup()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetGroup();

            cmBGroup.Items.Clear();

            cmBGroup.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBGroup.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        public void UpdateYear()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetYear();

            cmBYear.Items.Clear();

            cmBYear.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBYear.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        
        private void cmBYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBYear.SelectedIndex != -1)
            {
                if (cmBYear.SelectedIndex == 0)
                {
                    UpdateGroup();
                }
                else
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Обновление для Групп
                    string query = $" WHERE Year = '{cmBYear.Text}'";
                    dataTable = database.GetGroup_cmB(query);
                    cmBGroup.Items.Clear();
                    cmBGroup.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBGroup.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                }
            }
        }


    }
}
