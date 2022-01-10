using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using CSVLibraryAK;
using Microsoft.Win32;

namespace LaundryApps.Controller
{
    class UserListController
    {
        View.Admin.UsersListPage view;
        Model.DBconn db;
        Model.UserList model;
        
        public UserListController(View.Admin.UsersListPage view)
        {
            db = new Model.DBconn();
            model = new Model.UserList();
            this.view = view;
        }

        public void FillDataGrid(string cari = "")
        {
            DataTable data = model.loadData(cari);
            if (data == null) MessageBox.Show("Error while load data", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            else view.UserListGrid.ItemsSource = data.DefaultView;

            view.lblOrderstotal.Content = "Showing " + view.UserListGrid.Items.Count.ToString() + " users";
        }

        public void deleteUser(string username)
        {
            if (model.DeleteUser(username)) MessageBox.Show("Successfully delete " + username, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Failed delete " + username, "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void exportFile()
        {
            try
            {
                if (view.UserListGrid.Items.Count <= 0)
                {
                    MessageBox.Show("Data not available", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DataTable data = new DataTable();
                data = ((DataView)view.UserListGrid.ItemsSource).ToTable();

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
