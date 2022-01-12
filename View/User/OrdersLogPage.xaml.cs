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
        public string LogedUser { get; set; }
        public OrdersLogPage()
        {
            InitializeComponent();
            OD = new Controller.OrdersLogUserController(this);
            LogedUser = getLoged();
        }

        private string getLoged()
        {
            return ((Home)Application.Current.Windows[0]).lblLogedUser.Content.ToString();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OD.FillDatagrid();
        }

        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.User.CreateOrderPage());
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
            string status = (OrdersGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            if(status == "On Progres" || status == "Completed")
            {
                MessageBox.Show("This order is "+ status +", you can't cancel!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure cancel this order?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) OD.ChangeStatus(id, "Canceled");
                OD.FillDatagrid();
            }
            
        }


        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search here...";
        }

        private void btnSeeDetails_Click(object sender, RoutedEventArgs e)
        {
            object item = OrdersGrid.SelectedItem;
            string id = "Order #" + (OrdersGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            NavigationService.Navigate(new View.User.OrderDetailPage(id));
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            OD.exportFile();
        }
    }
}
