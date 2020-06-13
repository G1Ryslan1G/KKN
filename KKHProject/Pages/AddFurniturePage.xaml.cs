using KKHProject.DataBase;
using System.Windows.Controls;

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
