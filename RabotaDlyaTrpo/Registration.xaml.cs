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
using System.IO;

namespace RabotaDlyaTrpo
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            LoginTextBox.MaxLength = 15;
            PasswordBox.MaxLength = 20;
            FamiliyaTextBox.MaxLength = 20;
            ImyaTextBox.MaxLength = 20;
            OtchestvoTextBox.MaxLength = 20;

        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                MessageBox.Show("Пустой логин", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(VerifyPasswordBox.Password))
            {
                MessageBox.Show("Введите подтверждение пароля", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (PasswordBox.Password != VerifyPasswordBox.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(ImyaTextBox.Text))
            {
                MessageBox.Show("Имя не введено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(FamiliyaTextBox.Text))
            {
                MessageBox.Show("Фамилия не введена", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(OtchestvoTextBox.Text))
            {
                MessageBox.Show("Отчество не введено", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (LoginTextBox.Text != "" && ImyaTextBox.Text != "" && FamiliyaTextBox.Text != "" && OtchestvoTextBox.Text != "" && PasswordBox.Password != "" && VerifyPasswordBox.Password != "")
            {
                // Заглушка
                //User _user = new User();

                //_user.login = LoginTextBox.Text;
                //_user.password = VerifyPasswordBox.Password;
                //_user.imya = ImyaTextBox.Text;
                //_user.familiya = FamiliyaTextBox.Text;
                //_user.otchestvo = OtchestvoTextBox.Text;
                //StreamWriter _streamWriter = new StreamWriter("bd.txt");
                //_streamWriter.WriteLine(_user.login);



                MessageBox.Show("Регистрация прошла успешно!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);

                Window _registrationWindow = new MainWindow();
                this.Close();
                _registrationWindow.ShowDialog();
            }
        }

        private void FamiliyaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void ImyaTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void OtchestvoTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

    }
}
