using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LaundryApps.Model
{
    class Register
    {
        Model.DBconn db;

        public string username { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime date { get; set; }
        public string number { get; set; }
        public string password { get; set; }

        public bool Regist()
        {
            bool result;
            db = new Model.DBconn();
            

            string data = "'" + username + "','" + name + "','" + address + "','" + date + "','" + number + "','" + password + "',' 0'";
            result = db.Insert("pengguna", data);


            return result;
        }
        public bool usernameCheck()
        {
            bool result;
            db = new Model.DBconn();
            DataSet ds = new DataSet();

            string kondisi = "email = '" + username + "'";
            ds = db.Select("pengguna", kondisi);

            if (ds.Tables[0].Rows.Count > 0) result = true;
            else result = false;

            return result;

        }
    }
}
