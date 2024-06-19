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

namespace Diplom.Components.MotherBoard
{
    /// <summary>
    /// Логика взаимодействия для MotherBoardWindow.xaml
    /// </summary>
    public partial class MotherBoardWindow : Window
    {
        public Frame MainFrame { get; set; }
        public MotherBoardWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvMotherBoard.ItemsSource = ClassHelper.EF.Context.MotherBoard.ToList();
        }


        private void BtnEditMotherBoard_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var motherboard = button.DataContext as DataBase.MotherBoard;
            AddMotherBoardWindow editMotherBoardWindow = new AddMotherBoardWindow(motherboard);
            editMotherBoardWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelMotherBoard_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.MotherBoard;
            var result = MessageBox.Show($"Вы уверены что хотите удалить материнскую плату \"{service.Title}\"?", "Удаление материнской платы", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.MotherBoard.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddMotherBoard_Click(object sender, RoutedEventArgs e)
        {
            AddMotherBoardWindow addMotherBoardWindow = new AddMotherBoardWindow();
            addMotherBoardWindow.ShowDialog();
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
