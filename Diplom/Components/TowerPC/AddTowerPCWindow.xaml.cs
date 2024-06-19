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

namespace Diplom.Components.TowerPC
{
    /// <summary>
    /// Логика взаимодействия для AddTowerPCWindow.xaml
    /// </summary>
    public partial class AddTowerPCWindow : Window
    {
        private string PathImage;
        private bool isEdit = false;
        DataBase.TowerPC editTowerPC = null;
        public AddTowerPCWindow()
        {
            InitializeComponent();
            CbTypeTowerID.ItemsSource = ClassHelper.EF.Context.TypeTower.ToList();
            CbTypeTowerID.DisplayMemberPath = "Title";
            CbTypeTowerID.SelectedIndex = 0;
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbManufacturerID.SelectedIndex = 0;
            CbColorID.ItemsSource = ClassHelper.EF.Context.Color.ToList();
            CbColorID.DisplayMemberPath = "TitleColor";
            CbColorID.SelectedIndex = 0;
            CbFormFactorID.ItemsSource = ClassHelper.EF.Context.FormFactor.ToList();
            CbFormFactorID.DisplayMemberPath = "Title";
            CbFormFactorID.SelectedIndex = 0;
        }

        public AddTowerPCWindow (DataBase.TowerPC TowerPC)
        {
            InitializeComponent();
            isEdit = true;
            editTowerPC = TowerPC;
            CbTypeTowerID.ItemsSource = ClassHelper.EF.Context.TypeTower.ToList();
            CbTypeTowerID.DisplayMemberPath = "Title";
            CbManufacturerID.ItemsSource = ClassHelper.EF.Context.Manufacturer.ToList();
            CbManufacturerID.DisplayMemberPath = "Title";
            CbColorID.ItemsSource = ClassHelper.EF.Context.Color.ToList();
            CbColorID.DisplayMemberPath = "TitleColor";
            CbFormFactorID.ItemsSource = ClassHelper.EF.Context.FormFactor.ToList();
            CbFormFactorID.DisplayMemberPath = "Title";

            if (ImgImageTowerPC.Source != null)
            {
                ImgImageTowerPC.Source = new BitmapImage(new Uri(editTowerPC.PhotoLink));
            }
            TbTitle.Text = editTowerPC.Title;
            TbCost.Text = Convert.ToString(editTowerPC.Cost);
            CbColorID.SelectedItem = ClassHelper.EF.Context.Color.Where(i => i.ID == editTowerPC.ColorID).FirstOrDefault();
            CbFormFactorID.SelectedItem = ClassHelper.EF.Context.FormFactor.Where(i => i.ID == editTowerPC.FormFactorID).FirstOrDefault();
            CbManufacturerID.SelectedItem = ClassHelper.EF.Context.Manufacturer.Where(i => i.ID == editTowerPC.ManufacturerID).FirstOrDefault();
            CbTypeTowerID.SelectedItem = ClassHelper.EF.Context.TypeTower.Where(i => i.ID == editTowerPC.TypeTowerID).FirstOrDefault();

        }

        private void AddTowerPC_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                DataBase.TowerPC addTower = new DataBase.TowerPC();
                addTower.Title = TbTitle.Text;
                addTower.Cost = Convert.ToDecimal(TbCost.Text);
                addTower.ColorID = (CbColorID.SelectedItem as DataBase.Color).ID;
                addTower.FormFactorID = (CbFormFactorID.SelectedItem as FormFactor).ID;
                addTower.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                addTower.TypeTowerID = (CbTypeTowerID.SelectedItem as TypeTower).ID;
                if (PathImage != null)
                {
                    addTower.PhotoLink = PathImage;
                }
                ClassHelper.EF.Context.TowerPC.Add(addTower);
                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("TowerPC added", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                editTowerPC.Title = TbTitle.Text;
                editTowerPC.Cost = Convert.ToDecimal(TbCost.Text);
                editTowerPC.ColorID = (CbColorID.SelectedItem as DataBase.Color).ID;
                editTowerPC.FormFactorID = (CbFormFactorID.SelectedItem as FormFactor).ID;
                editTowerPC.ManufacturerID = (CbManufacturerID.SelectedItem as Manufacturer).ID;
                editTowerPC.TypeTowerID = (CbTypeTowerID.SelectedItem as TypeTower).ID;

                if (PathImage != null)
                {
                    editTowerPC.PhotoLink = PathImage;
                }

                ClassHelper.EF.Context.SaveChanges();
                MessageBox.Show("TowerPC updated", "Success.", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void BtnImageSearch_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            if (openfiledialog.ShowDialog() == true)
            {
                ImgImageTowerPC.Source = new BitmapImage(new Uri(openfiledialog.FileName));
                PathImage = openfiledialog.FileName;
            }
        }

        private void pnlControlBarWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
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

        private void BtnCloseTowerPCWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
