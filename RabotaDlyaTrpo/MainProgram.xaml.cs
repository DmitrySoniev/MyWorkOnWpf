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
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void angleRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void firstDiagonalRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void secondDiagonalRomb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
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
            //Спросить про формулы вычисления ромба

            if (sideRomb.Text != "" && angleRomb.Text != "")
            {
                var A = Convert.ToInt32(sideRomb.Text);
                var B = Convert.ToInt32(angleRomb.Text);
                int S;
                S = A + B;
                areaRomb.Text = S.ToString();
            }

            if (firstDiagonalRomb.Text != "" && secondDiagonalRomb.Text != "")
            {
                var A = Convert.ToInt32(firstDiagonalRomb.Text);
                var B = Convert.ToInt32(secondDiagonalRomb.Text);
                int S;
                S = A + B;
                areaRomb.Text = S.ToString();
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
