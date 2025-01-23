using _22._101_Брицева_authorization.Models;
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

namespace _22._101_Брицева_authorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly KontrEntities _context;
        private object resultTextBlock;
        private object loginTextBox;
        private object passwordBox;

        public MainWindow()
        {
            InitializeComponent();
            _context = new KontrEntities();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = (string)loginTextBox;
            string password = (string)passwordBox;

            var user = _context.User
                .FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                string roleName = _context.Role
                 .Where(r => r.ID_Role == user.ID_Role)
                     .Select(r => r.Role1)
                       .FirstOrDefault();
                resultTextBlock = $"Добро пожаловать! Ваша роль: {roleName}";
            }
            else
            {
                resultTextBlock = "Неверно введены логин или пароль!";
            }
        }

        private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
