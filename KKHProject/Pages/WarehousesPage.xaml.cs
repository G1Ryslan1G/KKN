using KKHProject.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для WarehousesPage.xaml
    /// </summary>
    public partial class WarehousesPage : Page
    {
        public WarehousesPage(User user)
        {
            InitializeComponent();
            WaterhosesLV.ItemsSource = MainWindow.KKHDB.Warehouses.ToList();
            if (user.RoleId != 2)
            {
                AddBTN.Visibility = Visibility.Collapsed;
                EditBTN.Visibility = Visibility.Collapsed;
                DelBTN.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
