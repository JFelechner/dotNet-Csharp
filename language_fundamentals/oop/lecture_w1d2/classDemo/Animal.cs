
using System;

namespace classDemo
{
    public class Animal
    {
        public string species;
        public string diet;
        public bool isExtinct;
        public int avgLifespan;
        public double weight; 

        // multiple constructors!
        public Animal(string sp, string d, bool ext, int ls, double wgt)
        //liger
        {
            species = sp;
            diet = d;
            isExtinct = ext;
            avgLifespan = ls;
            weight = wgt;
        }

        public Animal(string sp, string d, int ls, double wgt)
        //dino
        {
            species = sp;
            diet = d;
            isExtinct = true;
            avgLifespan = ls;
            weight = wgt;
        }

        public Animal(string sp, string d, bool ext, double wgt)
        //dino2
        {
            species = sp;
            diet = d;
            isExtinct = ext;
            avgLifespan = 20;
            weight = wgt;
        }

        // Methods are functions that are declared within a class.
        public void makeNoise(string noise)
        {
            Console.WriteLine(noise);
        }

        public void eat()
        {
            Console.WriteLine("Munch Munch");
            this.weight+=0.3;
            Console.WriteLine($"{species} ate some food and now weighs {weight} lbs");
        }
    }
}