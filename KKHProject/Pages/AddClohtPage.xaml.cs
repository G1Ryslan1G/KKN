using KKHProject.DataBase;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClohtPage.xaml
    /// </summary>
    public partial class AddClohtPage : Page
    {
        private Cloht cloht;

        public AddClohtPage()
        {
            InitializeComponent();
        }

        public AddClohtPage(Cloht cloht)
        {
            this.cloht = cloht;
        }
    }
}
