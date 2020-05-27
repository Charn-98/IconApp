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

namespace _02_IconApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<decimal> oNumbers = new List<decimal>();

        public MainWindow()
        {
            InitializeComponent();
        }
        

        public void Validate(string ANumber)
        {
            bool bValid = false;
            decimal dResult = 0;

            try
            {
                if (decimal.TryParse(ANumber, out dResult))
                    bValid = true;

                if (!bValid)
                {
                    lblResult.Content = $"Invalid number value";
                }
                else
                {
                    lblResult.Content = string.Empty;
                    if (oNumbers.Count != 5)
                    {
                        oNumbers.Add(dResult);
                        lblNumber.Content = $"#{oNumbers.Count}";
                        lblResult.Content = "Added!";
                    }

                    if (oNumbers.Count == 5)
                    {
                        btnAdd.IsEnabled = false;
                        txtNumber1.IsEnabled = false;
                        Calculate(oNumbers);
                    }
                }
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
        
        private void Calculate(List<decimal> ANumbers)
        {
            try
            {
                decimal dResult = 0;
                foreach (decimal item in ANumbers)
                {
                    dResult += item;
                }
                
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Validate(txtNumber1.Text);
        }
    }
}
