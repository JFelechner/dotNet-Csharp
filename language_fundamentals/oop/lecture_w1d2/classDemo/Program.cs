
using System;

namespace classDemo
{
    class Program
    {
        static void Main(string[] args)
        { //initilizing liger
            Animal liger = new Animal("Liger", "carnivor", false, 20, 500);
            Console.WriteLine(liger.species);

            Animal dino = new Animal("Quetzalcoatlus", "omnivore", 20, 405.2);
            Console.WriteLine(dino.isExtinct);

            Animal dino2 = new Animal("Broncosaurus", "omnivore", true, 405.2);
            Console.WriteLine(dino.isExtinct);

            Animal pegasus = new Animal("Pegasus", "herbivore", false, 20, 102.3);

            dino.makeNoise("SCREEEEECH!!");
            pegasus.makeNoise("Neigh!");

            dino.eat();
            liger.eat();
            pegasus.makeNoise($"{dino.species}");
        }
    }
}
