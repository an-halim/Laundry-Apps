using System;
using System.Collections.Generic;
using System.Text;

namespace LaundryApps.Controller
{
    class OrderDetailController
    {
        Model.OrderDetail model;
        View.Admin.OrderDetail view;

        public OrderDetailController(View.Admin.OrderDetail view)
        {
            model = new Model.OrderDetail();
            this.view = view;
        }

        public void LoadOrder()
        {
            string orderid = (view.lblOrderID.Content.ToString()).Replace("Order #", "");
            view.OrderDetailGrid.ItemsSource = model.loadData(orderid).DefaultView;
            view.txtName.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["name"].ToString();
            view.txtPhone.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["number"].ToString();
            view.txtAddress.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["address"].ToString();
            view.txtDate.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["trx_date"].ToString();
            view.txtStatus.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["state"].ToString();
            view.txtPayment.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["payment_method"].ToString();
            view.txtNote.Text = model.loadCustomer(orderid).Tables[0].Rows[0]["note"].ToString();
        }
    }
}
