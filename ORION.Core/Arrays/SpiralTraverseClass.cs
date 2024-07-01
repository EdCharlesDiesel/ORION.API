using System;
using System.Collections.Generic;

namespace SpiralTraverse
{
    /// <summary>
    /// Write a function that takes in an n x m two-dimensional array (that can be square-shaped
    /// when n==m) and returns one-dimensional array of all the array's elements in spiral order.
    /// 
    /// Spiral order starts at the top left corner of the two-dimensional array, goes to the right,
    /// and proceeds in a spiral pattern all the way until every element has been visited.
    /// </summary>
    public static class SpiralTraverseClass
    {
        public static List<int> SpiralTraverse(int[,] array)
        {
     
            if (array.GetLength(0)==0) return new List<int>();

            var result = new List<int>();
            var startRow =0;
            var endRow =array.GetLength(0)-1;
            var startCol = 0;
            var endCol = array.GetLength(1) - 1;
            while (startRow <= endRow && startCol<= endCol) {
                for (int col = startCol; col <= endCol; col++)
                {
                    result.Add(array[startRow, col]);
                }

                for (int row = startRow +1; row <= endRow;row++)
                {
                    result.Add(array[row, endCol]);
                }

                for (int col = endCol-1; col >= startCol; col--)
                {
                    // Handle the edge case there's a single row
                    // in the middle of the matrix. In this case, we don't
                    // want  to double-count the values in this row, which
                    // we've already counted inthe first the loop above.
                    // See the test Case 8 for an example of this edge case
                    if (startRow == endRow) break;
                    result.Add(array[endRow, col]);
                    
                }

                for (int row = endRow -1; row > startRow; row--)
                {
                    // handle the edge case when there's a sing;e column
                    // in the middle of the matrix. In this case, we don't
                    // want to double-count the values in the column, which
                    // we've already counted in the second for loop above.
                    // See Test case 9 for an example of the edge case.

                    if (startCol == endCol) break;
                    result.Add(array[row, startCol]);
                }

                startRow++;
                endRow--;
                startCol++;
                endCol--;
            }

            return result;
        }
    }
}