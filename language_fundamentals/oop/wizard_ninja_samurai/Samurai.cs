using System;
namespace wizard_ninja_samurai
{
    public class Samurai : Human
    {
        // 3.) Samurai should have a default health of 200
        public Samurai(string n, int str, int intel, int dext) : base(n, str, intel, dext, 200)
        {
            // no new stats being added so this can stay empty
        }
        
        // 6.) Provide an override Attack method to Samurai, which calls the base Attack and reduces the target to 0 if it has less than 50 remaining health points.
        public override int Attack(Human target)
        {
            int remaining = base.Attack(target);
            if(remaining<50)
            {
                target.getHealth = 0;
                Console.WriteLine($"{Name} eliminated {target.Name}");
            }
            return remaining;
        }

        // 8.) Samurai should have a method called Meditate, which when invoked, heals the Samurai back to full health
        public int Meditate()
        {
            int med = 200;
            getHealth = med;
            Console.WriteLine($"{Name} meditated! Health is {this.getHealth}");
            return this.getHealth;
        }
    }
}