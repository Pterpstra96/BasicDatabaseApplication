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

namespace BasicDatabaseApplication
{
    /// <summary>
    /// Interaction logic for viewuserdatabases.xaml
    /// </summary>
    public partial class viewuserdatabases : Window
    {
        public viewuserdatabases()
        {
            InitializeComponent();
           

        }

        private void DBListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DBListView.SelectedItem.ToString() = 
        }
    }
}
