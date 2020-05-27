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

namespace _05_IconApp
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

        private void BtnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = string.Empty;

            var dtDOB = new DateTime();
            var dtBirthday = new DateTime();
            var dtNextBirthday = new DateTime();
            string sDateOfBirth = string.Empty;
            string sIDNumber = string.Empty;
            string sHasBirthdayPassed = string.Empty;
            int iAge = 0;
            int iYear = 0;
            int iMonth = 0;
            int iDay = 0;
            bool bHasBirthdayPassed = false;

            sIDNumber = txtIDNumber.Text;

            try
            {
                if (sIDNumber.Count() == 13)
                {
                    if (IsDigitsOnly(sIDNumber))
                    {
                        iYear = Convert.ToInt16(sIDNumber.Substring(0, 2));
                        iMonth = Convert.ToInt16(sIDNumber.Substring(2, 2));
                        iDay = Convert.ToInt16(sIDNumber.Substring(4, 2));

                        if (iYear < (DateTime.Now.Year % 100))
                            iYear += 2000;
                        else
                            iYear += 1900;

                        dtDOB = new DateTime(iYear, iMonth, iDay);
                        dtBirthday = new DateTime(DateTime.Now.Year, iMonth, iDay);

                        //GET DATE OF BIRTH
                        sDateOfBirth = dtDOB.ToString("dd MMMM yyyy");

                        //GET HAS BIRTHDAY PASSED
                        if (dtBirthday < DateTime.Now)
                            bHasBirthdayPassed = true;

                        //GET NEXT BIRTHDAY
                        if (bHasBirthdayPassed)
                            dtNextBirthday = new DateTime(DateTime.Now.Year + 1, iMonth, iDay);
                        else
                            dtNextBirthday = dtBirthday;

                        //GET AGE
                        iAge = DateTime.Now.Year - dtDOB.Year;

                        if (DateTime.Now.Month < dtDOB.Month 
                            || (DateTime.Now.Month == dtDOB.Month 
                            && DateTime.Now.Day < dtDOB.Day))
                            iAge--;

                        sHasBirthdayPassed = bHasBirthdayPassed ? "Yes" : "No";

                        txtResults.Text = $"Date of Birth: {sDateOfBirth}{Environment.NewLine}" +
                                          $"Age: {iAge}{Environment.NewLine}" +
                                          $"Has birthday passed?: {sHasBirthdayPassed}{Environment.NewLine}" +
                                          $"Next birthday: {dtNextBirthday.ToString("dd MMMM yyyy")}";
                    }
                    else
                    {
                        MessageBox.Show("ID Number is invalid. Please try again.", "Invalid ID Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("ID Number has an invalid length. Please try again.", "Invalid ID Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong :(", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        bool IsDigitsOnly(string AIDNumber)
        {
            foreach (char item in AIDNumber)
            {
                if (item < '0' || item > '9')
                    return false;
            }

            return true;
        }
    }
}
