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
    /// Interaction logic for FoodTrackerPage.xaml
    /// </summary>
    public partial class FoodTrackerPage : Page
    {
        public int trackerNum;
        public FoodTrackerPage()
        {
            InitializeComponent();
            trackerNum = DataManager.currentUser.Tracker.Count - 1;
        }

        private void FTP_BTNAddFood_Click(object sender, RoutedEventArgs e)
        {
            if(FTP_TBFoodName.Visibility == Visibility.Visible)
            {
                FoodClass food = new FoodClass(FTP_TBFoodName.Text, int.Parse(FTP_TBFoodCalories.Text), int.Parse(FTP_TBFoodProtein.Text), int.Parse(FTP_TBFoodCarbs.Text), int.Parse(FTP_TBFoodFat.Text));
                DataManager.currentUser.Tracker[trackerNum].Foods.Add(food);
                UpdateContent();
                UpdateFoodList();
                FTP_TBFoodName.Text = "Enter Food Name";
                FTP_TBFoodCalories.Text = "Enter Calories";
                FTP_TBFoodProtein.Text = "Enter Protein(g)";
                FTP_TBFoodCarbs.Text = "Enter Carbs(g)";
                FTP_TBFoodFat.Text = "Enter Fat(g)";

                FTP_TBFoodName.Visibility = Visibility.Collapsed;
                FTP_TBFoodCalories.Visibility = Visibility.Collapsed;
                FTP_TBFoodProtein.Visibility = Visibility.Collapsed;
                FTP_TBFoodCarbs.Visibility = Visibility.Collapsed;
                FTP_TBFoodFat.Visibility = Visibility.Collapsed;
            }
            else
            {
                FTP_TBFoodName.Visibility = Visibility.Visible;
                FTP_TBFoodCalories.Visibility = Visibility.Visible;
                FTP_TBFoodProtein.Visibility = Visibility.Visible;
                FTP_TBFoodCarbs.Visibility = Visibility.Visible;
                FTP_TBFoodFat.Visibility = Visibility.Visible;
            }
        }

        private void FTP_TBFoodName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(FTP_TBFoodName.Text == "Enter Food Name")
            {
                FTP_TBFoodName.Text = "";
            }
        }
        private void FTP_TBFoodName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FTP_TBFoodName.Text))
            {
                FTP_TBFoodName.Text = "Enter Food Name";
            }
        }

        private void FTP_TBFoodCalories_GotFocus(object sender, RoutedEventArgs e)
        {
            if(FTP_TBFoodCalories.Text == "Enter Calories")
            {
                FTP_TBFoodCalories.Text = "";
            }
        }

        private void FTP_TBFoodCalories_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FTP_TBFoodCalories.Text))
            {
                FTP_TBFoodCalories.Text = "Enter Calories";
            }
        }

        private void FTP_TBFoodProtein_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FTP_TBFoodProtein.Text == "Enter Protein(g)")
            {
                FTP_TBFoodProtein.Text = "";
            }
        }

        private void FTP_TBFoodProtein_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FTP_TBFoodProtein.Text))
            {
                FTP_TBFoodProtein.Text = "Enter Protein(g)";
            }
        }

        private void FTP_TBFoodCarbs_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FTP_TBFoodCarbs.Text == "Enter Carbs(g)")
            {
                FTP_TBFoodCarbs.Text = "";
            }
        }

        private void FTP_TBFoodCarbs_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FTP_TBFoodCarbs.Text))
            {
                FTP_TBFoodCarbs.Text = "Enter Carbs(g)";
            }
        }

        private void FTP_TBFoodFat_GotFocus(object sender, RoutedEventArgs e)
        {
            if (FTP_TBFoodFat.Text == "Enter Fat(g)")
            {
                FTP_TBFoodFat.Text = "";
            }
        }
        private void FTP_TBFoodFat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FTP_TBFoodFat.Text))
            {
                FTP_TBFoodFat.Text = "Enter Fat(g)";
            }
        }

        private void UpdateContent()
        {
            //update info labels
            FTP_LBCalorieLeftDisplay.Content = DataManager.currentUser.DailyCalorieIntake - DataManager.currentUser.Tracker[trackerNum].GetTotalCaloriesConsumed();
            FTP_LBCalorieConsumed.Content = DataManager.currentUser.Tracker[trackerNum].GetTotalCaloriesConsumed() + " Calories Consumed";
            FTP_LBProteinDisplay.Content = DataManager.currentUser.Tracker[trackerNum].GetTotalProteinConsumed() + "g Protein";
            FTP_LBCarbDisplay.Content = DataManager.currentUser.Tracker[trackerNum].GetTotalCarbsConsumed() + "g Carbs";
            FTP_LBFatDisplay.Content = DataManager.currentUser.Tracker[trackerNum].GetTotalFatConsumed() + "g Fat";

        }
        private void UpdateFoodList()
        {
            FTP_SPFoodLabelList.Children.Clear();
            for (int i = 0; i < DataManager.currentUser.Tracker[trackerNum].Foods.Count; i++)
            {
                
                FoodClass food = DataManager.currentUser.Tracker[trackerNum].Foods[i];
                Label foodNameLB = new Label();
                foodNameLB.Content = food.FoodName + "     ItemID - " + (i + 1);
                foodNameLB.Foreground = new SolidColorBrush(Color.FromRgb(113, 111, 120));
                foodNameLB.Background = new SolidColorBrush(Color.FromRgb(239, 235, 253));
                foodNameLB.FontFamily = new FontFamily("Roboto");
                foodNameLB.HorizontalContentAlignment = HorizontalAlignment.Left;
                foodNameLB.Margin = new Thickness(0, 10, 0, 0);

                Label foodInfoLB = new Label();
                foodInfoLB.Content = food.Protein + "g Protein " + food.Carbs + "g Carbs " + food.Fat + "g Fat";
                foodInfoLB.Foreground = new SolidColorBrush(Color.FromRgb(113, 111, 120));
                foodInfoLB.Background = new SolidColorBrush(Color.FromRgb(239, 235, 253));
                foodInfoLB.FontFamily = new FontFamily("Roboto");
                foodInfoLB.HorizontalContentAlignment = HorizontalAlignment.Left;

                FTP_SPFoodLabelList.Children.Add(foodNameLB);
                FTP_SPFoodLabelList.Children.Add(foodInfoLB);
            }
        }
        private void DeleteFood(int itemID)
        {
            if (int.TryParse(FTP_TBDeleteItemNumber.Text, out int n))
            {
                DataManager.currentUser.Tracker[trackerNum].Foods.RemoveAt(itemID - 1);
            }
        }

        private void FTP_BTNDeleteFood_Click(object sender, RoutedEventArgs e)
        {
            if(FTP_TBDeleteItemNumber.Visibility == Visibility.Visible)
            {
                DeleteFood(int.Parse(FTP_TBDeleteItemNumber.Text));
                UpdateContent();
                UpdateFoodList();
                FTP_TBDeleteItemNumber.Text = "Enter ItemID";
                FTP_TBDeleteItemNumber.Visibility = Visibility.Collapsed;
            }
            else
            {
                FTP_TBDeleteItemNumber.Visibility = Visibility.Visible;
            }
        }

        private void FTP_TBDeleteItemNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            if(FTP_TBDeleteItemNumber.Text == "Enter ItemID")
            {
                FTP_TBDeleteItemNumber.Text = "";
            }
        }

        private void FTP_TBDeleteItemNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FTP_TBDeleteItemNumber.Text))
            {
                FTP_TBDeleteItemNumber.Text = "Enter ItemID";
            }
        }
    }
}
