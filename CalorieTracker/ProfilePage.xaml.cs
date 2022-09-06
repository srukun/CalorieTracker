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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            MakeProfileInfoReadOnly();
            PP_LBInitials.Content = "" + DataManager.currentUser.FirstName[0] + DataManager.currentUser.LastName[0];
        }
        private void MakeProfileInfoReadOnly()
        {
            SetTextBoxPropertiesView(PP_TBEmail);
            PP_TBEmail.Text = DataManager.currentUser.UserEmail;
            SetTextBoxPropertiesView(PP_TBUsername);
            PP_TBUsername.Text = DataManager.currentUser.Username;
            SetTextBoxPropertiesView(PP_TBPassword);
            PP_TBPassword.Text = DataManager.currentUser.Password;
            SetTextBoxPropertiesView(PP_TBFirstName);
            PP_TBFirstName.Text = DataManager.currentUser.FirstName;
            SetTextBoxPropertiesView(PP_TBLastName);
            PP_TBLastName.Text = DataManager.currentUser.LastName;
            SetTextBoxPropertiesView(PP_TBCurrentWeight);
            PP_TBCurrentWeight.Text = DataManager.currentUser.CurrentWeight.ToString();
            SetTextBoxPropertiesView(PP_TBGoalWeight);
            PP_TBGoalWeight.Text = DataManager.currentUser.GoalWeight.ToString();
        }
        private void MakeProfileInfoEditable()
        {
            SetTextBoxPropertiesEdit(PP_TBEmail);
            SetTextBoxPropertiesEdit(PP_TBUsername);
            SetTextBoxPropertiesEdit(PP_TBPassword);
            SetTextBoxPropertiesEdit(PP_TBFirstName);
            SetTextBoxPropertiesEdit(PP_TBLastName);
            SetTextBoxPropertiesEdit(PP_TBCurrentWeight);
            SetTextBoxPropertiesEdit(PP_TBGoalWeight);
        }

        private void SetTextBoxPropertiesView(TextBox tb)
        {
            tb.IsReadOnly = true;
            tb.Background = new SolidColorBrush(Color.FromRgb(242, 240, 247));
            tb.Foreground = new SolidColorBrush(Color.FromRgb(171, 169, 176));
            tb.BorderThickness = new Thickness(0, 0, 0, 0);
        }
        private void SetTextBoxPropertiesEdit(TextBox tb)
        {
            tb.IsReadOnly = false;
            tb.Background = new SolidColorBrush(Color.FromRgb(239, 235, 253));
            tb.Foreground = new SolidColorBrush(Color.FromRgb(113, 111, 120));
            tb.BorderBrush = new SolidColorBrush(Color.FromRgb(131, 98, 240));
            tb.BorderThickness = new Thickness(0, 0, 0, 1);
        }

        private void PP_BTNEditInformation_Click(object sender, RoutedEventArgs e)
        {
            PP_BTNEditInformation.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            PP_BTNSaveInformation.Background = new SolidColorBrush(Color.FromRgb(127, 124, 255));

            MakeProfileInfoEditable();

        }

        private void PP_BTNSaveInformation_Click(object sender, RoutedEventArgs e)
        {
            PP_BTNEditInformation.Background = new SolidColorBrush(Color.FromRgb(127, 124, 255));
            PP_BTNSaveInformation.Background = new SolidColorBrush(Color.FromRgb(48, 48, 48));
            UserClass user = DataManager.currentUser;
            user.UserEmail = PP_TBEmail.Text;
            user.Username = PP_TBUsername.Text;
            user.Password = PP_TBPassword.Text;
            user.FirstName = PP_TBFirstName.Text;
            user.LastName = PP_TBLastName.Text;
            user.CurrentWeight = float.Parse(PP_TBCurrentWeight.Text);
            user.GoalWeight = float.Parse(PP_TBGoalWeight.Text);
            MakeProfileInfoReadOnly();
            PP_LBInitials.Content = "" + DataManager.currentUser.FirstName[0] + DataManager.currentUser.LastName[0];
        }
    }
}
