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

        int maksProduk = 0; //maksimal service id yg berbeda adalah 10 items

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
                createOrder.fillServices(CurentPos.ToString());
                createOrder.getOrderID();
                if (CheckBoxDelivery.IsChecked.Value)
                {
                    lblShipingFee.Content = "Delivery Fee: Rp.15.000";
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
            lblOrderID.Content = "";
            createOrder.emptyCart();
            maksProduk = 0;
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            createOrder.PlaceOrder();
        }        

        private void addTOcart_Click(object sender, RoutedEventArgs e)
        {
            
            object item = DGServices.SelectedItem;          
            string id = (DGServices.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            string price = (DGServices.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            createOrder.UpdateCart(id, price);
            maksProduk++;

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

        private void CBAddNote_Checked(object sender, RoutedEventArgs e)
        {
            txtNote.IsEnabled = true;
            txtNote.Focus();
        }
    }
}
