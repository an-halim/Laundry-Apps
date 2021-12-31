﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class LoginController
    {
        Model.Login model;
        View.Login view;
        Controller.AuthUserController auth;

        public LoginController(View.Login view)
        {
            model = new Model.Login();
            this.view = view;
            auth = new Controller.AuthUserController();
        }

        public void loginCheck()
        {
            model.username = view.txtUsername.Text;
            model.password = view.txtPassword.Password;
            bool result = model.LoginCheck();
            bool isAdmin = model.isAdmin();
            if (result)
            {
                if (isAdmin)
                {
                    View.Admin.Home hm = new View.Admin.Home();
                    hm.lblLogedUser.Content = model.username;
                    hm.Show();
                    view.Close();
                }
                else
                {
                    new View.User.Home().Show();
                    view.Close();
                }

                auth.setLogedUser(model.username);
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password , please try again.", "Warning!");
                view.txtUsername.Focus();
            }
            
        }
    }
}
