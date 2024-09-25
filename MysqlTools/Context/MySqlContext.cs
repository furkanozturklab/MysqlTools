using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MysqlTools.Context
{
    public class MySqlContext
    {
     

        private string _sqlConnectionString;
        private MySqlConnection? _conn;

        public MySqlContext(string server, string database, string userId, string password)
        {
            _sqlConnectionString = $"Server={server};Database={database};User ID={userId};Password={password};";
        }

        public void Connect()
        {
            _conn = new MySqlConnection(_sqlConnectionString);

            try
            {
                _conn.Open();
                Debug.WriteLine("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Bağlantı hatası: {ex.Message}");
                throw new Exception("Bağlantı Hatası");
            }
            finally
            {
                _conn?.Close();
            }
        }


        public List<string> GetAllTableNames(string dbName)
        {
            List<string> tableNames = new List<string>();

            using (_conn = new MySqlConnection(_sqlConnectionString))
            {
                _conn.Open();
                string query = $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{dbName}'"; // Veritabanı adını güncelle

                using (MySqlCommand cmd = new MySqlCommand(query, _conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tableNames.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return tableNames;
        }


        public DataTable GetTableData(string tableName)
        {


            using (_conn = new MySqlConnection(_sqlConnectionString))
            {
                _conn.Open();
                string query = $"SELECT * FROM {tableName}"; // Dikkat: SQL Enjeksiyonu riski!
                MySqlCommand cmd = new MySqlCommand(query, _conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }

        }


        public int ExecuteNonQuery(string query)
        {
            using (_conn = new MySqlConnection(_sqlConnectionString))
            {
                try
                {
                    _conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, _conn);
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Hata: {ex.Message}");
                    return -1;
                }
                finally
                {
                    _conn.Close();
                }
            }
        }



    }
}
