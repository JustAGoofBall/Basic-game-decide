using MySql.Data.MySqlClient;
using System;

namespace Basic_game_decide.Classes
{
    public class DatabaseHandler
    {
        private MySqlConnection _connection;
        private string _server;
        private string _database;
        private string _uid;
        private string _password;

        public MySqlConnection Connection
        {
            get { return _connection; }
        }

        public DatabaseHandler()
        {
            _server = "localhost";
            _database = "basicgame";
            _uid = "root";
            _password = "";
            string connectionString = $"SERVER={_server};PORT=3308;DATABASE={_database};UID={_uid};PASSWORD={_password};";
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

        public bool CheckUsernameExists(string username)
        {
            try
            {
                Open();

                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM playertabel WHERE naam = @username", _connection);
                command.Parameters.AddWithValue("@username", username);

                int result = Convert.ToInt32(command.ExecuteScalar());
                return result > 0;
            }
            finally
            {
                Close();
            }
        }

        public int GetScore(string username)
        {
            try
            {
                Open();

                MySqlCommand command = new MySqlCommand("SELECT s.score FROM playertabel p INNER JOIN scores s ON p.id = s.id WHERE p.naam = @username", _connection);
                command.Parameters.AddWithValue("@username", username);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                return 0;
            }
            finally
            {
                Close();
            }
        }

        public void UpdateScore(string username, int score)
        {
            try
            {
                Open();

                MySqlCommand command = new MySqlCommand("UPDATE scores s INNER JOIN playertabel p ON p.id = s.id SET s.score = @score WHERE p.naam = @username", _connection);
                command.Parameters.AddWithValue("@score", score);
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }

        public void InsertScore(string username, int score)
        {
            try
            {
                Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO scores (score, id) VALUES (@score, (SELECT id FROM playertabel WHERE naam = @username))", _connection);
                command.Parameters.AddWithValue("@score", score);
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }

        public bool DeleteAccount(string username, string password)
        {
            try
            {
                Open();

                MySqlCommand command = new MySqlCommand("DELETE FROM playertabel WHERE naam = @username AND wachtwoord = @password", _connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            finally
            {
                Close();
            }
        }


    }
}
