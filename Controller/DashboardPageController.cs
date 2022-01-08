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
            try { view.OrdersGrid.ItemsSource = model.FillData("orders order by trx_date asc", "top 5 order_id, user_id, product_total, format(total_price, 'c', 'id-ID') as total_price, format(trx_date, 'dd/MM/yyyy' ) as trx_date, state, payment_method").DefaultView; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getBalance()
        {
            try 
            { 
                string duit = model.Select("orders", "state!='Canceled'", "format(sum(total_price), 'c', 'id-ID') as total").Tables[0].Rows[0]["total"].ToString();
                if (duit == null || duit == "") view.lblBalance.Content = "Rp.0";
                else view.lblBalance.Content = duit;
            }
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
                FirstValue = float.Parse(model.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-14, 111)) AND (CONVERT(VARCHAR(10), GETDATE()-7, 111)) AND state!='Canceled'", "sum(total_price) as total").Tables[0].Rows[0]["total"].ToString());
                SecondValue = float.Parse(model.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-7, 111)) AND (CONVERT(VARCHAR(10), GETDATE(), 111)) AND state!='Canceled'", "sum(total_price) as total").Tables[0].Rows[0]["total"].ToString());
                if (FirstValue == 0 && SecondValue == 0) Percentage = 0;
                else Percentage = (SecondValue - FirstValue) / FirstValue * 100;
            }
            catch(Exception) 
            {
                Percentage = 0;
            }

            return Percentage;
        }
        public float GetOrderPrecentage()
        {
            float FirstValue, SecondValue, Percentage;
            try
            {
                FirstValue = float.Parse(model.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-14, 111)) AND (CONVERT(VARCHAR(10), GETDATE()-7, 111))", "count(*) as total").Tables[0].Rows[0]["total"].ToString());
                SecondValue = float.Parse(model.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-7, 111)) AND (CONVERT(VARCHAR(10), GETDATE(), 111))", "count(*) as total").Tables[0].Rows[0]["total"].ToString());
                if (FirstValue == 0  && SecondValue == 0) Percentage = 0;
                else Percentage = (SecondValue - FirstValue) / FirstValue*100;
                
                
            }
            catch(Exception) 
            {
                Percentage = 0; 
            }

            return Percentage;
        }
    }
}
