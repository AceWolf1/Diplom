using Diplom.DataBase;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для AddProcWindow.xaml
    /// </summary>
    public partial class AddProcWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.Processor editProcessor = null;
        public AddProcWindow()
        {
            InitializeComponent();

            CbGraphicsCore.Items.Add(true);
            CbGraphicsCore.Items.Add(false);

            CbSocketID.ItemsSource = ClassHelper.EF.Context.Socket.ToList();
            CbSocketID.DisplayMemberPath = "Title";
            CbSocketID.SelectedIndex = 0;
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbTypeOfMemoryID.SelectedIndex = 0;
            CbCPUFamilyID.ItemsSource = ClassHelper.EF.Context.CpuFamilyID.ToList(); /// CpuFamilyID НАЗЫВАЕТСЯ ТАК В БАЗЕ ДАННЫХ СУЩНОСТЬ
            CbCPUFamilyID.DisplayMemberPath = "Title";
            CbCPUFamilyID.SelectedIndex = 0;
            CbGraphicsCore.SelectedIndex = 0;
            CbProseccorFrequencyID.ItemsSource = ClassHelper.EF.Context.ProcessorFrequency.ToList();
            CbProseccorFrequencyID.DisplayMemberPath = "Quantity";
            CbProseccorFrequencyID.SelectedIndex = 0;
            CbGenerationCPUID.ItemsSource = ClassHelper.EF.Context.GenerationCPU.ToList();
            CbGenerationCPUID.DisplayMemberPath = "Title";
            CbGenerationCPUID.SelectedIndex = 0;
            CbQuantityCoreID.ItemsSource = ClassHelper.EF.Context.QuantityCore.ToList();
            CbQuantityCoreID.DisplayMemberPath = "Quantity";
            CbQuantityCoreID.SelectedIndex = 0;
            CbManufacturerGPUID.ItemsSource = ClassHelper.EF.Context.ManufacturerGPU.ToList();
            CbManufacturerGPUID.DisplayMemberPath = "Title";
            CbManufacturerGPUID.SelectedIndex = 0;

        }
        public AddProcWindow(DataBase.Processor processor)
        {

            InitializeComponent();

            CbGraphicsCore.Items.Add(true);
            CbGraphicsCore.Items.Add(false);

            isEdit = true;
            editProcessor = processor;
            CbSocketID.ItemsSource = ClassHelper.EF.Context.Socket.ToList();
            CbSocketID.DisplayMemberPath = "Title";
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbCPUFamilyID.ItemsSource = ClassHelper.EF.Context.CpuFamilyID.ToList(); /// CpuFamilyID НАЗЫВАЕТСЯ ТАК В БАЗЕ ДАННЫХ СУЩНОСТЬ
            CbCPUFamilyID.DisplayMemberPath = "Title";
            
            CbProseccorFrequencyID.ItemsSource = ClassHelper.EF.Context.ProcessorFrequency.ToList();
            CbProseccorFrequencyID.DisplayMemberPath = "Quantity";
            CbGenerationCPUID.ItemsSource = ClassHelper.EF.Context.GenerationCPU.ToList();
            CbGenerationCPUID.DisplayMemberPath = "Title";
            CbQuantityCoreID.ItemsSource = ClassHelper.EF.Context.QuantityCore.ToList();
            CbQuantityCoreID.DisplayMemberPath = "Quantity";
            CbManufacturerGPUID.ItemsSource = ClassHelper.EF.Context.ManufacturerGPU.ToList();
            CbManufacturerGPUID.DisplayMemberPath = "Title";


            if (ImgImageProcessor.Source != null)
            {
                ImgImageProcessor.Source = new BitmapImage(new Uri(editProcessor.PhotoLink));
            }

            TbTitle.Text = editProcessor.Title;
            TbCost.Text = Convert.ToString(editProcessor.Cost);
            TbEnergyConsumption.Text = Convert.ToString((int)editProcessor.EnergyConsumption);
            CbSocketID.SelectedItem = ClassHelper.EF.Context.Socket.Where (i  => i.ID == editProcessor.SocketID).FirstOrDefault();
            CbTypeOfMemoryID.SelectedItem = ClassHelper.EF.Context.TypeOfMemory.Where (i => i.ID == editProcessor.TypeOfMemoryID).FirstOrDefault();
            CbProseccorFrequencyID.SelectedItem = ClassHelper.EF.Context.ProcessorFrequency.Where (i => i.ID == editProcessor.ProcessorFrequencyID).FirstOrDefault();
            CbGenerationCPUID.SelectedItem = ClassHelper.EF.Context.GenerationCPU.Where (i => i.ID ==editProcessor.GenerationCPUID).FirstOrDefault();
            
            CbCPUFamilyID.SelectedItem = ClassHelper.EF.Context.CpuFamilyID.Where (i => i.ID == editProcessor.CPUFamilyID).FirstOrDefault();
            CbQuantityCoreID.SelectedItem = ClassHelper.EF.Context.QuantityCore.Where (i => i.ID == editProcessor.QuantityCoreID).FirstOrDefault();
            CbManufacturerGPUID.SelectedItem = ClassHelper.EF.Context.ManufacturerGPU.Where (i => i.ID ==editProcessor.ManufacturerGPUID).FirstOrDefault();
            CbGraphicsCore.SelectedItem = editProcessor.GraphicsCore;
        }

        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageProcessor.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void AddProcessor_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.Processor addProcessor = new DataBase.Processor();
                addProcessor.Title = TbTitle.Text;
                addProcessor.SocketID = (CbSocketID.SelectedItem as DataBase.Socket).ID; /// возможно ошибка
                addProcessor.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                addProcessor.CPUFamilyID = (CbCPUFamilyID.SelectedItem as DataBase.CpuFamilyID).ID;
                addProcessor.GraphicsCore = (CbGraphicsCore.SelectedItem as bool?).Value;
                addProcessor.ProcessorFrequencyID = (CbProseccorFrequencyID.SelectedItem as ProcessorFrequency).ID;
                addProcessor.GenerationCPUID = (CbGenerationCPUID.SelectedItem as GenerationCPU).ID;
                addProcessor.QuantityCoreID = (CbQuantityCoreID.SelectedItem as QuantityCore).ID;
                addProcessor.ManufacturerGPUID = (CbManufacturerGPUID.SelectedItem as ManufacturerGPU).ID;
                addProcessor.Cost = Convert.ToDecimal(TbCost.Text);
                addProcessor.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                if (PathImage != null)
                {
                    addProcessor.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.Processor.Add(addProcessor);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Processor added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editProcessor.Title = TbTitle.Text;
                editProcessor.SocketID = (CbSocketID.SelectedItem as DataBase.Socket).ID; /// возможно ошибка
                editProcessor.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                editProcessor.CPUFamilyID = (CbCPUFamilyID.SelectedItem as DataBase.CpuFamilyID).ID;
                editProcessor.GraphicsCore = (CbGraphicsCore.SelectedItem as DataBase.Processor).GraphicsCore;
                editProcessor.ProcessorFrequencyID = (CbProseccorFrequencyID.SelectedItem as ProcessorFrequency).ID;
                editProcessor.GenerationCPUID = (CbGenerationCPUID.SelectedItem as GenerationCPU).ID;
                editProcessor.QuantityCoreID = (CbQuantityCoreID.SelectedItem as QuantityCore).ID;
                editProcessor.ManufacturerGPUID = (CbManufacturerGPUID.SelectedItem as ManufacturerGPU).ID;
                editProcessor.Cost = Convert.ToDecimal(TbCost.Text);
                editProcessor.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);

                if (PathImage != null) 
                {
                    editProcessor.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Processor updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCloseProcessorWindow_Click(object sender, RoutedEventArgs e)
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
