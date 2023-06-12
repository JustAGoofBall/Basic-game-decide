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
    }
}
