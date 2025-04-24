using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using K4os.Compression.LZ4.Streams.Adapters;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Windows;
using System.IO.Packaging;


namespace WpfApp1
{
    internal class database
    {
        private readonly string ConnectionString = "server=localhost;database=introcafe;uid=root;pwd=;charset=utf8;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public DataTable GetOrders()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string lekerdezes = "SELECT * FROM introcafe.upload_orders ORDER BY UploadedOrderTime ASC";
                    using (MySqlCommand cmd = new MySqlCommand(lekerdezes, con))
                    using (MySqlDataAdapter adat = new MySqlDataAdapter(cmd))
                    {
                        adat.Fill(tabla);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tabla;
        }

        public void RendelesTorles(int elmentettid)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string lekerdezes = $"DELETE FROM introcafe.upload_orders WHERE UploadedOrderId = {elmentettid}";
                    using (MySqlCommand cmd = new MySqlCommand(lekerdezes, con))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} rows deleted.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public DataTable GetItems()
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string lekerdezes = "SELECT * FROM introcafe.items";
                    using (MySqlCommand cmd = new MySqlCommand(lekerdezes, con))
                    using (MySqlDataAdapter adat = new MySqlDataAdapter(cmd))
                    {
                        adat.Fill(tabla);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tabla;
        }


        public DataTable SearchItems(string searchTerm)
        {
            DataTable tabla = new DataTable();
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    string lekerdezes = "SELECT * FROM introcafe.items WHERE Name LIKE @searchTerm";
                    using (MySqlCommand cmd = new MySqlCommand(lekerdezes, con))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                        using (MySqlDataAdapter adat = new MySqlDataAdapter(cmd))
                        {
                            adat.Fill(tabla);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return tabla;
        }

        public bool CheckOrderId(int sorszam, MySqlConnection con)
        {
            string query = $"SELECT COUNT(*) FROM introcafe.upload_orders WHERE UploadedOrderId = {sorszam}";

            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // True if the ID exists, False if it's available
            }
        }

        public void AdatbazisbaFelvetel(string kuldeslista, int totalCost, string fogyasztastipus)
        {
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();

                    int maxRetries = 1002;
                    int retryCount = 0;
                    int sorszam;
                    Random random = new Random();

                    do
                    {
                        sorszam = random.Next(1, 1000);
                        retryCount++;

                        if (retryCount >= maxRetries)
                        {
                            MessageBox.Show("Nincs több szabad ID!");
                            return;
                        }
                    }
                    while (CheckOrderId(sorszam, con));

                    string query = $"INSERT INTO introcafe.upload_orders (UploadedOrderId, UploadedItems, UploadedTakeway," +
                        $"UploadedTotalCost) VALUES ({sorszam},'{kuldeslista}','{fogyasztastipus}',{totalCost})";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row added, OrderId: {sorszam}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
