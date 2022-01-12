using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;

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
            ds = db.Select("userdata join orders on userdata.username=orders.user_id", "userdata.username='" + userID + "'", "userdata.name, userdata.number, userdata.birth_date, userdata.password, userdata.address, userdata.is_admin, orders.order_id, orders.state, format(orders.total_price, 'c', 'id-ID') as total_price, orders.payment_method");
            if(ds == null || ds.Tables[0].Rows.Count <= 0)
            {
                ds = db.Select("userdata", "userdata.username='" + userID + "'");
            }
            return ds;
        }

        public bool Update(string userID, string name, string number, string birth_date, string pass, string address, string isAdmin)
        {
            bool result;
            string data = "username='" + userID + "', name='" + name + "', number='" + number + "', birth_date='" + birth_date + "', password='" + pass + "', address='" + address + "', is_admin='"+ isAdmin +"'";
            result = db.Update("userdata", data, "userdata.username='" + userID + "'");

            return result;
        }
    }
}
