using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace LaundryApps.Model
{
    class ServiceSetting
    {
        Model.DBconn db;
        private Random _num = new Random();

        public ServiceSetting()
        {
            db = new Model.DBconn();
        }

        public string[] getDetail(string serviceId)
        {
            string[] data = { "", "", "" };
            try
            {
                data[0] = db.Select("service", "service_id='" + serviceId + "'").Tables[0].Rows[0]["service_name"].ToString();
                data[1] = db.Select("service", "service_id='" + serviceId + "'").Tables[0].Rows[0]["price"].ToString();
                data[2] = db.Select("service", "service_id='" + serviceId + "'").Tables[0].Rows[0]["service_detail"].ToString();
            }
            catch (Exception)
            {
                data[0] = "";
            }

            return data;
        }

        public bool update(string serviceId, string price, string name, string detail)
        {
            bool result;
            try
            {
                string data = "price='" + price + "', service_name='" + name + "', service_detail='" + detail + "'";
                result = db.Update("service", data, "service_id='" + serviceId + "'");
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


        public bool Insert(string serviceID, string name, string price, string detail)
        {
            bool result;
            string data = "'"+ serviceID +"', '"+ price +"', '"+ name + "', '"+ detail +"'";
            result = db.Insert("service", data);
            return result;
        }

        private int RandomNumber(int min, int max)
        {
            return _num.Next(min, max);
        }

        public string generateServiceID()
        {
            DataSet ds = new DataSet();
            bool isUsed = false;
            string serviceid;

            do
            {
                serviceid = "DK" + (RandomNumber(1000, 9999).ToString());
                string kondisi = "service_id LIKE '" + serviceid + "' ";
                ds = db.Select("service", kondisi);
                if (ds.Tables[0].Rows.Count > 0) isUsed = true; // its mean that order id has used on database
                else isUsed = false;

            } while (isUsed);

            return serviceid;
        }

    }
}
