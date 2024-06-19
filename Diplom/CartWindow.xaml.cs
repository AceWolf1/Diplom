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
using System.Windows.Shapes;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetPCClassList();
        }
        public void GetPCClassList()
        {
            LvConfig.ItemsSource = ClassHelper.PCClass.PCClassesList;
        }

        private void BtnDeleteCartService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
