using KKHProject.DataBase;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectorMain.xaml
    /// </summary>
    public partial class DirectorMain : Page
    {
        private readonly User user;

        public DirectorMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void WaterBt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new WarehousesPage(user));
        }

        private void UsersBt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AdminMain());
        }

        private void PostvBt_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new ShipmentsPage(user));
        }
    }
}
