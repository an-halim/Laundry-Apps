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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for UserDetailPage.xaml
    /// </summary>
    public partial class UserDetailPage : Page
    {
        Controller.UserDetailController detail;
        public UserDetailPage(string username)
        {
            InitializeComponent();
            txtUsername.Text = username;
            detail = new Controller.UserDetailController(this);
            detail.LoadData();
            lblUserOrders.Content = username + "'s order (" + OrdersGrid.Items.Count.ToString() + " orders)";
        }



        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.IsEnabled = false;
            btnSave.IsEnabled = true;
            txtName.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtBirthDate.IsEnabled = true;
            txtPass.IsEnabled = true;
            txtAddress.IsEnabled = true;
            txtName.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.UsersListPage());
        }
    }
}
