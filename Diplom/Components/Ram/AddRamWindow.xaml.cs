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

namespace Diplom.Components.Ram
{
    /// <summary>
    /// Логика взаимодействия для AddRamWindow.xaml
    /// </summary>
    public partial class AddRamWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.Ram editRam = null;
        public AddRamWindow()
        {
            InitializeComponent();
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbTypeOfMemoryID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;
            CbClockSpeedID.ItemsSource = ClassHelper.EF.Context.ClockSpeed.ToList();
            CbClockSpeedID.DisplayMemberPath = "Title";
            CbClockSpeedID.SelectedIndex = 0;
        }
        public AddRamWindow(DataBase.Ram ram)
        {
            InitializeComponent();
            isEdit = true;
            editRam = ram;
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbClockSpeedID.ItemsSource = ClassHelper.EF.Context.ClockSpeed.ToList();
            CbClockSpeedID.DisplayMemberPath = "Title";

            ImgImageRam.Source = new BitmapImage(new Uri(editRam.PhotoLink));
            TbTitle.Text = editRam.Title;
            CbTypeOfMemoryID.SelectedItem = ClassHelper.EF.Context.TypeOfMemory.Where (i => i.ID == editRam.TypeOfMemoryID).FirstOrDefault();
            TbQuantityRam.Text = Convert.ToString (editRam.QuantityRam);
            CbClockSpeedID.SelectedItem = ClassHelper.EF.Context.ClockSpeed.Where (i => i.ID == editRam.ClockSpeedID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where (i => i.ID == editRam.ManufacturerID).FirstOrDefault();
            TbCost.Text = Convert.ToString (editRam.Cost);
            TbEnergyConsumption.Text = Convert.ToString(editRam.EnergyConsumption);

        }

        private void AddRam_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.Ram addRam = new DataBase.Ram();
                addRam.Title = TbTitle.Text;
                addRam.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                addRam.QuantityRam = Convert.ToInt32(TbQuantityRam.Text);
                addRam.ClockSpeedID = (CbClockSpeedID.SelectedItem as ClockSpeed).ID;
                addRam.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                addRam.Cost = Convert.ToDecimal(TbCost.Text);
                addRam.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                if (PathImage != null)
                {
                    addRam.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.Ram.Add(addRam);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Ram added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editRam.Title = TbTitle.Text;
                editRam.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                editRam.QuantityRam = Convert.ToInt32(TbQuantityRam.Text);
                editRam.ClockSpeedID = (CbClockSpeedID.SelectedItem as ClockSpeed).ID;
                editRam.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                editRam.Cost = Convert.ToDecimal(TbCost.Text);
                editRam.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                

                if  (PathImage != null)
                {
                    editRam.PhotoLink = PathImage;
                }

                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Ram updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            } 
                    
            
        }

        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageRam.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCloseRamWindow_Click(object sender, RoutedEventArgs e)
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
