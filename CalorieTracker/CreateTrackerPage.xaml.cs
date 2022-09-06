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
using CalorieTracker.Storage;
namespace CalorieTracker
{
    /// <summary>
    /// Interaction logic for CreateTrackerPage.xaml
    /// </summary>
    public partial class CreateTrackerPage : Page
    {
        public CreateTrackerPage()
        {
            InitializeComponent();
        }

        private void CTP_BTNCreateTracker_Click(object sender, RoutedEventArgs e)
        {
            
            int day = 0;
            int month = 0;
            int year = 0;
            //check if num and is valid num
            if (int.TryParse(CTP_TBMonthInput.Text, out int m) && int.Parse(CTP_TBMonthInput.Text) >= 1 && int.Parse(CTP_TBMonthInput.Text) <= 12)
            {
                month = int.Parse(CTP_TBMonthInput.Text);
            }
            if (int.TryParse(CTP_TBDayInput.Text, out int n) && int.Parse(CTP_TBDayInput.Text) >= 1 && int.Parse(CTP_TBDayInput.Text) <= 31)
            {
                day = int.Parse(CTP_TBDayInput.Text);
            }
            if (int.TryParse(CTP_TBYearInput.Text, out int o) && int.Parse(CTP_TBYearInput.Text) >= 1900 && int.Parse(CTP_TBYearInput.Text) <= 2100)
            {
                year = int.Parse(CTP_TBYearInput.Text);
            }



            if(month > 0 && month < 13 && day > 0 && day < 32 && year > 1912 && year < 2035)
            {
                TrackerClass tracker = new TrackerClass(month, day, year);
                DataManager.currentUser._trackers.Add(tracker);
                CTP_LBNotificationContent.Content = "Succuss! A new tracker for " + " has been added.";

            }
            CTP_TBDayInput.Text = "Example 24";
            CTP_TBMonthInput.Text = "Example 8";
            CTP_TBYearInput.Text = "Example 2022";
        }

        private void CTP_TBDayInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if(CTP_TBDayInput.Text == "Example 24")
            {
                CTP_TBDayInput.Text = "";
            }
        }

        private void CTP_TBMonthInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CTP_TBMonthInput.Text == "Example 8")
            {
                CTP_TBMonthInput.Text = "";
            }
        }

        private void CTP_TBYearInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CTP_TBYearInput.Text == "Example 2022")
            {
                CTP_TBYearInput.Text = "";
            }
        }

        private void CTP_TBDayInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CTP_TBDayInput.Text))
            {
                CTP_TBDayInput.Text = "Example 24";
            }
        }
        private void CTP_TBMonthInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CTP_TBMonthInput.Text))
            {
                CTP_TBMonthInput.Text = "Example 8";
            }
        }
        private void CTP_TBYearInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CTP_TBYearInput.Text))
            {
                CTP_TBYearInput.Text = "Example 2022";
            }
        }


    }
}
