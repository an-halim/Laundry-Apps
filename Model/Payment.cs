using System;
using System.Collections.Generic;
using System.Text;

namespace LaundryApps.Model
{
    class Payment
    {
        Model.DBconn model;

        public Payment()
        {
            model = new Model.DBconn();
        }

        public bool confirmPay(string payment, string orderid)
        {
            bool result;
            try
            {
                result = model.Update("orders", "state = 'Received', payment_method='" + payment + "'", "order_id='" + orderid + "'");
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool Cancel(string orderid)
        {
            bool result;
            try
            {
                result = model.Update("orders", "state = 'Canceled'", "order_id='" + orderid + "'");
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
