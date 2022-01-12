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
using Microsoft.Win32;
using CSVLibraryAK;
using System.Data;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for UsersListPage.xaml
    /// </summary>
    public partial class UsersListPage : Page
    {
        Controller.UserListController UserList;
        public UsersListPage()
        {
            InitializeComponent();
            UserList = new Controller.UserListController(this);
        }
        private string getLoged()
        {
            return ((Home)Application.Current.Windows[0]).lblLogedUser.Content.ToString();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserList.FillDataGrid();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            new View.Admin.EditUserWindow().Show();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            object item = UserListGrid.SelectedItem;
            string username = (UserListGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            if(username == getLoged())
            {
                MessageBox.Show("Can't delete your self!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure delete this user?", "Confirmation!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) UserList.deleteUser(username);
                UserList.FillDataGrid();
            }
            
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Admin.AddUserPage());
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.ToString() != "Search here...")
            {
                UserList.FillDataGrid(txtSearch.Text.ToString());
            }
        }

        private void Label_LostFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "Search here...";
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            UserList.exportFile();
        }

        private void btnSeeDetails_Click(object sender, RoutedEventArgs e)
        {
            object item = UserListGrid.SelectedItem;
            string username = (UserListGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            NavigationService.Navigate(new View.Admin.UserDetailPage(username));
        }
    }
}
