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

namespace LaundryApps.View
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            frmContent.Navigate(new View.DasboardPage());
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.DasboardPage());
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.CustomerPage());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            new View.Logout().Show();
            this.Close();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.SettingPage());
        }
    }
}
