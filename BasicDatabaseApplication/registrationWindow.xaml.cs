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
    
    public partial class registrationWindow : Window
    {
        public registrationWindow()
        {
            InitializeComponent();

        }
        private void regSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            DBaccess access = new DBaccess();
            string name = usernameTextbox.Text;
            string password = passwordTextbox.Text;
            string email = emailTextbox.Text;

            access.addData(name, password, email);

            MessageBox.Show("Thanks for registering a new account!");
            this.Close();


        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
