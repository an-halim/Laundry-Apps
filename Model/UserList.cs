using System;
using System.Collections.Generic;
using System.Text;

namespace LaundryApps.Model
{
    class UserList
    {
        Model.DBconn db;

        public UserList()
        {
            db = new DBconn();
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
