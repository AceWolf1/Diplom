using Diplom.Components.CoolingProcessor;
using Diplom.Components.HardWare;
using Diplom.Components.MotherBoard;
using Diplom.Components.PowerSupply;
using Diplom.Components.Processor;
using Diplom.Components.Ram;
using Diplom.Components.TowerPC;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void PowerSupplyMainWindow_Click(object sender, RoutedEventArgs e)
        {
            PowerSupplyWindow powerSupplyWindow = new PowerSupplyWindow();
            powerSupplyWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = powerSupplyWindow.Content;
        }

        private void TowerPCMainWindow_Click(object sender, RoutedEventArgs e)
        {
            TowerPCWindow towerPCWindow = new TowerPCWindow();
            towerPCWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = towerPCWindow.Content;
        }

        private void CoolingMainWindow_Click(object sender, RoutedEventArgs e)
        {
            CoolingWindow coolingWindow = new CoolingWindow();
            coolingWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = coolingWindow.Content;
        }

        private void HardWareMainWindow_Click(object sender, RoutedEventArgs e)
        {
            HardWareWindow hardWareWindow = new HardWareWindow();
            hardWareWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = hardWareWindow.Content;
        }

        private void RamMainWindow_Click(object sender, RoutedEventArgs e)
        {
            RamWindow ramWindow = new RamWindow();
            ramWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = ramWindow.Content;
        }

        private void MotherBoardMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MotherBoardWindow motherBoardWindow = new MotherBoardWindow();
            motherBoardWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = motherBoardWindow.Content;
        }

        private void BtnProcMainWindow_Click(object sender, RoutedEventArgs e)
        {
            ProcWindow procWindow = new ProcWindow();
            procWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = procWindow.Content;
        }

        private void BtnVideoCardMainWindow_Click(object sender, RoutedEventArgs e)
        {
            VideocardWindow videocardWindow = new VideocardWindow();
            videocardWindow.MainFrame = WindowsFrame;
            WindowsFrame.Content = videocardWindow.Content;
        }

        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.Show();
            this.Close();
        }
    }
}
