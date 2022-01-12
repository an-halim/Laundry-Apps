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
    /// Interaction logic for CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        Controller.CreateOrderController createOrder;
        int CurentPos;
        public CreateOrderPage()
        {
            InitializeComponent();
            createOrder = new Controller.CreateOrderController(this);
            txtUsername.Text = getLoged();
            createOrder.LoadCustomer();
        }
        private string getLoged()
        {
            return ((Home)Application.Current.Windows[0]).lblLogedUser.Content.ToString();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            gridCustomersDetail.IsEnabled = false;
            GridCart.IsEnabled = true;
            GridSevice.IsEnabled = true;
            createOrder.fillServicesUser(CurentPos.ToString());
            createOrder.getOrderIDUser();
            if (CheckBoxDelivery.IsChecked.Value)
            {
                lblShipingFee.Content = "Delivery Fee: Rp.15.000";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            gridCustomersDetail.IsEnabled = true;
            GridCart.IsEnabled = false;
            GridSevice.IsEnabled = false;
            DGServices.ItemsSource = "";
            lblOrderID.Content = "";
            createOrder.emptyCartUser();
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            if (createOrder.PlaceOrderUser())
            {
                NavigationService.Navigate(new View.User.PaymentPage("Order #" + lblOrderID.Content.ToString(), lblTotal.Content.ToString()));
            }
        }

        private void addTOcart_Click(object sender, RoutedEventArgs e)
        {
            object item = DGServices.SelectedItem;
            string id = (DGServices.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            string price = (DGServices.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            createOrder.UpdateCartUser(id, price);
        }


        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            DGServices.ItemsSource = "";
            CurentPos += 3;
            createOrder.fillServicesUser(CurentPos.ToString());
            if (DGServices.Items.Count == 0)// avoid empty database, it will return to the previous data and disable next button
            {
                CurentPos -= 3;
                createOrder.fillServicesUser(CurentPos.ToString());
                btnNext.IsEnabled = false;
                MessageBox.Show("You have reach end of service list", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                btnPrev.IsEnabled = true;
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (CurentPos == 0)// avoid user if has reach start data, it will disable prev button
            {
                MessageBox.Show("You have reach start of service list", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnPrev.IsEnabled = false;
            }
            else
            {
                DGServices.ItemsSource = "";
                CurentPos -= 3;
                createOrder.fillServicesUser(CurentPos.ToString());
                btnNext.IsEnabled = true;
            }
        }

        private void CBAddNote_Checked(object sender, RoutedEventArgs e)
        {
            txtNote.IsEnabled = true;
            txtNote.Focus();
        }
    }
}
