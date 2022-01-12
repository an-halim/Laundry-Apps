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
    /// Interaction logic for ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Page
    {
        Controller.ServiceListController service;
        int curentPos = 0;
        public ServiceList()
        {
            InitializeComponent();
            service = new Controller.ServiceListController(this);
            service.FillServices(curentPos.ToString());
            
        }

        private void keranjang_Click(object sender, RoutedEventArgs e)
        {
            GridService.IsEnabled = false;
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
            if(curentPos < 0)
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

        private void btnDeleteCard1_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID1.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard2_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID2.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard3_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID3.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard4_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID4.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard5_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID5.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard6_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID6.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard7_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID7.Content.ToString());
            service.FillServices(curentPos.ToString());
        }
        private void btnDeleteCard8_Click(object sender, RoutedEventArgs e)
        {
            service.deleteService(lblServiceID8.Content.ToString());
            service.FillServices(curentPos.ToString());
        }

        private void btnAddservice_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow();
            w.action = "insert";
            w.Show();
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search here...";
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnEdit1_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID1.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit2_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID2.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit3_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID3.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit4_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID4.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit5_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID5.Content.ToString());
            w.Title = "Edit service";
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit6_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID6.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit7_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID7.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }

        private void btnEdit8_Click(object sender, RoutedEventArgs e)
        {
            View.Admin.ServiceSettingWindow w = new View.Admin.ServiceSettingWindow(lblServiceID8.Content.ToString());
            w.Title = "Edit service";
            w.action = "update";
            w.Show();
        }
    }
}
