
using System;
using System.Collections.Generic;


namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays
            // Create an array to hold integer values 0 through 9
            int[] numArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] namesArray = { "Tim", "Martin", "Nikki", "Sara" };
            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] trueFalseArray = { true, false, true, false, true, false, true, false, true, false };


            // List of Flavors
            // Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> iceCreamFlavors = new List<string>();


            // User Info Dictionary
            // Create a dictionary that will store both string keys as well as string values
            Dictionary<string, string> userInfo = new Dictionary<string, string>();




            // **********************
            // Console.WriteLine("Hello World!");
            // Console.WriteLine(numArray);
            // Console.WriteLine(strArray);
            // Console.WriteLine(trueFalseArray);
            iceCreamFlavors.Add("vanilla");
            iceCreamFlavors.Add("chocolate");
            iceCreamFlavors.Add("butterscotch");
            iceCreamFlavors.Add("fudge");
            iceCreamFlavors.Add("orange");

            // Output the length of this list after building it
            Console.WriteLine("Here are the ice creame flavors");
            for (var i = 0; i < iceCreamFlavors.Count; i++)
            {
                Console.WriteLine("-" + iceCreamFlavors[i]);
            }

            // Output the third flavor in the list, then remove this value
            Console.WriteLine("Flavor 3: " + iceCreamFlavors[2]);
            iceCreamFlavors.Remove(iceCreamFlavors[2]);

            // Output the new length of the list (It should just be one fewer!)
            Console.WriteLine("Here are the updated ice creame flavors");
            for (var i = 0; i < iceCreamFlavors.Count; i++)
            {
                Console.WriteLine("-" + iceCreamFlavors[i]);
            }

            // Add key/value pairs to this dictionary where:
            // each key is a name from your names array
            // each value is a randomly select a flavor from your flavors list.
            userInfo.Add(namesArray[0], iceCreamFlavors[0]);
            userInfo.Add(namesArray[1], iceCreamFlavors[1]);
            userInfo.Add(namesArray[2], iceCreamFlavors[2]);
            userInfo.Add(namesArray[3], iceCreamFlavors[3]);

            // Loop through the dictionary and print out each user's name and their associated ice cream flavor
            foreach (KeyValuePair<string, string> entry in userInfo)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

        }
    };
}
