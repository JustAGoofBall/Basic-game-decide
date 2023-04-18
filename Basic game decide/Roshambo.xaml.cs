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
    /// <summary>
    /// Interaction logic for Roshambo.xaml
    /// </summary>
    public partial class Roshambo : Window
    {
        private string[] choices = { "rock", "paper", "scissors" };

        public Roshambo()
        {
            InitializeComponent();
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

            MessageBox.Show("You chose " + playerMove + ".\nComputer chose " + computerMove + ".\n" + result);
        }

        private void rock_click(object sender, RoutedEventArgs e)
        {
            play("rock");
            Image img = MyImage;
            img.Source = new BitmapImage(new Uri(@"C:\Data\Own project\Basic game decide\Basic game decide\Images\Paper.png"));
        }


        private void paper_click(object sender, RoutedEventArgs e)
        {
            play("paper");
        }

        private void scissor_click(object sender, RoutedEventArgs e)
        {
            play("scissors");
        }

    }
}
