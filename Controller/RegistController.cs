using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class RegistController
    {
        Model.Register model;
        View.Register view;

        public RegistController(View.Register view)
        {
            model = new Model.Register();
            this.view = view;
        }

        public void regist()
        {
            bool cek;
            bool regist;
            model.username = view.txtUsername.Text;
            model.name = view.txtName.Text;
            model.address = view.txtAddress.Text;
            model.date = view.datePick.SelectedDate.Value.Date;
            model.number = view.txtNumber.Text;
            model.password = view.txtPassword.Password;

            cek = model.usernameCheck();
            if (cek)
            {
                regist = model.Regist();
                if (regist) MessageBox.Show("Sign Up Successfully! you can login now");
                else MessageBox.Show("Sign Up failed!");
            }
            else
            {
                MessageBox.Show("Username already used, please try use other!");
            }
        }
    }
}
