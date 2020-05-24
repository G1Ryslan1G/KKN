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
    /// Логика взаимодействия для RawsPage.xaml
    /// </summary>
    public partial class RawsPage : Page
    {
        public RawsPage(Warehouse warehouse = null)
        {
            InitializeComponent();
            if(warehouse == null) 
            {
                
            }
        }

        private void ClohtSearchBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ClohtAddBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClohtEditBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClohtDelBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FurnituresSearchBOX_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FurnituresAddBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FurnituresEditBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FurnituresDelBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
