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
    /// Interaction logic for CreateOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        Controller.CreateOrderController createOrder;
        int CurentPos;
        class data
        {
            public string service { get; set; }
            public string price { get; set; }
            public string qty { get; set; }
            public string total { get; set; }
        }

        public CreateOrderPage()
        {
            InitializeComponent();
            createOrder = new Controller.CreateOrderController(this);
            createOrder.fillComboBox();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == null || txtName.Text == "") MessageBox.Show("Please choose customer!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                gridCustomersDetail.IsEnabled = false;
                GridCart.IsEnabled = true;
                GridSevice.IsEnabled = true;
                createOrder.fillServices("0");
                if (CheckBoxDelivery.IsChecked.Value)
                {
                    lblShipingFee.Content = "Shipping Fee: Rp.15.000";
                }
            }

            
        }

        private void cmbUsername_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            createOrder.CmbSelected();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            gridCustomersDetail.IsEnabled = true;
            GridCart.IsEnabled = false;
            GridSevice.IsEnabled = false;
            DGServices.ItemsSource = "";
            DGCart.Items.Clear();
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addTOcart_Click(object sender, RoutedEventArgs e)
        {
            object item = DGServices.SelectedItem;



            data d = new data();
            d.service = (DGServices.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            d.price = (DGServices.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            d.qty = "1";
            d.total = "Rp.10.000";
            DGCart.Items.Add(d);
            
            MessageBox.Show("Successfully add to cart!", "Successfully", MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void DGCart_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Successfully add to cart!", "Successfully");
           
        }

        private void DGCart_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            MessageBox.Show("Successfully add to cart!", "Successfully");
        }

        private void DGCart_AutoGeneratedColumns(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully add to cart!", "Successfully");
        }

        private void DGCart_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            MessageBox.Show("Successfully add to cart!", "Successfully");
        }

        private void DGCart_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("Successfully add to cart!", "Successfully");
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            DGServices.ItemsSource = "";
            CurentPos += 3;
            createOrder.fillServices(CurentPos.ToString());
            if (DGServices.Items.Count == 0)// avoid empty database, it will return to the previous data and disable next button
            {
                CurentPos -= 3;
                createOrder.fillServices(CurentPos.ToString());
                btnNext.IsEnabled = false;
                MessageBox.Show("You have reach end of service list", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                btnPrev.IsEnabled = true;
            }

        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            
            if(CurentPos == 0)// avoid user if has reach start data, it will disable prev button
            {
                MessageBox.Show("You have reach start of service list", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                btnPrev.IsEnabled = false;
            }
            else
            {
                DGServices.ItemsSource = "";
                CurentPos -= 3;
                createOrder.fillServices(CurentPos.ToString());
                btnNext.IsEnabled = true;
            }
        }
    }
}
