using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Data;

namespace LaundryApps.Controller
{
    class OrderLogsControler
    {
        View.Admin.OrdersLogsPage view;
        Model.OrderLogs model;

        public OrderLogsControler(View.Admin.OrdersLogsPage view)
        {
            model = new Model.OrderLogs();
            this.view = view;
        }

        public void FillDatagrid(string cari = "")
        {
            DataTable data = model.loadData(cari);
            if (data == null) MessageBox.Show("Error while load data", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            else view.OrdersGrid.ItemsSource = data.DefaultView;

            view.lblOrderstotal.Content = "Showing " + view.OrdersGrid.Items.Count.ToString() + " orders";
        }

        public void ChangeStatus(string orderid, string status)
        {
            bool result = false;
            result = model.changeStatus(orderid, status);
            if(result) MessageBox.Show("Update successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Update failed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
