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
    /// Interaction logic for OrdersLogs.xaml
    /// </summary>
    public partial class OrdersLogsPage : Page
    {

        Controller.OrderLogsControler OD;
        public OrdersLogsPage()
        {
            InitializeComponent();
            OD = new Controller.OrderLogsControler(this);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OD.FillDatagrid();
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
                OD.FillDatagrid(txtSearch.Text.ToString());
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            MessageBoxResult result = MessageBox.Show("Are you sure cancel this order?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) OD.ChangeStatus(id, "Canceled");
            OD.FillDatagrid();
        }
        private void btnProses_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            MessageBoxResult result = MessageBox.Show("Are you sure proses this order?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) OD.ChangeStatus(id, "On Progres");
            OD.FillDatagrid();
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            MessageBoxResult result = MessageBox.Show("Are you sure complete this order?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) OD.ChangeStatus(id, "Completed");
            OD.FillDatagrid();
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search here...";
        }

        private void btnSeeDetails_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = "Order #"+(OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            NavigationService.Navigate(new View.Admin.OrderDetail(id));
        }
    }
}
