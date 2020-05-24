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

            }
        }

        private void ClohtSearchBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                Navigation.NextPage(new AddClohtPage(ClohtLV.SelectedItem as Cloht));
            }
        }

        private void FurnituresSearchBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

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
                Navigation.NextPage(new AddFurniturePage(FurnituresLV.SelectedItem as Furniture));
            }
        }
    }
}
