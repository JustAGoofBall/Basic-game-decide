using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
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
using Basic_game_decide.Classes;

namespace Basic_game_decide
{
    /// <summary>
    /// Interaction logic for Register_Account.xaml
    /// </summary>
    public partial class Register_Account : Window
    {
        private DatabaseHandler _dbHandler;

        public Register_Account()
        {
            InitializeComponent();
            Closing += Register_Closing;
            _dbHandler = new DatabaseHandler();
        }

        private void Register_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            Log_in login_page = new Log_in();
            login_page.Show();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text; 
            string password = passwordTextBox.Text; 

            try
            {
                _dbHandler.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO users (name, password) VALUES (@name, @password)");

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Data not inserted!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to database: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _dbHandler.Close();
            }
        }

    }
}
