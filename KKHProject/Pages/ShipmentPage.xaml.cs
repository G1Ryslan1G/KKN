using KKHProject.DataBase;
using System.Linq;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShipmentPage.xaml
    /// </summary>
    public partial class ShipmentPage : Page
    {
        public ShipmentPage(Shipment shipment)
        {
            InitializeComponent();
            ShipmentLV.ItemsSource = MainWindow.KKHDB.ShipmentObjects.Where(so => so.id_shipment == shipment.Id).ToList();
        }
    }
}
