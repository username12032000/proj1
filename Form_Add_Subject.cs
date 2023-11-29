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
    public partial class Form_Add_Subject : Form
    {
        DataGridView mainDGV;
        Database database;
        ComboBox cmBTableChoice;

        public Form_Add_Subject()
        {
            InitializeComponent();
        }

        public Form_Add_Subject(Database database, DataGridView mainDGV, ComboBox cmBTableChoice)
        {
            InitializeComponent();
            this.database = database;
            this.mainDGV = mainDGV;
            this.cmBTableChoice = cmBTableChoice;
            UpdateYear();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (sender == btnAddRow_Subj && cmBTableChoice.Visible == true)
            {
                if (tBSubjName.Text != "" && cmBYear.Text != "")
                {
                    if (database.CheckRecordExistSubj(tBSubjName.Text, cmBYear.Text) == false)
                    {
                        database.InsertRowToDBUseBtn(mainDGV, tBSubjName.Text, Convert.ToInt32(cmBYear.Text));

                        if (cmBTableChoice.SelectedIndex == 2)
                            database.ShowTable(mainDGV, 2);
                        else
                            cmBTableChoice.SelectedIndex = 2;
                    }
                    else
                    {
                        MessageBox.Show("Данная запись уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Поле не может быть путым", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    }
}
