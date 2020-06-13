using KKHProject.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages.AddShipmentPages
{
    /// <summary>
    /// Логика взаимодействия для FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Page
    {
        private Frame frame;
        private List<ShipmentObject> objects;
        private Shipment shipment;
        private readonly User user;

        public FinalPage(Frame frame, List<ShipmentObject> objects, Shipment shipment, User user)
        {
            InitializeComponent();
            this.frame = frame;
            this.objects = objects;
            this.shipment = shipment;
            this.user = user;
            DestriptionTxt.Text = shipment.Descriptions;
            CountSum.Text = shipment.CostSupply.ToString();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            shipment.Descriptions = DestriptionTxt.Text;
            shipment.Date = DateTime.Now;
            shipment.CostSupply = Convert.ToDouble(CountSum.Text);
            shipment.id_status = 1;
            if (shipment.Id == 0)
            {
                MainWindow.KKHDB.Shipments.Add(shipment);
                MainWindow.KKHDB.SaveChanges();

                foreach(var shipmentObject in objects)
                {
                    shipmentObject.id_shipment = shipment.Id;
                    MainWindow.KKHDB.ShipmentObjects.Add(shipmentObject);
                }
                MainWindow.KKHDB.SaveChanges();
            }
            else
            {
                MainWindow.KKHDB.SaveChanges();
                foreach (var shipmentObject in MainWindow.KKHDB.ShipmentObjects.Where(obj=>obj.id_shipment == shipment.Id))
                {
                    MainWindow.KKHDB.ShipmentObjects.Remove(shipmentObject);
                }
                MainWindow.KKHDB.SaveChanges();

                foreach (var shipmentObject in objects)
                {
                    shipmentObject.id_shipment = shipment.Id;
                    MainWindow.KKHDB.ShipmentObjects.Add(shipmentObject);
                }
                MainWindow.KKHDB.SaveChanges();
            }
            MessageBox.Show("Готово!");
            if (user.RoleId == 2)
                Navigation.NextPage(new DirectorMain(user));
            else
                Navigation.NextPage(new ProviderMain(user));
        }

        private void CancleBtn_Click(object sender, RoutedEventArgs e)
        {
            frame.GoBack();
        }
    }
}
