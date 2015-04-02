using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    public class Common
    {
        public static bool ArrayEquals( int[] data1, int[] data2 )
        {
            if( data1 == null || data2 == null )
            {
                return false;
            }
            if( data1.Length != data2.Length )
           {
               return false;
           }

            for (int i = 0; i < data1.Length; i++ )
            {
                if( !int.Equals(data1[i], data2[i]) )
                {
                    return false ;
                }
            }
           return true;
        }
    }
}

