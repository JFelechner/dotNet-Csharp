using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My first C# project");
            // ALL you code writing happens here

            // BASIC 13
            Print1to255();
            PrintSum();
            int[] myarray = new int[] { 2, 46, 7, 4, 25, 7 };
            printArray(myarray);
        }

        public static void Print1to255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine(i);
                sum += i;
                Console.WriteLine(sum);
            }
        }

        public static void printArray(int[] arr)
        {
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static object[] dojoReplace(int[] arr)
        {
            // need to convert int array into object array
            object[] newArray = new object[]{arr};
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0)
                {
                    newArray[i] = "dojo";
                } else {
                    newArray[i] = arr[i];
                }
                foreach(var j in newArray)
                {
                    Console.WriteLine(j);
                }
                return newArray;
            }
            return newArray;
        }

    }
}