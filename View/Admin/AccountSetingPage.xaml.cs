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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for AccountSetingPage.xaml
    /// </summary>
    public partial class AccountSetingPage : Page
    {
        private string username;
        private string name;
        public AccountSetingPage()
        {
            InitializeComponent();


            txtUsername.Text = username;
            txtName.Focus();
        }
    }
}
