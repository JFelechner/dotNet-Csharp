using System;
namespace wizard_ninja_samurai

{
    public class Wizard : Human
    {
        // 1.) Wizard should have a default health of 50 and Intelligence of 25
        public Wizard(string n, int str, int dext) : base(n, str, 25, dext, 200)
        {
            // no new stats being added so this can stay empty
        }

        // 4.) Provide an override Attack method to Wizard, which reduces the target by 5 * Intelligence and heals the Wizard by the amount of damage dealt
        public override int Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.getHealth -= dmg;
            this.getHealth += dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Console.WriteLine($"{Name} health increased: {this.getHealth}");
            return target.getHealth;
        }

        // 7.) Wizard should have a method called Heal, which when invoked, heals a target Human by 10 * Intelligence
        public int Heal(Human target)
        {
            int heal = Intelligence * 10;
            target.getHealth += heal;
            Console.WriteLine($"{Name} Healed {target.Name} by {heal}!");
            return target.getHealth;
        }
    }
}