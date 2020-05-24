using KKHProject.DataBase;
using System.Linq;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProviderMain.xaml
    /// </summary>
    public partial class ProviderMain : Page
    {
        private Provider provider;

        public ProviderMain(Provider provider)
        {
            InitializeComponent();
            this.provider = provider;
        }

        private void ShipmentsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var user = MainWindow.KKHDB.Users.FirstOrDefault(u=>u.Id == provider.id_user);
            Navigation.NextPage(new ShipmentsPage(user, provider));
        }
    }
}
