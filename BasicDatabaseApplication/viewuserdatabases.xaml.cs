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
using System.Data ;

namespace BasicDatabaseApplication
{
    /// <summary>
    /// Interaction logic for viewuserdatabases.xaml
    /// </summary>
    public partial class viewuserdatabases : Window
    {
        public viewuserdatabases()
        {
            InitializeComponent(); ;


        }
        public void viewRefresh()
        {
            DBaccess access = new DBaccess();
            try
            {
                string selectedDB = DBListView.SelectedItem.ToString();
                if (selectedDB != "")
                {

                    DataTable currentData = access.ViewTableData(selectedDB);
                    dbgrid.ItemsSource = currentData.DefaultView;


                }
            }
            catch (Exception r)
            {
                MessageBox.Show(Convert.ToString(r));
            }
        }
        private void DBListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (viewbutton.IsEnabled == false)
            {
                string selectedDB = DBListView.SelectedItem.ToString();
                if (selectedDB != "")
                {
                    viewbutton.IsEnabled = true;

                }
            }
            else { return; }

        }

        private void viewbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedDB = DBListView.SelectedItem.ToString();
                if (selectedDB != "")
                {
                    DBaccess access = new DBaccess();
                    DataTable currentData = access.ViewTableData(selectedDB);
                    dbgrid.ItemsSource = currentData.DefaultView;
                    addDataButton.Opacity = 100;
                    addDataButton.IsEnabled = true;

                }
            }
            catch (Exception r)
            {
                MessageBox.Show(Convert.ToString(r));
            }


        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {



            this.Close();


        }

        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dbgrid.SelectedItem;
            string selectedId = dataRow.Row.ItemArray[0].ToString();



            for (int i = 0; i < dataRow.Row.ItemArray.Length; i++)
            {
                if (i == 0)
                {
                    editItem5.Opacity = 0;
                    editItem5.Text = "";

                    if (dataRow.Row.ItemArray[i].ToString() != "")

                    {
                        editItem1.Text = dataRow.Row.ItemArray[i].ToString();
                        editItem1.Opacity = 100;
                    }
                }
                if (i == 1)
                {
                    editItem5.Opacity = 0;
                    editItem5.Text = "";

                    if (dataRow.Row.ItemArray[i].ToString() != "")
                    {
                        editItem2.Text = dataRow.Row.ItemArray[i].ToString();
                        editItem2.Opacity = 100;
                    }
                }
                if (i == 2)
                {
                    editItem5.Opacity = 0;
                    editItem5.Text = "";

                    if (dataRow.Row.ItemArray[i].ToString() != "")
                    {
                        editItem3.Text = dataRow.Row.ItemArray[i].ToString();
                        editItem3.Opacity = 100;
                    }
                }
                if (i == 3)
                {
                    editItem5.Opacity = 0;
                    editItem5.Text = "";

                    if (dataRow.Row.ItemArray[i].ToString() != "")
                    {
                        editItem4.Text = dataRow.Row.ItemArray[i].ToString();
                        editItem4.Opacity = 100;
                    }
                }
                if (i == 4)
                {
                    editItem5.Opacity = 0;
                    editItem5.Text = "";

                    if (dataRow.Row.ItemArray[i].ToString() != "")
                    {
                        editItem5.Text = dataRow.Row.ItemArray[i].ToString();
                        editItem5.Opacity = 100;
                    }
                }
                deleteItemButton.IsEnabled = true;
                deleteItemButton.Opacity = 100;


            }
        }

        private void dbgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                string selectedDB = dbgrid.SelectedItem.ToString();
                if (selectedDB != "")
                {
                    editbutton.IsEnabled = true;

                }


            }
            catch (Exception p)
            { Console.WriteLine(p); }
        }

        private void editItems_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changeButton != null)

            {
                changeButton.IsEnabled = true;
                changeButton.Opacity = 100;
            }
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            DBaccess access = new DBaccess();
            string colOne = dbgrid.Columns[0].Header.ToString();
            string colTwo = dbgrid.Columns[1].Header.ToString();
            string colThree = dbgrid.Columns[2].Header.ToString();
            string colFour = dbgrid.Columns[3].Header.ToString();
            string colFive = dbgrid.Columns[4].Header.ToString();

            access.editDBEntry(DBListView.SelectedItem.ToString(), colOne, colTwo, colThree, colFour, colFive, editItem1.Text, editItem2.Text, editItem3.Text, editItem4.Text, editItem5.Text);
            changeButton.Opacity = 0;
            try
            {
                string selectedDB = DBListView.SelectedItem.ToString();
                if (selectedDB != "")
                {

                    DataTable currentData = access.ViewTableData(selectedDB);
                    dbgrid.ItemsSource = currentData.DefaultView;


                }
            }
            catch (Exception r)
            {
                MessageBox.Show(Convert.ToString(r));
            }
        }

        private void addDataButton_Click(object sender, RoutedEventArgs e)
        {

            DBaccess access = new DBaccess();
            string colOne = dbgrid.Columns[0].Header.ToString();
            string colTwo = dbgrid.Columns[1].Header.ToString();
            string colThree = dbgrid.Columns[2].Header.ToString();
            string colFour = dbgrid.Columns[3].Header.ToString();
            string colFive = dbgrid.Columns[4].Header.ToString();
            string col1type = "Integer";
            string col2type = "Text";
            string col3type = "Text";
            string col4type = "Text";
            string col5type = "Text";

            try
            {
                access.createDB(DBListView.SelectedItem.ToString(), colOne, colTwo, colThree, colFour, colFive, col1type, col2type, col3type, col4type, col5type);

                newDBWindow window = new newDBWindow();


                createDBSection2 zr = new createDBSection2();
                window.Content = zr;
                try
                {
                    zr.colOneLabel.Content = colOne; zr.colTwoLabel.Content = colTwo; zr.colThreeLabel.Content = colThree; zr.colFourLabel.Content = colFour; zr.colFiveLabel.Content = colFive; zr.tableLabel.Text = DBListView.SelectedItem.ToString();
                    window.Show();
                }
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

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DBaccess access = new DBaccess();
            string colOne = dbgrid.Columns[0].Header.ToString();
            access.deleteSingleItem(DBListView.SelectedItem.ToString(), colOne, editItem1.Text);
            viewRefresh();
            deleteItemButton.IsEnabled = false;
            deleteItemButton.Opacity = 0;
        }
    }
}
