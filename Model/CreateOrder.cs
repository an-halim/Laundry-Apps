using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;

namespace LaundryApps.Model
{
    class CreateOrder
    {
        public string username { get; set; }
        Model.DBconn model;        
        private readonly Random _num = new Random();
        string[,] content = new string[10, 4] { { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, };
        int items = 0;


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
                dt = model.FillData("service order by service_id asc offset "+startFrom+" row fetch next 3 row only", "service_id, format(price, 'c', 'id-ID') as price, CONCAT(service_name, ' ', service_detail) as detail");
            }
            catch (Exception) 
            {
                dt = null;
            }

            return dt;
        }

        public string ToIDR(string data)
        {
            return String.Format(CultureInfo.CreateSpecificCulture("id-ID"), "Rp{0:C}", data);
        }

        public int ToInt(string rupiah)
        {
            return int.Parse(rupiah.Replace("Rp", "").Replace(",00", "").Replace(".", ""));
        }
        private int RandomNumber(int min, int max)
        {
            return _num.Next(min, max);
        }

        public string generateOderID()
        {
            DataSet ds = new DataSet();
            bool isUsed = false;
            string orderid = "";

            do
            {
                orderid = RandomNumber(100000, 999999).ToString();
                string kondisi = "order_id LIKE '" + orderid + "' ";
                ds = model.Select("orders", kondisi);
                if (ds.Tables[0].Rows.Count > 0) isUsed = true; // its mean that order id has used on database
                else isUsed = false;

            } while (isUsed);

            return orderid;
        }
        public string[,] UpdateCart(string id, string price)
        {
            bool isFound = false;
            try
            {
                for (int i = 0; i < content.GetLength(0); i++)
                {
                    if (content[i, 0] == id)
                    {
                        int newQty = int.Parse(content[i, 2]) + 1;
                        int NewPrice = ToInt(price) + ToInt(content[i, 3]);
                        content[i, 2] = newQty.ToString();
                        content[i, 3] = ToIDR(NewPrice.ToString());
                        isFound = true;
                    }                    
                }

                if (!isFound)
                {
                    content[items, 0] = id;
                    content[items, 1] = ToIDR(ToInt(price).ToString());
                    content[items, 2] = "1";
                    content[items, 3] = ToIDR(ToInt(price).ToString());
                    items++;
                }
            }
            catch (Exception)
            {
                DeleteCart();
            }

            return content;                       
        }

        public bool CekMaks()
        {
            if (content[9, 0] != "") return true; // cek last index if value not empty string its mean maximus has reach
            else return false;
        }
        public string getTotalPay(bool isShiping)
        {
            int count = 0;
            for(int i = 0; i < content.GetLength(0); i++)
            {
                if(content[i,3] != "") count += ToInt(content[i, 3]);
            }

            if (isShiping) return ToIDR((count + 15000).ToString());
            return ToIDR(count.ToString());
        }
        public string getTotalItems()
        {
            int count = 0;
            for(int i = 0; i < content.GetLength(0); i++)
            {
                if(content[i,2] != "") count += ToInt(content[i, 2]);
            }

            return count.ToString();
        }
        public void DeleteCart() // set all data to empty string
        {
            items = 0;
            for (int i = 0; i < content.GetLength(0); i++)
            {
                for (int j = 0; j < content.GetLength(1); j++)
                {
                    content[i, j] = "";
                }
            }
        }

        public bool PutOder(string orderid, string userid, bool isShiping, string note = "")
        {
            bool res;
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            if (content[0,0] == "")
            {
                res = false;
            }
            else
            {
                try
                {
                    if (note == "")
                    {
                        model.Insert("orders", "'" + orderid + "', '" + userid + "', '" + date + "', '" + int.Parse(getTotalItems()) + "', '" + ToInt(getTotalPay(isShiping)) + "', 'Waiting Payment', 'Cash', ' '");
                    }
                    else
                    {
                        model.Insert("orders", "'" + orderid + "', '" + userid + "', '" + date + "', '" + int.Parse(getTotalItems()) + "', '" + ToInt(getTotalPay(isShiping)) + "', 'Waiting Payment', 'Cash', '" + note + "'");
                    }

                    for (int i = 0; i < content.GetLength(0); i++)
                    {
                        if (content[i, 0] != "")
                        {
                            string serviceId = content[i, 0];
                            string qty = content[i, 2];
                            int total = ToInt(content[i, 3]);
                            model.Insert("order_detail", "'" + orderid + "', '" + serviceId + "', '" + userid + "', '" + date + "', '" + qty + "', '" + total + "'");
                        }

                    }
                    res = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    res = false;
                }
            }

            return res;
        }

        
        
    }
}
