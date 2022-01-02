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

namespace LaundryApps.View.User
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            frmContent.Navigate(new HomePage());
        }

        private void lblLogedUser_MouseDown(object sender, MouseButtonEventArgs e)
        {
            View.User.AccountSettingPage Setting = new View.User.AccountSettingPage();
            Setting.txtUsername.Text = lblLogedUser.Content.ToString();
            frmContent.Navigate(Setting);
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            View.User.AccountSettingPage Setting = new View.User.AccountSettingPage();
            Setting.txtUsername.Text = lblLogedUser.Content.ToString();
            frmContent.Navigate(Setting);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            new View.User.Logout().Show();
        }

        private void btnDash_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.User.DashboardPage());
        }
    }
}
