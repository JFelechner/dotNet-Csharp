
using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human personOne = new Human("John");
            Console.WriteLine("Person 1:");
            Console.WriteLine(personOne.Name);
            Console.WriteLine(personOne.Strength);
            Console.WriteLine(personOne.Intelligence);
            Console.WriteLine(personOne.Dexterity);
            Console.WriteLine(personOne.getHealth);


            Human personTwo = new Human("Hunter", 25, 100, 80, 100);
            Console.WriteLine("Person 2:");
            Console.WriteLine(personTwo.Name);
            Console.WriteLine(personTwo.Strength);
            Console.WriteLine(personTwo.Intelligence);
            Console.WriteLine(personTwo.Dexterity);
            Console.WriteLine(personTwo.getHealth);
            personTwo.Attack(personOne);
        }
    }
}
