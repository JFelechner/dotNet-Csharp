
using System;
namespace wizard_ninja_samurai
{
    public class Human
    {
        // Fields for Human class
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;

        // Add an additional private field for health (int)
        private int health;

        // Add a public property to access or "get" health
        public int getHealth 
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        
        // Add a constructor method that takes a string to initialize Name - and that will initialize Strength, Intelligence, and Dexterity to a default value of 3, and health to default value of 100
        public Human(string n)
        {
            Name = n;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }


        // Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Human(string n, int str, int intel, int dext, int h)
        {
            Name = n;
            Strength = str;
            Intelligence = intel;
            Dexterity = dext;
            health = h;
        }

        // Now add a new method called Attack, which when invoked, should reduce the health of a Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker). This method should return the remaining health of the target object.
        public virtual int Attack(Human target)
        {
            int dmg = Strength * 5;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }

}

