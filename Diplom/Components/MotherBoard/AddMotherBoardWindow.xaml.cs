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

namespace Diplom.Components.MotherBoard
{
    /// <summary>
    /// Логика взаимодействия для AddMotherBoardWindow.xaml
    /// </summary>
    public partial class AddMotherBoardWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.MotherBoard editMotherboard = null;
        public AddMotherBoardWindow()
        {
            InitializeComponent();
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbTypeOfMemoryID.SelectedIndex = 0;
            CbChipsetID.ItemsSource = ClassHelper.EF.Context.Chipset.ToList();
            CbChipsetID.DisplayMemberPath = "Title";
            CbChipsetID.SelectedIndex = 0;
            CbSocketID.ItemsSource = ClassHelper.EF.Context.Socket.ToList();
            CbSocketID.DisplayMemberPath = "Title";
            CbSocketID.SelectedIndex = 0;
            CbPCI_E_ID.ItemsSource = ClassHelper.EF.Context.PCI_E.ToList();
            CbPCI_E_ID.DisplayMemberPath = "Title";
            CbPCI_E_ID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;
            CbFormFactorID.ItemsSource = ClassHelper.EF.Context.FormFactor.ToList();
            CbFormFactorID.DisplayMemberPath = "Title";
            CbFormFactorID.SelectedIndex = 0;
        }

        public AddMotherBoardWindow(DataBase.MotherBoard motherBoard)
        {
            InitializeComponent();
            isEdit = true;
            editMotherboard = motherBoard;
            CbTypeOfMemoryID.ItemsSource = ClassHelper.EF.Context.TypeOfMemory.ToList();
            CbTypeOfMemoryID.DisplayMemberPath = "Title";
            CbChipsetID.ItemsSource = ClassHelper.EF.Context.Chipset.ToList();
            CbChipsetID.DisplayMemberPath = "Title";
            CbSocketID.ItemsSource = ClassHelper.EF.Context.Socket.ToList();
            CbSocketID.DisplayMemberPath = "Title";
            CbPCI_E_ID.ItemsSource = ClassHelper.EF.Context.PCI_E.ToList();
            CbPCI_E_ID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbFormFactorID.ItemsSource = ClassHelper.EF.Context.FormFactor.ToList();
            CbFormFactorID.DisplayMemberPath = "Title";

            if (ImgImageMotherBoard.Source != null)
            {
                ImgImageMotherBoard.Source = new BitmapImage(new Uri(editMotherboard.PhotoLink));
            }

            TbTitle.Text = editMotherboard.Title;
            TbCost.Text = Convert.ToString(editMotherboard.Cost);
            TbEnergyConsumption.Text = Convert.ToString (editMotherboard.EnergyConsumption);
            CbTypeOfMemoryID.SelectedItem = ClassHelper.EF.Context.TypeOfMemory.Where (i => i.ID == editMotherboard.TypeOfMemoryID).FirstOrDefault();
            CbChipsetID.SelectedItem = ClassHelper.EF.Context.Chipset.Where (i => i.ID == editMotherboard.ChipsetID).FirstOrDefault();
            CbSocketID.SelectedItem = ClassHelper.EF.Context.Socket.Where (i => i.ID == editMotherboard.SocketID).FirstOrDefault();
            CbPCI_E_ID.SelectedItem = ClassHelper.EF.Context.PCI_E.Where (i => i.ID == editMotherboard.PCI_E_ID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where (i => i.ID == editMotherboard.ManufacturerID).FirstOrDefault();
            CbFormFactorID.SelectedItem = ClassHelper.EF.Context.FormFactor.Where (i => i.ID == editMotherboard.FormFactorID).FirstOrDefault();


        }

        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageMotherBoard.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void AddMotherBoard_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.MotherBoard addMotherboard = new DataBase.MotherBoard();
                addMotherboard.Title = TbTitle.Text;
                addMotherboard.Cost = Convert.ToDecimal(TbCost.Text);
                addMotherboard.EnergyConsumption = Convert.ToInt32 (TbEnergyConsumption.Text);
                addMotherboard.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                addMotherboard.ChipsetID = (CbChipsetID.SelectedItem as Chipset).ID;
                addMotherboard.SocketID = (CbSocketID.SelectedItem as Socket).ID;
                addMotherboard.PCI_E_ID = (CbPCI_E_ID.SelectedItem as PCI_E).ID;
                addMotherboard.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                addMotherboard.FormFactorID = (CbFormFactorID.SelectedItem as FormFactor).ID;

                if (PathImage != null)
                {
                    addMotherboard.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.MotherBoard.Add (addMotherboard);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("Motherboard added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editMotherboard.Title = TbTitle.Text;
                editMotherboard.Cost = Convert.ToDecimal(TbCost.Text);
                editMotherboard.EnergyConsumption = Convert.ToInt32(TbEnergyConsumption.Text);
                editMotherboard.TypeOfMemoryID = (CbTypeOfMemoryID.SelectedItem as TypeOfMemory).ID;
                editMotherboard.ChipsetID = (CbChipsetID.SelectedItem as Chipset).ID;
                editMotherboard.SocketID = (CbSocketID.SelectedItem as Socket).ID;
                editMotherboard.PCI_E_ID = (CbPCI_E_ID.SelectedItem as PCI_E).ID;
                editMotherboard.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                editMotherboard.FormFactorID = (CbFormFactorID.SelectedItem as FormFactor).ID;

                if (PathImage != null)
                {
                    editMotherboard.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.SaveChanges ();
                MessageBox.Show("Motherboard updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCloseMotherBoardWindow_Click(object sender, RoutedEventArgs e)
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
