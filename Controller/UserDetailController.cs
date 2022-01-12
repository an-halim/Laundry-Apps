using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

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
                view.txtBirthDate.Text = ds.Tables[0].Rows[0]["birth_date"].ToString();
                view.txtPass.Text = ds.Tables[0].Rows[0]["password"].ToString();
                view.txtAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            }

        }
    }
}
