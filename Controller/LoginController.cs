using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class LoginController
    {
        Model.Login model;
        View.Login view;

        public LoginController(View.Login view)
        {
            model = new Model.Login();
            this.view = view;
        }

        public void loginCheck()
        {
            model.username = view.txtUsername.Text;
            model.password = view.txtPassword.Password;
            bool result = model.LoginCheck();
            if (result)
            {
                new View.Admin.Home().Show();
                view.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password , please try again.");
                view.txtUsername.Focus();
            }
            
        }
    }
}
