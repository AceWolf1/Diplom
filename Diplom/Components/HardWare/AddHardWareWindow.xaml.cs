using Diplom.Components.MotherBoard;
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

namespace Diplom.Components.HardWare
{
    /// <summary>
    /// Логика взаимодействия для AddHardWareWindow.xaml
    /// </summary>
    public partial class AddHardWareWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.DataStorage editDatastorage = null;
        public AddHardWareWindow()
        {
            InitializeComponent();
            CbInternalStorageID.ItemsSource = ClassHelper.EF.Context.InternalStorage.ToList();
            CbInternalStorageID.DisplayMemberPath = "Quantity";
            CbInternalStorageID.SelectedIndex = 0;
            CbSpeedOfReadingID.ItemsSource = ClassHelper.EF.Context.SpeedOfReading.ToList();
            CbSpeedOfReadingID.DisplayMemberPath = "Speed";
            CbSpeedOfReadingID.SelectedIndex = 0;
            CbConnectorID.ItemsSource = ClassHelper.EF.Context.Conector.ToList();
            CbConnectorID.DisplayMemberPath = "Title";
            CbConnectorID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;
        }

        public AddHardWareWindow(DataBase.DataStorage dataStorage)
        {
            InitializeComponent();
            isEdit = true;
            editDatastorage = dataStorage;
            CbInternalStorageID.ItemsSource = ClassHelper.EF.Context.InternalStorage.ToList();
            CbInternalStorageID.DisplayMemberPath = "Quantity";
            CbSpeedOfReadingID.ItemsSource = ClassHelper.EF.Context.SpeedOfReading.ToList();
            CbSpeedOfReadingID.DisplayMemberPath = "Speed";
            CbConnectorID.ItemsSource = ClassHelper.EF.Context.Conector.ToList();
            CbConnectorID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";

            if (ImgImageHardWare.Source != null)
            {
                ImgImageHardWare.Source = new BitmapImage(new Uri(editDatastorage.PhotoLink));
            }
            TbTitle.Text = editDatastorage.Title;
            TbCost.Text = Convert.ToString(editDatastorage.Cost);
            TbEnergyConsumption.Text = Convert.ToString (editDatastorage.EnergyConsumption);
            CbInternalStorageID.SelectedItem = ClassHelper.EF.Context.InternalStorage.Where (i => i.ID == editDatastorage.InternalStorageID).FirstOrDefault(); 
            CbSpeedOfReadingID.SelectedItem = ClassHelper.EF.Context.SpeedOfReading.Where (i => i.ID == editDatastorage.SpeedOfReadingID).FirstOrDefault();
            CbConnectorID.SelectedItem = ClassHelper.EF.Context.Conector.Where(i => i.ID == editDatastorage.ConnectorID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where (i => i.ID == editDatastorage.ManufacturerID).FirstOrDefault();

        }


        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageHardWare.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void AddHardWare_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.DataStorage addDatastorage = new DataBase.DataStorage();
                addDatastorage.Title = TbTitle.Text;
                addDatastorage.Cost = Convert.ToDecimal(TbCost.Text);
                addDatastorage.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                addDatastorage.InternalStorageID = (CbInternalStorageID.SelectedItem as InternalStorage).ID;
                addDatastorage.SpeedOfReadingID = (CbSpeedOfReadingID.SelectedItem as SpeedOfReading).ID;
                addDatastorage.ConnectorID = (CbConnectorID.SelectedItem as Conector).ID;
                addDatastorage.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;

                if( PathImage != null )
                {
                    addDatastorage.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.DataStorage.Add(addDatastorage);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Hard Ware added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editDatastorage.Title = TbTitle.Text;
                editDatastorage.Cost = Convert.ToDecimal(TbCost.Text);
                editDatastorage.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                editDatastorage.InternalStorageID = (CbInternalStorageID.SelectedItem as InternalStorage).ID;
                editDatastorage.SpeedOfReadingID = (CbSpeedOfReadingID.SelectedItem as SpeedOfReading).ID;
                editDatastorage.ConnectorID = (CbConnectorID.SelectedItem as Conector).ID;
                editDatastorage.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;

                if ( PathImage != null )
                {
                    editDatastorage.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Hard Ware updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCloseHardWaredWindow_Click(object sender, RoutedEventArgs e)
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
