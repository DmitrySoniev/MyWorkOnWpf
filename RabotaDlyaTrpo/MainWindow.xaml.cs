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

namespace RabotaDlyaTrpo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginTextBox.Text = "Dmitry";
            LoginPasswordBox.Password = "Dmitry";
      
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            Window _registrationWindow = new Registration();
            this.Close();
            _registrationWindow.ShowDialog();
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                
                MessageBox.Show("Введите логин", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(LoginPasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string login = "Dmitry";
            string password = "Dmitry";

            if (LoginTextBox.Text != "" && LoginPasswordBox.Password != "")
            {

                if (LoginTextBox.Text == login && LoginPasswordBox.Password == password)
                {
                    Window _authorizationWindow = new Main();
                    this.Close();
                    _authorizationWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль, или учетная запись не создана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }

        private void JournalButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrEmpty(LoginPasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string admin = "admin";
            string password = "password";
            if (LoginTextBox.Text != "" && LoginPasswordBox.Password != "")
            {
                if (LoginTextBox.Text == admin && LoginPasswordBox.Password == password)
                {
                    Window _journalWindow = new Journal();
                    this.Close();
                    _journalWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Логин или пароль не соответсвует Админу", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
