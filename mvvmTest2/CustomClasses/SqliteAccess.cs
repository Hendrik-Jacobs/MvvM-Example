using System;
using System.IO;
using System.Windows;
using System.Data;
using System.Data.SQLite;

namespace mvvmTest2.CustomClasses
{
    static class SqliteAccess
    {
        private static string _filePath;
        public static string Filepath
        {
            get => _filePath;
            set => _filePath = value;
        }


        public static bool CreateIfNotExist(string path)
        {
            if (!File.Exists(path))
            {
                try
                {
                    SQLiteConnection.CreateFile(path);
                }
                catch
                {
                    return false;
                }
            }
            _filePath = path;
            return true;
        }


        public static void WriteSql(string command, string[] args = null)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(string.Format("Data Source = {0};Version = 3;", _filePath)))
                {
                    using (SQLiteCommand com = new SQLiteCommand(con))
                    {
                        con.Open();

                        com.CommandText = command;

                        if (args != null)
                        {
                            AddParameter(com, args);
                        }

                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Fail: " + command);
            }
        }


        private static void AddParameter(SQLiteCommand com, string[] args)
        {
            int counter = 0;
            foreach (string arg in args)
            {
                string name = "@param" + counter;
                com.Parameters.AddWithValue(name, arg);
                Console.WriteLine(name);
                counter++;
            }
        }


        public static DataTable ExecuteReadQuery(string query)
        {
            DataTable table = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(string.Format("Data Source = {0};Version = 3;", _filePath)))
            {
                SQLiteCommand com = new SQLiteCommand(query, con);
                try
                {
                    con.Open();
                    SQLiteDataReader reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Columns.Add(new DataColumn(reader.GetName(i)));
                        }
                    }

                    int j = 0;
                    while (reader.Read())
                    {
                        DataRow row = table.NewRow();
                        table.Rows.Add(row);

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Rows[j][i] = reader.GetValue(i);
                        }

                        j++;
                    }

                    con.Close();
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show($"Error:\n{e}");
                }
                return table;
            }
        }
    }
}
