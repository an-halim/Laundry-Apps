using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Media;

namespace LaundryApps.Controller
{
    class OrderDetailController
    {
        Model.OrderDetail model;
        View.Admin.OrderDetail view;
        View.User.OrderDetailPage viewUser;

        public OrderDetailController(View.Admin.OrderDetail view)
        {
            model = new Model.OrderDetail();
            this.view = view;
        }
        
        public OrderDetailController(View.User.OrderDetailPage view)
        {
            model = new Model.OrderDetail();
            this.viewUser = view;
        }

        // admin
        public void LoadOrder()
        {
            string orderid = (view.lblOrderID.Content.ToString()).Replace("Order #", "");
            DataTable data = new DataTable();
            data = model.loadData(orderid);
            view.OrderDetailGrid.ItemsSource = data.DefaultView;
            view.txtName.Text = data.Rows[0]["name"].ToString();
            view.txtPhone.Text = data.Rows[0]["number"].ToString();
            view.txtAddress.Text = data.Rows[0]["address"].ToString();
            view.txtDate.Text = data.Rows[0]["trx_date"].ToString();
            view.txtStatus.Text = data.Rows[0]["state"].ToString();
            view.txtPayment.Text = data.Rows[0]["payment_method"].ToString();
            view.txtNote.Text = data.Rows[0]["note"].ToString();
        }


        // user
        public void LoadOrderUser()
        {
            string orderid = (viewUser.lblOrderID.Content.ToString()).Replace("Order #", "");
            DataTable data = new DataTable();
            data = model.loadData(orderid);
            viewUser.OrderDetailGrid.ItemsSource = data.DefaultView;
            viewUser.txtName.Text = data.Rows[0]["name"].ToString();
            viewUser.txtPhone.Text = data.Rows[0]["number"].ToString();
            viewUser.txtAddress.Text = data.Rows[0]["address"].ToString();
            viewUser.txtDate.Text = data.Rows[0]["trx_date"].ToString();
            viewUser.txtStatus.Text = data.Rows[0]["state"].ToString();
            viewUser.txtPayment.Text = data.Rows[0]["payment_method"].ToString();
            viewUser.txtNote.Text = data.Rows[0]["note"].ToString();
        }
    }
}
