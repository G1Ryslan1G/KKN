using KKHProject.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private User user;

        public AddUserPage(User user = null)
        {
            InitializeComponent();

            CityCb.ItemsSource = MainWindow.KKHDB.Cities.ToList();
            RoleCb.ItemsSource = MainWindow.KKHDB.Roles.ToList();
            CityCb.DisplayMemberPath = "Name";
            RoleCb.DisplayMemberPath = "Name";

            if (user != null)
            {
                NameTxt.Text = user.Name;
                LoginTxt.Text = user.Login;
                PasswordTxt.Text = user.Password;
                CityCb.SelectedItem = user.City;
                RoleCb.SelectedItem = user.Role;
                IsVisiblBtn.IsChecked = user.IsVisibal;
                AddEditBTN.Content = "Редактировать";
                this.user = user;
            }
            else
            {
                IsVisiblBtn.IsChecked = true;
                AddEditBTN.Content = "Добавить";
            }
        }

        private void AddEditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                user.Name = NameTxt.Text;
                user.Login = LoginTxt.Text;
                user.Password = PasswordTxt.Text;
                user.IsVisibal = IsVisiblBtn.IsChecked!=true ? false : true;
                var SelCity = CityCb.SelectedItem as City;
                user.CityId = SelCity.Id;
                var SelRole = RoleCb.SelectedItem as Role;
                user.RoleId = SelRole.Id;
            }
            else
            {
                var SelCity = CityCb.SelectedItem as City;
                var SelRole = RoleCb.SelectedItem as Role;
                MainWindow.KKHDB.Users.Add(new User
                {
                    Name = NameTxt.Text,
                    Login = LoginTxt.Text,
                    Password = PasswordTxt.Text,
                    IsVisibal = IsVisiblBtn.IsChecked != true ? false : true,
                    CityId = SelCity.Id,
                    RoleId = SelRole.Id
                });
            }
            MainWindow.KKHDB.SaveChanges();
            MessageBox.Show("Успешно", "Добавление");
            Navigation.BackPage();
        }
    }
}
