using System;
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

            int[] result;
            Console.WriteLine("Loading from file...");
            int[] list = readFromFile();
            Console.WriteLine("File loaded.");
            Console.WriteLine("Please choose a sorting algorithm");
            Console.WriteLine();
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. MergeSort");
            Console.WriteLine("4. MySort");
            Console.WriteLine();

            string choice = Convert.ToString(GetInteger("Please enter the number of your selection"));
            Console.WriteLine();

            //User selection of Sorting Algorithm
            switch(choice)
            {
                case "1":
                    result = bubbleSort(list);
                    printList("Bubble Sort", result);
                    break;
                case "2":
                    result = insertionSort(list);
                    printList("Insertion Sort", result);
                    break;
                case "3":
                   result = MergeSort(list);
                   printList("MergeSort: ", result);
                    break;   
                case "4":
                    result = mySort(list);
                    printList("MySort: ", result);
                    break;    
                /* case "5":
                    selectionSort(list);
                    break;    */
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
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
 /*update for more*/if (x >0 && x<5)
                    {
                        return x;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter the number of your selection (1-4).");
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
        static int[] bubbleSort(int[] list)
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
            return list;
        }

        //Insertion Sort Method
        static int[] insertionSort(int[] list)
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
            return list;
        }

        //Merge Sort Method - Split
        static int[] MergeSort(int[] list)
        {
            if (list.Length <= 1)
            {
                return list;

            }

            //Split the list into two sublists
            int middleIndex = (list.Length) / 2;
            int[] left = new int[middleIndex];
            int[] right = new int[list.Length - middleIndex];

            Array.Copy(list, left, middleIndex);
            Array.Copy(list, middleIndex, right, 0, right.Length);

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
            //Convert input arrays to lists for flexibility and resizing
            List<int> leftList = left.OfType<int>().ToList();
            List<int> rightList = right.OfType<int>().ToList();
            List<int> resultList = new List<int>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    //Compare the 2 lists, append the smaller element to the result list
                    //remove from original list
                    if (leftList[0] <= rightList[0])
                    {
                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }
                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }
                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            //Convert list back to array and return
            int[] result = resultList.ToArray();
            return result;
        }

        static int[] mySort(int[] list)
        {
            List<int> arrayList = list.OfType<int>().ToList();
            List<int> resultList = new List<int>();

            for (int i = 0; i < list.Length; i++)
            {
                resultList.Add(arrayList.Min());
                arrayList.Remove(arrayList.Min());

            }
            return resultList.ToArray();
        }

    }
}
