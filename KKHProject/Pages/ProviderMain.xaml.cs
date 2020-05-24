using KKHProject.DataBase;
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
            Navigation.NextPage(new ShipmentsPage(provider));
        }
    }
}
