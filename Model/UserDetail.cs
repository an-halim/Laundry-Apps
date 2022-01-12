using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LaundryApps.Model
{
    class UserDetail
    {
        Model.DBconn db;

        public UserDetail()
        {
            db = new Model.DBconn();
        }

        public DataSet LoadDetail(string userID)
        {
            DataSet ds = new DataSet();
            ds = db.Select("userdata join orders on userdata.username=orders.user_id", "userdata.username='" + userID + "'", "userdata.name, userdata.number, userdata.birth_date, userdata.password, userdata.address, orders.order_id, orders.state, orders.total_price");
            return ds;
        }

        public bool Update(string userID, string name, string number, string birth_date, string pass, string address)
        {
            bool result;
            string data = "username='" + userID + "', name='" + name + "', number='" + number + "', birth_date='" + birth_date + "', password='" + pass + "', address='" + address + "'";
            result = db.Update("userdata", data, "userdata.username='" + userID + "'");

            return result;
        }
    }
}
