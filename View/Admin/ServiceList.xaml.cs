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
        public ServiceList()
        {
            InitializeComponent();
            Uri resoureUri = new Uri("/View/Images/img_laundry.png", UriKind.Relative);
            img1.Source = new BitmapImage(resoureUri);
            service = new Controller.ServiceListController(this);
            service.FillServices("0");
            
        }

        private void keranjang_Click(object sender, RoutedEventArgs e)
        {
            GridService.IsEnabled = false;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
