using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace LaundryApps.Model
{
    class AuthUser
    {
        Model.DBconn db;
        public AuthUser()
        {
            db = new DBconn();
        }
        public string username { get; set; }
        public string name { get; set; }
        string path = "user.txt";
        public void saveLoged()
        {
            File.WriteAllText(path, username);
        }

        public string getLoged()
        {
            username = File.ReadAllText(path);
            DataSet ds = new DataSet();
            string kondisi = "username = '" + username + "'";
            ds = db.Select("userdata", kondisi);
            username = ds.Tables[0].Rows[0]["username"].ToString();
            name = ds.Tables[0].Rows[0]["name"].ToString();
            return username + "|"+name;
        }
    }
}
