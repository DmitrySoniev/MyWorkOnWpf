using System;

using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace RabotaDlyaTrpo
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            areaRomb.IsReadOnly = true;
        }

        private void sideRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox _textBox = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
            if ((e.Text == ",") && ((_textBox.Text.IndexOf(",") != -1) || (_textBox.Text == "")))
            {
                e.Handled = true;
            }
        }

        private void angleRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox _textBox = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
                if ((e.Text == ",") && ((_textBox.Text.IndexOf(",") != -1) || (_textBox.Text == "")))
            { e.Handled = true; }
        }

        private void firstDiagonalRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox _textBox = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
                if ((e.Text == ",") && ((_textBox.Text.IndexOf(",") != -1) || (_textBox.Text == "")))
            { e.Handled = true; }

        }

        private void secondDiagonalRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox _textBox = sender as TextBox;
            if ((!Char.IsDigit(e.Text, 0)) && (e.Text != ","))
            {
                { e.Handled = true; }
            }
            else
                if ((e.Text == ",") && ((_textBox.Text.IndexOf(",") != -1) || (_textBox.Text == "")))
            { e.Handled = true; }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            firstDiagonalRomb.IsEnabled = true;
            secondDiagonalRomb.IsEnabled = true;
            sideRomb.IsEnabled = true;
            angleRomb.IsEnabled = true;

            firstDiagonalRomb.Clear();
            secondDiagonalRomb.Clear();
            sideRomb.Clear();
            angleRomb.Clear();
            areaRomb.Clear();
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Вы действительно хотите сменить пользователя", "Сменить пользователя?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

            }
            else
            {
                Window _mainWindow = new MainWindow();
                this.Close();
                _mainWindow.ShowDialog();
            }
        }


        private void sideRomb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            firstDiagonalRomb.IsEnabled = false;
            secondDiagonalRomb.IsEnabled = false;
        }

        private void angleRomb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            firstDiagonalRomb.IsEnabled = false;
            secondDiagonalRomb.IsEnabled = false;
        }

        private void CalculateRombButton_Click(object sender, RoutedEventArgs e)
        {

            if (sideRomb.Text == "" && firstDiagonalRomb.IsEnabled == false && secondDiagonalRomb.IsEnabled == false)
            {
                MessageBox.Show("Введите сторону ромба!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (angleRomb.Text == "" && firstDiagonalRomb.IsEnabled == false && secondDiagonalRomb.IsEnabled == false)
            {
                MessageBox.Show("Введите угол ромба!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (firstDiagonalRomb.Text == "" && sideRomb.IsEnabled == false && angleRomb.IsEnabled == false)
            {
                MessageBox.Show("Введите первую диагональ ромба!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (secondDiagonalRomb.Text == "" && sideRomb.IsEnabled == false && angleRomb.IsEnabled == false)
            {
                MessageBox.Show("Введите вторую диагональ ромба!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (sideRomb.Text != "" && angleRomb.Text != "")
            {
                //string writePath = @"E:\ТРПО\sideRombandangleRomb.txt";
                //Расскоментировать для пк
                string connectionString = @"Data Source=ДМИТРИЙ-ПК\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Дмитрий-ПК\Дмитрий;Password=";
                //Раскоментировать для ноутбука
                //string connectionString = @"Data Source=DMITRY\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Dmitry\Дмитрий;Password=";
                using (SqlConnection openConnection = new SqlConnection(connectionString))

                {
                    if (openConnection.State == ConnectionState.Closed)
                    {

                        openConnection.Open();
                        string saveUsers = "INSERT into [Romb] ([Storona],[Ugol],[Ploschad]) values (@Storona,@Ugol,@Ploschad)";

                        using (SqlCommand querySaveUsers = new SqlCommand(saveUsers))
                        {

                            querySaveUsers.Connection = openConnection;

                            using (db_SdgEntities db = new db_SdgEntities())
                            {
                                var users = db.ZavpisvZhurnale.OrderByDescending(x => x.Id_Zapisi).FirstOrDefault();
                                Spravochnik spravochnik = new Spravochnik { Nazvanie = "Вычисление" };
                                db.Spravochnik.Add(spravochnik);
                                db.SaveChanges();
                                ZavpisvZhurnale journal = new ZavpisvZhurnale { Data = DateTime.Now, Id_User = users.Id_User, Id_Deistviya = spravochnik.ID_Deistviya, Nazvanie_deistviya = spravochnik.Nazvanie, Login_user = users.Login_user };
                                db.ZavpisvZhurnale.Add(journal);
                                db.SaveChanges();

                            }
                            var storonaRomba = Convert.ToDouble(sideRomb.Text);
                            var ugolRomba = Convert.ToDouble(angleRomb.Text);
                            double Ploschad;
                            Ploschad = storonaRomba * storonaRomba * Math.Sin(ugolRomba);
                            areaRomb.Text = Ploschad.ToString();
                            querySaveUsers.Parameters.Add("@Storona", SqlDbType.Float).Value = storonaRomba;
                            querySaveUsers.Parameters.Add("@Ugol", SqlDbType.Float).Value = ugolRomba;
                            querySaveUsers.Parameters.Add("@Ploschad", SqlDbType.Float).Value = Ploschad;
                            querySaveUsers.ExecuteNonQuery();

                        }
                    }
                }
            }


            if (firstDiagonalRomb.Text != "" && secondDiagonalRomb.Text != "")
            {
                //Расскоментировать для пк
                string connectionString = @"Data Source=ДМИТРИЙ-ПК\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Дмитрий-ПК\Дмитрий;Password=";
                //Раскоментировать для ноутбука
                //string connectionString = @"Data Source=DMITRY\SQLEXPRESS;Database=db_Sdg;Trusted_Connection=Yes;User ID=Dmitry\Дмитрий;Password=";
                using (SqlConnection openConnection = new SqlConnection(connectionString))

                {
                    if (openConnection.State == ConnectionState.Closed)
                    {

                        openConnection.Open();
                        string saveUsers = "INSERT into [Romb] ([Diagonal1],[Digannal2],[Ploschad]) values (@Diagonal1,@Digannal2,@Ploschad)";

                        using (SqlCommand querySaveUsers = new SqlCommand(saveUsers))
                        {

                            querySaveUsers.Connection = openConnection;

                            using (db_SdgEntities db = new db_SdgEntities())
                            {

                                var users = db.ZavpisvZhurnale.OrderByDescending(x => x.Id_Zapisi).FirstOrDefault();
                                Spravochnik spravochnik = new Spravochnik { Nazvanie = "Вычисление" };
                                db.Spravochnik.Add(spravochnik);
                                db.SaveChanges();
                                ZavpisvZhurnale journal = new ZavpisvZhurnale { Data = DateTime.Now, Id_User = users.Id_User, Id_Deistviya = spravochnik.ID_Deistviya, Nazvanie_deistviya = spravochnik.Nazvanie, Login_user = users.Login_user };
                                db.ZavpisvZhurnale.Add(journal);
                                db.SaveChanges();

                            }
                            var DiagonalRomba1 = Convert.ToDouble(firstDiagonalRomb.Text);
                            var DiagonalRomba2 = Convert.ToDouble(secondDiagonalRomb.Text);
                            double Ploschad;
                            Ploschad = (DiagonalRomba1 * DiagonalRomba2) / 2;
                            areaRomb.Text = Ploschad.ToString();
                            querySaveUsers.Parameters.Add("@Diagonal1", SqlDbType.Float).Value = DiagonalRomba1;
                            querySaveUsers.Parameters.Add("@Digannal2", SqlDbType.Float).Value = DiagonalRomba2;
                            querySaveUsers.Parameters.Add("@Ploschad", SqlDbType.Float).Value = Ploschad;
                            querySaveUsers.ExecuteNonQuery();

                        }
                    }
                }
            }

            firstDiagonalRomb.IsEnabled = true;
            secondDiagonalRomb.IsEnabled = true;
            sideRomb.IsEnabled = true;
            angleRomb.IsEnabled = true;
        }

        private void firstDiagonalRomb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sideRomb.IsEnabled = false;
            angleRomb.IsEnabled = false;
        }

        private void secondDiagonalRomb_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sideRomb.IsEnabled = false;
            angleRomb.IsEnabled = false;
        }
    }
}
