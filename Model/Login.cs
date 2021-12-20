using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LaundryApps.Model
{
    class Login
    {
        Model.DBconn db;
        public string username { get; set; }
        public string password { get; set; }

        public bool LoginCheck()
        {
            bool result;
            db = new Model.DBconn();
            DataSet ds = new DataSet();

            string kondisi = "Username = '" + username + "' AND User_password = '" + password + "'";
            ds = db.Select("Tabel_user", kondisi);

            if (ds.Tables[0].Rows.Count > 0) result = true;
            else result = false;

            return result;
        }

        public bool isAdmin()
        {
            bool result;
            db = new Model.DBconn();
            DataSet ds = new DataSet();

            string kondisi = "Username = '" + username + "' AND User_password = '" + password + "' AND Is_admin LIKE '1' ";
            ds = db.Select("Tabel_user", kondisi);

            if (ds.Tables[0].Rows.Count > 0) result = true;
            else result = false;

            return result;
            
        }
    }
}
