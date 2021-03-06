﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Sort
{
    public class BubbleSort
    {
        public static void Execute( int[] data )
        {
            if (data == null) return;
            int end = data.Length -1;
            int tmp = 0;

            while(  end > 0  )
            {
                for (int i = 0; i < end; i++)
                {
                    if( data[i+1] < data[i] )
                    {
                        tmp = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = tmp;
                    }
                }
                --end;
            }
        }

        public static bool Test(  )
        {
            int[] data = { 8, 9, 6, 5, 1, 2, 3, 41024, 7, 14, 8, 4, 77, 9, 54, 45, 47, 89, 36, 102, 458, 789 };
            int[] correctResult = { 1, 2, 3, 4, 5, 6, 7, 8, 8, 9, 9, 14, 36, 45, 47, 54, 77, 89, 102, 458, 789, 41024 };

            Execute(data);

            return Common.ArrayEquals(data, correctResult);
        }
    }
}
