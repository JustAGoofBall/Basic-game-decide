using Basic_game_decide.Classes;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for Delete_Account.xaml
    /// </summary>
    public partial class Delete_Account : Window
    {
        private DatabaseHandler _connection;
        public Delete_Account()
        {
            InitializeComponent();
            _connection = new DatabaseHandler();
        }

        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                bool success = _connection.DeleteAccount(username, password);

                if (success)
                {
                    MessageBox.Show("Account deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete account. Please check your username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }
}
