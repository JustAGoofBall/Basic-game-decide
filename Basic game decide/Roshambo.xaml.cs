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

namespace Basic_game_decide
{
    public partial class Roshambo : Window
    {
        private string[] choices = { "rock", "paper", "scissors" };

        public Roshambo()
        {
            InitializeComponent();
            Closing += Roshambo_Closing;
        }

        private void play(string playerMove)
        {
            Random random = new Random();
            int computerChoice = random.Next(0, 3);
            string computerMove = choices[computerChoice];

            string result = "";

            if (playerMove == computerMove)
            {
                result = "It's a tie!";
            }
            else if (playerMove == "rock" && computerMove == "scissors"
                || playerMove == "paper" && computerMove == "rock"
                || playerMove == "scissors" && computerMove == "paper")
            {
                result = "You won!";
            }
            else
            {
                result = "You lost!";
            }

            MyImage.Source = new BitmapImage(new Uri("/Images/" + playerMove + ".png", UriKind.Relative));
            OtherImage.Source = new BitmapImage(new Uri("/Images/" + computerMove + ".png", UriKind.Relative));
            MessageBox.Show("You chose " + playerMove + ".\nComputer chose " + computerMove + ".\n" + result);
        }

        private void rock_click(object sender, RoutedEventArgs e)
        {
            play("rock");
            MyImage.Source = new BitmapImage(new Uri("/Images/Rock.png", UriKind.Relative));
        }

        private void paper_click(object sender, RoutedEventArgs e)
        {
            play("paper");
            MyImage.Source = new BitmapImage(new Uri("/Images/paper.png", UriKind.Relative));
        }

        private void scissor_click(object sender, RoutedEventArgs e)
        {
            play("scissors");
            MyImage.Source = new BitmapImage(new Uri("/Images/scissors.png", UriKind.Relative));
        }

        private void Roshambo_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}