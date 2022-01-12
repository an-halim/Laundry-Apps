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
    /// Interaction logic for PaymentPage.xaml
    /// </summary>
    ///    
    public partial class PaymentPage : Page
    {
        Controller.PaymentController payment;
        public bool isBtnCash_Pressed { get; set; }
        public bool isBtnEwal_Pressed { get; set; }
        public bool isBtnBank_Pressed { get; set; }
        public bool isBtnCredit_Pressed { get; set; }

        public PaymentPage(string orderid, string total)
        {
            InitializeComponent();
            lblOrderID.Content = orderid;
            lblTotal.Content = total;
            payment = new Controller.PaymentController(this);
        }


        private void BDCash_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isBtnCash_Pressed = Pressed(BDCash, isBtnCash_Pressed);
            isBtnEwal_Pressed = Unpressed(BDEwal);
            isBtnBank_Pressed = Unpressed(BDBank);
            isBtnCredit_Pressed = Unpressed(BDCredit);
        }

        private void BDEwal_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isBtnEwal_Pressed = Pressed(BDEwal, isBtnEwal_Pressed);
            isBtnCash_Pressed = Unpressed(BDCash);
            isBtnBank_Pressed = Unpressed(BDBank);
            isBtnCredit_Pressed = Unpressed(BDCredit);
        }

        private void BDBank_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isBtnBank_Pressed = Pressed(BDBank, isBtnBank_Pressed);
            isBtnCash_Pressed = Unpressed(BDCash);
            isBtnEwal_Pressed = Unpressed(BDEwal);
            isBtnCredit_Pressed = Unpressed(BDCredit);
        }

        private void BDCredit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isBtnCredit_Pressed = Pressed(BDCredit, isBtnCredit_Pressed);
            isBtnCash_Pressed = Unpressed(BDCash);
            isBtnBank_Pressed = Unpressed(BDBank);
            isBtnEwal_Pressed = Unpressed(BDEwal);
        }

        private bool Pressed(Border bd, bool IsPressed)
        {
            var tobrushColor = new System.Windows.Media.BrushConverter();
            var unspressed = (Brush)tobrushColor.ConvertFromString("#3085F1");
            var pressed = (Brush)tobrushColor.ConvertFromString("#005ACC");
            bool result;
            if (IsPressed)
            {
                bd.Height = 150;
                bd.Width = 150;
                bd.Background = unspressed;
                result = false;
            }
            else
            {
                bd.Height = 180;
                bd.Width = 180;
                bd.Background = pressed;
                result = true;

            }

            return result;
        }

        private bool Unpressed(Border bd)
        {
            var tobrushColor = new System.Windows.Media.BrushConverter();
            var unspressed = (Brush)tobrushColor.ConvertFromString("#3085F1");
            bd.Height = 150;
            bd.Width = 150;
            bd.Background = unspressed;
            return false;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (payment.confirmPaymentUser())
            {
                MessageBox.Show("Order successfully confirmed!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new View.User.OrderDetailPage(lblOrderID.Content.ToString()));
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (payment.cancelOrderUser()) NavigationService.Navigate(new View.User.CreateOrderPage());
        }
    }
}
