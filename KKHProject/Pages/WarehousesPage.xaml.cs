using KKHProject.DataBase;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для WarehousesPage.xaml
    /// </summary>
    public partial class WarehousesPage : Page
    {
        public WarehousesPage(User user)
        {
            InitializeComponent();
            if (user.RoleId != 2)
            {
                AddBTN.Visibility = Visibility.Collapsed;
                EditBTN.Visibility = Visibility.Collapsed;
                DelBTN.Visibility = Visibility.Collapsed;
            }
            Update();
        }

        private void OpenBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WaterhosesLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new RawsPage(WaterhosesLV.SelectedItem as Warehouse));
            }
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddWarehousesPage(this));
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WaterhosesLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new AddWarehousesPage(this, WaterhosesLV.SelectedItem as Warehouse));
            }
        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (WaterhosesLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка");
            }
            else
            {
                var warehouse = WaterhosesLV.SelectedItem as Warehouse;
                MessageBoxResult MBRes = MessageBox.Show("Вы уверены, что хотите удалить запись о складе?", "Удаление", MessageBoxButton.YesNo);
                switch (MBRes)
                {
                    case MessageBoxResult.Yes:
                        warehouse.VisibleStatus = false;
                        MainWindow.KKHDB.SaveChanges();
                        WaterhosesLV.ItemsSource = MainWindow.KKHDB.Warehouses.ToList();
                        MessageBox.Show("Удалено!");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                return;
            }
        }

        internal void Update()
        {
            WaterhosesLV.ItemsSource = MainWindow.KKHDB.Warehouses.ToList();
        }
    }
}
