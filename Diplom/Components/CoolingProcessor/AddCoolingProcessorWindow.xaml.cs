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

namespace Diplom.Components.CoolingProcessor
{
    /// <summary>
    /// Логика взаимодействия для AddCoolingProcessorWindow.xaml
    /// </summary>
    public partial class AddCoolingProcessorWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.CoolingProcessor editCoolingprocessor = null;
        public AddCoolingProcessorWindow()
        {
            InitializeComponent();
            CbTypeCoolingID.ItemsSource = ClassHelper.EF.Context.TypeCooling.ToList();
            CbTypeCoolingID.DisplayMemberPath = "Title";
            CbTypeCoolingID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;
        }

        public AddCoolingProcessorWindow(DataBase.CoolingProcessor coolingprocessor)
        {
            InitializeComponent();
            isEdit = true;
            editCoolingprocessor = coolingprocessor;
            CbTypeCoolingID.ItemsSource = ClassHelper.EF.Context.TypeCooling.ToList();
            CbTypeCoolingID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";

            if (ImgImageCoolingProcessor.Source != null)
            {
                ImgImageCoolingProcessor.Source = new BitmapImage(new Uri(editCoolingprocessor.PhotoLink));
            }
            TbTitle.Text = editCoolingprocessor.Title;
            TbCost.Text = Convert.ToString(editCoolingprocessor.Cost);
            TbEnergyConsumption.Text = Convert.ToString(editCoolingprocessor.EnergyConsumption);
            TbCoolerQuantity_SectionRadiator.Text = Convert.ToString(editCoolingprocessor.CoolerQuantity_SectionRadiator);
            CbTypeCoolingID.SelectedItem = ClassHelper.EF.Context.TypeCooling.Where (i => i.ID == editCoolingprocessor.TypeCoolingID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where (i => i.ID == editCoolingprocessor.ManufacturerID).FirstOrDefault();

        }

        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageCoolingProcessor.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void AddCoolingProcessor_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.CoolingProcessor addCoolingprocessor = new DataBase.CoolingProcessor();
                addCoolingprocessor.Title = TbTitle.Text;
                addCoolingprocessor.Cost = Convert.ToDecimal(TbCost.Text);
                addCoolingprocessor.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                addCoolingprocessor.CoolerQuantity_SectionRadiator = Convert.ToInt32 (TbCoolerQuantity_SectionRadiator.Text);
                addCoolingprocessor.TypeCoolingID = (CbTypeCoolingID.SelectedItem as TypeCooling).ID;
                addCoolingprocessor.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;

                if (PathImage != null)
                {
                    addCoolingprocessor.PhotoLink = PathImage;
                }

                ClassHelper.EF.Context.CoolingProcessor.Add(addCoolingprocessor);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Cooling Processor added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editCoolingprocessor.Title = TbTitle.Text;
                editCoolingprocessor.Cost = Convert.ToDecimal(TbCost.Text);
                editCoolingprocessor.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                editCoolingprocessor.CoolerQuantity_SectionRadiator = Convert.ToInt32(TbCoolerQuantity_SectionRadiator.Text);
                editCoolingprocessor.TypeCoolingID = (CbTypeCoolingID.SelectedItem as TypeCooling).ID;
                editCoolingprocessor.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;

                if (PathImage!= null)
                {
                    editCoolingprocessor.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Cooling Processor updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCloseCoolingProcessordWindow_Click(object sender, RoutedEventArgs e)
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
