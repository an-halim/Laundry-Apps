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
        public UsersListPage()
        {
            InitializeComponent();
            UserList = new Controller.UserListController(this);



        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserList.FIllDataGrid();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            new View.Admin.EditUserWindow().Show();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            new View.Admin.DeleteUserWindow().Show();
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.AddUserPage());
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
