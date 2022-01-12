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
                string join = "orders join userdata on orders.user_id = userdata.username join order_detail on orders.order_id=order_detail.order_id join service on order_detail.service_id = service.service_id";
                string column = "order_detail.service_id, order_detail.Jumlah_produk, format(order_detail.Total_harga, 'c', 'id-ID') as Total_harga, CONCAT(service.service_name, ' ', service.service_detail) as service_name, userdata.name, userdata.number, userdata.address, format(orders.trx_date, 'dd/MM/yyyy' ) as trx_date, orders.state, orders.payment_method, orders.note, orders.product_total, format(orders.total_price, 'c', 'id-ID') as total_price";
                dt = db.FillData(join, column, "orders.order_id='" + orderid + "'");
            }catch(Exception e)
            {
                MessageBox.Show("Error : "+ e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                dt = null;
            }

            return dt;
        }

        public string CekDelivery(string orderID)
        {
            string fee;
            try
            {
                string column = "format(total_price - sum(order_detail.total_harga), 'c', 'id-ID') as delivery_fee";
                string kondisi = "orders.order_id = '"+ orderID +"' group by orders.total_price";
                string table = "orders join order_detail on orders.order_id = order_detail.order_id";
                fee = db.Select(table, kondisi, column).Tables[0].Rows[0]["delivery_fee"].ToString();
            }
            catch (Exception)
            {
                fee = "Rp. 0";
            }

            return fee;
        }
    }
}
