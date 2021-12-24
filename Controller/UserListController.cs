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
        Model.DBconn model;
        
        public UserListController(View.Admin.UsersListPage view)
        {
            model = new Model.DBconn();
            this.view = view;
        }

        public void FIllDataGrid()
        {
            try { view.UserListGrid.ItemsSource = model.FillData("userdata", "username, name, address, format(birth_date, 'dd/MM/yyyy' ) as birth_date, number").DefaultView; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
}
