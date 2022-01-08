using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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

        public void FIllDataGrid()
        {
            try { view.UserListGrid.ItemsSource = db.FillData("userdata", "username, name, address, format(birth_date, 'dd/MM/yyyy' ) as birth_date, number").DefaultView; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void deleteUser(string username)
        {
            if (model.DeleteUser(username)) MessageBox.Show("Successfully delete " + username, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Failed delete " + username, "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
