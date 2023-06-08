using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace Basic_game_decide
{
    public partial class Fast_Clicky : Window
    {
        private int score;
        private int timeRemaining;
        private DispatcherTimer? timer;
        private MainWindow mainWindow;

        public Fast_Clicky(MainWindow mainWindow)
        {
            InitializeComponent();
            Closing += Fast_Clicky_Closing;

            this.mainWindow = mainWindow;

            InitializeGame();
        }

        private void InitializeGame()
        {
            score = 0;
            timeRemaining = 10;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            UpdateUI();

            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timeRemaining--;

            if (timeRemaining <= 0)
            {
                timer?.Stop();
                SaveScoreToDatabase();
                MessageBox.Show($"Time's up! Your score is: {score}");
                InitializeGame();
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            timerLabel.Content = $"Time Remaining: {timeRemaining}";
            scoreLabel.Content = $"Score: {score}";
        }

        private void SaveScoreToDatabase()
        {
            // TODO: Implement your database saving logic here
            // You can use ADO.NET, Entity Framework, or any other ORM
            // to connect to your database and save the score
            // Retrieve the player's ID, for example, from a login process
            // and then insert the score into the "scores" table.
        }

        private void clickButton_Click(object sender, RoutedEventArgs e)
        {
            score++;
            UpdateUI();
        }

        private void Fast_Clicky_Closing(object? sender, CancelEventArgs e)
        {
            mainWindow?.Show();
        }
    }
}
