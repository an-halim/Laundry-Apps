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
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        private void btnListUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.UsersListPage());
        }

        private void btnAddUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.AddUserPage());
        }
    }
}
