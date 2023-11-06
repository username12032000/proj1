using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Windows;
using System.Data.Entity;
using System.Data.Common;

namespace Students
{
    public class Database
    {
        private static string dbFileName = "main_DB.sqlite"; // Название файла БД
        private static SQLiteConnection SQLiteConnection = null; // Информация о подключении к БД
        private SQLiteCommand command; // Выполнение запросов
        private SQLiteDataAdapter adapter;
        private DataTable dataTable; // Таблица

        public Database()//System.Windows.Forms.ComboBox cbxGroup
        {
            SQLiteConnection = new SQLiteConnection($"Data Source={dbFileName};Version=3;"); // Соединение с БД

            // Проверяем наличие файла БД
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName); // Сохдание файла
            CreateOrCheckStartDB(); // Создание БД
        }

        #region[Создание БД]
        private void CreateOrCheckStartDB() // Создание начальной БД
        {
            command = new SQLiteCommand();
            try
            {
                SQLiteConnection.Open();
                command.Connection = SQLiteConnection;
                // запрос на создания таблиц БД
                command.CommandText = "PRAGMA foreign_keys=on;" +

                                        "CREATE TABLE IF NOT EXISTS [Group] (" +
                                            "[GroupId] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                            "[GroupName] TEXT NOT NULL," +
                                            "[Year] INTEGER NOT NULL);" +

                                        "CREATE TABLE IF NOT EXISTS [Student] (" +
                                            "[StudentId] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                            "[Name] TEXT NOT NULL," +
                                            "[GroupId] INTEGER," +
                                            "FOREIGN KEY (GroupId) REFERENCES [Group] (GroupId) ON DELETE CASCADE ON UPDATE CASCADE);" +

                                        "CREATE TABLE IF NOT EXISTS [Subject] (" +
                                            "[SubjectId] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                            "[SubjectName] TEXT NOT NULL, " +
                                            "[Year] INTEGER NOT NULL);" +

                                        "CREATE TABLE IF NOT EXISTS [Work] (" +
                                            "[WorkId] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                            "[SubjectId] INTEGER," +
                                            "[WorkName] TEXT NOT NULL," +
                                            "FOREIGN KEY (SubjectId) REFERENCES [Subject] (SubjectId) ON DELETE CASCADE ON UPDATE CASCADE);" +

                                        "CREATE TABLE IF NOT EXISTS [Grade] (" +
                                            "[GradeId] INTEGER PRIMARY KEY AUTOINCREMENT," +
                                            "[StudentId] INTEGER," +
                                            "[WorkId] INTEGER," +
                                            "[Value] TEXT," +
                                            "FOREIGN KEY (StudentId) REFERENCES [Student] (StudentId) ON DELETE CASCADE ON UPDATE CASCADE," +
                                            "FOREIGN KEY (WorkId) REFERENCES [Work] (WorkId) ON DELETE CASCADE ON UPDATE CASCADE);";
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }
        #endregion

        #region [Запросы по нажатию кнопок]
        public void InsertRowToDBFromExel(string FIO, string groupe, string year) //Добавление записи из Exel
        {
            command = new SQLiteCommand();
            try
            {
                SQLiteConnection.Open();
                command.Connection = SQLiteConnection;

                // Запрос на создание таблицы БД Группы
                command.CommandText = "INSERT INTO \"Group\" (GroupName, Year) " +
                                        $"SELECT '{groupe}', '{year}' " +
                                        "WHERE NOT EXISTS (" +
                                            "SELECT 1 " +
                                            "FROM \"Group\" " +
                                            $"WHERE GroupName = '{groupe}' AND Year = '{year}');";
                command.ExecuteNonQuery();

                // Запрос на создание таблицы БД Студенты
                command.CommandText = "INSERT INTO \"Student\" (Name, GroupId) " +
                                        $"SELECT '{FIO}', GroupId " +
                                        "FROM \"Group\" " +
                                        $"WHERE GroupName = '{groupe}' AND Year = '{year}' AND NOT EXISTS (" +
                                            "SELECT 1 " +
                                            "FROM \"Student\" " +
                                            $"WHERE Name = '{FIO}' AND GroupId IN (" +
                                                $"SELECT GroupId " +
                                                $"FROM \"Group\" " +
                                                $"WHERE GroupName = '{groupe}' AND Year = '{year}'));";

                command.ExecuteNonQuery();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        public void InsertRowToDBUseBtn(DataGridView dGV, string subjName, int year) // Предметы
        {
            string query = "";
            try
            {


                query = "INSERT INTO \"Subject\" (SubjectName, Year) " +
                        $"VALUES ('{subjName}', '{year}')";

                SQLiteConnection.Open();
                command = new SQLiteCommand();
                command.Connection = SQLiteConnection;
                command.CommandText = query;

                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }

        }

        public void InsertRowToDBUseBtn(DataGridView dGV, string subjName, string workName, int year) // Работы
        {
            string query = "";
            try
            {
                query = "INSERT INTO \"Work\" (WorkName, SubjectId) " +
                         $"SELECT '{workName}', SubjectId " +
                         "FROM \"Subject\" " +
                         $"WHERE SubjectName = '{subjName}' AND Year = '{year}';";


                SQLiteConnection.Open();
                command = new SQLiteCommand();
                command.Connection = SQLiteConnection;
                command.CommandText = query;

                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }

        }

        public void DeleteRowFromDGVandDB(DataGridView dGV, int choiceVal, string tableName, int rowInd, int colInd) // Удаление записи из БД
        {
            string query = "";
            if (choiceVal == 0) // Группа
            {
                string groupName = $"GroupName = '{dGV.Rows[rowInd].Cells[0].Value.ToString()}'";
                string year = $"Year = '{dGV.Rows[rowInd].Cells[1].Value.ToString()}'";
                query = $"PRAGMA foreign_keys=on;" +
                        $"DELETE FROM \"{tableName}\" WHERE {groupName} AND {year};";

            }
            else if (choiceVal == 1) // Студенты
            {
                string fio = $"Name = '{dGV.Rows[rowInd].Cells[0].Value.ToString()}'";
                string groupName = $"GroupName = '{dGV.Rows[rowInd].Cells[1].Value.ToString()}'";
                string year = $"Year = '{dGV.Rows[rowInd].Cells[2].Value.ToString()}'";
                query = $"PRAGMA foreign_keys=on;" +
                        $"DELETE FROM \"{tableName}\" " +
                        $"WHERE {fio} AND GroupId = (" +
                            "SELECT GroupId " +
                            "FROM \"Group\" " +
                            $"WHERE {groupName} AND {year});";

            }
            else if (choiceVal == 2) // Предметы
            {
                string subjectName = $"SubjectName = '{dGV.Rows[rowInd].Cells[0].Value.ToString()}'";
                string year = $"Year = '{dGV.Rows[rowInd].Cells[1].Value.ToString()}'";
                query = $"PRAGMA foreign_keys=on;" +
                        $"DELETE FROM \"{tableName}\" WHERE {subjectName} AND {year};";
            }
            else if (choiceVal == 3) // Работы
            {
                string workName = $"WorkName = '{dGV.Rows[rowInd].Cells[0].Value.ToString()}'";
                string subjectName = $"SubjectName = '{dGV.Rows[rowInd].Cells[1].Value.ToString()}'";
                string year = $"Year = '{dGV.Rows[rowInd].Cells[2].Value.ToString()}'";
                query = $"PRAGMA foreign_keys=on;" +
                        $"DELETE FROM \"{tableName}\" " +
                        $"WHERE {workName} AND SubjectId = (" +
                            "SELECT SubjectId " +
                            "FROM \"Subject\" " +
                            $"WHERE {subjectName} AND {year});";
            }

            try
            {
                var res = MessageBox.Show("Вы точно хотите удалить строку?", "Подтверждение удаления.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                if (res == DialogResult.Yes)
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Удалено.", "Удаление строки.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        public void EditRecordGroup(string groupOld, string yearOld, string groupNew, string yearNew)
        {
            string query = "UPDATE \"Group\" " +
                            $"SET GroupName = '{groupNew}', Year = '{yearNew}' " +
                            $"WHERE GroupName = '{groupOld}' AND Year = '{yearOld}';";

            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        public void EditRecordStudent(string groupOld, string yearOld, string nameOld, string nameNew)
        {
            string query = "PRAGMA foreign_keys=on; " +
                            "UPDATE \"Student\" as 't1' " +
                            $"SET Name = '{nameNew}' " +
                            $"WHERE t1.Name = '{nameOld}' AND t1.GroupId = (" +
                                $"SELECT t2.GroupId " +
                                $"FROM \"Group\" as 't2' " +
                                $"WHERE t2.GroupName = '{groupOld}' AND t2.Year = '{yearOld}');";

            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        public void EditRecordSubj(string subjOld, string yearOld, string subjNew, string yearNew)
        {
            string query = "UPDATE \"Subject\" " +
                            $"SET SubjectName = '{subjNew}', Year = '{yearNew}' " +
                            $"WHERE SubjectName = '{subjOld}' AND Year = '{yearOld}';";

            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        public void EditRecordWork(string subjOld, string yearOld, string workOld, string workNew)
        {
            string query = "PRAGMA foreign_keys=on; " +
                            "UPDATE \"Work\" as 't1' " +
                            $"SET WorkName = '{workNew}' " +
                            $"WHERE t1.WorkName = '{workOld}' AND t1.SubjectId = (" +
                                $"SELECT t2.SubjectId " +
                                $"FROM \"Subject\" as 't2' " +
                                $"WHERE t2.SubjectName = '{subjOld}' AND t2.Year = '{yearOld}');";

            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        #endregion

        #region[Показ выбранной таблицы таблицы]
        public void ShowTable(DataGridView dGV, int choiceVal)
        {
            string query = "";
            try
            {
                SQLiteConnection.Open();

                if (choiceVal == 0) // Группы
                {
                    query = "SELECT GroupName as 'Группа', Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                "FROM \"Group\" " +
                                "ORDER BY [Год] DESC, [Группа] ASC;";
                }
                else if (choiceVal == 1) // Студенты
                {
                    query = "SELECT t2.Name as 'ФИО', t1.GroupName as 'Группа', t1.Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                    "FROM \"Group\" as 't1', \"Student\" as 't2' " +
                                    "WHERE t1.GroupId = t2.GroupId " +
                                    "ORDER BY [Год] DESC, [Группа] ASC, [ФИО] ASC;";
                }
                else if (choiceVal == 2) // Предметы
                {
                    query = "SELECT SubjectName as 'Предмет', Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                "FROM \"Subject\" " +
                                "ORDER BY [Год] DESC, [Предмет] ASC;";
                }
                else if (choiceVal == 3) // Работы
                {
                    query = "SELECT t1.WorkName as 'Работа', t2.SubjectName as 'Предмет', t2.Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                "FROM \"Work\" as 't1', \"Subject\" as 't2' " +
                                "WHERE t1.SubjectId = t2.SubjectId " +
                                "ORDER BY [Год] DESC, [Предмет] ASC, [Работа] ASC;";
                }
                else if (choiceVal == 4) // Оценки
                {

                    query = "DROP TABLE IF EXISTS \"table_not_emp_val\"; " +
                            "CREATE TABLE \"table_not_emp_val\" as " +
                            "SELECT t1.GroupName as 'Группа', t2.Name as 'ФИО', t3.SubjectName as 'Предмет', t4.WorkName as 'Работа', t1.Year as 'Год', t5.Value as 'Оценка' " +
                            "FROM \"Group\" as 't1', \"Student\" as 't2', \"Subject\" as 't3', \"Work\" as 't4', \"Grade\" as 't5' " +
                            "WHERE t1.GroupId = t2.GroupId AND t3.SubjectId = t4.SubjectId AND t1.Year = t3.Year AND t5.StudentId = t2.StudentId AND t5.WorkId = t4.WorkId; " +

                            "DROP TABLE IF EXISTS \"table_emp_val\"; " +
                            "CREATE TABLE \"table_emp_val\" as " +
                            "SELECT t1.GroupName as 'Группа', t2.Name as 'ФИО', t3.SubjectName as 'Предмет', t4.WorkName as 'Работа', t1.Year as 'Год', NULL as 'Оценка' " +
                            "FROM \"Group\" as 't1', \"Student\" as 't2', \"Subject\" as 't3', \"Work\" as 't4' " +
                            "WHERE t1.GroupId = t2.GroupId AND t3.SubjectId = t4.SubjectId AND t1.Year = t3.Year; " +

                            "DELETE FROM \"table_emp_val\" as 't1' " +
                            "WHERE(t1.[Группа], t1.[ФИО], t1.[Предмет], t1.[Работа], t1.[Год]) IN( " +
                            "SELECT t2.[Группа], t2.[ФИО], t2.[Предмет], t2.[Работа], t2.[Год] " +

                            "FROM \"table_not_emp_val\" as 't2'); " +

                            "DROP TABLE IF EXISTS \"All_Marks\"; " +
                            "CREATE TABLE \"All_Marks\" as " +
                            "SELECT * FROM \"table_not_emp_val\" " +
                            "UNION ALL " +
                            "SELECT * FROM \"table_emp_val\"; " +

                            $"SELECT * FROM \"All_Marks\" " +
                            $"ORDER BY [Год] DESC, [Группа] ASC, [ФИО] ASC, [Предмет] ASC, [Работа] ASC;";
                }
                else
                {
                    return;
                }
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Работа с колонками
                dGV.Columns.Clear();

                if (choiceVal != 4) // Проверяем не зашли ли мы в таблицу оценок
                {
                    for (int i = 0; i < dataTable.Columns.Count - 2; i++)
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();
                        mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                        dGV.Columns.Add(mainCol);
                        dGV.Columns[i].ReadOnly = true;
                    }
                    for (int i = dataTable.Columns.Count - 2; i < dataTable.Columns.Count; i++)
                    {
                        DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
                        editCol.HeaderText = dataTable.Columns[i].ColumnName;
                        dGV.Columns.Add(editCol);
                        dGV.Columns[i].ReadOnly = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();

                        if (dataTable.Columns.Count - 1 == i)
                        {
                            mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                            mainCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                            dGV.Columns.Add(mainCol);
                            dGV.Columns[i].ReadOnly = false;
                            break;
                        }

                        mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                        dGV.Columns.Add(mainCol);
                        dGV.Columns[i].ReadOnly = true;

                    }
                }
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                // Работа с данными
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    //int g = dGV.Columns.Count;
                    dGV.Rows.Add(dataTable.Rows[j].ItemArray);
                }

                dGV.Show();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }
        #endregion

        #region[Показ выбранной таблицы таблицы с условием]
        public void ShowTable(DataGridView dGV, int choiceVal, string condition)
        {
            string query = "";
            try
            {
                SQLiteConnection.Open();

                if (choiceVal == 0) // Группы
                {
                    query = "SELECT GroupName as 'Группа', Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                $"FROM \"Group\"{condition} " +
                                $"ORDER BY [Год] DESC, [Группа] ASC;";
                }
                else if (choiceVal == 1) // Студенты
                {
                    query = "SELECT t2.Name as 'ФИО', t1.GroupName as 'Группа', t1.Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                    "FROM \"Group\" as 't1', \"Student\" as 't2' " +
                                    $"WHERE t1.GroupId = t2.GroupId{condition} " +
                                    $"ORDER BY [Год] DESC, [Группа] ASC, [ФИО] ASC;";
                }
                else if (choiceVal == 2) // Предметы
                {
                    query = "SELECT SubjectName as 'Предмет', Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                $"FROM \"Subject\"{condition} " +
                                $"ORDER BY [Год] DESC, [Предмет] ASC;";
                }
                else if (choiceVal == 3) // Работы
                {
                    query = "SELECT t1.WorkName as 'Работа', t2.SubjectName as 'Предмет', t2.Year as 'Год', \"\" as 'Редактирование', \"\" as 'Удаление' " +
                                "FROM \"Work\" as 't1', \"Subject\" as 't2' " +
                                $"WHERE t1.SubjectId = t2.SubjectId{condition} " +
                                $"ORDER BY [Год] DESC, [Предмет] ASC, [Работа] ASC;";
                }
                else if (choiceVal == 4) // Оценки
                {
                    query = "DROP TABLE IF EXISTS \"table_not_emp_val\"; " +
                            "CREATE TABLE \"table_not_emp_val\" as " +
                            "SELECT t1.GroupName as 'Группа', t2.Name as 'ФИО', t3.SubjectName as 'Предмет', t4.WorkName as 'Работа', t1.Year as 'Год', t5.Value as 'Оценка' " +
                            "FROM \"Group\" as 't1', \"Student\" as 't2', \"Subject\" as 't3', \"Work\" as 't4', \"Grade\" as 't5' " +
                            "WHERE t1.GroupId = t2.GroupId AND t3.SubjectId = t4.SubjectId AND t1.Year = t3.Year AND t5.StudentId = t2.StudentId AND t5.WorkId = t4.WorkId; " +

                            "DROP TABLE IF EXISTS \"table_emp_val\"; " +
                            "CREATE TABLE \"table_emp_val\" as " +
                            "SELECT t1.GroupName as 'Группа', t2.Name as 'ФИО', t3.SubjectName as 'Предмет', t4.WorkName as 'Работа', t1.Year as 'Год', NULL as 'Оценка' " +
                            "FROM \"Group\" as 't1', \"Student\" as 't2', \"Subject\" as 't3', \"Work\" as 't4' " +
                            "WHERE t1.GroupId = t2.GroupId AND t3.SubjectId = t4.SubjectId AND t1.Year = t3.Year; " +

                            "DELETE FROM \"table_emp_val\" as 't1' " +
                            "WHERE(t1.[Группа], t1.[ФИО], t1.[Предмет], t1.[Работа], t1.[Год]) IN( " +
                            "SELECT t2.[Группа], t2.[ФИО], t2.[Предмет], t2.[Работа], t2.[Год] " +

                            "FROM \"table_not_emp_val\" as 't2'); " +

                            "DROP TABLE IF EXISTS \"All_Marks\"; " +
                            "CREATE TABLE \"All_Marks\" as " +
                            $"SELECT * FROM \"table_not_emp_val\"{condition} " +
                            "UNION ALL " +
                            $"SELECT * FROM \"table_emp_val\"{condition}; " +

                            $"SELECT * FROM \"All_Marks\" " +
                            $"ORDER BY [Год] DESC, [Группа] ASC, [ФИО] ASC, [Предмет] ASC, [Работа] ASC;";
                }
                else
                {
                    return;
                }
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Работа с колонками
                dGV.Columns.Clear();

                if (choiceVal != 4) // Проверяем не зашли ли мы в таблицу оценок
                {
                    for (int i = 0; i < dataTable.Columns.Count - 2; i++)
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();
                        mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                        dGV.Columns.Add(mainCol);
                        dGV.Columns[i].ReadOnly = true;
                    }
                    for (int i = dataTable.Columns.Count - 2; i < dataTable.Columns.Count; i++)
                    {
                        DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
                        editCol.HeaderText = dataTable.Columns[i].ColumnName;
                        dGV.Columns.Add(editCol);
                        dGV.Columns[i].ReadOnly = true;
                    }
                }
                else
                {
                    for (int i = 0; i < dataTable.Columns.Count - 1; i++)
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();
                        mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                        dGV.Columns.Add(mainCol);
                        dGV.Columns[i].ReadOnly = true;
                    }
                    for (int i = dataTable.Columns.Count - 1; i < dataTable.Columns.Count; i++)
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();
                        mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                        mainCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                        dGV.Columns.Add(mainCol);
                        dGV.Columns[i].ReadOnly = false;
                    }
                }
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                // Работа с данными
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    dGV.Rows.Add(dataTable.Rows[j].ItemArray);
                }

                dGV.Show();

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }
        #endregion

        #region[Показ выбранной таблицы таблицы с ОСОБЫМ условием]
        public void ShowTable(DataGridView dGV, string group, string year, string subject)
        {
            string query = "";
            try
            {
                SQLiteConnection.Open();

                // Запрос на получение всех Оценок
                query = "DROP TABLE IF EXISTS \"table_not_emp_val\"; " +
                        "CREATE TABLE \"table_not_emp_val\" as " +
                        "SELECT t1.GroupName as 'Группа', t2.Name as 'ФИО', t3.SubjectName as 'Предмет', t4.WorkName as 'Работа', t1.Year as 'Год', t5.Value as 'Оценка' " +
                        "FROM \"Group\" as 't1', \"Student\" as 't2', \"Subject\" as 't3', \"Work\" as 't4', \"Grade\" as 't5' " +
                        "WHERE t1.GroupId = t2.GroupId AND t3.SubjectId = t4.SubjectId AND t1.Year = t3.Year AND t5.StudentId = t2.StudentId AND t5.WorkId = t4.WorkId; " +

                        "DROP TABLE IF EXISTS \"table_emp_val\"; " +
                        "CREATE TABLE \"table_emp_val\" as " +
                        "SELECT t1.GroupName as 'Группа', t2.Name as 'ФИО', t3.SubjectName as 'Предмет', t4.WorkName as 'Работа', t1.Year as 'Год', NULL as 'Оценка' " +
                        "FROM \"Group\" as 't1', \"Student\" as 't2', \"Subject\" as 't3', \"Work\" as 't4' " +
                        "WHERE t1.GroupId = t2.GroupId AND t3.SubjectId = t4.SubjectId AND t1.Year = t3.Year; " +

                        "DELETE FROM \"table_emp_val\" as 't1' " +
                        "WHERE(t1.[Группа], t1.[ФИО], t1.[Предмет], t1.[Работа], t1.[Год]) IN( " +
                        "SELECT t2.[Группа], t2.[ФИО], t2.[Предмет], t2.[Работа], t2.[Год] " +

                        "FROM \"table_not_emp_val\" as 't2'); " +

                        "DROP TABLE IF EXISTS \"All_Marks\"; " +
                        "CREATE TABLE \"All_Marks\" as " +
                        $"SELECT * FROM \"table_not_emp_val\" WHERE [Группа] = '{group}' AND [Год] = '{year}' AND [Предмет] = '{subject}' " +
                        "UNION ALL " +
                        $"SELECT * FROM \"table_emp_val\" WHERE [Группа] = '{group}' AND [Год] = '{year}' AND [Предмет] = '{subject}'; " +

                        $"SELECT * FROM \"All_Marks\" " +
                        $"ORDER BY [Год] DESC, [Группа] ASC, [ФИО] ASC, [Предмет] ASC, [Работа] ASC;";

                // Запрос на название ЛР которые есть у данной группы в этом году по этому предмету
                string query1 = "SELECT t1.WorkName " +
                    "FROM \"Work\" as 't1' " +
                    "WHERE t1.SubjectId = (" +
                            $"SELECT t2.SubjectId " +
                            $"FROM \"Subject\" as 't2' " +
                            $"WHERE t2.SubjectName = '{subject}' AND t2.Year = '{year}');";

                // Заполняем все оценки
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Заполняем работы
                adapter = new SQLiteDataAdapter(query1, SQLiteConnection);
                DataTable dataTableWork = new DataTable();
                dataTableWork.Columns.Clear();
                adapter.Fill(dataTableWork);

                // Работа с колонками
                dGV.Columns.Clear();

                // Заполняем колонки
                for (int i = 0, col = 0; col < dataTableWork.Rows.Count; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3) // Пытаемся выловить колонки кроме Работы и Оценки
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();
                        if (i == 3) // Если нам нужен год
                            mainCol.HeaderText = dataTable.Columns[i + 1].ColumnName;
                        else // Другие колонки
                            mainCol.HeaderText = dataTable.Columns[i].ColumnName;
                        if (i == 2 || i == 3)
                        {
                            mainCol.Visible = true; // Видимость столбцов [Предмета и Года]
                            dGV.Columns.Add(mainCol);
                            dGV.Columns[i].ReadOnly = true;
                        }
                        else
                        {
                            mainCol.Visible = true;
                            dGV.Columns.Add(mainCol);
                            dGV.Columns[i].ReadOnly = true;
                        }
                    }
                    else // Формируем столбцы [Работы-Оценки]
                    {
                        DataGridViewColumn mainCol = new DataGridViewTextBoxColumn();
                        mainCol.HeaderText = dataTableWork.Rows[col].ItemArray[0].ToString();
                        dGV.Columns.Add(mainCol);
                        dGV.Columns[3 + col].ReadOnly = false;
                        col++;
                    }
                }

                // Автоматическмй размер по содержимому
                for (int i = 0; i < dGV.Columns.Count; i++)
                {
                    dGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                dGV.Rows.Add(); // Добавляем пустую строку
                // Работа с данными
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    DataGridViewRow row = (DataGridViewRow)dGV.Rows[0].Clone(); // Клонируем строку
                    row.Cells[0].Value = dataTable.Rows[j].ItemArray[0].ToString(); // 1-й элемент строки [Группа]
                    row.Cells[1].Value = dataTable.Rows[j].ItemArray[1].ToString(); // 2-й элемент строки [ФИО]
                    row.Cells[2].Value = dataTable.Rows[j].ItemArray[2].ToString(); // 3-й элемент строки [Предмет] [Visible = false]
                    row.Cells[3].Value = dataTable.Rows[j].ItemArray[4].ToString(); // Последний элемент строки [Год] [Visible = false]
                    for (int r = 0; r < dataTableWork.Rows.Count; r++) // Добавление остальных элементов строки [Работа-Оценка]
                    {
                        row.Cells[4 + r].Value = dataTable.Rows[j + r].ItemArray[5].ToString(); // Заполняем все Оценки Студента
                    }
                    j += dataTableWork.Rows.Count - 1; // Увеличиваем индекс для чтения другого Студента


                    dGV.Rows.Add(row); // Добавление строки
                }
                dGV.Rows.Remove(dGV.Rows[0]); // Удаляем пустую строку [1]

                dGV.Show(); // Отображаем Таблицу

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }
        #endregion

        #region [Получение определенных данных из БД]
        public DataTable GetGroup()
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = "SELECT DISTINCT GroupName FROM \"Group\";";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetGroup_cmB(string condition)
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = $"SELECT DISTINCT GroupName FROM \"Group\"{condition};";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetFIO()
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = "SELECT DISTINCT Name FROM \"Student\";";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetFIO_cmB(string condition)
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = $"SELECT DISTINCT t1.Name FROM \"Student\" as 't1'{condition};";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetSubject()
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = "SELECT DISTINCT SubjectName FROM \"Subject\";";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetSubject_cmB(string condition)
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = $"SELECT DISTINCT SubjectName FROM \"Subject\"{condition};";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetYear()
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = "SELECT DISTINCT Year FROM \"Group\" UNION SELECT DISTINCT Year FROM \"Subject\";";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetWork()
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = "SELECT DISTINCT WorkName FROM \"Work\";";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public DataTable GetWork_cmB(string condition)
        {
            string query = "";
            dataTable.Clear();
            try
            {
                SQLiteConnection.Open();
                query = $"SELECT DISTINCT t1.WorkName FROM \"Work\" as 't1'{condition};";
                adapter = new SQLiteDataAdapter(query, SQLiteConnection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return dataTable;
        }

        public bool CheckRecordExistGroup(string group, string year)
        {
            bool count = false;
            string query = "SELECT EXISTS(" +
                                "SELECT 1 " +
                                "FROM \"Group\" " +
                                $"WHERE GroupName = '{group}' AND Year = '{year}')";
            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                count = Convert.ToBoolean(command.ExecuteScalar());
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return count;
        }

        public bool CheckRecordExistStudent(string group, string year, string name)
        {
            bool count = false;
            string query = "SELECT 1 " +
                            "FROM \"Student\" as 't1' " +
                            $"WHERE t1.Name = '{name}' AND t1.GroupId = (" +
                                $"SELECT t2.GroupId " +
                                $"FROM \"Group\" as 't2' " +
                                $"WHERE t2.GroupName = '{group}' AND t2.Year = '{year}');";
            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                count = Convert.ToBoolean(command.ExecuteScalar());
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return count;
        }

        public bool CheckRecordExistSubj(string subj, string year)
        {
            bool count = false;
            string query = "SELECT EXISTS(" +
                                "SELECT 1 " +
                                "FROM \"Subject\" " +
                                $"WHERE SubjectName = '{subj}' AND Year = '{year}')";
            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                count = Convert.ToBoolean(command.ExecuteScalar());
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return count;
        }

        public bool CheckRecordExistWork(string subj, string year, string work)
        {
            bool count = false;
            string query = "SELECT 1 " +
                            "FROM \"Work\" as 't1' " +
                            $"WHERE t1.WorkName = '{work}' AND t1.SubjectId = (" +
                                $"SELECT t2.SubjectId " +
                                $"FROM \"Subject\" as 't2' " +
                                $"WHERE t2.SubjectName = '{subj}' AND t2.Year = '{year}');";
            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                count = Convert.ToBoolean(command.ExecuteScalar());
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
            return count;
        }

        #endregion

        #region [Добавление оценок]
        public void UpdateGrade(string group, string fio, string subj, string work, string year, string value)
        {
            string query = "";
            string query_check = "SELECT COUNT(*) " +
                                    "FROM \"table_not_emp_val\" as 't1' " +
                                    $"WHERE t1.[Группа] = '{group}' AND t1.[ФИО] = '{fio}' AND t1.[Предмет] = '{subj}' AND t1.[Работа] = '{work}';";
            object res = null;

            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query_check, SQLiteConnection);
                res = command.ExecuteScalar();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }

            if (res != null)
            {
                if (res.ToString() == "0")
                {
                    string query_ins = "PRAGMA foreign_keys=on; " +
                                "INSERT INTO \"Grade\" (StudentId, WorkId, Value) " +
                                $"VALUES ((" +
                                    $"SELECT t1.StudentId " +
                                    $"FROM \"Student\" as 't1', \"Group\" as 't2' " +
                                    $"WHERE t1.Name = '{fio}' AND t2.GroupName = '{group}' AND t2.Year = '{year}' AND t1.GroupId = t2.GroupId), (" +
                                        $"SELECT t3.WorkId " +
                                        $"FROM \"Work\" as 't3', \"Subject\" as 't4' " +
                                        $"WHERE t3.WorkName = '{work}' AND t4.SubjectName = '{subj}' AND t4.Year = '{year}' AND t3.SubjectId = t4.SubjectId), '{value}');";
                    query = query_ins;
                }
                else
                {
                    string query_upd = "PRAGMA foreign_keys=on; " +
                                "UPDATE \"Grade\" as 't1' " +
                                $"SET Value = '{value}' " +
                                $"WHERE t1.StudentId = (" +
                                    $"SELECT t2.StudentId " +
                                    $"FROM \"Student\" as 't2', \"Group\" as 't3' " +
                                    $"WHERE t2.Name = '{fio}' AND t3.GroupName = '{group}' AND t3.Year = '{year}' AND t2.GroupId = t3.GroupId) AND t1.WorkId = ( " +
                                        $"SELECT t4.WorkId " +
                                        $"FROM \"Work\" as 't4', \"Subject\" as 't5' " +
                                        $"WHERE t4.WorkName = '{work}' AND t5.SubjectName = '{subj}' AND t5.Year = '{year}' AND t4.SubjectId = t5.SubjectId);";
                    query = query_upd;
                }
            }


            try
            {
                SQLiteConnection.Open();
                command = new SQLiteCommand(query, SQLiteConnection);
                command.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { SQLiteConnection.Close(); }
        }

        #endregion
    }
}
