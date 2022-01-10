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

namespace LaundryApps.View.User
{
    /// <summary>
    /// Interaction logic for OrdersLog.xaml
    /// </summary>
    public partial class OrdersLogPage : Page
    {
        Controller.OrdersLogUserController OD;
        string LogedUser;
        public OrdersLogPage(string username)
        {
            InitializeComponent();
            OD = new Controller.OrdersLogUserController(this);
            LogedUser = username;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OD.FillDatagrid(LogedUser);
        }

        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.CreateOrderPage());
        }


        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtSearch.Text.ToString() != "Search here...")
            {
                OD.FillDatagrid(LogedUser, txtSearch.Text.ToString());
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            MessageBoxResult result = MessageBox.Show("Are you sure cancel this order?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) OD.ChangeStatus(id, "Canceled");
            OD.FillDatagrid(LogedUser);
        }


        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search here...";
        }

        private void btnSeeDetails_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = "Order #" + (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            NavigationService.Navigate(new View.Admin.OrderDetail(id));
        }
    }
}
