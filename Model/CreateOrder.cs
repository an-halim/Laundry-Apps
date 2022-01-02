using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LaundryApps.Model
{
    class CreateOrder
    {
        public string username { get; set; }
        Model.DBconn model;

        public CreateOrder()
        {
            model = new Model.DBconn();
        }

        public string[] fillbox()
        {
            string[] result = {"", "", "" };
            try
            {
                result[0] = model.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["name"].ToString();
                result[1] = model.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["number"].ToString();
                result[2] = model.Select("userdata", "username='" + username + "'").Tables[0].Rows[0]["address"].ToString();
            }
            catch (Exception)
            {
                result[0] = null;
            }

            return result;
        }

        public DataTable fillCombox()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = model.FillData("userdata", "*");
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable FillServices(string startFrom)
        {
            DataTable dt = new DataTable();
            try 
            { 
                dt = model.FillData("service order by service_id asc offset "+startFrom+" row fetch next 3 row only", "service_id, format(price, 'c', 'id-ID') as price, service_detail");
            }
            catch (Exception) 
            {
                dt = null;
            }

            return dt;
        }


    }
}
