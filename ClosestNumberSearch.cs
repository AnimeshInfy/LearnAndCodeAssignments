using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindClosestNumInArray
{
    internal class ClosestNumberSearch
    {
        public int N;
        public int X;
        public int[] A;

        public void getClosestNumber()
        {
            N = Convert.ToInt32(Console.ReadLine());

            //Array Input, To generate array in required format
            string elements = Console.ReadLine();
            string[] stringArray = elements.Split(' ');
            A = new int[stringArray.Length];
            for (int index = 0; index < stringArray.Length; index++)
            {
                if (int.TryParse(stringArray[index], out int value) && value >= 0)
                {
                    A[index] = value;
                }
                else
                {
                    Console.WriteLine($"Invalid input: '{stringArray[index]}' is not a non-negative integer.");
                    return;
                }
            }

            X = Convert.ToInt32(Console.ReadLine());

            int indexOfSmallestDiff;
            List<int> differenceList = new List<int>();

            Array.Sort(A);

            foreach (int arrayElements in A)
            {
                int diff = Math.Abs(X - arrayElements);
                differenceList.Add(diff);
            }

            int smallestInDiffList = differenceList.Min();

            for (int index = 0; index < differenceList.Count; index++)
            {
                if (differenceList[index] == smallestInDiffList)
                {
                    indexOfSmallestDiff = index;
                    Console.WriteLine($"{A[indexOfSmallestDiff]}");
                    break;
                }
            }

        }

        static void Main()
        {
            ClosestNumberSearch closestNum = new ClosestNumberSearch();
            closestNum.getClosestNumber();
        }
    }
}
