using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для AutWindow.xaml
    /// </summary>
    public partial class AutWindow : Window
    {
        
        public AutWindow()
        {
            InitializeComponent();

        }

        private void btnRegAutWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
        }

        public static int authFlag;


        private void btnEnterAutWindow_Click(object sender, RoutedEventArgs e)
        {
           
            DataBase.User userName = ClassHelper.EF.Context.User.ToList().
              Where(i => i.Nickname == NickNameAutWindowBox.Text && i.Password == PasswordAutWindowBox.Password).
              FirstOrDefault();
            if (userName != null)
                
                
            {
                ClassHelper.EF.User = userName;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                

            }
            else
            {
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCloseAutWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximizeAutWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void BtnMinimizeAutWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void pnlControlBarAutWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
