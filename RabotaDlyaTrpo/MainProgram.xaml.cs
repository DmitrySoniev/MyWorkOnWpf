﻿using System;
using System.Collections.Generic;
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
                string writePath = @"E:\ТРПО\sideRombandangleRomb.txt";
                var A = Convert.ToDouble(sideRomb.Text);
                var B = Convert.ToDouble(angleRomb.Text);
                double S;
                S = A * A * Math.Sin(B);
                areaRomb.Text = S.ToString();
                //using (StreamWriter _streamWriter = new StreamWriter(writePath))
                //{
                //    _streamWriter.WriteLine("Сторона ромба " + sideRomb.Text);
                //    _streamWriter.WriteLine("Угол ромба " + angleRomb.Text);
                //    _streamWriter.WriteLine("Ответ" + areaRomb.Text);
                //    _streamWriter.Close();
                //}
            }


            if (firstDiagonalRomb.Text != "" && secondDiagonalRomb.Text != "")
            {
                string writePath = @"E:\ТРПО\firstDiagonalRombandSecondDiagonalRomb.txt";
                var A = Convert.ToDouble(firstDiagonalRomb.Text);
                var B = Convert.ToDouble(secondDiagonalRomb.Text);
                double S;
                S = (A * B) / 2;
                areaRomb.Text = S.ToString();
                //using (StreamWriter _streamWriter2 = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                //{
                //    _streamWriter2.WriteLine("Первая диагональ ромба " + firstDiagonalRomb.Text);
                //    _streamWriter2.WriteLine("Вторая диагональ ромба " + secondDiagonalRomb.Text);
                //    _streamWriter2.WriteLine("Ответ" + areaRomb.Text);
                //    _streamWriter2.Close();
                //}
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
