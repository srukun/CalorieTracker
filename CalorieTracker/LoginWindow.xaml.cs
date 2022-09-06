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
using System.Windows.Shapes;
using CalorieTracker.Storage;
namespace CalorieTracker
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            UserClass user = new UserClass("sharrukun2@gmail.com", "sharr", "password", "Shahriyar", "Rukun", 176.4f, 155.0f, 1600);
            DataManager.userList.Add(user);
        }

        private void LW_BTNLogin_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < DataManager.userList.Count; i++)
            {
                if (LW_TBUsername.Text.ToLower() == DataManager.userList[i].Username && LW_PBPassword.Password == DataManager.userList[i].Password)
                {
                    MainWindow MW = new MainWindow();
                    MW.Show();
                    this.Close();
                    DataManager.currentUser = DataManager.userList[i];
                }
            }

        }

        private void LW_BTNRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow RW = new RegisterWindow();
            RW.Show();
            this.Close();
        }





    }
}
