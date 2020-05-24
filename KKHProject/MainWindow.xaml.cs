using KKHProject.DataBase;
using System.Windows;

namespace KKHProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static KKHDB KKHDB = new KKHDB();

        public MainWindow()
        {
            InitializeComponent();
            Navigation.main = this;
            Navigation.NextPage(new AuthorizationPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }
    }
}
