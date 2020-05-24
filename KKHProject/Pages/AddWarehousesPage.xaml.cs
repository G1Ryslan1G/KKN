using KKHProject.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddWarehousesPage.xaml
    /// </summary>
    public partial class AddWarehousesPage : Page
    {
        private readonly Warehouse warehouse;

        public AddWarehousesPage(Warehouse warehouse = null)
        {
            InitializeComponent();
            WatLV.ItemsSource = MainWindow.KKHDB.Users.Where(y => y.RoleId == 3).ToList();
            CityCB.ItemsSource = MainWindow.KKHDB.Cities.ToList();
            CityCB.DisplayMemberPath = "Name";

            if(warehouse != null)
            {
                WatLV.SelectedItem = warehouse.User;
                CityCB.SelectedItem = warehouse.City;
                AddEditBTN.Content = "Редактировать";
            }
            else
            {
                AddEditBTN.Content = "Создать";
            }

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
                MainWindow.KKHDB.SaveChanges();
                MessageBox.Show("Готово!");
            }
            else
            {
                MainWindow.KKHDB.Warehouses.Add(new Warehouse
                {
                    id_chief = (WatLV.SelectedItem as User).Id,
                    Id_city = (CityCB.SelectedItem as City).Id,
                    Phone = PhoneTB.Text,
                    Description = DescriptTB.Text,

                });
            }
        }
    }
}
