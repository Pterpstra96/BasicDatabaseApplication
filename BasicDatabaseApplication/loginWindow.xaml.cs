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
    /// Interaction logic for loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            loggedInDBpage logDB = new loggedInDBpage();
            DBaccess access = new DBaccess();
            string name = usernameBox.Text;
            string password = passwordBox.Text;
           bool userValid =  access.checkUser(name, password);
            if (userValid == true)
            {
                logDB.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Either the username or password is not valid. Please try again.");
            
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
