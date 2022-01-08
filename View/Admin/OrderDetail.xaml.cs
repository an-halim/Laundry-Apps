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
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public partial class OrderDetail : Page
    {
        Controller.OrderDetailController detail;
        public OrderDetail(string orderid)
        {
            InitializeComponent();
            lblOrderID.Content = orderid;
            detail = new Controller.OrderDetailController(this);
            detail.LoadOrder();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.OrdersLogsPage());
        }
    }
}
