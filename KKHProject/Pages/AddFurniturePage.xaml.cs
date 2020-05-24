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
    /// Логика взаимодействия для AddFurniturePage.xaml
    /// </summary>
    public partial class AddFurniturePage : Page
    {
        private Furniture furniture;

        public AddFurniturePage()
        {
            InitializeComponent();
        }

        public AddFurniturePage(Furniture furniture)
        {
            this.furniture = furniture;
        }
    }
}
