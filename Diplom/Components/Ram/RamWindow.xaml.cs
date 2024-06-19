using Diplom.Components.TowerPC;
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

namespace Diplom.Components.Ram
{
    /// <summary>
    /// Логика взаимодействия для RamWindow.xaml
    /// </summary>
    public partial class RamWindow : Window
    {
        public Frame MainFrame { get; set; }
        public RamWindow()
        {
            InitializeComponent();
            GetListService();
        }

        private void GetListService()
        {
            LvRam.ItemsSource = ClassHelper.EF.Context.Ram.ToList();
        }

        private void BtnEditRam_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var ram = button.DataContext as DataBase.Ram;
            AddRamWindow editRamWindow = new AddRamWindow(ram);
            editRamWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelRam_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Ram;
            var result = MessageBox.Show($"Вы уверены что хотите удалить оперативную память \"{service.Title}\"?", "Удаление оперативной памяти", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.Ram.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddRam_Click(object sender, RoutedEventArgs e)
        {
            AddRamWindow addRamWindow = new AddRamWindow();
            addRamWindow.ShowDialog();
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
