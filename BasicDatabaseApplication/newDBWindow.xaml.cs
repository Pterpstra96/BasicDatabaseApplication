using BasicDatabaseApplication.Models;
using BasicDatabaseApplication.Services;
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

namespace BasicDatabaseApplication
{
    
    public partial class newDBWindow : Window
    {
        
        public newDBWindow()
        {
            InitializeComponent();
            ObservableCollection<string> cmbDataType = new ObservableCollection<string>(); ObservableCollection<string> idComboType = new ObservableCollection<string>();
            cmbDataType.Add("Text"); cmbDataType.Add("Integer"); cmbDataType.Add("Date/Time"); idComboType.Add("Integer");
            dataTypeComboOne.ItemsSource = idComboType; dataTypeComboOne.SelectedIndex = 0 ; dataTypeComboTwo.ItemsSource = cmbDataType; dataTypeComboThree.ItemsSource = cmbDataType; dataTypeComboFour.ItemsSource = cmbDataType; dataTypeComboFive.ItemsSource = cmbDataType;

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DBaccess access = new DBaccess();
            string tableName = tableNameBox.Text;
            string colOne = colOneNameBox.Text; string col1type = dataTypeComboOne.Text;
            string colTwo = colTwoNameBox.Text; string col2type = dataTypeComboTwo.Text;
            string colThree = colThreeNameBox.Text; string col3type = dataTypeComboThree.Text;
            string colFour = colFourNameBox.Text; string col4type = dataTypeComboFour.Text;
            string colFive = colFiveNameBox.Text; string col5type = dataTypeComboFive.Text;

            try { access.createDB(tableName, colOne, colTwo, colThree, colFour, colFive, col1type, col2type, col3type, col4type, col5type);


                

                createDBSection2 zr = new createDBSection2();
                this.Content = zr;
                try { zr.colOneLabel.Content = colOne; zr.colTwoLabel.Content = colTwo; zr.colThreeLabel.Content = colThree; zr.colFourLabel.Content = colFour; zr.colFiveLabel.Content = colFive; zr.tableLabel.Text = tableName; }
                catch (Exception p)
                {
                    Console.WriteLine(p);
                }
            }
            

            // data from the added section needs to be moved enmasse
            catch (Exception red)
                {
                MessageBox.Show(Convert.ToString(red));
            
            
            }





        }

    }
}
