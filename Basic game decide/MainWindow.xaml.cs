using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Basic_game_decide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }
        
        private void Roshambo_Click(object sender, RoutedEventArgs e)
        {
            Roshambo roshambo = new Roshambo();

            roshambo.Show();
            this.Hide();
        }

        private void SpinningWheel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Spinning Wheel");
            SpinningWheel SpinningWheel = new SpinningWheel();

            SpinningWheel.Show();
            this.Hide();
        }

        private void BlackJack_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Black Jack");
            BlackJack BlackJack = new BlackJack();

            BlackJack.Show();
            this.Hide();
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            Begin_Screen begin_Screen = new Begin_Screen();
            begin_Screen.Show();
        }

        private void Fast_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Reflex Clicky");
            Fast_Clicky Reflex_Clicky = new Fast_Clicky();

            Reflex_Clicky.Show();
            this.Hide();
        }
    }
}
