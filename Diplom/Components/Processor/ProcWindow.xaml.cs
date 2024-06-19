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

namespace Diplom.Components.Processor
{
    /// <summary>
    /// Логика взаимодействия для ProcWindow.xaml
    /// </summary>
    public partial class ProcWindow : Window
    {
        public Frame MainFrame { get; set; }
        public ProcWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvProcessor.ItemsSource = ClassHelper.EF.Context.Processor.ToList();
        }

        private void BtnEditProc_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var processor = button.DataContext as DataBase.Processor;
            AddProcWindow editProcWindow = new AddProcWindow(processor);
            editProcWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelProc_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Processor;
            var result = MessageBox.Show($"Вы уверены что хотите удалить процессор \"{service.Title}\"?", "Удаление процессора", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.Processor.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddProcessor_Click(object sender, RoutedEventArgs e)
        {
            AddProcWindow addProcWindow = new AddProcWindow();
            addProcWindow.ShowDialog();
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
