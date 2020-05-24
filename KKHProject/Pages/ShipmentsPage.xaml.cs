using KKHProject.DataBase;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShipmentsPage.xaml
    /// </summary>
    public partial class ShipmentsPage : Page
    {
        private readonly Provider provider;

        public ShipmentsPage(Provider provider = null)
        {
            InitializeComponent();
            StatusCB.ItemsSource = MainWindow.KKHDB.Status.ToList();
            StatusCB.DisplayMemberPath = "Name";
            if (provider == null)
            {
                ShipmentsLV.ItemsSource = MainWindow.KKHDB.Shipments.ToList();
                ExecutedBTN.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShipmentsLV.ItemsSource = MainWindow.KKHDB.Shipments.Where(s => s.id_provider == provider.Id).ToList();
                AddBTN.Visibility = Visibility.Collapsed;
                EditBTN.Visibility = Visibility.Collapsed;
            }
            this.provider = provider;
        }

        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e) => Update();

        private void SearchBOX_TextChanged(object sender, TextChangedEventArgs e) => Update();

        private void Update()
        {
            var sel = StatusCB.SelectedItem as Status;
            var lv = MainWindow.KKHDB.Shipments.Where(s => s.Provider.User.Name.Contains(SearchBOX.Text.Trim()) || SearchBOX.Text.Trim() == "")
                .Where(s => s.id_status == sel.Id || sel.Id == 0)
                .ToList();
            ShipmentsLV.ItemsSource = provider != null ? lv.Where(s => s.id_provider == provider.Id) : lv;
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddShipmentPage());
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ShipmentsLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставку", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddShipmentPage(ShipmentsLV.SelectedItem as Shipment));
            }
        }

        private void ExecutedBTN_Click(object sender, RoutedEventArgs e)
        {
            var sel = ShipmentsLV.SelectedItem as Shipment;
            var shipments = MainWindow.KKHDB.Shipments.FirstOrDefault(s => s.Id == sel.Id);
            shipments.id_status = 2;
            MainWindow.KKHDB.SaveChanges();

            Task.Delay(10); 

            Update();
        }
    }
}
