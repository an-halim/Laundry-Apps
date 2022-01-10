using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Data;
using Microsoft.Win32;
using CSVLibraryAK;

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

        public void exportFile()
        {
            try
            {
                if (view.OrdersGrid.Items.Count <= 0)
                {
                    MessageBox.Show("Data not available", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DataTable data = new DataTable();
                data = ((DataView)view.OrdersGrid.ItemsSource).ToTable();

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CSV Files (*.csv)|*.csv";


                if (save.ShowDialog() == true)
                {
                    CSVLibraryAK.Core.CSVLibraryAK.Export(save.FileName, data);
                    MessageBox.Show("OK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.Write(ex);
            }
        }
    }
}
