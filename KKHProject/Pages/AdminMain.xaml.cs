using KKHProject.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Page
    {
        public AdminMain()
        {
            InitializeComponent();
            UsersLV.ItemsSource = MainWindow.KKHDB.Users.ToList();
            var lv = MainWindow.KKHDB.Cities.ToList();
            lv.Insert(0, new City { Id = 0, Name = "Все" });
            CityCB.ItemsSource = lv;
            CityCB.DisplayMemberPath = "Name";
        }

        private void SearchBOX_TextChanged(object sender, TextChangedEventArgs e) => Update();


        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e) => Update();

        private void Update()
        {
            var sel = CityCB.SelectedItem as City;
            UsersLV.ItemsSource = MainWindow.KKHDB.Users.Where(u => u.Name.Contains(SearchBOX.Text.Trim()) || SearchBOX.Text.Trim() == "")
                .Where(u => u.CityId == sel.Id || sel.Id == 0).ToList();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {

            Navigation.NextPage(new AddUserPage());
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (UsersLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddUserPage(UsersLV.SelectedItem as User));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (UsersLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя", "Ошибка");
            }
            else
            {
                var user = UsersLV.SelectedItem as User;
                MessageBoxResult MBRes = MessageBox.Show("Вы уверены, что хотите удалить запись о комплексе?", "Удаление", MessageBoxButton.YesNo);
                switch (MBRes)
                {
                    case MessageBoxResult.Yes:
                        user.IsVisibal = false;
                        MainWindow.KKHDB.SaveChanges();
                        MessageBox.Show("Удалено!");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}
