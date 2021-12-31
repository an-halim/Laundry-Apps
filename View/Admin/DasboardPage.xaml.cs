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
    /// Interaction logic for DasboardPage.xaml
    /// </summary>
    public partial class DasboardPage : Page
    {

        Controller.DashboardPageController dashboard;

        public DasboardPage()
        {
            InitializeComponent();
            dashboard = new Controller.DashboardPageController(this);
        }


        private void lblSeeMore_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.ServiceList());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dashboard.FillDatagrid();
            dashboard.getBalance();
            dashboard.getTotalOrder();
            dashboard.getCompletOrder();
            dashboard.getReceivedOrder();
            dashboard.getProgresOrder();
        }
    }
}
