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
    /// <summary>
    /// Interaction logic for createDBSection2.xaml
    /// </summary>
    public partial class createDBSection2 : UserControl
    {
        public createDBSection2()
        {
            InitializeComponent();
            
        }

        private void addData_Click(object sender, RoutedEventArgs e)
        {
            bool added = false;
            DBaccess access = new DBaccess();
            if (r1c1.Text != "" )
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r1c1.Text, r1c2.Text, r1c3.Text, r1c4.Text, r1c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }
            
            }
            if (r2c1.Text != "")
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r2c1.Text, r2c2.Text, r2c3.Text, r2c4.Text, r2c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }

            }
            if (r3c1.Text != "")
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r3c1.Text, r3c2.Text, r3c3.Text, r3c4.Text, r3c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }

            }
            if (r4c1.Text != "")
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r4c1.Text, r4c2.Text, r4c3.Text, r4c4.Text, r4c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }

            }
            if (r5c1.Text != "")
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r5c1.Text, r5c2.Text, r5c3.Text, r5c4.Text, r5c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }

            }
            if (r6c1.Text != "")
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r6c1.Text, r6c2.Text, r6c3.Text, r6c4.Text, r6c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }

            }
            if (r7c1.Text != "")
            {
                try
                {
                    access.addDBData(tableLabel.Text, morph(colOneLabel.Content), morph(colTwoLabel.Content), morph(colThreeLabel.Content), morph(colFourLabel.Content), morph(colFiveLabel.Content), r7c1.Text, r7c2.Text, r7c3.Text, r7c4.Text, r7c5.Text);
                    added = true;
                }
                catch (Exception r)
                { Console.WriteLine(r); }

            }
            if (added == true)
            {
                MessageBox.Show("The information has been added");
                clearTextBoxes();
            }

        }
        public string morph(object input)
        { string value = Convert.ToString(input);
            return value;
        }

        private void clearData_Click(object sender, RoutedEventArgs e)
        {
            clearTextBoxes();
    }
    private void clearTextBoxes()
    {
            try
            {
                for (int i = 0; i < mainGrid.Children.Count; i++)
                {
                    try
                    {

                        if (mainGrid.Children[i].GetType() == typeof(TextBox))
                        { ((TextBox)mainGrid.Children[i]).Text = ""; }
                        else { }

                    }
                    catch (Exception m)
                    { Console.WriteLine(m); }
                }
            }
            catch (Exception r)
            { Console.WriteLine(r); }
        }
    }

}
