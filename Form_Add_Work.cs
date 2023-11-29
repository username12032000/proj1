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
    public partial class Form_Add_Work : Form
    {
        DataGridView mainDGV;
        Database database;
        ComboBox cmBTableChoice;

        public Form_Add_Work()
        {
            InitializeComponent();
        }

        public Form_Add_Work(Database database, DataGridView mainDGV, ComboBox cmBTableChoice)
        {
            InitializeComponent();
            this.database = database;
            this.mainDGV = mainDGV;
            this.cmBTableChoice = cmBTableChoice;
            UpdateYear();
            UpdateSubj();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (sender == btnAddRow_Work && cmBTableChoice.Enabled == true)
            {
                if (cmBSubj.Text != "" && tBWorkName.Text != "" && cmBYear.Text != "")
                {
                    if (database.CheckRecordExistWork(cmBSubj.Text, cmBYear.Text, tBWorkName.Text) == false)
                    {
                        database.InsertRowToDBUseBtn(mainDGV, cmBSubj.Text, tBWorkName.Text, Convert.ToInt32(cmBYear.Text));

                        if (cmBTableChoice.SelectedIndex == 3)
                            database.ShowTable(mainDGV, 3);
                        else
                            cmBTableChoice.SelectedIndex = 3;
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

        private void UpdateSubj()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetSubject();
            cmBSubj.Items.Clear();

            cmBSubj.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBSubj.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        private void cmBYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBYear.SelectedIndex != -1)
            {
                if (cmBYear.SelectedIndex == 0)
                {
                    UpdateSubj();
                }
                else
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    
                    // Обновление для Предметов
                    string query = $" WHERE Year = '{cmBYear.Text}'";
                    dataTable = database.GetSubject_cmB(query);
                    cmBSubj.Items.Clear();
                    cmBSubj.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBSubj.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                }
            }
        }


    }
}
