using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-KP5AV2H;Initial Catalog=LDB;Integrated Security=True;Pooling=False";

            return conn;
        }

        public DataSet Select(string tabel, string kondisi)
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                if (kondisi == null) command.CommandText = "SELCT * FROM " + tabel;
                else command.CommandText = "SELECT * FROM " + tabel + " WHERE " + kondisi;

                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds, tabel);
            }
            catch (SqlException)
            {
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
            catch (SqlException)
            {
                result = false;
            }

            return result;
        }
        public Boolean Update(string tabel, string kondisi)
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

            return result;
        }
    }
}
