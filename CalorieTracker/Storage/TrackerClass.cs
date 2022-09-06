using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTracker.Storage
{
    public class TrackerClass
    {
        string _date;
        int _month;
        int _day;
        int _year;
        List<FoodClass> _foods;
        List<ExerciseClass> _exercises;
        int _calorieConsumed;
        int _calorieBurnt;
        public TrackerClass(int month, int day, int year)
        {
            _month = month;
            _day = day;
            _year = year;
            _foods = new List<FoodClass>();
            _exercises = new List<ExerciseClass>();
            _calorieConsumed = 0;
            _calorieBurnt = 0;
        }
        public string Date { get => _date; set => _date = value; }
        public List<FoodClass> Foods { get => _foods; set => _foods = value; }
        public List<ExerciseClass> Exercises { get => _exercises; set => _exercises = value; }
        public int CaloriesConsumed { get => _calorieConsumed; set => _calorieConsumed = value; }
        public int CaloriesBurnt { get => _calorieBurnt; set => _calorieBurnt = value; }


        
        public int GetTotalCaloriesConsumed()
        {
            int totalCalories = 0;
            for(int i = 0; i < _foods.Count; i++)
            {
                totalCalories += _foods[i].Calories;
            }
            return totalCalories;
        }

        public int GetTotalProteinConsumed()
        {
            int totalProtein = 0;
            for(int i = 0; i < _foods.Count; i++)
            {
                totalProtein += _foods[i].Protein;
            }
            return totalProtein;
        }
        public int GetTotalCarbsConsumed()
        {
            int totalCarbs = 0;
            for (int i = 0; i < _foods.Count; i++)
            {
                totalCarbs += _foods[i].Carbs;
            }
            return totalCarbs;
        }
        public int GetTotalFatConsumed()
        {
            int totalFat = 0;
            for (int i = 0; i < _foods.Count; i++)
            {
                totalFat += _foods[i].Fat;
            }
            return totalFat;
        }

        public int GetTotalCaloriesBurnt()
        {
            int returnCalories = 0;
            for(int i = 0; i < _exercises.Count; i++)
            {
                returnCalories += _exercises[i].CaloriesBurnt;
            }
            return returnCalories;
        }
        public int GetTotalProteinIntake()
        {
            int proteinIntake = 0;
            for(int i = 0; i < _foods.Count; i++)
            {
                proteinIntake += _foods[i].Protein;
            }
            return proteinIntake;
        }
        public float GetTotalDuration()
        {
            float totalDuration = 0;
            for(int i = 0; i < _exercises.Count; i++)
            {
                totalDuration += _exercises[i].Duration;
            }
            return totalDuration;
        }
    }
}