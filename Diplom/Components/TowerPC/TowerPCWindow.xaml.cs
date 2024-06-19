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

namespace Diplom.Components.TowerPC
{
    /// <summary>
    /// Логика взаимодействия для TowerPCWindow.xaml
    /// </summary>
    public partial class TowerPCWindow : Window
    {
        public Frame MainFrame { get; set; }
        public TowerPCWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvTowerPC.ItemsSource = ClassHelper.EF.Context.TowerPC.ToList();
        }

        private void BtnEditTowerPC_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            var towerpc = button.DataContext as DataBase.TowerPC;
            AddTowerPCWindow editTowerpcWindow = new AddTowerPCWindow(towerpc);
            editTowerpcWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelTowerPC_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.TowerPC;
            var result = MessageBox.Show($"Вы уверены что хотите удалить корпус \"{service.Title}\"?", "Удаление корпуса", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.TowerPC.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddTowerPC_Click(object sender, RoutedEventArgs e)
        {
            AddTowerPCWindow addTowerPCWindow = new AddTowerPCWindow();
            addTowerPCWindow.ShowDialog();
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
