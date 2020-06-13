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
        private User user;

        public ProviderMain(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ShipmentsBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Navigation.NextPage(new ShipmentsPage(user));
        }
    }
}
