using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class BinarySearch
    {
        public static int Execute( int [] data, int target )
        {
            if (data == null) return -1;

            int left = 0, right = data.Length - 1,middle = 0;

            while ( left <= right )
            {
                middle = (left + right)/2;

                if( target > data[middle] )
                {
                    left  = middle +1;
                }
                else if( target < data[middle] )
                {
                    right = middle -1;
                }
                else
                {
                    return middle;  
                }
            }

            return -1;
        }
        public static bool Test()
        {
            int[] data = new int[] { 1,5,8,45,89,96,425,789,999,1000,1002,5487,6578};

            int result = Execute(data, 1000);

            if( result != 9 )
            {
                return false;
            }

            result = Execute(data, 1001);
            if( result != -1 )
            {
                return false;
            }

            result = Execute(data, 6578);
            if (result != 12)
            {
                return false;
            }
            result = Execute(data, 1);
            if (result != 0)
            {
                return false;
            }

            return true;
        }
    }
}
