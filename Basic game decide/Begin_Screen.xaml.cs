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

namespace Basic_game_decide
{
    /// <summary>
    /// Interaction logic for Begin_Screen.xaml
    /// </summary>
    public partial class Begin_Screen : Window
    {
        public Begin_Screen()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Hide();
        }

        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            Log_in log_in = new Log_in();

            log_in.Show();
            this.Hide();
        }
    }
}