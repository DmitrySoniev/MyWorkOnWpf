using RabotaDlyaTrpo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
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



            if (LoginTextBox.Text != "" && LoginPasswordBox.Password != "")
            {

                bool success = false;
                string login = LoginTextBox.Text;
                string password = LoginPasswordBox.Password;

                //Расскоментировать для компьютера
                string connectionString = @"Data Source=ДМИТРИЙ-ПК\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Дмитрий-ПК\Дмитрий;Password=";
                //Расскоментировать для ноутбука
                //string connectionString = @"Data Source=DMITRY\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Dmitry\Дмитрий;Password=";
                const string CheckUsers = "Select * From [User]  Where [Login] = @Login AND [Password]=@Password";
                using (SqlConnection openConnection = new SqlConnection(connectionString))
                {
                    if (openConnection.State == ConnectionState.Closed)
                    {


                        openConnection.Open();

                        SqlCommand check = new SqlCommand(CheckUsers, openConnection);
                        check.Parameters.AddWithValue("@Login", login);
                        check.Parameters.AddWithValue("@Password", password);
                        using (var dataReader = check.ExecuteReader())
                        {
                            success = dataReader.Read();

                        }
                        if (success)
                        {

                            using (db_SdgEntities db = new db_SdgEntities())
                            {
                                
                                var logins = db.User.FirstOrDefault(data => data.Login==login);
                                Spravochnik spravochnik = new Spravochnik { Nazvanie = "Авторизация" };
                                db.Spravochnik.Add(spravochnik);
                                db.SaveChanges();
                                ZavpisvZhurnale journal = new ZavpisvZhurnale { Data = DateTime.Now, Id_User = logins.Id_User, Id_Deistviya = spravochnik.ID_Deistviya, Nazvanie_deistviya = spravochnik.Nazvanie, Login_user=logins.Login};
                                db.ZavpisvZhurnale.Add(journal);
                                db.SaveChanges();

                            }
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

