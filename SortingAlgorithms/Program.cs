using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var strNums = File.ReadAllLines("C:/Users/Ryordan Panter/source/repos/SortingAlgorithms/unsorted_numbers.csv");
            List<int> nums = new List<int>();
            foreach (var num in strNums)
            {
                int i = int.Parse(num);
                nums.Add(i);
            }

            int[] insertionSortedNums = InsertionSort(nums.ToArray());
            List<string> stringNums = new List<string>();
            foreach (var num in insertionSortedNums)
            {
                stringNums.Add(num.ToString());
            }

            File.WriteAllLines(@"./insertion_sorted.csv", strNums.ToArray());

            Console.WriteLine("");

            int[] shellSortedNums = nums.ToArray();
            ShellSort(shellSortedNums, shellSortedNums.Length);
            List<string> stringShellNums = new List<string>();
            foreach (var num in shellSortedNums)
            {
                stringShellNums.Add(num.ToString());
            }

            File.WriteAllLines(@"./shell_sorted.csv", stringShellNums.ToArray());

            Console.WriteLine("");

            int[] fifteenHundredthNums = LinearSearch(nums.ToArray());

            Console.WriteLine("");

            var bsStart = DateTime.Now;
            Console.WriteLine("Binary Search | Time Started: " + bsStart.ToString("h:mm:ss.fff tt"));
            int counter = 0;
            foreach (var numb in fifteenHundredthNums)
            {
                counter++;
                Console.WriteLine(counter * 1500 + "th number: " + BinarySearch(shellSortedNums.ToArray(), numb));
            }
            var bsEnd = DateTime.Now;
            var bsTime = bsEnd - bsStart;
            Console.WriteLine("Binary Search | Time Ended: " + bsEnd.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Binary Search | Duration: " + bsTime.TotalMilliseconds + " ms.");

            Console.ReadLine();
        }
        public static int[] InsertionSort(int[] numbers)
        {
            var isStart = DateTime.Now;
            Console.WriteLine("Insetion Sort | Time Started: " + isStart.ToString("h:mm:ss.fff tt"));
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        int temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            var isEnd = DateTime.Now;
            var isTime = isEnd - isStart;
            Console.WriteLine("Insetion Sort | Time Ended: " + isEnd.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Insetion Sort | Duration: " + isTime.TotalMilliseconds + " ms.");
            return numbers;
        }

        public static void ShellSort(int[] arr, int n)
        {
            var ssStart = DateTime.Now;
            Console.WriteLine("Shell Sort | Time Started: " + ssStart.ToString("h:mm:ss.fff tt"));
            int i, j, pos, temp;
            pos = 3;
            while (pos > 0)
            {
                for (i = 0; i < n; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= pos) && (arr[j - pos] > temp))
                    {
                        arr[j] = arr[j - pos];
                        j = j - pos;
                    }
                    arr[j] = temp;
                }
                if (pos / 2 != 0)
                    pos = pos / 2;
                else if (pos == 1)
                    pos = 0;
                else
                    pos = 1;
            }
            var ssEnd = DateTime.Now;
            var ssTime = ssEnd - ssStart;
            Console.WriteLine("Shell Sort | Time Ended: " + ssEnd.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Shell Sort | Duration: " + ssTime.TotalMilliseconds + " ms.");
        }

        public static int[] LinearSearch(int[] numbers)
        {
            List<int> fifteenHundredthNums = new List<int>();
            var lsStart = DateTime.Now;
            Console.WriteLine("Linear Search | Time Started: " + lsStart.ToString("h:mm:ss.fff tt"));
            int bigNum = 0;
            int counter = 0;
            foreach (var num in numbers)
            {
                counter++;
                if (num > bigNum)
                {
                    bigNum = num;
                }
                if (counter % 1500 == 0)
                {
                    fifteenHundredthNums.Add(num);
                    Console.WriteLine(counter + "th number: " + num);
                }
            }
            var lsEnd = DateTime.Now;
            var lsTime = lsEnd - lsStart;
            Console.WriteLine("Linear Search | Time Ended: " + lsEnd.ToString("h:mm:ss.fff tt"));
            Console.WriteLine("Linear Search | Duration: " + lsTime.TotalMilliseconds + " ms.");
            return fifteenHundredthNums.ToArray();
        }

        public static object BinarySearch(int[] numbers, int key)
        {

            int min = 0;
            int max = numbers.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == numbers[mid])
                {
                    return numbers[mid];
                }
                else if (key < numbers[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return "Nil";
        }

        
    }
}