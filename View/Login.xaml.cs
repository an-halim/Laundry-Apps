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

namespace LaundryApps.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
   
        }

 


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           new Home().Show();
          this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
          System.Environment.Exit(0);
        }

    }
}
