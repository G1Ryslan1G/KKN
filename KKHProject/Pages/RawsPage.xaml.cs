using KKHProject.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для RawsPage.xaml
    /// </summary>
    public partial class RawsPage : Page
    {
        private readonly Warehouse warehouse;

        public RawsPage(Warehouse warehouse = null)
        {
            InitializeComponent();
            if(warehouse == null) 
            {
                ClohtLV.ItemsSource = MainWindow.KKHDB.Clohts.ToList();
                FurnituresLV.ItemsSource = MainWindow.KKHDB.Furnitures.ToList();
            }
            else
            {
                ClohtLV.ItemsSource = MainWindow.KKHDB.Clohts.Where(c => c.ObjectsContainers.Any(o => o.Container.id_warehouse == warehouse.Id)).ToArray();
                FurnituresLV.ItemsSource = MainWindow.KKHDB.Furnitures.Where(f => f.ObjectsContainers.Any(o => o.Container.id_warehouse == warehouse.Id)).ToArray();
            }

            this.warehouse = warehouse;
        }

        private void ClohtSearchBOX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (warehouse == null)
            {
                ClohtLV.ItemsSource = MainWindow.KKHDB.Clohts.Where(c=>c.Name.Contains(ClohtSearchBOX.Text)).ToList();
            }
            else
            {
                ClohtLV.ItemsSource = MainWindow.KKHDB.Clohts
                    .Where(c => c.ObjectsContainers.Any(o => o.Container.id_warehouse == warehouse.Id))
                    .Where(c => c.Name.Contains(ClohtSearchBOX.Text))
                    .ToArray();
            }
        }

        private void ClohtAddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddClohtPage());
        }

        private void ClohtEditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ClohtLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите ткань", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new OpenClohtPage(ClohtLV.SelectedItem as Cloht, warehouse));
            }
        }

        private void FurnituresSearchBOX_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (warehouse == null)
            {
                FurnituresLV.ItemsSource = MainWindow.KKHDB.Furnitures
                    .Where(c => c.Name.Contains(FurnituresSearchBOX.Text))
                    .ToList();
            }
            else
            {
                FurnituresLV.ItemsSource = MainWindow.KKHDB.Furnitures.Where(f => f.ObjectsContainers.Any(o => o.Container.id_warehouse == warehouse.Id)).ToArray();
            }
        }

        private void FurnituresAddBTN_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new AddFurniturePage());
        }

        private void FurnituresEditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (FurnituresLV.SelectedItem == null)
            {
                MessageBox.Show("Выберите фурнитуру", "Ошибка");
            }
            else
            {
                Navigation.NextPage(new OpenFurniturePage(FurnituresLV.SelectedItem as Furniture, warehouse));
            }
        }
    }
}
