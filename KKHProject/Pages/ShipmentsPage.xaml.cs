using KKHProject.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShipmentsPage.xaml
    /// </summary>
    public partial class ShipmentsPage : Page
    {
        private User user;
        private Provider provider;

        public ShipmentsPage(User user)
        {
            InitializeComponent();
            var lv = MainWindow.KKHDB.Status.ToList();
            lv.Insert(0, new Status { Id = 0, Name = "Все" });
            StatusCB.ItemsSource = lv;
            StatusCB.DisplayMemberPath = "Name";
            StatusCB.SelectedIndex = 0;

            if(user.RoleId == 4)
                provider = MainWindow.KKHDB.Providers.First(p => p.id_user == user.Id);

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

            this.user = user;
        }

        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e) => Update();

        private void SearchBOX_TextChanged(object sender, TextChangedEventArgs e) => Update();

        private void Update()
        {
            var sel = StatusCB.SelectedItem as Status;
            var lv = MainWindow.KKHDB.Shipments.Where(s => s.Provider.User.Name.Contains(SearchBOX.Text.Trim()) || SearchBOX.Text.Trim() == "")
                .Where(s => s.id_status == sel.Id || sel.Id == 0)
                .ToList();
            ShipmentsLV.ItemsSource = provider != null ? lv.Where(s => s.id_provider == provider.Id || s.id_provider == null) : lv;
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddShipmentPage(user));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ShipmentsLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставку", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddShipmentPage(user, ShipmentsLV.SelectedItem as Shipment));
            }
        }

        private async void ExecutedBTN_Click(object sender, RoutedEventArgs e)
        {
            var sel = ShipmentsLV.SelectedItem as Shipment;
            var shipments = MainWindow.KKHDB.Shipments.FirstOrDefault(s => s.Id == sel.Id);
            shipments.id_status = 2;
            MainWindow.KKHDB.SaveChanges();

            Update();
        }
    }
}
