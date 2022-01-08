using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class AddUserController
    {
        Model.Register model;
        View.Admin.AddUserPage view;

        public AddUserController(View.Admin.AddUserPage view)
        {
            model = new Model.Register();
            this.view = view;
        }

        public bool regist()
        {
            bool cek;
            bool regist = false;

            try
            {
                model.username = view.txtUsername.Text;
                model.name = view.txtName.Text;
                model.address = view.txtAddress.Text;
                model.date = view.datePick.SelectedDate.Value.Date;
                model.number = view.txtNumber.Text;
                model.password = "123";


                cek = model.usernameCheck();
                if (cek)
                {
                    MessageBox.Show("Username already used, please try use other!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (!CheckLength(model.username))
                    {
                        regist = model.Regist();
                        if (regist) MessageBox.Show("Sign Up Successfully! you can login now", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                        else MessageBox.Show("Sign Up failed!", "Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Sign Up failed, Username use too many character!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Field can't blank!", "Sign Up failed!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return regist;

        }

        public bool CheckLength(string username)
        {
            bool result;

            if (username.Length > 10) result = true;
            else result = false;

            return result;
        }

    }
}
