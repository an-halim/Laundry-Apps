using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LaundryApps.Model
{
    class UserList
    {
        Model.DBconn db;

        public UserList()
        {
            db = new DBconn();
        }

        public DataTable loadData(string cari)
        {
            DataTable dt = new DataTable();
            try 
            {
                if (cari == "" || cari.Length <= 0 || cari == " ")
                {
                    dt = db.FillData("userdata", "username, name, address, format(birth_date, 'dd/MM/yyyy' ) as birth_date, number");
                }
                else
                {
                    string kondisi = "username LIKE '%" + cari + "%' OR name LIKE '%" + cari + "%' OR address LIKE '%" + cari + "%' OR birth_date LIKE '%" + cari + "%' OR number LIKE '%" + cari + "%'";
                    dt = db.FillData("userdata", "username, name, address, format(birth_date, 'dd/MM/yyyy' ) as birth_date, number", kondisi);
                }
            }
            catch (Exception) 
            { 
                dt = null; 
            }

            return dt;
        }

        public bool DeleteUser(string username)
        {
            bool result = false;
            bool deletOrderDetail = db.Delete("order_detail", "user_id='" + username + "'");
            bool deleteOrder = db.Delete("orders", "user_id='" + username + "'");
            bool deleteUser = db.Delete("userdata", "username='" + username + "'");            
            
            if (deleteUser && deleteOrder && deletOrderDetail) result = true;

            return result;
        }
    }
}
