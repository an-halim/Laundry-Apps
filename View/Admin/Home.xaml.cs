﻿using System;
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
            frmContent.Navigate(new View.CustomerPage());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            new View.Admin.Logout().Show();
            this.Close();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            frmContent.Navigate(new View.Admin.SettingPage());
        }


        public void StartBtn()
        {
            frmContent.Navigate(new View.Admin.DasboardPage());
        }
    }
}
