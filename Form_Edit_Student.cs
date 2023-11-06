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
    public partial class Form_Edit_Student : Form
    {
        string nameNew = "";
        Database database;
        public Form_Edit_Student()
        {
            InitializeComponent();
        }


        public Form_Edit_Student(Database database, string groupName, string year, string name)
        {
            InitializeComponent();
            this.database = database;
            tBGroupOld.Text = groupName;
            tBYearOld.Text = year;
            tBNameOld.Text = name;
            tBNameNew.Text = name;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tBNameNew.Text != "")
            {
                if (tBNameNew.Text == tBNameOld.Text)
                {
                    MessageBox.Show("Старые и новые данные не могут совпадать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (database.CheckRecordExistStudent(tBGroupOld.Text, tBYearOld.Text, tBNameNew.Text) == true)
                {
                    MessageBox.Show("Данная запись уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    nameNew = tBNameNew.Text;
                    database.EditRecordStudent(tBGroupOld.Text, tBYearOld.Text, tBNameOld.Text,tBNameNew.Text);
                    MessageBox.Show("Запись обновленна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();//закрытие формы
                }
            }
            else
            {
                MessageBox.Show("Поле не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
