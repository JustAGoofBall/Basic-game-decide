using MySql.Data.MySqlClient;
using System;

namespace Basic_game_decide.Classes
{
    internal class DatabaseHandler
    {
        private MySqlConnection _connection;

        public DatabaseHandler()
        {
            // Set the connection string
            string connectionString = "server=localhost;database=basicgame;uid=root;pwd=;";

            // Create a new MySqlConnection object
            _connection = new MySqlConnection(connectionString);
        }

        public void Open()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void Close()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
    }
}
