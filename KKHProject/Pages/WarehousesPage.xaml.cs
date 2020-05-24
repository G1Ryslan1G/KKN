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
    /// Логика взаимодействия для WarehousesPage.xaml
    /// </summary>
    public partial class WarehousesPage : Page
    {
        public WarehousesPage(User user)
        {
            InitializeComponent();
                WaterhosesLV.ItemsSource = MainWindow.KKHDB.Warehouses.ToList();
            if (user.Id == 2)
            {
            }
            else
            {
                AddBTN.Visibility = Visibility.Collapsed;
                DelBTN.Visibility = Visibility.Collapsed;
            }
        }

        private void OpenBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
