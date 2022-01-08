using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class CreateOrderController
    {
        Model.DBconn model;
        Model.CreateOrder CO;
        View.Admin.CreateOrderPage view;


        public CreateOrderController(View.Admin.CreateOrderPage view)
        {
            model = new Model.DBconn();
            CO = new Model.CreateOrder();
            this.view = view;
        }

        class data
        {
            public string service { get; set; }
            public string price { get; set; }
            public string qty { get; set; }
            public string total { get; set; }
        }

        public void fillComboBox()
        {
            if(CO.fillCombox() == null)
            {
                MessageBox.Show("Error while getting data.", "Warning!");
            }
            else
            {
                view.cmbUsername.ItemsSource = CO.fillCombox().DefaultView;
                view.cmbUsername.DisplayMemberPath = "username";
                view.cmbUsername.SelectedValuePath = "username";
            }
                       
        }

        public void CmbSelected()
        {
            CO.username = view.cmbUsername.SelectedValue.ToString();
            string[] data = CO.fillbox();
            if(data[0] == null)
            {
                MessageBox.Show("Error while getting data.", "Warning!");
            }
            else
            {
                view.txtName.Text = data[0];
                view.txtPhone.Text = data[1];
                view.txtAddress.Text = data[2];
            }
            
        }

        public void fillServices(string StartPos)
        {
            if(CO.FillServices(StartPos) != null)
            {
                view.DGServices.ItemsSource = CO.FillServices(StartPos).DefaultView;
            }
            else
            {
                MessageBox.Show("Unknown Error!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateCart(string id, string price)
        {
            
            try
            {
                if(CO.CekMaks())
                {
                    MessageBox.Show("You have reach maksimum items on your shoping cart!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    view.DGCart.Items.Clear();
                    string[,] content = CO.UpdateCart(id, price);
                    for (int i = 0; i < content.GetLength(0); i++)
                    {
                        if (content[i, 0] != "")
                        {
                            data d = new data();
                            d.service = content[i, 0];
                            d.price = content[i, 1];
                            d.qty = content[i, 2];
                            d.total = content[i, 3];
                            view.DGCart.Items.Add(d);
                        }
                    }
                    view.lblTotal.Content = "Total Payment: " + CO.getTotalPay(view.CheckBoxDelivery.IsChecked.Value);
                    MessageBox.Show("Successfully add to cart!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        public void emptyCart()
        {
            view.DGCart.Items.Clear();
            CO.DeleteCart();
        }

        public void getOrderID()
        {
            view.lblOrderID.Content = CO.generateOderID();
        }

        public bool PlaceOrder()
        {
            return CO.PutOder(view.lblOrderID.Content.ToString(), view.cmbUsername.SelectedValue.ToString(), view.CheckBoxDelivery.IsChecked.Value, view.txtNote.Text);
        }

        
    }
}
