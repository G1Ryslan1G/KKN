using KKHProject.DataBase;
using System.Windows.Controls;
using KKHProject.Pages.AddShipmentPages;
using System.Collections.Generic;
using System.Linq;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddShipmentPage.xaml
    /// </summary>
    public partial class AddShipmentPage : Page
    {
        public AddShipmentPage(User user, Provider provider = null, Shipment shipment = null)
        {
            InitializeComponent();
            List<ShipmentObject> list = new List<ShipmentObject>();
            if (shipment != null)
                list = MainWindow.KKHDB.ShipmentObjects.Where(o => o.id_shipment == shipment.Id).ToList();
            AddShipmentFrame.Navigate(new SelectionSupplierPage(AddShipmentFrame, list, user, provider, shipment));
        }
    }
}
