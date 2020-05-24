using KKHProject.DataBase;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для StorekeeperMain.xaml
    /// </summary>
    public partial class StorekeeperMain : Page
    {
        private readonly User user;

        public StorekeeperMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void RawBt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigation.NextPage(new RawsPage());
        }

        private void WaterBt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigation.NextPage(new WarehousesPage(user));
        }
    }
}
