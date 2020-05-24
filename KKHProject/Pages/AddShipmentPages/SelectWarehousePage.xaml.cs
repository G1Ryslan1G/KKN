﻿using KKHProject.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages.AddShipmentPages
{
    /// <summary>
    /// Логика взаимодействия для SelectWarehousePage.xaml
    /// </summary>
    public partial class SelectWarehousePage : Page
    {
        private Frame frame;
        private List<ShipmentObject> objects;
        private Shipment shipment;
        private User user;
        private Provider provider;

        public SelectWarehousePage(Frame frame, List<ShipmentObject> objects, Shipment shipment, User user, Provider provider = null)
        {
            InitializeComponent();

            this.frame = frame;
            this.objects = objects;
            this.shipment = shipment;
            this.user = user;
            this.provider = provider;
            WarehouseLV.ItemsSource = MainWindow.KKHDB.Warehouses.ToList();
            if (shipment.Warehouse != null)
                WarehouseLV.SelectedItem = shipment.Warehouse;
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            shipment.id_warehouse = (WarehouseLV.SelectedItem as Warehouse).Id;
            frame.Navigate(new FinalPage(frame,objects,shipment,user,provider));
        }
    }
}
