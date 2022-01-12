using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class AccountSettingController
    {
        View.Admin.AccountSetingPage view;
        View.User.AccountSettingPage viewUser;
        Model.AccountSetting model;

        //admin
        public AccountSettingController(View.Admin.AccountSetingPage view)
        {
            model = new Model.AccountSetting();
            this.view = view;
        }
        
        //user
        public AccountSettingController(View.User.AccountSettingPage view)
        {
            model = new Model.AccountSetting();
            this.viewUser = view;
        }

        //admin
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
        
        //user
        public void LoadDataUser()
        {
            string username = viewUser.txtUsername.Text;

            string[] data = model.getDetail(username);
            if(data[0] == "")
            {
                MessageBox.Show("Unknown error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                viewUser.txtName.Text = data[0];
                viewUser.txtAddress.Text = data[1];
                viewUser.txtNumber.Text = data[2];
                viewUser.txtPass.Text = data[3];
            }
        }

        public void UpdateUser()
        {
            string username = viewUser.txtUsername.Text;
            string name = viewUser.txtName.Text;
            string address = viewUser.txtAddress.Text;
            string number = viewUser.txtNumber.Text;
            string pass = viewUser.txtPass.Text;

            if(model.update(username, name, address, number, pass))
            {
                MessageBox.Show("Succesfully update account!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadDataUser();
            }
            else
            {
                MessageBox.Show("Failed update account!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
