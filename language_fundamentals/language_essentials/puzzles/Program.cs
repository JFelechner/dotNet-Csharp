
using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            randArr();
            CoinToss();
        }

        // Random Array
        // Create a function called RandomArray() that returns an integer array 
        static void randArr()
        {
            List<int> tenRandInt = new List<int>();

            Random num = new Random();
            for (int x = 0; x < 10; x++)
            {
                tenRandInt.Add(num.Next(5, 25));
            }
            int[] numArr = tenRandInt.ToArray();

            foreach (int value in tenRandInt)
            {
                Console.WriteLine(value);
            }


            //Print the min and max values of the array
            //Print the sum of all the values
            int sum = numArr[0];
            int max = numArr[0];
            int min = numArr[0];
            for (int i = 1; i < numArr.Length; i++)
            {
                if (numArr[i] < min)
                {
                    min = numArr[i];
                }
                if (numArr[i] > max)
                {
                    max = numArr[i];
                }
                sum += numArr[i];
            }
            Console.WriteLine("Min value: " + min + " & " + " Max value: " + max);
            Console.WriteLine("Sum of values: " + sum);
        }


        //Create a function called TossCoin() that returns a string
        public static string CoinToss()
        {
            //Have the function print "Tossing a Coin!"
            Console.WriteLine("Tossing a Coin!");

            //Randomize a coin toss with a result signaling either side of the coin
            List<int> randomTosses = new List<int>();

            Random toss = new Random();

            for (int x = 0; x < 50; x++)
            {
                randomTosses.Add(toss.Next(1, 50));
            }
            int[] numArr = randomTosses.ToArray();
            int sum = numArr[0];

            for (int i = 0; i < numArr.Length; i++)
            {
                sum += numArr[i];
            }

            int tossResult = sum;
            Console.WriteLine(tossResult);

            string coinSide;

            if (tossResult % 2 != 0)
            {
                coinSide = "Heads";
            }
            else
            {
                coinSide = "Tails";
            }

            // /Have the function print either "Heads" or "Tails"
            Console.WriteLine("Toss result: " + coinSide );
            return coinSide;
        }

    }
}

