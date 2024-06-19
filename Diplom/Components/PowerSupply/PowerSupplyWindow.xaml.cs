using Diplom.Components.Videocard;
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

namespace Diplom.Components.PowerSupply
{
    /// <summary>
    /// Логика взаимодействия для PowerSupplyWindow.xaml
    /// </summary>
    public partial class PowerSupplyWindow : Window
    {
        public Frame MainFrame { get; set; }
        public PowerSupplyWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvPowerSupply.ItemsSource = ClassHelper.EF.Context.PowerSupply.ToList();
        }

        private void BtnEditPowerSupply_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var powersupply = button.DataContext as DataBase.PowerSupply;
            AddPowerSupplyWindow editPowerSupplyWindow = new AddPowerSupplyWindow(powersupply);
            editPowerSupplyWindow.ShowDialog();
            GetListService();
        }

        private void BtnDelPowerSupply_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.PowerSupply;
            var result = MessageBox.Show($"Вы уверены что хотите удалить блок питания \"{service.Title}\"?", "Удаление блока питания", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ClassHelper.EF.Context.PowerSupply.Remove(service);
                ClassHelper.EF.Context.SaveChanges();
            }
            else
            {
                return;
            }

            GetListService();
        }

        private void BtnAddPowerSupply_Click(object sender, RoutedEventArgs e)
        {
            AddPowerSupplyWindow addPowerSupplyWindow = new AddPowerSupplyWindow();
            addPowerSupplyWindow.ShowDialog();
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
