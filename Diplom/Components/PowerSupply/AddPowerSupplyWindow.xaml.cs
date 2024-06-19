using Diplom.DataBase;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddPowerSupplyWindow.xaml
    /// </summary>
    public partial class AddPowerSupplyWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.PowerSupply editPowerSupply = null;
        public AddPowerSupplyWindow()
        {
            InitializeComponent();
            CbPowerID.ItemsSource = ClassHelper.EF.Context.Power.ToList();
            CbPowerID.DisplayMemberPath = "PowerQuantity";
            CbPowerID.SelectedIndex = 0;
            CbConnectorCPUID.ItemsSource = ClassHelper.EF.Context.ConectorCPU.ToList();
            CbConnectorCPUID.DisplayMemberPath = "Title";
            CbConnectorCPUID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;

        }
        public AddPowerSupplyWindow(DataBase.PowerSupply powerSupply)
        {
            InitializeComponent();
            isEdit = true;
            editPowerSupply = powerSupply;
            CbPowerID.ItemsSource = ClassHelper.EF.Context.Power.ToList();
            CbPowerID.DisplayMemberPath = "PowerQuantity";
            CbConnectorCPUID.ItemsSource = ClassHelper.EF.Context.ConectorCPU.ToList();
            CbConnectorCPUID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";

            if (ImgImagePowerSupply.Source != null)
            {
                ImgImagePowerSupply.Source = new BitmapImage(new Uri(editPowerSupply.PhotoLink));
            }
            
            TbTitle.Text = editPowerSupply.Title;
            TbCost.Text = Convert.ToString(editPowerSupply.Cost);
            CbPowerID.SelectedItem = ClassHelper.EF.Context.Power.Where (i => i.ID == editPowerSupply.PowerID).FirstOrDefault();
            CbConnectorCPUID.SelectedItem = ClassHelper.EF.Context.ConectorCPU.Where (i => i.ID == editPowerSupply.ConectorCPUID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where (i => i.ID == editPowerSupply.ManufacturerID).FirstOrDefault();
        }

        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImagePowerSupply.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void AddPowerSupply_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.PowerSupply addPowerSupply = new DataBase.PowerSupply();
                addPowerSupply.Title = TbTitle.Text;
                addPowerSupply.PowerID = (CbPowerID.SelectedItem as Power).ID;
                addPowerSupply.ConectorCPUID = (CbConnectorCPUID.SelectedItem as ConectorCPU).ID;
                addPowerSupply.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                addPowerSupply.Cost = Convert.ToDecimal(TbCost.Text);
                if (PathImage != null)
                {
                    addPowerSupply.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.PowerSupply.Add(addPowerSupply);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Power Supply added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

            else
            {
                editPowerSupply.Title = TbTitle.Text;
                editPowerSupply.PowerID = (CbPowerID.SelectedItem as Power).ID;
                editPowerSupply.ConectorCPUID = (CbConnectorCPUID.SelectedItem as ConectorCPU).ID;
                editPowerSupply.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                editPowerSupply.Cost = Convert.ToDecimal(TbCost.Text);

                if (PathImage != null)
                {
                    editPowerSupply.PhotoLink = PathImage;
                }

                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Videocard updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            
        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnClosePowerSupplydWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void BtnMinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
