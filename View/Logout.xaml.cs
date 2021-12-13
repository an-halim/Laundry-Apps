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
    /// Interaction logic for Logout.xaml
    /// </summary>
    public partial class Logout : Window
    {
        public bool isLogin = false;
        public Logout()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            new View.Login().Show();
            this.Close();
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        { 
            new View.Admin.Home().Show();
            this.Close();
        }
    }
}
