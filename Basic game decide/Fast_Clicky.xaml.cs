using Basic_game_decide.Classes;
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
        private DatabaseHandler _connection;

        public Fast_Clicky(MainWindow mainWindow)
        {
            InitializeComponent();
            Closing += Fast_Clicky_Closing;
            this.mainWindow = mainWindow;
            _connection = new DatabaseHandler();
            timer = null;
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
            string username = Uname.Text;

            int currentScore = _connection.GetScore(username);

            if (score > currentScore)
            {
                if (currentScore > 0)
                {
                    _connection.UpdateScore(username, score);
                    MessageBox.Show("New high score recorded!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _connection.InsertScore(username, score);
                    MessageBox.Show("New score added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Try to beat your old score!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void clickButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer?.IsEnabled == true)
            {
                score++;
                UpdateUI();
            }
            else
            {
                timer?.Start();
            }
        }

        private void Fast_Clicky_Closing(object? sender, CancelEventArgs e)
        {
            mainWindow?.Show();
        }
    }
}
