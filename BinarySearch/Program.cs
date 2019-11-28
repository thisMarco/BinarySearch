//Marco Picchillo - Sorting Array and BinarySearch
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static public int binarySearch(int[] sortedArray, int n, int target)
        {
            int leftMargin = 0;
            int rightMargin = n-1;
          
            Console.WriteLine("\n\nSearching for the number = {0}", target);
            Console.WriteLine("\n\t\tleft\tright\tpos\tfound?\tComment");
            Console.Write("Pre-amble\t{0}\t{1}",leftMargin,rightMargin);
            Console.Read();

            int passCounter = 0;
            while (leftMargin <= rightMargin)
            {
                passCounter++;
                int center = (leftMargin + rightMargin) / 2;
                if (target == sortedArray[center])
                {
                    Console.WriteLine("After {0} pass\t{1}\t{2}\t{3}\tTrue\t{4} has been found at index {5}.", passCounter,leftMargin,rightMargin, center, target, center);
                    return center;
                }
                else if (target < sortedArray[center])
                {
                    rightMargin = center - 1;
                    Console.WriteLine("After {0} pass\t{1}\t{2}\t{3}\tFalse\tArray[{4}] = {5} > {6}. New Right Margin {7}.", passCounter, leftMargin, rightMargin, center, center, sortedArray[center], target, center - 1);
                }
                else
                {
                    leftMargin = center + 1;
                    Console.WriteLine("After {0} pass\t{1}\t{2}\t{3}\tFalse\tArray[{4}] = {5} < {6}. New Left Margin {7}.", passCounter, leftMargin, rightMargin, center, center, sortedArray[center], target, center + 1);
                }
                Console.ReadKey();
            }
            return -1;
        }

        static public void sortArray(int[] array, int n)
        {
            int lastSorted = n - 1; //index of last sorted element of the array.
            bool sorted;
            do
            {
                sorted = false;
                int i = 0;
                do
                {
                    if (array[i] > array[i + 1])
                    {
                        //Swap elements
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        sorted = true;
                    }
                    i++;
                } while (i < lastSorted);
                lastSorted--;
            } while (lastSorted > 0 && sorted);
        }

        static public void printArray(int[] array, int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" {0}", array[i]);
        }
        static void Main(string[] args)
        {
            int[] array = new int[20]; //arrays containing integer.
            int n = -1; //number of integer to read.

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Marco Picchillo - West Lothian College - HND Software Dev. 2018/2019\n");
            Console.ResetColor();

            //Reading n
            Console.Write("How many number do you want in your array? [MAX 20]: ");
            do
            {
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n < 1 || n > 20)
                        Console.Write("\nYou must enter a value between 1 and 20.\nPlease try again: ");
                }
                catch
                {
                    Console.Write("Your input is not an integer number.\nPlease try again: ");
                }

            } while (n < 1 || n > 20);

            //Populating the array with n integer numbers.
            int i = 0;
            do
            {
                try
                {
                    Console.Write("Please insert the value for array[{0}]: ", i);
                    array[i] = int.Parse(Console.ReadLine());
                    i++;
                }
                catch
                {
                    Console.WriteLine("Your input is not an integer number.");
                }
            } while (i < n);

            Console.Clear();
            //Sorting array if n>1
            if (n > 1)
                sortArray(array, n);

            ConsoleKeyInfo userQuit;
            //Loop until user want to quit the program.
            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Marco Picchillo - West Lothian College - HND Software Dev. 2018/2019\n");
                Console.ResetColor();

                //Printing sorted array
                Console.WriteLine("Sorted array: ");
                printArray(array, n);
                
                //Reading number to search from user
                bool valueOk = false;
                int targhet = -1; //Initialize targhet to avoid compiler error.
                do
                {
                    
                    try
                    {
                        Console.Write("\n\nWhat is the number you are looking for? ");
                        targhet = int.Parse(Console.ReadLine());
                        valueOk = true;
                    }
                    catch
                    {
                        Console.WriteLine("\nMust be an integer number! Try again.");
                    }
                } while (!valueOk);

                int targhetPosition = binarySearch(array, n, targhet);

                if (targhetPosition >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nFound! The position in the array of the number {0} is: {1}.", targhet, targhetPosition);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nLeft Margin and Right Margin crossed!\nThe number {0} is not present in the array.", targhet);
                }

                Console.ResetColor();
                Console.Read();
                Console.Write("\n\nDo you want to user the same array for another search? [Y/N]: ");
                do
                {
                    userQuit = Console.ReadKey();
                    Console.WriteLine();
                } while (userQuit.Key != ConsoleKey.Y && userQuit.Key != ConsoleKey.N);

            } while (userQuit.Key == ConsoleKey.Y);
        }
    }
}
