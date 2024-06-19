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


namespace Diplom.Components.Videocard
{
    /// <summary>
    /// Логика взаимодействия для AddVideoCardWindow.xaml
    /// </summary>
    public partial class AddVideoCardWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.Videocard editVideocard = null;
        public AddVideoCardWindow()
        {
            InitializeComponent();
            CbVideoRamID.ItemsSource = ClassHelper.EF.Context.VideoRam.ToList();
            CbVideoRamID.DisplayMemberPath = "Title";
            CbVideoRamID.SelectedIndex = 0;
            CbGPUID.ItemsSource = ClassHelper.EF.Context.GPU.ToList();
            CbGPUID.DisplayMemberPath = "Title";
            CbGPUID.SelectedIndex = 0;
            CbMemoryBusWidhtID.ItemsSource = ClassHelper.EF.Context.MemoryBusWidth.ToList();
            CbMemoryBusWidhtID.DisplayMemberPath = "Title";
            CbMemoryBusWidhtID.SelectedIndex = 0;
            CbPCI_E_ID.ItemsSource = ClassHelper.EF.Context.PCI_E.ToList();
            CbPCI_E_ID.DisplayMemberPath = "Title";
            CbPCI_E_ID.SelectedIndex = 0;
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbTypeOfMemoryID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;
        }

        public AddVideoCardWindow(DataBase.Videocard videocard)
        {
            InitializeComponent();
            isEdit = true;
            editVideocard = videocard;
            CbVideoRamID.ItemsSource = ClassHelper.EF.Context.VideoRam.ToList();
            CbVideoRamID.DisplayMemberPath = "Title";
            CbGPUID.ItemsSource = ClassHelper.EF.Context.GPU.ToList();
            CbGPUID.DisplayMemberPath = "Title";
            CbMemoryBusWidhtID.ItemsSource = ClassHelper.EF.Context.MemoryBusWidth.ToList();
            CbMemoryBusWidhtID.DisplayMemberPath = "Title";
            CbPCI_E_ID.ItemsSource = ClassHelper.EF.Context.PCI_E.ToList();
            CbPCI_E_ID.DisplayMemberPath = "Title";
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";

            if (ImgImageVideocard.Source != null)
            {
                ImgImageVideocard.Source = new BitmapImage(new Uri(editVideocard.PhotoLink));
            }
            
            TbTitle.Text = editVideocard.Title;
            TbCost.Text = Convert.ToString (editVideocard.Cost);
            TbEnergyConsumption.Text = Convert.ToString (editVideocard.EnergyConsumption);
            TbQuantityVentilator.Text = Convert.ToString (editVideocard.QuantityVentilator);
            CbVideoRamID.SelectedItem = ClassHelper.EF.Context.VideoRam.Where(i => i.ID == editVideocard.VideoRamID).FirstOrDefault();
            CbGPUID.SelectedItem = ClassHelper.EF.Context.GPU.Where(i => i.ID == editVideocard.GPUID).FirstOrDefault();
            CbMemoryBusWidhtID.SelectedItem = ClassHelper.EF.Context.MemoryBusWidth.Where(i => i.ID == editVideocard.MemoryBusWidthID).FirstOrDefault();
            CbPCI_E_ID.SelectedItem = ClassHelper.EF.Context.PCI_E.Where(i => i.ID == editVideocard.PCI_E_ID).FirstOrDefault();
            CbTypeOfMemoryID.SelectedItem = ClassHelper.EF.Context.TypeOfMemory.Where(i => i.ID == editVideocard.TypeOfMemoryID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where(i => i.ID == editVideocard.ManufacturerID).FirstOrDefault();
            
        }


        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageVideocard.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void AddVideoCard_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.Videocard addVideocard = new DataBase.Videocard();
                addVideocard.Title = TbTitle.Text;
                addVideocard.VideoRamID = (CbVideoRamID.SelectedItem as VideoRam).ID;
                addVideocard.GPUID = (CbGPUID.SelectedItem as GPU).ID;
                addVideocard.QuantityVentilator = Convert.ToInt32(TbQuantityVentilator.Text);
                addVideocard.MemoryBusWidthID = (CbMemoryBusWidhtID.SelectedItem as MemoryBusWidth).ID;
                addVideocard.PCI_E_ID = (CbPCI_E_ID.SelectedItem as PCI_E).ID;
                addVideocard.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                addVideocard.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                addVideocard.Cost = Convert.ToDecimal(TbCost.Text);
                addVideocard.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                if (PathImage != null)
                {
                    addVideocard.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.Videocard.Add(addVideocard);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Videocard added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editVideocard.Title = TbTitle.Text;
                editVideocard.VideoRamID = (CbVideoRamID.SelectedItem as VideoRam).ID;
                editVideocard.GPUID = (CbGPUID.SelectedItem as GPU).ID;
                editVideocard.QuantityVentilator = Convert.ToInt32(TbQuantityVentilator.Text);
                editVideocard.MemoryBusWidthID = (CbMemoryBusWidhtID.SelectedItem as MemoryBusWidth).ID;
                editVideocard.PCI_E_ID = (CbPCI_E_ID.SelectedItem as PCI_E).ID;
                editVideocard.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                editVideocard.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                editVideocard.Cost = Convert.ToDecimal(TbCost.Text);
                editVideocard.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);

                if (PathImage != null)
                {
                    editVideocard.PhotoLink = PathImage;
                }


                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Videocard updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void BtnCloseVideocardWindow_Click(object sender, RoutedEventArgs e)
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

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
