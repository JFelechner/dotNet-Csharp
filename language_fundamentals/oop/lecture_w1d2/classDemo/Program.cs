
using System;

namespace classDemo
{
    class Program
    {
        static void Main(string[] args)
        { //initilizing liger
            Animal liger = new Animal("Liger", "carnivor", false, 20, 500);
            Console.WriteLine(liger.species);

            Dinosaur dino = new Dinosaur("Quetzalcoatlus", "omnivore", 20, 405.2, "Cretatious");
            Console.WriteLine(dino.isExtinct);
            dino.makeNoise(); // if you pass a string thru it it will recognize the original makeNoise function.

            Animal dino2 = new Animal("Broncosaurus", "omnivore", true, 405.2);
            Console.WriteLine(dino2.isExtinct);

            Animal pegasus = new Animal("Pegasus", "herbivore", false, 20, 102.3);

            dino.makeNoise("SCREEEEECH!!");
            pegasus.makeNoise("Neigh!");

            dino.eat();
            liger.eat();
            pegasus.makeNoise($"{dino.species}");

            Mythical phoenix = new Mythical("Phoenix", "Fire", 100000, 120.6, "Egypt", true);

            Console.WriteLine(phoenix.species);
            phoenix.makeNoise("Skraw");
            phoenix.eat();
        }
    }
}
