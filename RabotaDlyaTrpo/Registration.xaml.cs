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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Core.Objects;

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
            VerifyPasswordBox.MaxLength = 20;
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
                string login = LoginTextBox.Text;
                string password = VerifyPasswordBox.Password;
                string imya = ImyaTextBox.Text;
                string otchestvo = OtchestvoTextBox.Text;
                string familiya = FamiliyaTextBox.Text;
                //Расскоментировать для компьютера
                string connectionString = @"Data Source=ДМИТРИЙ-ПК\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Дмитрий-ПК\Дмитрий;Password=";
                //Расскоментировать для ноутбука
                //string connectionString = @"Data Source=DMITRY\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Dmitry\Дмитрий;Password=";
                using (SqlConnection openConnection = new SqlConnection(connectionString))

                {
                    if (openConnection.State == ConnectionState.Closed)
                    {
                        bool FindedUser;
                        openConnection.Open();
                        string saveUsers = "INSERT into [User] ([Login],[Password],[Familiya],[Imya],[Otchestvo]) values (@Login,@Password,@Familiya,@Imya,@Otchestvo)";
                        string selectUsers = "SELECT * from [User] Where [Login]=@Login";
                        using (SqlCommand querySaveUsers = new SqlCommand(saveUsers))
                        {
                                                                                                          
                            querySaveUsers.Connection = openConnection;
                            SqlCommand checkLogin = new SqlCommand(selectUsers, openConnection);
                            checkLogin.Parameters.AddWithValue("@Login", login);

                            using (var dataReader = checkLogin.ExecuteReader())
                            {
                                FindedUser = dataReader.Read();
                            }
                            if (FindedUser)
                            {
                                MessageBox.Show("Пользователь с таким логином уже зарегистрирован", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;

                            }
                            else
                            {
                                using (db_SdgEntities db = new db_SdgEntities())
                                {
                                    User users = new User { Login = login, Familiya = familiya, Imya = imya, Otchestvo = otchestvo, Password = password };
                                    db.User.Add(users);
                                    db.SaveChanges();
                                    Spravochnik spravochnik = new Spravochnik { Nazvanie = "регистрация" };
                                    db.Spravochnik.Add(spravochnik);
                                    db.SaveChanges();
                                    ZavpisvZhurnale journal = new ZavpisvZhurnale { Data = DateTime.Now, Id_User = users.Id_User, Id_Deistviya = spravochnik.ID_Deistviya, Nazvanie_deistviya = spravochnik.Nazvanie,Login_user=login };
                                    db.ZavpisvZhurnale.Add(journal);
                                    db.SaveChanges();
                                    MessageBox.Show("Регистрация прошла успешно!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                                    Window _registrationWindow = new MainWindow();
                                    this.Close();
                                    _registrationWindow.ShowDialog();
                                }

                            }
                        }
                    }
                }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
