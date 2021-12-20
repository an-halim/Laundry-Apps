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
        bool hidePass = true;
        Controller.LoginController login;
        public Login()
        {
            InitializeComponent();
            login = new Controller.LoginController(this);
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            login.loginCheck();
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.SelectionStart = 0;
            txtUsername.SelectionLength = txtUsername.Text.Length;
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

        private void btnShowPass_Click(object sender, RoutedEventArgs e)
        {
            if (hidePass)
            {
                txtPassword.Visibility = Visibility.Hidden;
                txtUnmaskPass.Text = txtPassword.Password;
                txtUnmaskPass.Visibility = Visibility.Visible;
                hidePass = false;
            }
            else
            {
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Password = txtUnmaskPass.Text;
                txtUnmaskPass.Visibility = Visibility.Hidden;
                hidePass = true;
            }
        }

        private void txtUnmaskPass_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txtUnmaskPass.Text;

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) login.loginCheck();
        }
    }
}
