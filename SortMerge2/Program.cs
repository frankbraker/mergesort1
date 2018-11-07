using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMerge2
{
    class Arr       // the Arr class!  Which is short of Array!  And it has a merge sort as part of it.
    {
        public static void mergesort(ref int[] array)
        {
            int[] temp = new int[array.Length];
            mergesort(ref array, ref temp, 0, array.Length - 1, 0);
        }

        public static void mergesort(ref int[] array, ref int[] temp, int leftSTART, int rightEND, int depth)
        {
            if (rightEND - leftSTART > 1)
            {
                int middle = (leftSTART + rightEND) / 2;
                mergesort(ref array, ref temp, leftSTART, middle, depth + 1);
                mergesort(ref array, ref temp, middle + 1, rightEND, depth + 1);
            }
            mergeHalves(ref array, ref temp, leftSTART, rightEND, depth);       // by passing start and end, the same arrays can be used rather than passing new ones
        }
        public static void mergeHalves(ref int[] array, ref int[] temp, int leftSTART, int rightEND, int depth)
        {
            int leftEND = (rightEND + leftSTART) / 2;
            int rightSTART = leftEND + 1;
            int size = rightEND - leftSTART + 1;

            int lIndex = leftSTART;
            int rIndex = rightSTART;
            int tIndex = leftSTART;     // tIndex is always bumped, while lIndex and rIndex only bump if they won

            while (lIndex <= leftEND || rIndex <= rightEND)
            {
                bool leftValid = lIndex <= leftEND;
                bool rightValid = rIndex <= rightEND;
                int rightValue = rightValid ? array[rIndex] : int.MaxValue;     // don't index if invalid
                int leftValue = leftValid ? array[lIndex] : int.MaxValue;             // don't index if invalid
                bool leftIsLess = leftValid && (leftValue < rightValue);

                // not used bool rightIsLess    = leftValid && !leftIsLess;

                int winner = leftIsLess ? leftValue : rightValue;         // that's all that's needed
                //int loser = !leftIsLess ? leftValue : rightValue;

                if (winner == 0)
                {
                    Console.Write("no this is bad!");
                }

                temp[tIndex++] = winner;                       // leftSTART is always used even then leftSTART has gone past leftEND
                                                               //                if (lIndex<temp.Length)
                                                               //                    temp[tIndex] = loser;
                if (leftIsLess) lIndex++;
                else rIndex++;
            }

            Array.Copy(temp, leftSTART, array, leftSTART, size);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 5, 3, 4,2,9,1,13,8,9 };
            //mergesort(a);

            Console.WriteLine("Show original array:");
            foreach (int i in a)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine("\nShow sorted array:");
            Arr.mergesort(ref a);
            foreach (int i in a)
            {
                Console.Write(i + ",");
            }

        }
    }
}
