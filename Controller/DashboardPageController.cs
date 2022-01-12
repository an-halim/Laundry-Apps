using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace LaundryApps.Controller
{
    class DashboardPageController
    {
        View.Admin.DasboardPage view;
        Model.DBconn db;

        public DashboardPageController(View.Admin.DasboardPage view)
        {
            db = new Model.DBconn();
            this.view = view;
        }

        public void FillDatagrid()
        {
            try { view.OrdersGrid.ItemsSource = db.FillData("orders order by trx_date asc", "top 5 order_id, user_id, product_total, format(total_price, 'c', 'id-ID') as total_price, format(trx_date, 'dd/MM/yyyy' ) as trx_date, state, payment_method").DefaultView; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getBalance()
        {
            try 
            { 
                string duit = db.Select("orders", "state!='Canceled'", "format(sum(total_price), 'c', 'id-ID') as total").Tables[0].Rows[0]["total"].ToString();
                if (duit == null || duit == "") view.lblBalance.Content = "Rp.0";
                else view.lblBalance.Content = duit;
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getTotalOrder()
        {
            try { view.lblOrders.Content = db.Select("orders", null, "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void getCompletOrder()
        {
            try { view.lblCompleted.Content = db.Select("orders", "state='Completed'", "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public void getReceivedOrder()
        {
            try { view.lblReceived.Content = db.Select("orders", "state='Received'", "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public void getProgresOrder()
        {
            try { view.lblOnProgres.Content = db.Select("orders", "state='On Progres'", "count(*) as total").Tables[0].Rows[0]["total"]; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        public void GetBalancePrecentage()
        {
            float FirstValue, SecondValue, Percentage = 0;
            try
            {
                FirstValue = ObjectToFloat(db.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-14, 111)) AND (CONVERT(VARCHAR(10), GETDATE()-7, 111)) AND state <> 'Canceled'", "sum(total_price) as total").Tables[0].Rows[0]["total"]);
                SecondValue = ObjectToFloat(db.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-7, 111)) AND (CONVERT(VARCHAR(10), GETDATE(), 111)) AND state <> 'Canceled'", "sum(total_price) as total").Tables[0].Rows[0]["total"]);
                if (FirstValue == 0 && SecondValue == 0) Percentage = 0;
                else if (FirstValue == 0) Percentage = 100;
                else if (FirstValue < SecondValue) Percentage = (SecondValue - FirstValue) / FirstValue * 100;
                else if (FirstValue > SecondValue) Percentage = ((FirstValue - SecondValue) / FirstValue * 100) - 100;
            }
            catch(Exception) 
            {
                Percentage = 0;
            }

            if (Percentage <= 0)
            {
                view.lblBalancePrecentage.Foreground = Brushes.Red;
                view.lblBalancePrecentage.Content = Percentage.ToString() + "% This week";
            }
            else
            {
                view.lblBalancePrecentage.Foreground = Brushes.LightGreen;
                view.lblBalancePrecentage.Content = "+" + Percentage.ToString() + "% This week";
            }
        }
        public void GetOrderPrecentage()
        {
            float FirstValue, SecondValue, Percentage = 0;
            try
            {
                FirstValue = ObjectToFloat(db.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-14, 111)) AND (CONVERT(VARCHAR(10), GETDATE()-7, 111))", "count(*) as total").Tables[0].Rows[0]["total"]);
                SecondValue = ObjectToFloat(db.Select("orders", "trx_date between (CONVERT(VARCHAR(10), GETDATE()-7, 111)) AND (CONVERT(VARCHAR(10), GETDATE(), 111))", "count(*) as total").Tables[0].Rows[0]["total"]);
                if (FirstValue == 0 && SecondValue == 0) Percentage = 0;
                else if (FirstValue == 0) Percentage = 100;
                else if (FirstValue < SecondValue) Percentage = (SecondValue - FirstValue) / FirstValue * 100;
                else if (FirstValue > SecondValue) Percentage = ((FirstValue - SecondValue) / FirstValue * 100) - 100;


            }
            catch(Exception) 
            {
                Percentage = 0; 
            }

            if (Percentage <= 0)
            {
                view.lblOrderPrecentage.Foreground = Brushes.Red;
                view.lblOrderPrecentage.Content = Percentage.ToString() + "% This week";
            }
            else
            {
                view.lblOrderPrecentage.Foreground = Brushes.LightGreen;
                view.lblOrderPrecentage.Content = "+" + Percentage.ToString() + "% This week";
            }
        }
        

        static float ObjectToFloat(object data)
        {
            float result = 0;
            if(Convert.ToString(data) == string.Empty)            
                result = 0;            
            else            
                result = float.Parse((data.ToString()));            

            return result;
        }
    }
}
