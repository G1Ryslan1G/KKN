using KKHProject.DataBase;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KKHProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClohtPage.xaml
    /// </summary>
    public partial class AddClohtPage : Page
    {
        private Cloht cloht;
        private string nnnn = "Площадь ткани: ";

        public AddClohtPage()
        {
            InitializeComponent();
        }

        public AddClohtPage(Cloht cloht)
        {
            this.cloht = cloht;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => Update();

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e) => Update();

        private void Update()
        {
            if (TxHedigt.Text.Length != 0)
                if (TxWidth.Text.Length != 0)
                    VolumeCloht.Content = nnnn + Convert.ToDouble(TxWidth.Text) * Convert.ToDouble(TxHedigt.Text);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var cloht = new Cloht
            {
                Length = Convert.ToDouble(TxHedigt.Text),
                Name = Tx_Name.Text,
                Volume = Convert.ToDouble(TxWidth.Text) * Convert.ToDouble(TxHedigt.Text),
                Width = Convert.ToDouble(TxWidth.Text) 
            };
            MainWindow.KKHDB.Clohts.Add(cloht);
            MessageBox.Show("Добавлено!");
            Navigation.BackPage();
        }
    }
}
