using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LaundryApps.Controller
{
    class ServiceSettingController
    {
        View.Admin.ServiceSettingWindow view;
        Model.ServiceSetting model;

        public ServiceSettingController(View.Admin.ServiceSettingWindow view)
        {
            model = new Model.ServiceSetting();
            this.view = view;
        }

        public void LoadData(string serviceID = "")
        {

            if(serviceID == "")// its mean add new data
            {
                view.txtServiceID.Text = model.generateServiceID();
            }
            else // its mean load exiting data
            {
                string[] data = model.getDetail(serviceID);
                if (data[0] == "")
                {
                    MessageBox.Show(serviceID, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show("Unknown error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    view.txtServiceID.Text = serviceID;
                    view.txtName.Text = data[0];
                    view.txtprice.Text = data[1];
                    view.txtDetail.Text = data[2];
                }
            }
        }

        public bool Update()
        {
            bool res = false;
            string serviceID = view.txtServiceID.Text;
            string serviceName = view.txtName.Text;
            string price = view.txtprice.Text;
            string detail = view.txtDetail.Text;
            if (serviceID == "" || serviceName == "" || price == "" || detail == "") MessageBox.Show("Field can't blank!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!isInt(price)) MessageBox.Show("Please fill numeric price!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                if (model.update(serviceID, price, serviceName, detail))
                {
                    MessageBox.Show("Succesfully update service!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    res = true;
                }
                else
                {
                    MessageBox.Show("Failed update service!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
                    res = false;
                }
            }
            

            return res;
        }
        
        public bool Insert()
        {
            bool res = false;
            string serviceID = view.txtServiceID.Text;
            string serviceName = view.txtName.Text;
            string price = view.txtprice.Text;
            string detail = view.txtDetail.Text;

            if (serviceID == "" || serviceName == "" || price == "" || detail == "") MessageBox.Show("Field can't blank!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!isInt(price)) MessageBox.Show("Please fill numeric price!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                if (model.Insert(serviceID, serviceName, price, detail))
                {
                    MessageBox.Show("Succesfully add service!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    res = true;
                }
                else
                {
                    MessageBox.Show("Failed update service!", "Failed", MessageBoxButton.OK, MessageBoxImage.Information);
                    res = false;
                }
            }

            

            return res;
        }

        private bool isInt(string rupiah) /// return false if contain some char
        {
            return int.TryParse(rupiah, out int result);
        }
    }
}
