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
    /// Interaction logic for SettingPage.xaml
    /// </summary>
    public partial class SettingPage : Page
    {
        public SettingPage()
        {
            InitializeComponent();
        }

        private void PanelAccountSet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new View.Admin.AccountSetingPage());
        }

        private void PanelServiceSet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("sercie");
        }
    }
}
