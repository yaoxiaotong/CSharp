using CSharpPractice.leetcode;
using CSharpPractice.Matrix;
using CSharpPractice.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool result = BinarySearch.Test();
            //bool result = SearchInOrderedMatrix.Test();
            //bool result = BubbleSort.Test();
            //bool result = InsertionSort.Test();
            //bool result = QuickSort.Test();

            //int[] A = { 1,2};
            //int[] B = { 1, 2,3 };

            Solution s = new Solution();

            Console.WriteLine(s.TrailingZeroes(20));
            Console.Read();
        }

    }
}
