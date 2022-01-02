﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class DashboardPageController
    {
        View.Admin.DasboardPage view;
        Model.DBconn model;

        public DashboardPageController(View.Admin.DasboardPage view)
        {
            model = new Model.DBconn();
            this.view = view;
        }

        public void FillDatagrid()
        {
            try { view.OrdersGrid.ItemsSource = model.FillData("orders", "top 5 order_id, user_id, product_total, format(total_price, 'c', 'id-ID') as total_price, format(trx_date, 'dd/MM/yyyy' ) as trx_date, state, payment_method").DefaultView; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getBalance()
        {
            try { view.lblBalance.Content = model.Select("orders", null, "format(sum(total_price), 'c', 'id-ID') as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getTotalOrder()
        {
            try { view.lblOrders.Content = model.Select("orders", null, "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getCompletOrder()
        {
            try { view.lblCompleted.Content = model.Select("orders", "state='Completed'", "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public void getReceivedOrder()
        {
            try { view.lblReceived.Content = model.Select("orders", "state='Received'", "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public void getProgresOrder()
        {
            try { view.lblOnProgres.Content = model.Select("orders", "state='On Progres'", "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public float GetBalancePrecentage()
        {
            float FirstValue, SecondValue, Percentage;
            try
            {
                FirstValue = float.Parse(model.Select("orders", "trx_date between GETDATE()-14 AND GETDATE()-7", "sum(total_price) as total").Tables[0].Rows[0]["total"].ToString());
                SecondValue = float.Parse(model.Select("orders", "trx_date between GETDATE()-7 AND GETDATE()", "sum(total_price) as total").Tables[0].Rows[0]["total"].ToString());
                Percentage = (SecondValue - FirstValue) /FirstValue*100;
            }
            catch(Exception e) 
            {
                Percentage = 0;
                MessageBox.Show(e.Message); 
            }

            return Percentage;
        }
        public float GetOrderPrecentage()
        {
            float FirstValue, SecondValue, Percentage;
            try
            {
                FirstValue = float.Parse(model.Select("orders", "trx_date between GETDATE()-14 AND GETDATE()-7", "count(*) as total").Tables[0].Rows[0]["total"].ToString());
                SecondValue = float.Parse(model.Select("orders", "trx_date between GETDATE()-7 AND GETDATE()", "count(*) as total").Tables[0].Rows[0]["total"].ToString());
                Percentage = (SecondValue- FirstValue) /FirstValue*100;
            }
            catch(Exception e) 
            {
                Percentage = 0;
                MessageBox.Show(e.Message); 
            }

            return Percentage;
        }
    }
}
