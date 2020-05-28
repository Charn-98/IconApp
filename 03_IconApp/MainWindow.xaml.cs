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

namespace _03_IconApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<int, string> oNames = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
            dtResults.ItemsSource = oNames; //untilizing binding expression
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int iCount = oNames.Count + 1;

            try
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    oNames.Add(iCount, txtName.Text);
                    dtResults.ItemsSource = null;
                    dtResults.ItemsSource = oNames; //utilizing binding expression
                    txtName.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Field was left empty. Please provide valid name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! We ran into a problem. Please try again later.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void BtnGet_Click(object sender, RoutedEventArgs e)
        {
            string sName = string.Empty;
            int iItemNumber = 0;

            try
            {
                if (int.TryParse(txtNumber.Text, out iItemNumber))
                {
                    if (iItemNumber <= oNames.Count)
                    {
                        if (oNames.Count(x => x.Key == iItemNumber) != 0)
                        {
                            sName = oNames.Where(x => x.Key == iItemNumber)
                                          .Select(x => x.Value)
                                          .FirstOrDefault();

                            lblResult.Content = $"{iItemNumber}: {sName}";
                        }
                        else
                        {
                            MessageBox.Show($"Corresponding name could not be found for {iItemNumber}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        if(oNames.Count == 0)
                            MessageBox.Show($"Sorry, there is nothing do display for number {iItemNumber}. Please add values to the list", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                            MessageBox.Show($"Sorry, there is nothing do display for number {iItemNumber}. Please enter numbers 1 - {oNames.Count}", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Number {txtNumber.Text} is invalid. Name could not be retrieved", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                    MessageBox.Show($"There has been a problem. Please try again", "System Error", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
