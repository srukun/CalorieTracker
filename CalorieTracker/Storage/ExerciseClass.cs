using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTracker.Storage
{
    public class ExerciseClass
    {
        string _exerciseName;
        int _caloriesBurnt;
        float _duration;
        public ExerciseClass(string exerciseName, int caloriesBurnt, float duration)
        {
            _exerciseName = exerciseName;
            _caloriesBurnt = caloriesBurnt;
            _duration = duration;
        }
        public string ExerciseName { get => _exerciseName; set => _exerciseName = value; }
        public int CaloriesBurnt { get => _caloriesBurnt; set => _caloriesBurnt = value; }
        public float Duration { get => _duration; set => _duration = value; }

        public string GetExercise()
        {
            return "Exercise: " + _exerciseName + " Calories Burnt: " + _caloriesBurnt + " Duration: " + _duration;
        }

    }
}
