

using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    public class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        // add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        // add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories
        public bool IsFull
        {
            get
            {
                return calorieIntake > 1200;
            }
        }

        // build out the Eat method that: if the Ninja is NOT full
        // public
        public bool Eat(Food meal)
        {
            if (!IsFull)
            {
                calorieIntake += meal.Calories;
                FoodHistory.Add(meal);
                Console.WriteLine($"Still hungry! more: {meal.Name}");
            }
            if (IsFull)
            {
                Console.WriteLine("Ninja is full! No more food!");
            }
            return IsFull;
        }
    }
}