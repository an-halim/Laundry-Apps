using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for AddServiceWindow.xaml
    /// </summary>
    public partial class ServiceSettingWindow : Window
    {
        Controller.ServiceSettingController serviceSetting;
        public string action { get; set; }
        public ServiceSettingWindow(string serviceID = "") // default value parameter "" for add new service its mean dont load from exiting data
        {
            InitializeComponent();
            serviceSetting = new Controller.ServiceSettingController(this);
            serviceSetting.LoadData(serviceID);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (file.ShowDialog() == true)
            {
                string filename = file.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(filename);
                bitmap.EndInit();
                imgFoto.Source = bitmap;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(action == "update")
            {
                if(serviceSetting.Update()) this.Close();
            }
            else if(action == "insert")
            {
                if (serviceSetting.Insert()) this.Close();
            }
        }
    }
}
