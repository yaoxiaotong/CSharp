using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Sort
{
    public class QuickSort
    {
        public static void Execute(int[] data)
        {
            if (data == null) return;
            Sort( data, 0,data.Length -1 );
        }

        private static void Sort(int[] data, int low, int high)
        {
            if (low >= high) return;

            int key = data[low];
            int tmp = 0;
            int left = low, right = high;

            while( true)
            {
                while (left < right && data[right] >= key) { --right; }
                
                while (left< right && data[left] <= key ) { ++left; }

                if( left < right )
                {
                    tmp = data[left];
                    data[left] = data[right];
                    data[right] = tmp;
                }
                else
                {
                    break;
                }
            }
            tmp = data[right];
            data[right] = key;
            data[low] = tmp;

            Sort(data, low, right - 1);
            Sort(data, right + 1, high);

        }

        public static bool Test()
        {
            int[] data = { 8, 9, 6, 5, 1, 2, 3, 41024, 7, 14, 8, 4, 77, 9, 54, 45, 47, 89, 36, 102, 458, 789 };
            int[] correctResult = { 1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 9, 14, 36, 45, 47, 54, 77, 89, 102, 458, 789, 41024 };

            Execute(data);

            return Common.ArrayEquals(data, correctResult);
        }
    }
}
