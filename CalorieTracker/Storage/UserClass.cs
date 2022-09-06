using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTracker.Storage
{
    public class UserClass
    {
        public string _userEmail;
        public string _username;
        public string _password;
        public string _firstName;
        public string _lastName;
        public float _currentWeight;
        public float _goalWeight;
        public int _dailyCalorieIntake;
        public List<TrackerClass> _trackers;
        public UserClass(string userEmail, string username, string password, string firstName, string lastName, float currentWeight, float goalWeight, int dailyCalorieIntake)
        {
            _userEmail = userEmail;
            _username = username;
            _password = password;
            _firstName = firstName;
            _lastName = lastName;
            _currentWeight = currentWeight;
            _goalWeight = goalWeight;
            _dailyCalorieIntake = dailyCalorieIntake;
            _trackers = new List<TrackerClass>();
        }
        public string UserEmail { get => _userEmail; set => _userEmail = value; }
        public string Username { get => _username; set => _password = value; }
        public string Password { get => _password; set => _password = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public float CurrentWeight { get => _currentWeight; set => _currentWeight = value; }
        public float GoalWeight { get => _goalWeight; set => _goalWeight = value; }
        public int DailyCalorieIntake { get => _dailyCalorieIntake; set => _dailyCalorieIntake = value; }
        public List<TrackerClass> Tracker { get => _trackers;}



    }
}
