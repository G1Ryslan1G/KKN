using KKHProject.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages.AddShipmentPages
{
    /// <summary>
    /// Логика взаимодействия для SelectionSupplierPage.xaml
    /// </summary>
    public partial class SelectionSupplierPage : Page
    {
        private readonly List<ShipmentObject> objects;
        private readonly User user;
        private readonly Provider provider;

        public SelectionSupplierPage(Frame frame, List<ShipmentObject> objects, User user, Provider provider = null, Shipment shipment = null)
        {
            InitializeComponent();
            ProvidersLV.ItemsSource = MainWindow.KKHDB.Providers.ToList();
            if(shipment != null)
            {
                ProvidersLV.SelectedItem = shipment.Provider;
            }
            Frame = frame;
            this.objects = objects;
            this.user = user;
            this.provider = provider;
            Shipment = shipment;
        }

        public Frame Frame { get; }
        public Shipment Shipment { get; set; }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Shipment == null)
            {
                Shipment = new Shipment();
            }
            Shipment.id_provider = (ProvidersLV.SelectedItem as Provider).Id;
                    
            Frame.Navigate(new SelectionProductsPage(Frame, objects, Shipment, user, provider));
        }
    }
}
