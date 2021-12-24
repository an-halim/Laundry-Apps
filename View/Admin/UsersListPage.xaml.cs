using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for UsersListPage.xaml
    /// </summary>
    public partial class UsersListPage : Page
    {
        Controller.UserListController UserList;
        View.Admin.EditUserWindow edit;
        public UsersListPage()
        {
            InitializeComponent();
            UserList = new Controller.UserListController(this);
            edit = new View.Admin.EditUserWindow();


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserList.FIllDataGrid();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (edit.IsActive)
            {
                edit.Close();
                edit.Show();
            } else edit.Show();
        }
    }
}
