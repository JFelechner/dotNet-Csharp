using System;
namespace wizard_ninja_samurai
{
    public class Ninja : Human
    {
        // 2.) Ninja should have a default dexterity of 175
        public Ninja(string n, int str, int intel, int h) : base(n, str, intel, 175, h)
        {
            // no new stats being added so this can stay empty
        }

        // 5.) Provide an override Attack method to Ninja, which reduces the target by 5 * Dexterity and a 20% chance of dealing an additional 10 points of damage.
        public override int Attack(Human target)
        {
            int dmg = Dexterity * 5;
            Random rand = new Random();
            if (rand.Next(100) < 20)
            {
                dmg += 10;
            }
            target.getHealth -= dmg;
            Console.WriteLine($"{Name} attacked{target.Name} for {dmg} damage!");
            return target.getHealth;
        }

        // 9.) Ninja should have a method called Steal, reduces a target Human's health by 5 and adds this amount to its own health.
        public int Steal(Human target)
        {
            int steal = 5;
            target.getHealth -= steal;
            this.getHealth += steal;
            Console.WriteLine($"{Name} stole {target.Name} health by {steal}!");
            Console.WriteLine($"{Name} health: {this.getHealth}");
            return target.getHealth;
        }
    }
}