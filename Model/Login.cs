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
            bool result = false;
            db = new Model.DBconn();
            DataSet ds = new DataSet();

            string kondisi = "email = '" + username + "' AND pass = '" + password + "'";
            ds = db.Select("pengguna", kondisi);

            if (ds.Tables[0].Rows.Count > 0) result = true;
            else result = false;

            return result;
        }
    }
}
