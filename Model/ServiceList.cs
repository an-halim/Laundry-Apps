using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Model
{
    class ServiceList
    {
        Model.DBconn model;

        public ServiceList()
        {
            model = new Model.DBconn();
        }

        public string[,] FillServices(string startFrom)
        {
            string[,] result = new string[8, 4] { { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" } };
            try
            {
                for(int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if(j==0)
                        result[i, j] = model.Select("service order by service_id asc offset " + startFrom + " row fetch next 8 row only",null, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["service_id"].ToString();
                        else if(j==1)
                        result[i, j] = model.Select("service order by service_id asc offset " + startFrom + " row fetch next 8 row only", null, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["Service_name"].ToString();
                        else if(j==2)
                        result[i, j] = model.Select("service order by service_id asc offset " + startFrom + " row fetch next 8 row only", null, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["Service_detail"].ToString();
                        else
                        result[i, j] = model.Select("service order by service_id asc offset " + startFrom + " row fetch next 8 row only", null, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["idr_price"].ToString();
                    }                    
                }
                
            }
            catch (Exception)
            {
                result[0, 0] = null;
            }

            return result;
        }

       public string[,] SearchService(string seacrh)
        {
            string[,] result = new string[8, 4] { { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" } };
            try
            {
                string kondisi = "service_id like '%" + seacrh + "%' or service_name like '%" + seacrh + "%' or service_detail like '%" + seacrh + "%' or price like '%" + seacrh + "%'";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                            result[i, j] = model.Select("service", kondisi, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["service_id"].ToString();
                        else if (j == 1)
                            result[i, j] = model.Select("service", kondisi, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["Service_name"].ToString();
                        else if (j == 2)
                            result[i, j] = model.Select("service", kondisi, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["Service_detail"].ToString();
                        else
                            result[i, j] = model.Select("service", kondisi, "*, format(price, 'c', 'id-ID') as idr_price").Tables[0].Rows[i]["idr_price"].ToString();
                    }
                }

            }
            catch (Exception)
            {
                result[0, 0] = null;
            }

            return result;
        }
    }
}
