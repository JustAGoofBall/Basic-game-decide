using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_game_decide.Classes
{
    public class User
    {
        public string Username { get; set; }
        public int UserId { get; set; }

        public User(string username, int userId)
        {
            Username = username;
            UserId = userId;
        }
    }
}
