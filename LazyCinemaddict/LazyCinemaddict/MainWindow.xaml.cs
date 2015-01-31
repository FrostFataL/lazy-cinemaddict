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

namespace LazyCinemaddict
{
    /// <summary>
    /// Interaction logic for NewFilm.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkWithFile qwe;

        public MainWindow()
        {
            InitializeComponent();
            qwe = new WorkWithFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewFilm film = new AddNewFilm(qwe);
            //this.Hide();
            film.Owner = this;
            film.ShowDialog();
            //this.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
