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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicDatabaseApplication
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DBaccess access = new DBaccess();

            try
            {
                access.intializeDataBase();   // INITIALIZES SQL SCRIPT TO CONSTRUCT DB
            }
            catch (Exception e)
            { Console.WriteLine(e); }
        }

        private void registerNavButton_Click(object sender, RoutedEventArgs e)
        {
            registrationWindow reg = new registrationWindow();
            
            reg.Show();
        }

        private void loginnavButton_Click(object sender, RoutedEventArgs e)
        {
            loginWindow log = new loginWindow();
            log.Show();
        }

        private void uninstallButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
