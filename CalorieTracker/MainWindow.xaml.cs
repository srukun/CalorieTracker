using CalorieTracker.Storage;
using System.Windows;
namespace CalorieTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            UserClass user = new UserClass("sharrukun2@gmail.com", "sharr", "password", "Shahriyar", "Rukun", 176.4f, 155.0f, 1600);
            DataManager.userList.Add(user);
        }

        private void MW_BTNHome_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomePage();
        }

        private void MW_BTNProfile_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ProfilePage();

        }


        private void MW_BTNCreateTracker_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateTrackerPage();
        }
        private void MW_BTNFoodTracker_Click(object sender, RoutedEventArgs e)
        {
            if (DataManager.currentUser.Tracker.Count > 0)
            {
                Main.Content = new FoodTrackerPage();
            }
            else
            {
                Main.Content = new CreateTrackerPage();
            }
        }






        private void Window_Activated(object sender, System.EventArgs e)
        {
            //Main.Content = new LoginPage();
        }

        public void HomePage()
        {
            Main.Content = new HomePage();
        }

        private void MW_BTNExerciseTracker_Click(object sender, RoutedEventArgs e)
        {
            if (DataManager.currentUser.Tracker.Count > 0)
            {
                Main.Content = new ExerciseTrackerPage();
            }
            else
            {
                Main.Content = new CreateTrackerPage();
            }
        }

        private void MWLogin_BTNLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < DataManager.userList.Count; i++)
                {
                    if (MWLogin_TBUsername.Text.ToLower() == DataManager.userList[i].Username && MWLogin_PBPassword.Password == DataManager.userList[i].Password)
                    {
                        DataManager.currentUser = DataManager.userList[i];
                        Main.Visibility = Visibility.Visible;
                        MW_NavPannel.Visibility = Visibility.Visible;
                        MWLogin_SP.Visibility = Visibility.Collapsed;
                        this.HomePage();
                        

                    }
                }
            }
            catch
            {

            }
        }

        private void MWLogin_BTNGoToRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RegisterPage();
        }
    }
}
