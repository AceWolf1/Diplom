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

namespace Diplom.Components.CoolingProcessor
{
    /// <summary>
    /// Логика взаимодействия для CoolingWindow.xaml
    /// </summary>
    public partial class CoolingWindow : Window
    {
        public Frame MainFrame { get; set; }
        public CoolingWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvCooling.ItemsSource = ClassHelper.EF.Context.CoolingProcessor.ToList();
        }

        private void BtnEditCooling_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var coolingProcessor = button.DataContext as DataBase.CoolingProcessor;
            AddCoolingProcessorWindow editCoolingProcessorWindow = new AddCoolingProcessorWindow(coolingProcessor);
            editCoolingProcessorWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelCooling_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.CoolingProcessor;
            var result = MessageBox.Show($"Вы уверены что хотите удалить охлаждение процессора \"{service.Title}\"?", "Удаление охлаждения процессора", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.CoolingProcessor.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddCooling_Click(object sender, RoutedEventArgs e)
        {
            AddCoolingProcessorWindow addCoolingProcessorWindow = new AddCoolingProcessorWindow();
            addCoolingProcessorWindow.ShowDialog();
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
