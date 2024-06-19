using Diplom.ClassHelper;
using Diplom.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


namespace Diplom.Components.Videocard
{
    /// <summary>
    /// Логика взаимодействия для VideocardWindow.xaml
    /// </summary>
    public partial class VideocardWindow : Window
    {
        public Frame MainFrame { get; set; }
        public VideocardWindow()
        {
            InitializeComponent();
            GetListService();


        }
        private void GetListService()
        {
            LvVideocard.ItemsSource = ClassHelper.EF.Context.Videocard.ToList();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Videocard;
            var result = MessageBox.Show($"Вы уверены что хотите удалить видеокарту \"{service.Title}\"?", "Удаление видеокарты", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.Videocard.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var videocard = button.DataContext as DataBase.Videocard;
            AddVideoCardWindow editVideocardWindow = new AddVideoCardWindow(videocard);
            editVideocardWindow.ShowDialog();
            GetListService();
        }

        private void BtnAddVideocard_Click(object sender, RoutedEventArgs e)
        {
            AddVideoCardWindow addVideoCardWindow = new AddVideoCardWindow();
            addVideoCardWindow.ShowDialog();
            GetListService();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var pC = button.DataContext as DataBase.PC;

            PCClass.PCClassesList.Add(pC);


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
