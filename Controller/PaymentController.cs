using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class PaymentController
    {
        Model.Payment pay;
        View.Admin.PaymentPage view;
        View.User.PaymentPage viewUser;

        //admin
        public PaymentController(View.Admin.PaymentPage view)
        {
            pay = new Model.Payment();
            this.view = view;
        }
        
        //user
        public PaymentController(View.User.PaymentPage view)
        {
            pay = new Model.Payment();
            this.viewUser = view;
        }

        //admin
        public bool confirmPayment()
        {
            bool result;
            string payment_method = "";
            if (view.isBtnBank_Pressed)
            {
                payment_method = "Bank Transfer";
            }else if (view.isBtnCash_Pressed)
            {
                payment_method = "Cash";
            }else if (view.isBtnCredit_Pressed)
            {
                payment_method = "Credit Card";
            }else if (view.isBtnEwal_Pressed)
            {
                payment_method = "E-Wallet";
            }
            else
            {
                MessageBox.Show("Please choose payment method!", "Failed!", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            result = pay.confirmPay(payment_method, (view.lblOrderID.Content.ToString()).Replace("Order #", ""));
            return result;
        }

        public bool cancelOrder()
        {
            return pay.Cancel((view.lblOrderID.Content.ToString()).Replace("Order #", ""));
        }
        
        
        //user
        public bool confirmPaymentUser()
        {
            bool result;
            string payment_method = "";
            if (viewUser.isBtnBank_Pressed)
            {
                payment_method = "Bank Transfer";
            }else if (viewUser.isBtnCash_Pressed)
            {
                payment_method = "Cash";
            }else if (viewUser.isBtnCredit_Pressed)
            {
                payment_method = "Credit Card";
            }else if (viewUser.isBtnEwal_Pressed)
            {
                payment_method = "E-Wallet";
            }
            else
            {
                MessageBox.Show("Please choose payment method!", "Failed!", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            result = pay.confirmPay(payment_method, (viewUser.lblOrderID.Content.ToString()).Replace("Order #", ""));
            return result;
        }

        public bool cancelOrderUser()
        {
            return pay.Cancel((viewUser.lblOrderID.Content.ToString()).Replace("Order #", ""));
        }
    }
}
