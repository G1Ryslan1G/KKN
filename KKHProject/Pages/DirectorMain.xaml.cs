using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectorMain.xaml
    /// </summary>
    public partial class DirectorMain : Page
    {
        public DirectorMain()
        {
            InitializeComponent();
        }

        private void WaterBt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new WarehousesPage());
        }

        private void UsersBt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AdminMain());
        }

        private void PostvBt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new ShipmentsPage());
        }
    }
}
