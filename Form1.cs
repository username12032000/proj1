#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using OfficeOpenXml;// Подключение EPPlus
using Exel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;
using OfficeOpenXml.Style;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Students
{
    public partial class Form1 : Form
    {
        Database database;

        public Form1()
        {
            InitializeComponent();

            // БД
            database = new Database();
            database.ShowTable(mainDGV, 0);

            // Начальные установки
            cmBTableChoice.Enabled = true;
            cmBTableChoice.SelectedIndex = 0;

            //// Обновление cmB's
            //UpdateYear();
            //UpdateGroup();

        }

        #region [Загрузка Exel]
        private void LoadExelClick(object sender, EventArgs e) // Нажатие на кнопку загрузки Exel
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Открытие диалога
            openFileDialog.Filter = "Файлы Exel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Выберите файл Excel для открытия";

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Если файл выбран
            {
                string selectedFilePath = openFileDialog.FileName;// Путь до файла exel


                try
                {
                    ExcelPackage excel = new ExcelPackage(new FileInfo($"{selectedFilePath}"));
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Установка для exel
                    ExcelWorksheet list = excel.Workbook.Worksheets[0];

                    // Проверка файла Exel
                    // 1) Названия колонок
                    // 2) Год - 4 цифры
                    // 3) Пустые клетки
                    // 4) Короткие строки
                    if (CheckExel(list) == false)
                        return;


                    // Установка элементов которые будут отображены
                    cmBTableChoice.Enabled = true;
                    cmBTableChoice.SelectedIndex = 0;
                    database.ShowTable(mainDGV, 0);

                    UpdateSubj();
                    UpdateYear();
                    UpdateGroup();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region [Вывод таблиц и обновление данных для фильтров]
        private void cmBTableChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender == cmBTableChoice || sender == loadExelBtn) && cmBTableChoice.Visible == true)
            {
                database.ShowTable(mainDGV, cmBTableChoice.SelectedIndex);
            }


            if (cmBTableChoice.SelectedIndex == 0) // Группы
            {
                cmBYear1.Enabled = true;
                cmBGroup1.Enabled = true;
                cmBFIO1.Enabled = false;
                cmBFIO1.Items.Clear();
                cmBSubj1.Enabled = false;
                cmBSubj1.Items.Clear();
                cmBWork1.Enabled = false;
                cmBWork1.Items.Clear();

                UpdateYear();
                UpdateGroup();

            }
            else if (cmBTableChoice.SelectedIndex == 1) // Студенты
            {
                cmBYear1.Enabled = true;
                cmBGroup1.Enabled = true;
                cmBFIO1.Enabled = true;
                cmBSubj1.Enabled = false;
                cmBSubj1.Items.Clear();
                cmBWork1.Enabled = false;
                cmBWork1.Items.Clear();

                UpdateYear();
                UpdateGroup();
                UpdateFIO();
            }
            else if (cmBTableChoice.SelectedIndex == 2) // Предметы
            {
                cmBYear1.Enabled = true;
                cmBGroup1.Enabled = false;
                cmBGroup1.Items.Clear();
                cmBFIO1.Enabled = false;
                cmBFIO1.Items.Clear();
                cmBSubj1.Enabled = true;
                cmBWork1.Enabled = false;
                cmBWork1.Items.Clear();

                UpdateYear();
                UpdateSubj();
            }
            else if (cmBTableChoice.SelectedIndex == 3) // Работы
            {
                cmBYear1.Enabled = true;
                cmBGroup1.Enabled = false;
                cmBGroup1.Items.Clear();
                cmBFIO1.Enabled = false;
                cmBFIO1.Items.Clear();
                cmBSubj1.Enabled = true;
                cmBWork1.Enabled = true;

                UpdateYear();
                UpdateSubj();
                UpdateWork();
            }
            else if (cmBTableChoice.SelectedIndex == 4) // Оценки
            {
                cmBYear1.Enabled = true;
                cmBGroup1.Enabled = true;
                cmBFIO1.Enabled = true;
                cmBSubj1.Enabled = true;
                cmBWork1.Enabled = true;

                UpdateYear();
                UpdateGroup();
                UpdateFIO();
                UpdateSubj();
                UpdateWork();
            }
            else
            {
                cmBYear1.Enabled = false;
                cmBGroup1.Enabled = false;
                cmBFIO1.Enabled = false;
                cmBSubj1.Enabled = false;
                cmBWork1.Enabled = false;
            }
        }

        #endregion

        #region [Обновление и заполнение cmB's]
        private void UpdateGroup()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetGroup();

            cmBGroup1.Items.Clear();

            cmBGroup1.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBGroup1.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        private void UpdateFIO()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetFIO();

            cmBFIO1.Items.Clear();

            cmBFIO1.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBFIO1.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        private void UpdateSubj()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetSubject();
            cmBSubj1.Items.Clear();
            cmBSubj2.Items.Clear();

            cmBSubj1.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBSubj1.Items.Add(dataTable.Rows[i].ItemArray[0]);
                cmBSubj2.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        private void UpdateYear()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetYear();

            cmBYear1.Items.Clear();
            cmBYear2.Items.Clear();
            cmBYear3.Items.Clear();

            cmBYear1.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBYear1.Items.Add(dataTable.Rows[i].ItemArray[0]);
                cmBYear2.Items.Add(dataTable.Rows[i].ItemArray[0]);
                cmBYear3.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        private void UpdateWork()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable = database.GetWork();

            cmBWork1.Items.Clear();

            cmBWork1.Items.Add("");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cmBWork1.Items.Add(dataTable.Rows[i].ItemArray[0]);
            }
        }

        #endregion

        #region [Обработка нажатий кнопок]
        private void btnAddRow_Subj_Click(object sender, EventArgs e) // Предметы
        {
            if (sender == btnAddRow_Subj && cmBTableChoice.Visible == true)
            {
                if (tBSubjName.Text != "" && cmBYear2.Text != "")
                {
                    if (database.CheckRecordExistSubj(tBSubjName.Text, cmBYear2.Text) == false)
                    {
                        database.InsertRowToDBUseBtn(mainDGV, tBSubjName.Text, Convert.ToInt32(cmBYear2.Text));

                        if (cmBTableChoice.SelectedIndex == 2)
                            database.ShowTable(mainDGV, 2);
                        else
                            cmBTableChoice.SelectedIndex = 2;

                        UpdateSubj();
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

        private void btnAddRow_Work_Click(object sender, EventArgs e) // Работы
        {
            if (sender == btnAddRow_Work && cmBTableChoice.Enabled == true)
            {
                if (cmBSubj2.Text != "" && tBWorkName.Text != "" && cmBYear3.Text != "")
                {
                    if (database.CheckRecordExistWork(cmBSubj2.Text, cmBYear3.Text, tBWorkName.Text) == false)
                    {
                        database.InsertRowToDBUseBtn(mainDGV, cmBSubj2.Text, tBWorkName.Text, Convert.ToInt32(cmBYear3.Text));

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

        private void btnUseFiltrs_Click(object sender, EventArgs e) // Фильтр
        {
            // Группа
            if (cmBTableChoice.SelectedIndex == 0)
            {
                if (cmBGroup1.SelectedIndex == -1 && cmBYear1.SelectedIndex == -1)
                {
                    database.ShowTable(mainDGV, 0);
                }
                else
                {
                    string addQuery = "";

                    if (cmBGroup1.Text != "" || cmBYear1.Text != "")
                    {
                        string group = "";
                        string year = "";

                        if (cmBGroup1.Text != "")
                            group = $"GroupName = '{cmBGroup1.Text}'";
                        if (cmBYear1.Text != "")
                            year = $"Year = '{cmBYear1.Text}'";

                        string result_string = $"{group} AND {year}";
                        while (result_string.IndexOf(" AND ") == 0)
                            result_string = result_string.Remove(0, 5);
                        while (result_string.IndexOf(" AND ", result_string.Length - 5) == result_string.Length - 5)
                            result_string = result_string.Remove(result_string.Length - 5);
                        addQuery = $" WHERE {result_string}";
                    }
                    // Вывод с условием
                    database.ShowTable(mainDGV, 0, addQuery);
                }
            }
            // Студент
            else if (cmBTableChoice.SelectedIndex == 1)
            {
                if (cmBGroup1.SelectedIndex == -1 && cmBYear1.SelectedIndex == -1 && cmBFIO1.SelectedIndex == -1)
                {
                    database.ShowTable(mainDGV, 1);
                }
                else
                {
                    string addQuery = "";

                    if (cmBGroup1.Text != "" || cmBYear1.Text != "" || cmBFIO1.Text != "")
                    {
                        string group = "";
                        string year = "";
                        string fio = "";

                        if (cmBGroup1.Text != "")
                            group = $"t1.GroupName = '{cmBGroup1.Text}'";
                        if (cmBYear1.Text != "")
                            year = $"t1.Year = '{cmBYear1.Text}'";
                        if (cmBFIO1.Text != "")
                            fio = $"t2.Name = '{cmBFIO1.Text}'";

                        string result_string = $" AND {group} AND {year} AND {fio}";
                        while ((result_string.Remove(0, 5)).IndexOf(" AND ") == 0)
                            result_string = result_string.Remove(5, 5);
                        while (result_string.IndexOf(" AND  AND ") != -1)
                            result_string = result_string.Replace(" AND  AND ", " AND ");
                        while (result_string.IndexOf(" AND ", result_string.Length - 5) == result_string.Length - 5)
                            result_string = result_string.Remove(result_string.Length - 5);
                        addQuery = $"{result_string}";
                    }
                    // Вывод с условием
                    database.ShowTable(mainDGV, 1, addQuery);
                }
            }
            // Предмет
            else if (cmBTableChoice.SelectedIndex == 2)
            {
                if (cmBSubj1.SelectedIndex == -1 && cmBYear1.SelectedIndex == -1)
                {
                    database.ShowTable(mainDGV, 2);
                }
                else
                {
                    string addQuery = "";

                    if (cmBSubj1.Text != "" || cmBYear1.Text != "")
                    {
                        string subject = "";
                        string year = "";

                        if (cmBSubj1.Text != "")
                            subject = $"SubjectName = '{cmBSubj1.Text}'";
                        if (cmBYear1.Text != "")
                            year = $"Year = '{cmBYear1.Text}'";

                        string result_string = $"{subject} AND {year}";
                        while (result_string.IndexOf(" AND ") == 0)
                            result_string = result_string.Remove(0, 5);
                        while (result_string.IndexOf(" AND ", result_string.Length - 5) == result_string.Length - 5)
                            result_string = result_string.Remove(result_string.Length - 5);
                        addQuery = $"WHERE {result_string};";
                    }
                    // Вывод с условием
                    database.ShowTable(mainDGV, 2, addQuery);
                }
            }
            // Работа
            else if (cmBTableChoice.SelectedIndex == 3)
            {
                if (cmBSubj1.SelectedIndex == -1 && cmBYear1.SelectedIndex == -1 && cmBWork1.SelectedIndex == -1)
                {
                    database.ShowTable(mainDGV, 3);
                }
                else
                {
                    string addQuery = "";

                    if (cmBSubj1.Text != "" || cmBYear1.Text != "" || cmBWork1.Text != "")
                    {
                        string subject = "";
                        string year = "";
                        string work = "";

                        if (cmBSubj1.Text != "")
                            subject = $"t2.SubjectName = '{cmBSubj1.Text}'";
                        if (cmBYear1.Text != "")
                            year = $"t2.Year = '{cmBYear1.Text}'";
                        if (cmBWork1.Text != "")
                            work = $"t1.WorkName = '{cmBWork1.Text}'";

                        string result_string = $" AND {subject} AND {year} AND {work}";
                        while ((result_string.Remove(0, 5)).IndexOf(" AND ") == 0)
                            result_string = result_string.Remove(5, 5);
                        while (result_string.IndexOf(" AND  AND ") != -1)
                            result_string = result_string.Replace(" AND  AND ", " AND ");
                        while (result_string.IndexOf(" AND ", result_string.Length - 5) == result_string.Length - 5)
                            result_string = result_string.Remove(result_string.Length - 5);
                        addQuery = $"{result_string}";
                    }
                    // Вывод с условием
                    database.ShowTable(mainDGV, 3, addQuery);
                }
            }
            // Оценки
            else if (cmBTableChoice.SelectedIndex == 4)
            {
                if (cmBGroup1.SelectedIndex == -1 && cmBFIO1.SelectedIndex == -1 && cmBSubj1.SelectedIndex == -1 && cmBYear1.SelectedIndex == -1 && cmBWork1.SelectedIndex == -1)
                {
                    database.ShowTable(mainDGV, 4);
                }
                else if (cmBGroup1.SelectedIndex >= 1 && cmBSubj1.SelectedIndex >= 1 && cmBYear1.SelectedIndex >= 1 && cmBFIO1.SelectedIndex < 1 && cmBWork1.SelectedIndex < 1)
                {

                    // Вывод с ОСОБЫМ условием
                    database.ShowTable(mainDGV, cmBGroup1.Text, cmBYear1.Text, cmBSubj1.Text);
                }
                else
                {
                    string addQuery = "";

                    if (cmBGroup1.Text != "" || cmBFIO1.Text != "" || cmBSubj1.Text != "" || cmBYear1.Text != "" || cmBWork1.Text != "")
                    {
                        string group = "";
                        string fio = "";
                        string subject = "";
                        string year = "";
                        string work = "";

                        if (cmBGroup1.Text != "")
                            group = $"[Группа] = '{cmBGroup1.Text}'";
                        if (cmBFIO1.Text != "")
                            fio = $"[ФИО] = '{cmBFIO1.Text}'";
                        if (cmBSubj1.Text != "")
                            subject = $"[Предмет] = '{cmBSubj1.Text}'";
                        if (cmBYear1.Text != "")
                            year = $"[Год] = '{cmBYear1.Text}'";
                        if (cmBWork1.Text != "")
                            work = $"[Работа] = '{cmBWork1.Text}'";

                        string result_string = $" WHERE {group} AND {fio} AND {subject} AND {year} AND {work}";
                        while ((result_string.Remove(0, 7)).IndexOf(" AND ") == 0)
                            result_string = result_string.Remove(7, 5);
                        while (result_string.IndexOf(" AND  AND ") != -1)
                            result_string = result_string.Replace(" AND  AND ", " AND ");
                        while (result_string.IndexOf(" AND ", result_string.Length - 5) == result_string.Length - 5)
                            result_string = result_string.Remove(result_string.Length - 5);
                        addQuery = $"{result_string}";
                    }
                    // Вывод с условием
                    database.ShowTable(mainDGV, 4, addQuery);
                }
            }
        }

        private void btnCancelFilters_Click(object sender, EventArgs e) // Сброс фильтров
        {
            if (cmBGroup1.Enabled == true && cmBGroup1.Items.Count > 0)
                cmBGroup1.SelectedIndex = 0;
            if (cmBSubj1.Enabled == true && cmBSubj1.Items.Count > 0)
                cmBSubj1.SelectedIndex = 0;
            if (cmBYear1.Enabled == true && cmBYear1.Items.Count > 0)
                cmBYear1.SelectedIndex = 0;
            if (cmBWork1.Enabled == true && cmBWork1.Items.Count > 0)
                cmBWork1.SelectedIndex = 0;
            if (cmBFIO1.Enabled == true && cmBFIO1.Items.Count > 0)
                cmBFIO1.SelectedIndex = 0;
            database.ShowTable(mainDGV, cmBTableChoice.SelectedIndex);
        }

        #endregion

        #region [Обработка нажатия на dGV]
        private void mainDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mainDGV.Columns[e.ColumnIndex].HeaderText == "Удаление" && (e.RowIndex > -1 || e.ColumnIndex > -1))
            {
                if (cmBTableChoice.SelectedIndex == 0)
                {
                    database.DeleteRowFromDGVandDB(mainDGV, 0, "Group", e.RowIndex, e.ColumnIndex);
                    database.ShowTable(mainDGV, 0);
                    UpdateGroup();
                    UpdateYear();
                }
                if (cmBTableChoice.SelectedIndex == 1)
                {
                    database.DeleteRowFromDGVandDB(mainDGV, 1, "Student", e.RowIndex, e.ColumnIndex);
                    database.ShowTable(mainDGV, 1);
                    UpdateFIO();
                }
                if (cmBTableChoice.SelectedIndex == 2)
                {
                    database.DeleteRowFromDGVandDB(mainDGV, 2, "Subject", e.RowIndex, e.ColumnIndex);
                    database.ShowTable(mainDGV, 2);
                    UpdateYear();
                    UpdateSubj();
                }
                if (cmBTableChoice.SelectedIndex == 3)
                {
                    database.DeleteRowFromDGVandDB(mainDGV, 3, "Work", e.RowIndex, e.ColumnIndex);
                    database.ShowTable(mainDGV, 3);
                    UpdateWork();
                }
            }
            else if (mainDGV.Columns[e.ColumnIndex].HeaderText == "Редактирование" && (e.RowIndex > -1 || e.ColumnIndex > -1))
            {
                if (cmBTableChoice.SelectedIndex == 0)
                {
                    Form_Edit_Group form_Edit_Group = new Form_Edit_Group(database, mainDGV.Rows[e.RowIndex].Cells[0].Value.ToString(), mainDGV.Rows[e.RowIndex].Cells[1].Value.ToString());
                    form_Edit_Group.ShowDialog();
                    database.ShowTable(mainDGV, 0);
                    UpdateGroup();
                    UpdateYear();
                }
                if (cmBTableChoice.SelectedIndex == 1)
                {
                    Form_Edit_Student form_Edit_Student = new Form_Edit_Student(database, mainDGV.Rows[e.RowIndex].Cells[1].Value.ToString(), mainDGV.Rows[e.RowIndex].Cells[2].Value.ToString(), mainDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                    form_Edit_Student.ShowDialog();
                    database.ShowTable(mainDGV, 1);
                    UpdateFIO();
                }
                if (cmBTableChoice.SelectedIndex == 2)
                {
                    Form_Edit_Subject form_Edit_Group = new Form_Edit_Subject(database, mainDGV.Rows[e.RowIndex].Cells[0].Value.ToString(), mainDGV.Rows[e.RowIndex].Cells[1].Value.ToString());
                    form_Edit_Group.ShowDialog();
                    database.ShowTable(mainDGV, 2);
                    UpdateYear();
                    UpdateSubj();
                }
                if (cmBTableChoice.SelectedIndex == 3)
                {
                    Form_Edit_Work form_Edit_Student = new Form_Edit_Work(database, mainDGV.Rows[e.RowIndex].Cells[1].Value.ToString(), mainDGV.Rows[e.RowIndex].Cells[2].Value.ToString(), mainDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
                    form_Edit_Student.ShowDialog();
                    database.ShowTable(mainDGV, 3);
                    UpdateWork();
                }
            }
        }

        #endregion

        private void mainDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e) // Изменение оценок
        {
            // Условие проверки заголовка
            if (mainDGV.Columns[e.ColumnIndex].HeaderText == "Год" ||
                mainDGV.Columns[e.ColumnIndex].HeaderText == "Группа" ||
                mainDGV.Columns[e.ColumnIndex].HeaderText == "ФИО" ||
                mainDGV.Columns[e.ColumnIndex].HeaderText == "Предмет" ||
                mainDGV.Columns[e.ColumnIndex].HeaderText == "Работа")
                return;

            // Переменные для хранения промежуточной информации
            string group = "";
            string fio = "";
            string subj = "";
            string work = "";
            string year = "";
            string value = "";

            // Проверяем решили ли мы изменить Оценку в столбце оценок
            if (mainDGV.Columns[e.ColumnIndex].HeaderText == "Оценка")
            {
                int ind = 0;
                foreach (DataGridViewColumn column in mainDGV.Columns) // Перебор всех столбцов
                {
                    // Получаем данные из строки Таблицы
                    if (column.HeaderText == "Группа")
                        group = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "ФИО")
                        fio = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "Предмет")
                        subj = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "Работа")
                        work = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "Год")
                        year = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "Оценка")
                        value = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    ind++;
                }

                database.UpdateGrade(group, fio, subj, work, year, value); // Обновление оценок
            }
            // Если изменили значение где нет столбца оценок [Особый вывод]
            else
            {
                int ind = 0;
                foreach (DataGridViewColumn column in mainDGV.Columns) // Перебор всех столбцов
                {
                    // Получаем данные из строки Таблицы
                    if (column.HeaderText == "Группа")
                        group = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "ФИО")
                        fio = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "Предмет")
                        subj = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";
                    if (column.HeaderText == "Год")
                        year = $"{mainDGV.Rows[e.RowIndex].Cells[ind].Value}";

                    // Ищем название предмета
                    if (column.HeaderText != "Группа" &&
                        column.HeaderText != "ФИО" &&
                        column.HeaderText != "Предмет" &&
                        column.HeaderText != "Год" &&
                        column.Index == e.ColumnIndex) // Дополнительная проверка на нужный столбец
                    {
                        work = $"{column.HeaderText}";
                        value = $"{mainDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}";
                    }
                    ind++;
                }
                database.UpdateGrade(group, fio, subj, work, year, value); // Обновление оценок
            }
        }

        private void cmBYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBYear1.SelectedIndex != -1)
            {
                if (cmBYear1.SelectedIndex == 0)
                {
                    btnCancelFilters_Click(sender, e);
                    UpdateGroup();
                    UpdateSubj();
                }
                else
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    // Обновление для Групп
                    string query = $" WHERE Year = '{cmBYear1.Text}'";
                    dataTable = database.GetGroup_cmB(query);
                    cmBGroup1.Items.Clear();
                    cmBGroup1.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBGroup1.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                    // Обновление для Предметов
                    query = $" WHERE Year = '{cmBYear1.Text}'";
                    dataTable = database.GetSubject_cmB(query);
                    cmBSubj1.Items.Clear();
                    cmBSubj1.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBSubj1.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                }
            }
        }

        private void cmBGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBGroup1.SelectedIndex != -1)
            {
                if (cmBGroup1.SelectedIndex == 0)
                {
                    if (cmBFIO1.Enabled == true && cmBFIO1.Items.Count > 0)
                        cmBFIO1.SelectedIndex = 0;
                    UpdateFIO();
                }
                else
                {
                    if (cmBFIO1.Enabled == true && cmBFIO1.Items.Count > 0)
                        cmBFIO1.SelectedIndex = 0;

                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    string year = "";
                    if (cmBYear1.Text != "")
                    {
                        year = $" AND t2.Year = '{cmBYear1.Text}'";
                    }
                    // Обновление для ФИО
                    string query = $" WHERE t1.GroupId = (SELECT t2.GroupId From \"Group\" as 't2' WHERE t2.GroupName = '{cmBGroup1.Text}'{year})";
                    dataTable = database.GetFIO_cmB(query);
                    cmBFIO1.Items.Clear();
                    cmBFIO1.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBFIO1.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                }
            }
        }

        private void cmBSubj1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBSubj1.SelectedIndex != -1)
            {
                if (cmBSubj1.SelectedIndex == 0)
                {
                    if (cmBWork1.Enabled == true && cmBWork1.Items.Count > 0)
                        cmBWork1.SelectedIndex = 0;
                    UpdateWork();
                }
                else
                {
                    if (cmBWork1.Enabled == true && cmBWork1.Items.Count > 0)
                        cmBWork1.SelectedIndex = 0;

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    string year = "";
                    if (cmBYear1.Text != "")
                    {
                        year = $" AND t2.Year = '{cmBYear1.Text}'";
                    }
                    // Обновление для ФИО
                    string query = $" WHERE t1.SubjectId = (SELECT t2.SubjectId From \"Subject\" as 't2' WHERE t2.SubjectName = '{cmBSubj1.Text}')";
                    dataTable = database.GetWork_cmB(query);
                    cmBWork1.Items.Clear();
                    cmBWork1.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBWork1.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                }
            }
        }

        private void cmBYear3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBYear3.SelectedIndex != -1)
            {
                if (cmBYear3.SelectedIndex == 0)
                {
                    UpdateSubj();
                }
                else
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();

                    // Обновление для Предметов
                    string query = $" WHERE Year = '{cmBYear3.Text}'";
                    dataTable = database.GetSubject_cmB(query);
                    cmBSubj2.Items.Clear();
                    cmBSubj2.Items.Add("");
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        cmBSubj2.Items.Add(dataTable.Rows[i].ItemArray[0]);
                    }
                }
            }
        }

        private bool CheckExel(ExcelWorksheet list) // Проверка Exel файла
        {
            // Проверка названий колонок
            if (Convert.ToString(list.Cells["A1"].Value) != "ФИО")
            {
                MessageBox.Show("Нет названия колонки 'ФИО' в клетке A1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToString(list.Cells["B1"].Value) != "Группа")
            {
                MessageBox.Show("Нет названия колонки 'Группа' в клетке B1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Convert.ToString(list.Cells["C1"].Value) != "Год")
            {
                MessageBox.Show("Нет названия колонки 'Год' в клетке C1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            int empCell = 0;
            int falseYear = 0;


            // Переменные для хранения данных
            string? FIO;
            string? groupe;
            string? year;

            // Перебор строк
            for (int i = 2; i <= list.Dimension.Rows; i++)
            {
                FIO = Convert.ToString(list.Cells["A" + i].Value);
                groupe = Convert.ToString(list.Cells["B" + i].Value);
                year = Convert.ToString(list.Cells["C" + i].Value);

                if (FIO == null || FIO == "" || groupe == null || groupe == "" || year == null || year.ToString() == "")
                {
                    empCell++;
                    continue;
                }
                else if (year.ToString().Length > 4 || year.ToString().Length < 4 || !int.TryParse(year, out _))
                {
                    falseYear++;
                    continue;
                }
                else
                {
                    database.InsertRowToDBFromExel(FIO, groupe, year);
                }
            }

            MessageBox.Show($"Всего строк: {list.Dimension.Rows - 1}\n" +
                            $"Пустых клеток: {empCell}\n" +
                            $"Не верный год: {falseYear}\n" +
                            $"Строк добавленно: {list.Dimension.Rows - 1 - empCell - falseYear}", "Добавленные строки", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        private void btnSaveToExel_Click(object sender, EventArgs e)
        {
            if (mainDGV.Columns.Count <= 0)
            {
                MessageBox.Show("Пустая таблица...\n" +
                                "Нечего экспортировать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mainDGV.Rows.Count <= 0)
            {
                MessageBox.Show("В таблице нету строк для экспорта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            { // Доступ к Exel файлу


                // Создаем новую рабочую книгу Excel
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Заполняем заголовки столбцов
                for (int i = 1; i <= mainDGV.Columns.Count; i++)
                {
                    if (mainDGV.Columns[i - 1].HeaderText == "Редактирование" || mainDGV.Columns[i - 1].HeaderText == "Удаление")
                        continue;
                    worksheet.Cells[1, i].Value = mainDGV.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                    worksheet.Cells[1, i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[1, i].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                // Заполняем данные
                for (int i = 0; i < mainDGV.Rows.Count; i++)
                {
                    for (int j = 0; j < mainDGV.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = mainDGV.Rows[i].Cells[j].Value.ToString();
                        worksheet.Cells[i + 2, j + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[i + 2, j + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }
                }

                // Автонастройка размеров столбцов
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                DateTime currentDate = DateTime.Now;
                string file_path = $"Import_data_{currentDate.ToString("dd.MM.yyyy_HH.mm.ss")}.xlsx";

                // Сохраняем файл Excel
                File.WriteAllBytes(file_path, package.GetAsByteArray());

                // Получение полного пути
                FileInfo f = new FileInfo(file_path);
                string full_path = $@"""{f.FullName}"""; // [кавычки нужны для пути содержащего пробелы] [@ для одного '\']

                // Открытие сохраненного файла
                Process process = new Process();
                Process.Start("Excel.exe", $"{full_path}");
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //// Получение полного пути
            //FileInfo f = new FileInfo("help.chm");
            //string full_path = f.FullName;

            // Открытие файла справки
            try
            {
                Process process = new Process();
                Process.Start("help.chm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                MessageBox.Show("Файл справки не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
