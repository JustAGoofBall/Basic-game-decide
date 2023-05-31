using MySql.Data.MySqlClient;

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
    }
}