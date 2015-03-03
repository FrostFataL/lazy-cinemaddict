using LazyCinemaddict.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AllFilmsList.xaml
    /// </summary>
    public partial class AllFilmsList : Window
    {        
        public AllFilmsList(ListViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
