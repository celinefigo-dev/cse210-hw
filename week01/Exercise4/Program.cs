using System;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<int> numberList = new List<int>();
        int number;

        do
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            Console.Write("Enter number: ");
            string numberStr = Console.ReadLine();
            number = int.Parse(numberStr);

            numberList.Add(number);

        } while (number != 0);

        // Part One
        Console.WriteLine($"The sum is: {numberList.Sum()}");

        // Part 3

        int average = numberList.Sum() / numberList.Count;
        Console.WriteLine($"The average is: {average}");

        // Part 3
        Console.WriteLine($"The largest number is: {numberList.Max()}");
    }
}
