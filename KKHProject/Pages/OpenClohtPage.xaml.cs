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
    /// Логика взаимодействия для OpenClohtPage.xaml
    /// </summary>
    public partial class OpenClohtPage : Page
    {
        private Cloht cloht;
        private Warehouse warehouse;

        public OpenClohtPage(Cloht cloht, Warehouse warehouse)
        {
            this.cloht = cloht;
            this.warehouse = warehouse;
            InitializeComponent();

            if(warehouse == null)
                ClohtsLV.ItemsSource = MainWindow.KKHDB.ObjectsContainers.Where(o => o.id_cloth == cloht.Id).ToList();
            else
                ClohtsLV.ItemsSource = MainWindow.KKHDB.ObjectsContainers
                    .Where(o => o.id_cloth == cloht.Id)
                    .Where(o=>o.Container.id_warehouse == warehouse.Id)
                    .ToList();

        }
    }
}
