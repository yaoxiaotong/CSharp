using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Matrix
{
    /// <summary>
    /// 给一个二维数组，都是整数，每行都是从小到大排列，每列也是从小到大。
    /// （但是第二行的第一个不一定大于第一行最后一个），给一个target，判断是否存在于这个矩阵中。
    /// Given an two dimension array with int, each line is ordered from small to large, and each column is ordered from small to large too
    /// However, the first number in sencond line may not bigger than the last number in the first line. 
    /// Given a target, determin whether the target is in the array. 
    /// </summary>
    public class SearchInOrderedMatrix
    {
        public static bool Contains( int[][] data, int target, int startRow, int startColumn,int endRow, int endColumn  )
        {
            if (data == null || data.Length == 0 ||  endRow < startRow || endColumn <startColumn) 
            {
                return false;
            }

            if (startRow >= data.Length || startColumn >= data[0].Length || endRow >= data.Length || endColumn >= data[0].Length)
            {
                return false;
            }

            int width = endColumn - startColumn + 1;
            int height = endRow - startRow + 1;
            int length = Math.Min(width, height);

            if( width != height )
            {

                return Contains(data, target, startRow, startColumn, startRow + length-1 , startColumn + length -1 ) 
                    || Contains(data, target, length == height?startRow:startRow + length , length == height? startColumn+ length  :startColumn,endRow,endColumn   );

            }
            else
            {
                int targetStartColumn = -1;
                int targetStartRow = -1;
                int targetEndColumn = -1;
                int targetEndRow = -1;
                bool result = BinarySearch(data, target, startRow, startColumn, startRow + length -1, startColumn + length -1,
                    out targetStartRow,out  targetStartColumn, out  targetEndRow, out  targetEndColumn);
                if( result )
                {
                    if( targetStartRow ==targetEndRow )
                    {
                        return true;
                    }
                    else
                    {
                        return Contains(data, target, startRow, targetStartColumn + 1, targetStartRow, targetEndColumn)
                            || Contains(data, target, targetStartRow + 1, startColumn, targetEndRow, targetStartColumn );
                    }
                }

            }

            return false;
        }
        private static bool BinarySearch(int[][] data, int target, int startRow, int startColumn, int endRow,
            int endColumn, out int targetStartRow, out int targetStartColumn, out int targetEndRow, out int targetEndColumn )
        {
            targetStartColumn = -1;
            targetStartRow= -1;
            targetEndColumn = -1;
            targetEndRow = -1;

            int length = endColumn - startColumn + 1;

            int left = 0, right = length -1, middle= 0;

            while( left <= right )
            {
                middle = (left + right) / 2;
                
                int column = startColumn + middle;
                int row = startRow +middle  ;


                if( target == data[row ][ column] )
                {
                    targetStartColumn = column;
                    targetStartRow= row;
                    targetEndColumn = column;
                    targetEndRow = row;
                    return true;
                }
                else if( row > 1 && column > 1 && target < data[row ][ column] && target >  data[row -1 ][ column -1]  )
                {
                     targetStartColumn = column -1;
                    targetStartRow= row -1;
                    targetEndColumn = column;
                    targetEndRow = row;
                    return true;
                }
                else if( target < data[row ][ column]  )
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return false;
        }

        public static bool Test()
        {
            int[][] data = new int[][] 
            {
                new int[]{1,3,5,7,9,10} ,
                new int[]{2,11,13,15,20,22},
                new int[]{12,14,16,18,25,26},
                new int[]{19,21,23,24,28,30}
            };

            bool result ;
            result = SearchInOrderedMatrix.Contains(data, 17, 0, 0, data.Length - 1, data[0].Length - 1);
            if (result)
            {
                return false;
            }

            result = SearchInOrderedMatrix.Contains(data, 100, 0, 0, data.Length - 1, data[0].Length - 1);
            if (result)
            {
                return false;
            }

            result = SearchInOrderedMatrix.Contains(data, 23, 0, 0, data.Length - 1, data[0].Length - 1);
            if( !result )
            {
                return false;
            }
            result = SearchInOrderedMatrix.Contains(data, 24, 0, 0, data.Length - 1, data[0].Length - 1);
            if (!result)
            {
                return false;
            }
            result = SearchInOrderedMatrix.Contains(data, 1, 0, 0, data.Length - 1, data[0].Length - 1);
            if (!result)
            {
                return false;
            }

            result = SearchInOrderedMatrix.Contains(data, 30, 0, 0, data.Length - 1, data[0].Length - 1);
            if (!result)
            {
                return false;
            }

            result = SearchInOrderedMatrix.Contains(data, 28, 0, 0, data.Length - 1, data[0].Length - 1);
            if (!result)
            {
                return false;
            }

            result = SearchInOrderedMatrix.Contains(data, 11, 0, 0, data.Length - 1, data[0].Length - 1);
            if (!result)
            {
                return false;
            }

            return true;
        }
    }
}
