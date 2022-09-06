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
using System.Windows.Controls.Primitives;
using CalorieTracker.Storage;

namespace CalorieTracker
{
    /// <summary>
    /// Interaction logic for ExerciseTrackerPage.xaml
    /// </summary>
    public partial class ExerciseTrackerPage : Page
    {
        int trackerNum;
        public ExerciseTrackerPage()
        {
            InitializeComponent();
            trackerNum = DataManager.currentUser.Tracker.Count - 1;
        }

        private void ETP_TBExerciseName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(ETP_TBExerciseName.Text == "Exercise Name")
            {
                ETP_TBExerciseName.Text = "";
            }
        }

        private void ETP_TBExerciseName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ETP_TBExerciseName.Text))
            {
                ETP_TBExerciseName.Text = "Exercise Name";
            }
        }

        private void ETP_TBExerciseDurationMinutes_GotFocus(object sender, RoutedEventArgs e)
        {
            if( ETP_TBExerciseDurationMinutes.Text == "Exercise Duration(Minutes)")
            {
                ETP_TBExerciseDurationMinutes.Text = "";
            }
        }
        private void ETP_TBExerciseDurationMinutes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ETP_TBExerciseDurationMinutes.Text))
            {
                ETP_TBExerciseDurationMinutes.Text = "Exercise Duration(Minutes)";
            }
        }

        private void ETP_TBExerciseDurationSeconds_GotFocus(object sender, RoutedEventArgs e)
        {
            if (ETP_TBExerciseDurationSeconds.Text == "Exercise Duration(Seconds)")
            {
                ETP_TBExerciseDurationSeconds.Text = "";
            }
        }

        private void ETP_TBExerciseDurationSeconds_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ETP_TBExerciseDurationSeconds.Text))
            {
                ETP_TBExerciseDurationSeconds.Text = "Exercise Duration(Seconds)";
            }
        }

        private void ETP_TBExerciseDeleteItemID_GotFocus(object sender, RoutedEventArgs e)
        {
            if(ETP_TBExerciseDeleteItemID.Text == "Exercise ID")
            {
                ETP_TBExerciseDeleteItemID.Text = "";
            }
        }

        private void ETP_TBExerciseDeleteItemID_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ETP_TBExerciseDeleteItemID.Text))
            {
                ETP_TBExerciseDeleteItemID.Text = "Exercise ID";
            }
        }

        private void ETP_BTNAddExercise_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ETP_TBExerciseName.Visibility == Visibility.Collapsed)
                {
                    ETP_TBExerciseName.Visibility = Visibility.Visible;
                    ETP_TBExerciseCaloriesBurnt.Visibility = Visibility.Visible;
                    ETP_TBExerciseDurationMinutes.Visibility = Visibility.Visible;
                    ETP_TBExerciseDurationSeconds.Visibility = Visibility.Visible;
                }
                else
                {
                    float minutes = float.Parse(ETP_TBExerciseDurationMinutes.Text);
                    float seconds = float.Parse(ETP_TBExerciseDurationSeconds.Text);
                    ExerciseClass exercise = new ExerciseClass(ETP_TBExerciseName.Text, int.Parse(ETP_TBExerciseCaloriesBurnt.Text), minutes + (seconds / 60));
                    DataManager.currentUser.Tracker[trackerNum].Exercises.Add(exercise);
                    UpdateExerciseStats();
                    UpdateExerciseList();
                    ETP_TBExerciseName.Text = "Exercise Name";
                    ETP_TBExerciseCaloriesBurnt.Text = "Calories Burnt";
                    ETP_TBExerciseDurationMinutes.Text = "Exercise Duration(Minutes)";
                    ETP_TBExerciseDurationSeconds.Text = "Exercise Duration(Seconds)";

                    ETP_TBExerciseName.Visibility = Visibility.Collapsed;
                    ETP_TBExerciseCaloriesBurnt.Visibility = Visibility.Collapsed;
                    ETP_TBExerciseDurationMinutes.Visibility = Visibility.Collapsed;
                    ETP_TBExerciseDurationSeconds.Visibility = Visibility.Collapsed;
                }
            }
            catch
            {
                Popup addExerciseInvalidInputPopup = new Popup();
                TextBlock tb = new TextBlock();
                tb.Text = "Ivalid Input";
                addExerciseInvalidInputPopup.Child = tb;
            }

        }

        private void ETP_TBExerciseCaloriesBurnt_GotFocus(object sender, RoutedEventArgs e)
        {
            if( ETP_TBExerciseCaloriesBurnt.Text == "Calories Burnt")
            {
                ETP_TBExerciseCaloriesBurnt.Text = "";
            }
        }

        private void ETP_TBExerciseCaloriesBurnt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ETP_TBExerciseCaloriesBurnt.Text))
            {
                ETP_TBExerciseCaloriesBurnt.Text = "Calories Burnt";
            }
        }
        private void UpdateExerciseStats()
        {
            ETP_LBCalorieBurntDisplay.Content = DataManager.currentUser.Tracker[trackerNum].GetTotalCaloriesBurnt();
            ETP_LBDurationDisplay.Content = DataManager.currentUser.Tracker[trackerNum].GetTotalDuration();
        }
        private void UpdateExerciseList()
        {
            ETP_SPExerciseLabelList.Children.Clear();
            for (int i = 0; i < DataManager.currentUser.Tracker[trackerNum].Exercises.Count; i++)
            {

                ExerciseClass exercise = DataManager.currentUser.Tracker[trackerNum].Exercises[i];
                Label exerciseLB = new Label();
                exerciseLB.Content = exercise.ExerciseName + " Duration: " + exercise.Duration + "     ItemID - " + (i + 1);
                exerciseLB.Foreground = new SolidColorBrush(Color.FromRgb(113, 111, 120));
                exerciseLB.Background = new SolidColorBrush(Color.FromRgb(239, 235, 253));
                exerciseLB.FontFamily = new FontFamily("Roboto");
                exerciseLB.HorizontalContentAlignment = HorizontalAlignment.Left;
                exerciseLB.Margin = new Thickness(0, 10, 0, 0);


                ETP_SPExerciseLabelList.Children.Add(exerciseLB);
            }
        }

        private void ETP_BTNDeleteExercise_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ETP_TBExerciseDeleteItemID.Visibility == Visibility.Collapsed)
                {
                    ETP_TBExerciseDeleteItemID.Visibility = Visibility.Visible;
                }
                else
                {
                    int deleteAtIndex = int.Parse(ETP_TBExerciseDeleteItemID.Text) - 1;
                    DataManager.currentUser.Tracker[trackerNum].Exercises.RemoveAt(deleteAtIndex);
                    UpdateExerciseList();
                    UpdateExerciseStats();
                    ETP_TBExerciseDeleteItemID.Text = "Exercise ID";
                    ETP_TBExerciseDeleteItemID.Visibility = Visibility.Collapsed;

                }
            }
            catch
            {

            }
        }

        private void ETP_BTNNextTracker_Click(object sender, RoutedEventArgs e)
        {
            if (DataManager.currentUser.Tracker[trackerNum+1] != null)
            {
                trackerNum++;
                UpdateExerciseStats();
                UpdateExerciseList();
            }
            
        }

        private void ETP_BTNPrevTracker_Click(object sender, RoutedEventArgs e)
        {
            if (DataManager.currentUser.Tracker[trackerNum - 1] != null)
            {
                trackerNum--;
                UpdateExerciseStats();
                UpdateExerciseList();
            }
        }
    }
}
