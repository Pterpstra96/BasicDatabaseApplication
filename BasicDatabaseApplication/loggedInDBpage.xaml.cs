using BasicDatabaseApplication.Services;
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
    /// Interaction logic for loggedInDBpage.xaml
    /// </summary>
    public partial class loggedInDBpage : Window
    {
        public loggedInDBpage()
        {
            InitializeComponent();
        }

        

        private void newDbButton_Click(object sender, RoutedEventArgs e)
        {
            newDBWindow db = new newDBWindow();
            db.Show();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            DBaccess access = new DBaccess();
            access.signUserOut();
            this.Close();
        }

        private void viewDBButton_Click(object sender, RoutedEventArgs e)
        {
            DBaccess access = new DBaccess();
            List<string> dbList = access.currentUserDBList();
            viewuserdatabases data = new viewuserdatabases();
            data.DBListView.ItemsSource = dbList;
            data.titleLabel.Content = access.getUserName() + "'s Database Tables:" ;
            data.Show();
        }
    }
}
