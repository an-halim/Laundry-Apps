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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        bool hidePass = true;
        public Register()
        {
            InitializeComponent();
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = "";
        }

        private void txtNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            txtNumber.SelectionStart = 0;
            txtNumber.SelectionLength = txtNumber.Text.Length;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            new View.Login().Show();
            this.Close();
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.SelectionStart = 0;
            txtUsername.SelectionLength = txtUsername.Text.Length;
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.SelectionStart = 0;
            txtName.SelectionLength = txtName.Text.Length;
        }

        private void txtAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            txtAddress.SelectionStart = 0;
            txtAddress.SelectionLength = txtAddress.Text.Length;
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
    }
}
