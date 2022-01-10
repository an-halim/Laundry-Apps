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
    /// Interaction logic for ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Page
    {
        Controller.ServiceListUserController service;
        int curentPos = 0;
        public ServiceList()
        {
            InitializeComponent();
            service = new Controller.ServiceListUserController(this);
            service.FillServices(curentPos.ToString());

        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.ToString() != "Search here...")
            {
                service.SearchService(txtSearch.Text.ToString());
                chekCardContent();
            }


        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            curentPos -= 8;
            if (curentPos < 0)
            {
                MessageBox.Show("You have reach start of service list", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnPrev.IsEnabled = false;
            }
            else
            {
                service.FillServices(curentPos.ToString());
                btnNext.IsEnabled = true;
            }
            chekCardContent();

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            curentPos += 8;
            service.FillServices(curentPos.ToString());
            if (lblServiceDetail1.Text.ToString().Length <= 0)
            {
                curentPos -= 8;
                service.FillServices(curentPos.ToString());
                MessageBox.Show("You have reach start of service list", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnNext.IsEnabled = false;
            }
            else
            {
                btnPrev.IsEnabled = true;
            }
            chekCardContent();

        }

        //Disable card if content empty
        private void chekCardContent()
        {
            if (lblServiceDetail1.Text.ToString().Length <= 0)
                card1.Visibility = Visibility.Hidden;
            else
                card1.Visibility = Visibility.Visible;

            if (lblServiceDetail2.Text.ToString().Length <= 0)
                card2.Visibility = Visibility.Hidden;
            else
                card2.Visibility = Visibility.Visible;

            if (lblServiceDetail3.Text.ToString().Length <= 0)
                card3.Visibility = Visibility.Hidden;
            else
                card3.Visibility = Visibility.Visible;

            if (lblServiceDetail4.Text.ToString().Length <= 0)
                card4.Visibility = Visibility.Hidden;
            else
                card4.Visibility = Visibility.Visible;

            if (lblServiceDetail5.Text.ToString().Length <= 0)
                card5.Visibility = Visibility.Hidden;
            else
                card5.Visibility = Visibility.Visible;

            if (lblServiceDetail6.Text.ToString().Length <= 0)
                card6.Visibility = Visibility.Hidden;
            else
                card6.Visibility = Visibility.Visible;

            if (lblServiceDetail7.Text.ToString().Length <= 0)
                card7.Visibility = Visibility.Hidden;
            else
                card7.Visibility = Visibility.Visible;

            if (lblServiceDetail8.Text.ToString().Length <= 0)
                card8.Visibility = Visibility.Hidden;
            else
                card8.Visibility = Visibility.Visible;
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search here...";
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
