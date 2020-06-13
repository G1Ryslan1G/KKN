using KKHProject.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddWarehousesPage.xaml
    /// </summary>
    public partial class AddWarehousesPage : Page
    {
        private readonly WarehousesPage page;
        private readonly Warehouse warehouse;

        public AddWarehousesPage(WarehousesPage page, Warehouse warehouse = null)
        {
            InitializeComponent();
            WatLV.ItemsSource = MainWindow.KKHDB.Users.Where(y => y.RoleId == 3).ToList();
            CityCB.ItemsSource = MainWindow.KKHDB.Cities.ToList();
            CityCB.DisplayMemberPath = "Name";

            if(warehouse != null)
            {
                WatLV.SelectedItem = warehouse.User;
                CityCB.SelectedItem = warehouse.City;
                PhoneTB.Text = warehouse.Phone;
                DescriptTB.Text = warehouse.Description;
                AddEditBTN.Content = "Редактировать";
                Title = "Редактировать";
            }
            else
            {
                Title = "Добавить";
                AddEditBTN.Content = "Создать";
            }

            this.page = page;
            this.warehouse = warehouse;
        }

        private void AddEditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (warehouse != null)
            {
                warehouse.id_chief = (WatLV.SelectedItem as User).Id;
                warehouse.Id_city = (CityCB.SelectedItem as City).Id;
                warehouse.Phone = PhoneTB.Text;
                warehouse.Description = DescriptTB.Text;
                MessageBox.Show("Успешно", "Редактирование");
            }
            else
            {
                MainWindow.KKHDB.Warehouses.Add(new Warehouse
                {
                    id_chief = (WatLV.SelectedItem as User).Id,
                    Id_city = (CityCB.SelectedItem as City).Id,
                    Phone = PhoneTB.Text,
                    Description = DescriptTB.Text,
                    VisibleStatus = true
                });
                MessageBox.Show("Успешно", "Добавление");
            }
            MainWindow.KKHDB.SaveChanges();
            page.Update();
            Navigation.BackPage();
        }
    }
}
