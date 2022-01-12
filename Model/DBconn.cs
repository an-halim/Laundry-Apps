using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace LaundryApps.Model
{
    class DBconn
    {
        private static SqlConnection conn;
        private SqlCommand command;
        private bool result;

        public DBconn()
        {
            GetConnection();
        }
        public static SqlConnection GetConnection()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Data Source=DESKTOP-KP5AV2H;Initial Catalog=db_laundry;Integrated Security=True;Pooling=False";
            }
            catch (Exception)
            {
                MessageBox.Show("Cant connect to database!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return conn;
        }

        public DataSet Select(string tabel, string kondisi = null, string column = "*")
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                if (kondisi == null) command.CommandText = "SELECT "+ column +" FROM " + tabel;
                else command.CommandText = "SELECT " + column + " FROM " + tabel + " WHERE " + kondisi;

                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, tabel);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                ds = null;
            }

            conn.Close();
            return ds;
        }

        public Boolean Insert(string tabel, string data)
        {
            result = false;
            try
            {
                string query = "INSERT INTO " + tabel + " VALUES (" + data + ")";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }

            conn.Close();
            return result;
        }
        public Boolean Update(string tabel, string data, string kondisi)
        {
            result = false;
            try
            {
                string query = "UPDATE " + tabel + " SET " + data + " WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                result = false;
            }

            conn.Close();
            return result;
        }
        public Boolean Delete(string tabel, string kondisi)
        {
            result = false;
            try
            {
                string query = "DELETE FROM " + tabel + " WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }

            conn.Close();
            return result;
        }

        public DataTable FillData(string table, string column, string kondisi = null)
        {
            DataTable dt;
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                if (kondisi == null) command.CommandText = "SELECT " + column + " FROM " + table;
                else command.CommandText = "SELECT "+column+" FROM " + table + " WHERE " + kondisi;

                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable(table);
                sda.Fill(dt);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                dt = null;
            }

            conn.Close();
            return dt;
        }

        
    }
}
