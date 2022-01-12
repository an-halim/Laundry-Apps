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
    /// Interaction logic for OrderDetailPage.xaml
    /// </summary>
    public partial class OrderDetailPage : Page
    {
        Controller.OrderDetailController detail;
        public OrderDetailPage(string orderid)
        {
            InitializeComponent();
            InitializeComponent();
            lblOrderID.Content = orderid;
            detail = new Controller.OrderDetailController(this);
            detail.LoadOrderUser();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.User.OrdersLogPage());
        }
    }
}
