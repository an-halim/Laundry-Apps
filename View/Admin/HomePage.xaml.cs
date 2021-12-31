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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        
        
        public HomePage()
        {
            InitializeComponent();          
           
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.Admin.DasboardPage());
        }
    }
}
