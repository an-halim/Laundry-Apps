using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;

namespace LaundryApps.Controller
{
    class OrdersLogUserController
    {
        View.User.OrdersLogPage view;
        Model.OrderLogs model;

        public OrdersLogUserController(View.User.OrdersLogPage view)
        {
            model = new Model.OrderLogs();
            this.view = view;
        }

        public void FillDatagrid(string username, string cari = "")
        {
            DataTable data = model.loadDataUser(cari, username);
            if (data == null) MessageBox.Show("Error while load data", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            else view.OrdersGrid.ItemsSource = data.DefaultView;

            view.lblOrderstotal.Content = "Showing " + view.OrdersGrid.Items.Count.ToString() + " orders";
        }

        public void ChangeStatus(string orderid, string status)
        {
            bool result = false;
            result = model.changeStatus(orderid, status);
            if (result) MessageBox.Show("Update successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Update failed!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
