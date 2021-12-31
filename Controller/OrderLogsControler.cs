using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class OrderLogsControler
    {
        View.Admin.OrdersLogsPage view;
        Model.DBconn model;

        public OrderLogsControler(View.Admin.OrdersLogsPage view)
        {
            model = new Model.DBconn();
            this.view = view;
        }

        public void FillDatagrid()
        {
            try { view.OrdersGrid.ItemsSource = model.FillData("orders", "order_id, user_id, product_total, format(total_price, 'c', 'id-ID') as total_price, format(trx_date, 'dd/MM/yyyy' ) as trx_date, state").DefaultView; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
}
