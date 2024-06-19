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

namespace Diplom.Components.HardWare
{
    /// <summary>
    /// Логика взаимодействия для HardWareWindow.xaml
    /// </summary>
    public partial class HardWareWindow : Window
    {
        public Frame MainFrame { get; set; }
        public HardWareWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvHardWare.ItemsSource = ClassHelper.EF.Context.DataStorage.ToList();
        }

        private void BtnEditHardWare_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var datastorage = button.DataContext as DataBase.DataStorage;
            AddHardWareWindow editDataStorageWindow = new AddHardWareWindow(datastorage);
            editDataStorageWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelHardWare_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.DataStorage;
            var result = MessageBox.Show($"Вы уверены что хотите удалить жесткий диск \"{service.Title}\"?", "Удаление жесткого диска", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.DataStorage.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddHardWare_Click(object sender, RoutedEventArgs e)
        {
            AddHardWareWindow addDataStorageWindow = new AddHardWareWindow();
            addDataStorageWindow.ShowDialog();
            GetListService();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void AdminCheck_loaded(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            if (ClassHelper.EF.User != null && ClassHelper.EF.User.PositionID != 1)

            {
                button.Visibility = Visibility.Collapsed;
            }
        }
    }

}
