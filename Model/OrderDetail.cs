using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace LaundryApps.Model
{
    class OrderDetail
    {
        Model.DBconn db;

        public OrderDetail()
        {
            db = new Model.DBconn();
        }

        public DataTable loadData(string orderid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.FillData("orders join order_detail on orders.order_id=order_detail.order_id", "order_detail.service_id, order_detail.Jumlah_produk, order_detail.Total_harga", "orders.order_id='" + orderid + "'");
            }catch(Exception e)
            {
                MessageBox.Show("Error : "+ e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                dt = null;
            }

            return dt;
        }

        public DataSet loadCustomer(string orderid)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = db.Select("userdata join orders on userdata.username=orders.user_id", "orders.order_id='" + orderid + "'", "userdata.name, userdata.number, userdata.address, CONVERT(VARCHAR(10), orders.trx_date, 111) as trx_date, orders.state, orders.payment_method, orders.note, orders.total_price");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                ds = null;
            }

            return ds;
        }
    }
}
