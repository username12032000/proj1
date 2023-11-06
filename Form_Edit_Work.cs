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
    public partial class Form_Edit_Work : Form
    {
        string workNameNew = "";
        Database database;
        public Form_Edit_Work()
        {
            InitializeComponent();
        }

        public Form_Edit_Work(Database database, string subj, string year, string name)
        {
            InitializeComponent();
            this.database = database;
            tBSubjOld.Text = subj;
            tBYearOld.Text = year;
            tBWorkOld.Text = name;
            tBWorkNew.Text = name;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tBWorkNew.Text != "")
            {
                if (tBWorkNew.Text == tBWorkOld.Text)
                {
                    MessageBox.Show("Старые и новые данные не могут совпадать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (database.CheckRecordExistWork(tBSubjOld.Text, tBYearOld.Text, tBWorkNew.Text) == true)
                {
                    MessageBox.Show("Данная запись уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    workNameNew = tBWorkNew.Text;
                    database.EditRecordWork(tBSubjOld.Text, tBYearOld.Text, tBWorkOld.Text, tBWorkNew.Text);
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
