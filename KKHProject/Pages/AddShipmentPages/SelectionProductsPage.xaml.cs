using KKHProject.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages.AddShipmentPages
{
    /// <summary>
    /// Логика взаимодействия для SelectionProductsPage.xaml
    /// </summary>
    public partial class SelectionProductsPage : Page
    {
        private Frame frame;
        private List<ShipmentObject> objects;
        private Shipment shipment;
        private User user;
        private Provider provider;

        public SelectionProductsPage(Frame frame, List<ShipmentObject> objects, Shipment shipment, User user)
        {
            InitializeComponent();
            this.frame = frame;
            this.objects = objects;
            this.shipment = shipment;
            this.user = user;
            ClohtsLV.ItemsSource = MainWindow.KKHDB.Clohts.ToList();
            FutureLV.ItemsSource = MainWindow.KKHDB.Furnitures.ToList();

            if (objects.Count != 0)
                ObjectsLV.ItemsSource = objects;
        }

        private void AddCloht_Click(object sender, RoutedEventArgs e)
        {
            if (ClohtsLV.SelectedItem != null)
            {
                var sel = ClohtsLV.SelectedItem as Cloht;
                objects.Add(new ShipmentObject
                {
                    id_cloht = sel.Id,
                    Cloht = sel,
                    CountCloht = Convert.ToInt32(countCloht.Text)
                });
                ObjectsLV.ItemsSource = null;
                ObjectsLV.ItemsSource = objects;
                countCloht.Text = "1";
            }
        }

        private void AddFuture_Click(object sender, RoutedEventArgs e)
        {
            if (FutureLV.SelectedItem != null)
            {
                var sel = FutureLV.SelectedItem as Furniture;
                objects.Add(new ShipmentObject
                {
                    id_furniture = sel.Id,
                    Furniture = sel,
                    CountFurniture = Convert.ToInt32(countFuture.Text)
                });
                ObjectsLV.ItemsSource = null;
                ObjectsLV.ItemsSource = objects;
                countFuture.Text = "1";
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var sel = ObjectsLV.SelectedItem as ShipmentObject;
            objects.Remove(sel);
            ObjectsLV.ItemsSource = null;
            ObjectsLV.ItemsSource = objects;
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new SelectWarehousePage(frame, objects, shipment, user));
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
