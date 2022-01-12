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
using System.Windows.Shapes;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public string username()
        {
            return lblLogedUser.Content.ToString();
        }
        public Home()
        {
            InitializeComponent();
            frmContent.Navigate(new View.Admin.HomePage());
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.DasboardPage());
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.UsersListPage());
        }
        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.OrdersLogsPage());
        }
        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.ServiceList());
        }
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.AccountSetingPage());
        }

        private void lblLogedUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frmContent.Navigate(new View.Admin.AccountSetingPage());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            new View.Admin.Logout().Show();
        }
        
    }
}
