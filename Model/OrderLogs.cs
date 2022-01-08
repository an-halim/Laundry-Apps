using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LaundryApps.Model
{
    class OrderLogs
    {
        Model.DBconn db;

        public OrderLogs()
        {
            db = new Model.DBconn();
        }

        public DataTable loadData(string cari)
        {
            DataTable dt;
            try 
            {
                if(cari == "" || cari.Length <=0 || cari == " ")
                {
                    dt = db.FillData("orders", "order_id, user_id, product_total, format(total_price, 'c', 'id-ID') as total_price, format(trx_date, 'dd/MM/yyyy' ) as trx_date, state, payment_method, note");
                }
                else
                {
                    string kondisi = "order_id LIKE '%" + cari + "%' OR user_id LIKE '%" + cari + "%' OR product_total LIKE '%" + cari + "%' OR total_price LIKE '%" + cari + "%' OR trx_date LIKE '%" + cari + "%' OR state LIKE '%" + cari + "%' OR payment_method LIKE '%" + cari + "%' OR note LIKE '%" + cari + "%'";
                    dt = db.FillData("orders", "order_id, user_id, product_total, format(total_price, 'c', 'id-ID') as total_price, format(trx_date, 'dd/MM/yyyy' ) as trx_date, state, payment_method, note", kondisi);
                }

                
            }
            catch (Exception) 
            {
                dt = null;
            }

            return dt;
        }

        public bool changeStatus(string orderid, string newStatus)
        {
            bool res = false;
            res = db.Update("orders", "state='"+newStatus+"'", "order_id='"+ orderid +"'");
            return res;
        }
    }
}
