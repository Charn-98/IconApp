using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace IconApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal dNumber1 = Convert.ToDecimal(txtNumber1.Text);
                decimal dNumber2 = Convert.ToDecimal(txtNumber2.Text);
                decimal dNumber3 = Convert.ToDecimal(txtNumber3.Text);
                decimal dNumber4 = Convert.ToDecimal(txtNumber4.Text);
                decimal dNumber5 = Convert.ToDecimal(txtNumber5.Text);

                decimal dResult = dNumber1 + dNumber2 + dNumber3 + dNumber4 + dNumber5;
                lblResult.Content = $"Result: {dResult}";
            }
            catch (OverflowException)
            {
                lblResult.Content = $"One of the entered numbers are too large. Please try again.";
            }
            catch (Exception)
            {
                lblResult.Content = $"There has been a problem calculating the result. Please try again.";
            }
        }

        private void IsDecimal(object sender, TextCompositionEventArgs e)
        {
            bool bValid = false;
            decimal dResult = 0;

            //check for proper decimal seperator 
            string sDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (e.Text == sDecimal || decimal.TryParse(e.Text, out dResult))
                bValid = true;

            if (!bValid)
            {
                lblResult.Content = $"Invalid number value";
                e.Handled = true;
            }
            else
            {
                lblResult.Content = string.Empty;
            }
        }
    }
}
