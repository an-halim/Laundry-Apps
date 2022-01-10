using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace LaundryApps.Controller
{
    class ServiceListUserController
    {
        Model.DBconn model;
        Model.ServiceList Service;
        View.User.ServiceList view;

        public ServiceListUserController(View.User.ServiceList view)
        {
            model = new Model.DBconn();
            Service = new Model.ServiceList();
            this.view = view;
        }

        public void FillServices(string startFrom)
        {
            string[,] data = Service.FillServices(startFrom);
            string total = model.Select("service", null, "count(*) as total").Tables[0].Rows[0]["total"].ToString();

            view.lblTotalProducts.Content = "Showing " + (int.Parse(startFrom) + 8).ToString() + " of " + total + " Services";

            view.lblServiceID1.Content = data[0, 0];
            view.lblServiceName1.Content = data[0, 1];
            view.lblServiceDetail1.Text = data[0, 2];
            view.lblServicePrice1.Content = data[0, 3];

            view.lblServiceID2.Content = data[1, 0];
            view.lblServiceName2.Content = data[1, 1];
            view.lblServiceDetail2.Text = data[1, 2];
            view.lblServicePrice2.Content = data[1, 3];

            view.lblServiceID3.Content = data[2, 0];
            view.lblServiceName3.Content = data[2, 1];
            view.lblServiceDetail3.Text = data[2, 2];
            view.lblServicePrice3.Content = data[2, 3];

            view.lblServiceID4.Content = data[3, 0];
            view.lblServiceName4.Content = data[3, 1];
            view.lblServiceDetail4.Text = data[3, 2];
            view.lblServicePrice4.Content = data[3, 3];

            view.lblServiceID5.Content = data[4, 0];
            view.lblServiceName5.Content = data[4, 1];
            view.lblServiceDetail5.Text = data[4, 2];
            view.lblServicePrice5.Content = data[4, 3];

            view.lblServiceID6.Content = data[5, 0];
            view.lblServiceName6.Content = data[5, 1];
            view.lblServiceDetail6.Text = data[5, 2];
            view.lblServicePrice6.Content = data[5, 3];

            view.lblServiceID7.Content = data[6, 0];
            view.lblServiceName7.Content = data[6, 1];
            view.lblServiceDetail7.Text = data[6, 2];
            view.lblServicePrice7.Content = data[6, 3];

            view.lblServiceID8.Content = data[7, 0];
            view.lblServiceName8.Content = data[7, 1];
            view.lblServiceDetail8.Text = data[7, 2];
            view.lblServicePrice8.Content = data[7, 3];


        }
        public void SearchService(string search)
        {

            string[,] data = Service.SearchService(search);
            view.lblServiceID1.Content = data[0, 0];
            view.lblServiceName1.Content = data[0, 1];
            view.lblServiceDetail1.Text = data[0, 2];
            view.lblServicePrice1.Content = data[0, 3];

            view.lblServiceID2.Content = data[1, 0];
            view.lblServiceName2.Content = data[1, 1];
            view.lblServiceDetail2.Text = data[1, 2];
            view.lblServicePrice2.Content = data[1, 3];

            view.lblServiceID3.Content = data[2, 0];
            view.lblServiceName3.Content = data[2, 1];
            view.lblServiceDetail3.Text = data[2, 2];
            view.lblServicePrice3.Content = data[2, 3];

            view.lblServiceID4.Content = data[3, 0];
            view.lblServiceName4.Content = data[3, 1];
            view.lblServiceDetail4.Text = data[3, 2];
            view.lblServicePrice4.Content = data[3, 3];

            view.lblServiceID5.Content = data[4, 0];
            view.lblServiceName5.Content = data[4, 1];
            view.lblServiceDetail5.Text = data[4, 2];
            view.lblServicePrice5.Content = data[4, 3];

            view.lblServiceID6.Content = data[5, 0];
            view.lblServiceName6.Content = data[5, 1];
            view.lblServiceDetail6.Text = data[5, 2];
            view.lblServicePrice6.Content = data[5, 3];

            view.lblServiceID7.Content = data[6, 0];
            view.lblServiceName7.Content = data[6, 1];
            view.lblServiceDetail7.Text = data[6, 2];
            view.lblServicePrice7.Content = data[6, 3];

            view.lblServiceID8.Content = data[7, 0];
            view.lblServiceName8.Content = data[7, 1];
            view.lblServiceDetail8.Text = data[7, 2];
            view.lblServicePrice8.Content = data[7, 3];
        }

        public void deleteService(string serviceid)
        {
            MessageBoxResult result = MessageBox.Show("Delete " + serviceid, "Are you sure delete this?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                if (Service.delete(serviceid)) MessageBox.Show("Delete successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                else MessageBox.Show("Can't delete a service that's currently on order!", "Delete failed!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
