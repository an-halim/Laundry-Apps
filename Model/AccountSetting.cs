using System;
using System.Collections.Generic;
using System.Text;

namespace LaundryApps.Model
{
    class AccountSetting
    {
        Model.DBconn db;

        public AccountSetting()
        {
            db = new Model.DBconn();
        }

        public string[] getDetail(string username)
        {
            string[] accountDetail = { "", "", "", "" };
            try
            {
                accountDetail[0] = db.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["name"].ToString();
                accountDetail[1] = db.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["address"].ToString();
                accountDetail[2] = db.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["number"].ToString();
                accountDetail[3] = db.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["password"].ToString();
            }
            catch (Exception)
            {
                accountDetail[0] = "";
            }

            return accountDetail;
        }
        
        public bool update(string username, string name, string address, string phoneNumber, string password)
        {
            bool result;
            try
            {
                string data = "name='"+ name +"', address='"+ address +"', number='"+ phoneNumber +"', password='"+ password +"'";
                result = db.Update("userdata", data, "username='" + username + "'");
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}
