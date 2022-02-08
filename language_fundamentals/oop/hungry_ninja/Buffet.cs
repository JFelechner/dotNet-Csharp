
using System;
using System.Collections.Generic;

namespace hungry_ninja
{
    public class Buffet
    {
        public List<Food> Menu;

        // Create a Buffet class, which will contain a Menu of Food objects
        // add a constructor and set Menu to a hard coded list of 7 or more Food objects you instantiate manually
        public Buffet()
        {
            Menu = new List<Food>()
        {
            new Food("Jalapeno Pizza Slice", 150, true, false),
                new Food("Cheese Pizza Slice", 160, false, false),
                new Food("Sushi Roll", 200, false, false),
                new Food("Chicken breast", 300, false, false),
                new Food("Chocolate", 100, false, true),
                new Food("Bread", 100, false, false),
                new Food("Pie slice", 150, false, true)
        };
        }

        // build out a Serve method that randomly selects a Food object from the Menu list and returns the Food object
        public Food Serve()
        {
            Random random = new Random();
            return Menu[random.Next(Menu.Count)];
        }
    }
}