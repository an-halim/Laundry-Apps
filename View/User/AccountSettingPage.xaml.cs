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
    /// Interaction logic for AccountSetingPage.xaml
    /// </summary>
    public partial class AccountSettingPage : Page
    {
        Controller.AccountSettingController setting;
        public AccountSettingPage()
        {
            InitializeComponent();
            setting = new Controller.AccountSettingController(this);
            txtName.Focus();
            txtUsername.Text = getLoged();
            setting.LoadDataUser();
        }

        private string getLoged()
        {
            return ((Home)Application.Current.Windows[0]).lblLogedUser.Content.ToString();
        }
        
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            setting.UpdateUser();
        }
    }
}
