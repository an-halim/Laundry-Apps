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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Controller.LoginController login;
        public Login()
        {
            InitializeComponent();
            login = new Controller.LoginController(this);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login.loginCheck();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
          System.Environment.Exit(0);
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Clear();
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            new View.Register().Show();
            this.Close();
        }
    }
}
