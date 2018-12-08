using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
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

namespace RabotaDlyaTrpo
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        public Journal()
        {
            InitializeComponent();
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сменить пользователя", "Сменить пользователя?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
            }
            else
            {
                Window _authorizationWindow = new MainWindow();
                this.Close();
                _authorizationWindow.ShowDialog();
            }
        }

        private void CheckJournalButton_Click(object sender, RoutedEventArgs e)
        {
            //string selectUsers = @"SELECT * From[User]";
            //Расскоментировать для компьютера
            string connectionString = @"Data Source=ДМИТРИЙ-ПК\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Дмитрий-ПК\Дмитрий;Password=";
            //Расскоментировать для ноутбука
            //string connectionString = @"Data Source=DMITRY\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Dmitry\Дмитрий;Password=";
            using (SqlConnection openConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id_Zapisi,Id_User,Login_User,Data,ID_Deistviya,Nazvanie_Deistviya FROM [ZavpisvZhurnale]", openConnection);

                if (openConnection.State == ConnectionState.Closed)
                {
                    openConnection.Open();
                    SqlDataReader read = command.ExecuteReader(); 
                    while (read.Read()) 
                    {
                        JournaListBox.Items.Add("   Ид "+read.GetValue(0).ToString()+"  Ид Юзера    "+read.GetValue(1).ToString()+" Логин Пользователя  " + read.GetValue(2).ToString() + " Дата    " +read.GetValue(3).ToString() +"   Ид действия "+ read.GetValue(4).ToString() +"   Название Действия   "+read.GetValue(5).ToString()); 
                    }
                }
            }
        }
        private void ArchiveButton_Click(object sender, RoutedEventArgs e)
        {
            string zipPath = @"E:\ТРПО\temp";
            string zipFile = @"E:\ТРПО\DataAboutUsers.zip";
            ZipFile.CreateFromDirectory(zipPath, zipFile);
            //File.Delete(@"E:\ТРПО\User.txt");
            MessageBox.Show("Архивация прошла успешно!", "Выполнено!", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void DearchiveButton_Click(object sender, RoutedEventArgs e)
        {
            ZipFile.ExtractToDirectory(@"E:\ТРПО\DataAboutUsers.zip", @"E:\ТРПО\");
            //File.Delete(@"E:\ТРПО\DataAboutUsers.zip");
            MessageBox.Show("Разархивация прошла успешно", "Выполнено!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
