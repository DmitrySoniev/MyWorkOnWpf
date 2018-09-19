﻿using System;
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
            DateTime _dateTime = new DateTime();
            JournaListBox.Items.Add("Дата входа:" + _dateTime.ToLocalTime());

        }
    }
}
