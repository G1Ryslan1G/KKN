using KKHProject.Pages;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BltLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TxtLogin.Text.Trim();
            string password = TxtPassword.Text.Trim();

            var user = MainWindow.KKHDB.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (user != null)
            {
                if (user.RoleId == 1)
                {
                    Navigation.NextPage(new AdminMain());
                    return;
                }
                if (user.RoleId == 2)
                {
                    Navigation.NextPage(new DirectorMain(user));
                    return;
                }
                if (user.RoleId == 3)
                {
                    Navigation.NextPage(new StorekeeperMain(user));
                    return;
                }
                if (user.RoleId == 4)
                {
                    var provider = MainWindow.KKHDB.Providers.First(u => u.id_user == user.Id);
                    Navigation.NextPage(new ProviderMain(provider));
                    return;
                }
                    MessageBox.Show("Произошла ошибка в авторизации!", "Ошибка!", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль!", "Внимание!", MessageBoxButton.OK);
            }
        }
    }
}
