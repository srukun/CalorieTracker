using CalorieTracker.Storage;
using System.Windows;
using System.Globalization;
namespace CalorieTracker
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RW_LBSignIn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow LW = new LoginWindow();
            LW.Show();
            this.Close();
        }

        private void RW_BTNRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserClass user = new UserClass(RW_TBUserEmail.Text, RW_TBUsername.Text, RW_PBPassword.Password, RW_TBFirstName.Text, RW_TBLastName.Text, float.Parse(RW_TBCurrentWeight.Text, CultureInfo.InvariantCulture), float.Parse(RW_TBGoalWeight.Text, CultureInfo.InvariantCulture), int.Parse(RW_TBCalorieIntake.Text));
                DataManager.userList.Add(user);
                LoginWindow LW = new LoginWindow();
                LW.Show();
                this.Close();
            }
            catch
            {

            }
        }

        private void RW_TBLastName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
