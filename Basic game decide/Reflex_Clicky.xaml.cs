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

namespace Basic_game_decide
{
    /// <summary>
    /// Interaction logic for Reflex_Clicky.xaml
    /// </summary>
    public partial class Reflex_Clicky : Window
    {
        public Reflex_Clicky()
        {
            InitializeComponent();
            Closing += Reflex_Clicky_Closing;
        }
        private void Start(object sender, RoutedEventArgs e)
        {
            Reflex_Clicky Reflex_Clicky = new Reflex_Clicky();

            Reflex_Clicky.Show();
            this.Hide();
        }

        private void Reflex_Clicky_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
