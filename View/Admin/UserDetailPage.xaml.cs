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
            txtAddress.IsEnabled = true;
            CBadmin.IsEnabled = true;
            txtName.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool update = detail.Update();
            if (update)
            {
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                txtName.IsEnabled = false;
                txtPhone.IsEnabled = false;
                txtBirthDate.IsEnabled = false;
                txtPass.IsEnabled = false;
                txtAddress.IsEnabled = false;
                CBadmin.IsEnabled = false;
                MessageBox.Show("Update successfully", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Update failed", "Failed!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.UsersListPage());
        }

        private void btnSeeDetails_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            if (id == string.Empty) MessageBox.Show("Can't get order id!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            else NavigationService.Navigate(new View.Admin.OrderDetail(id));
        }
    }
}
