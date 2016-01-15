﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading from file...");
            int[] list = readFromFile();
            Console.WriteLine("File loaded.");
            Console.WriteLine("Please choose a sorting algorithm");
            Console.WriteLine();
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. Selection Sort");
            Console.WriteLine();

            string choice = Convert.ToString(GetInteger("Please enter the number of your selection"));
            Console.WriteLine();

            //User selection of Sorting Algorithm
            switch(choice)
            {
                case "1":
                    bubbleSort(list);
                    break;
                case "2":
                    insertionSort(list);
                    break;
                /* case "3":
                    selectionSort(list);
                    break;    */
                /* case "4":
                    selectionSort(list);
                    break;    */
                /* case "5":
                    selectionSort(list);
                    break;    */
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        //Method to capture user input of integer with validation
        static int GetInteger(string prompt)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    int x = int.Parse(input);
 /*upddate for more*/if (x >0 && x<3)
                    {
                        return x;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter the number of your selection (1-2).");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Please enter the number of your selection (1-2)");
                }
            }
        }

        //Fetch data from file, parse to array
        static int[] readFromFile()
        {
        string fileContents = File.ReadAllText("C:\\dev\\data\\unsorted-numbers.txt");
        int[] unsortedValues = fileContents.Split(',').Select(int.Parse).ToArray();
        return unsortedValues;
        }

        //Printing Method
        static void printList(string listName, int[] list)
        {
            Console.WriteLine("-- " + listName + " ---");
            for (int i = 0; i<list.Length; i++)
            {
                Console.Write(list[i]);
                if (list[i] != list.Length)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(".");
                }
            }
        }

        //Bubble Sort Method
        static void bubbleSort(int[] list)
        {
            for (var i = list.Length - 1; i >= 0; i--)
            {
                for (var j = 0; j <= i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var temp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
            printList("Bubble Sort", list);
        }

        //Insertion Sort Method
        static void insertionSort(int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int temp = list[i];
                int j = 0;

                for (j = i; j > 0; j--)
                {
                    if (list[j - 1] < temp)
                    {
                        break;
                    }
                    list[j] = list[j - 1];
                }
                list[j] = temp;
            }
            printList("Insertion Sort", list);
        }
        /*
        //Merge Sort Method - Split
        static int[] MergeSort(int[] list)
        {
            if (list.Length <= 1)
            {
                return list;
            }

            //Split the list into two sublists
            int middleIndex = (list.length) / 2;
            int[] left = new int[middleIndex];
            int[] right = new int[middleIndex];

            Array.Copy(list, left, middleIndex);
            Array.Copy(list, middleIndex, right, middleIndex, middleIndex);

            //Recursively call MergeSort() to split sublists to size of 1 each
            left = MergeSort(left);
            right = MergeSort(right);

            //Merge the sublists returned from prior calls to MergeSort
            //and return the resulting merged sublist
            return Merge(left, right);
        }

        //MergeSort Method - Merge

        static int[] Merge(int[] left, int[] right)
        {


        }
        */
    }
}