using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;

namespace LaundryApps.Controller
{
    class UserDetailController
    {
        Model.UserDetail model;
        View.Admin.UserDetailPage view;


        public UserDetailController(View.Admin.UserDetailPage view)
        {
            model = new Model.UserDetail();
            this.view = view;
        }

        public void LoadData()
        {
            DataSet ds = new DataSet();
            ds = model.LoadDetail(view.txtUsername.Text);
            if (ds != null)
            {
                view.OrdersGrid.ItemsSource = ds.Tables[0].DefaultView;
                view.txtName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                view.txtPhone.Text = ds.Tables[0].Rows[0]["number"].ToString();
                view.txtBirthDate.SelectedDate = DateTime.Parse(ds.Tables[0].Rows[0]["birth_date"].ToString());
                view.txtPass.Text = ds.Tables[0].Rows[0]["password"].ToString();
                view.txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                if (ds.Tables[0].Rows[0]["is_admin"].ToString() == "1")
                    view.CBadmin.IsChecked = true;
            }

        }


        public bool Update()
        {
            string SetAdmin;
            string username = view.txtUsername.Text;
            string name = view.txtName.Text;
            string phone = view.txtPhone.Text;
            string birth = view.txtBirthDate.SelectedDate.Value.ToString("yyyy/MM/dd");
            string address = view.txtAddress.Text;
            string pass = view.txtPass.Text;
            bool isAdminCheked = view.CBadmin.IsChecked.Value;
            if (isAdminCheked)
                SetAdmin = "1";
            else SetAdmin = "0";
            
            return model.Update(username, name, phone, birth, pass, address, SetAdmin);
        }
    }
}
