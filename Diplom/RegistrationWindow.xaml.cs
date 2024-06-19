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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BtnBackAutWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AutWindow autWindow = new AutWindow();
            autWindow.Show();
        }

        private void pnlControlBarRegWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnCloseRegWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximizeRegWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void BtnMinimizeRegWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnRegWindow_Click(object sender, RoutedEventArgs e)
        {
            DataBase.User addUser = new DataBase.User();
            addUser.Nickname = NickNameRegWindowBox.Text;
            addUser.Password = PasswordBoxRegWindow.Password;
            addUser.Email = EmailRegWindowBox.Text;
            addUser.Phone = PhoneRegWindowBox.Text;
            addUser.RegistrationDate = DateTime.Now;
            ClassHelper.EF.Context.User.Add(addUser);
            ClassHelper.EF.Context.SaveChanges();
            MessageBox.Show("Пользователь создан");
        }
    }
}
