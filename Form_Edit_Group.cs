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
    public partial class Form_Edit_Group : Form
    {
        string groupNameNew = "";
        string yearNew = "";
        Database database;
        public Form_Edit_Group()
        {
            InitializeComponent();
        }

        public Form_Edit_Group(Database database, string groupName, string year)
        {
            InitializeComponent();
            this.database = database;
            tBGroupOld.Text = groupName;
            tBYearOld.Text = year;
            tBGroupNew.Text = groupName;
            tBYearNew.Text = year;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tBGroupNew.Text != "" && tBYearNew.Text != "")
            {
                if (tBGroupNew.Text == tBGroupOld.Text && tBYearNew.Text == tBYearOld.Text)
                {
                    MessageBox.Show("Старые и новые данные не могут совпадать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (database.CheckRecordExistGroup(tBGroupNew.Text, tBYearNew.Text) == true)
                {
                    MessageBox.Show("Данная запись уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    groupNameNew = tBGroupNew.Text;
                    yearNew = tBYearNew.Text;
                    database.EditRecordGroup(tBGroupOld.Text, tBYearOld.Text, groupNameNew, yearNew);
                    MessageBox.Show("Запись обновленна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();//закрытие формы
                }
            }
            else
            {
                MessageBox.Show("Поля не могут быть пустыми!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
