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
    }
}
