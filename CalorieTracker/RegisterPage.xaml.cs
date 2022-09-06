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
using System.Globalization;
namespace CalorieTracker
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RP_BTNRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserClass user = new UserClass(RP_TBUserEmail.Text, RP_TBUsername.Text, RP_PBPassword.Password, RP_TBFirstName.Text, RP_TBLastName.Text, float.Parse(RP_TBCurrentWeight.Text, CultureInfo.InvariantCulture), float.Parse(RP_TBGoalWeight.Text, CultureInfo.InvariantCulture), int.Parse(RP_TBCalorieIntake.Text));
                DataManager.userList.Add(user);
                DataManager.currentUser = user;
                MainWindow mw = (MainWindow)Application.Current.MainWindow;
                mw.Content = new HomePage();

            }
            catch
            {

            }
        }

        private void RP_BTNGoToLoginPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
