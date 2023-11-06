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
    public partial class Form_Edit_Subject : Form
    {
        string subjNameNew = "";
        string yearNew = "";
        Database database;
        public Form_Edit_Subject()
        {
            InitializeComponent();
        }

        public Form_Edit_Subject(Database database, string subjName, string year)
        {
            InitializeComponent();
            this.database = database;
            tBSubjOld.Text = subjName;
            tBYearOld.Text = year;
            tBSubjNew.Text = subjName;
            tBYearNew.Text = year;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (tBSubjNew.Text != "" && tBYearNew.Text != "")
            {
                if (tBSubjNew.Text == tBSubjOld.Text && tBYearNew.Text == tBYearOld.Text)
                {
                    MessageBox.Show("Старые и новые данные не могут совпадать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (database.CheckRecordExistSubj(tBSubjNew.Text, tBYearNew.Text) == true)
                {
                    MessageBox.Show("Данная запись уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    subjNameNew = tBSubjNew.Text;
                    yearNew = tBYearNew.Text;
                    database.EditRecordSubj(tBSubjOld.Text, tBYearOld.Text, subjNameNew, yearNew);
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
