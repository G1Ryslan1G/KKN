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
    /// Логика взаимодействия для OpenFurniturePage.xaml
    /// </summary>
    public partial class OpenFurniturePage : Page
    {
        private Furniture furniture;
        private Warehouse warehouse;

        public OpenFurniturePage(Furniture furniture, Warehouse warehouse)
        {
            this.furniture = furniture;
            this.warehouse = warehouse;
            InitializeComponent();

            if (warehouse == null)
                FurnituresLV.ItemsSource = MainWindow.KKHDB.ObjectsContainers.Where(o => o.id_furniture == furniture.Id).ToList();
            else
                FurnituresLV.ItemsSource = MainWindow.KKHDB.ObjectsContainers
                    .Where(o => o.id_cloth == furniture.Id)
                    .Where(o => o.Container.id_warehouse == warehouse.Id)
                    .ToList();
        }
    }
}
