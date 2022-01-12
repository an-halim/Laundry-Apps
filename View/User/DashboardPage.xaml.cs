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
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        Controller.UserDashboardController dash;
        public string username { get; set; }
        public DashboardPage()
        {
            InitializeComponent();
            username = getLoged();
            dash = new Controller.UserDashboardController(this);
        }

        private string getLoged()
        {
            return ((Home)Application.Current.Windows[0]).lblLogedUser.Content.ToString();
        }

        private void lblSeeMore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new View.User.ServiceList());
        }

        private void btnSeeAll_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.User.OrdersLogPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dash.GetBalancePrecentage(username);
            dash.GetOrderPrecentage(username);
            dash.FillDatagrid(username);
            dash.getBalance(username);
            dash.getTotalOrder(username);
            dash.getCompletOrder(username);
            dash.getReceivedOrder(username);
            dash.getProgresOrder(username);
        }
    }
}
