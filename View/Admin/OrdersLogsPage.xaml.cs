﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaundryApps.View.Admin
{
    /// <summary>
    /// Interaction logic for OrdersLogs.xaml
    /// </summary>
    public partial class OrdersLogsPage : Page
    {

        Controller.OrderLogsControler OD;
        public OrdersLogsPage()
        {
            InitializeComponent();
            OD = new Controller.OrderLogsControler(this);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OD.FillDatagrid();
        }
    }
}
