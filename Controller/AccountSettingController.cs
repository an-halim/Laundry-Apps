using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class AccountSettingController
    {
        View.Admin.AccountSetingPage view;
        Model.AccountSetting model;

        public AccountSettingController(View.Admin.AccountSetingPage view)
        {
            model = new Model.AccountSetting();
            this.view = view;
        }

        public void LoadData()
        {
            string username = view.txtUsername.Text;

            string[] data = model.getDetail(username);
            if(data[0] == "")
            {
                MessageBox.Show("Unknown error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                view.txtName.Text = data[0];
                view.txtAddress.Text = data[1];
                view.txtNumber.Text = data[2];
                view.txtPass.Text = data[3];
            }
        }

        public void Update()
        {
            string username = view.txtUsername.Text;
            string name = view.txtName.Text;
            string address = view.txtAddress.Text;
            string number = view.txtNumber.Text;
            string pass = view.txtPass.Text;

            if(model.update(username, name, address, number, pass))
            {
                MessageBox.Show("Succesfully update account!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Failed update account!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
