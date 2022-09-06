using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTracker.Storage
{
    public class FoodClass
    {
        string _foodName;
        int _calories;
        int _protein;
        int _carbs;
        int _fat;
        public FoodClass(string foodName, int calories, int protein, int carbs, int fat)
        {
            _foodName = foodName;
            _calories = calories;
            _protein = protein;
            _carbs = carbs;
            _fat = fat;
        }
        public string FoodName { get => _foodName; set => _foodName = value; }
        public int Calories { get => _calories; set => _calories = value; }
        public int Protein { get => _protein; set => _protein = value; }
        public int Carbs { get => _carbs; set => _carbs = value; }
        public int Fat { get => _fat; set => _fat = value; }
    }
}
