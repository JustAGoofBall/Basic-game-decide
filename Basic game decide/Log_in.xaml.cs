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
using MySql.Data.MySqlClient;
using Basic_game_decide.Classes;

namespace Basic_game_decide
{
    /// <summary>
    /// Interaction logic for Log_in.xaml
    /// </summary>
    public partial class Log_in : Window
    {
        public string? LoggedInUsername { get; private set; }
        private DatabaseHandler _connection;

        public Log_in()
        {
            InitializeComponent();
            Closing += Log_in_Closing;
            _connection = new DatabaseHandler();
        }

        private void Log_in_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register_Account registerPage = new Register_Account();
            registerPage.Show();
            this.Hide();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string name = Username.Text;
            string password = Password.Text;

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM playertabel WHERE naam = @name AND wachtwoord = @password", _connection.Connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);

                int result = Convert.ToInt32(command.ExecuteScalar());

                if (result > 0)
                {
                    LoggedInUsername = name;

                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow mainWindow = new MainWindow();
                    Fast_Clicky fastClicky = new Fast_Clicky(mainWindow);
                    fastClicky.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to the database: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete_Account delete_page = new Delete_Account();
            delete_page.Show();
            this.Hide();
        }
    }
}
