using System.Collections.Generic;

namespace ORION.Core.Graphs
{
    internal class SquareOfZeroesClass2
    {
        // O(n^4) time | O(1) space - where n is the height and width of the matrix
        public static bool SquareOfZeroes(List<List<int>> matrix)
        {
            int n = matrix.Count;
            for (int topRow = 0; topRow < n; topRow++)
            {
                for (int leftCol = 0; leftCol < n; leftCol++)
                {
                    int squareLength = 2;
                    while (squareLength <= n - leftCol && squareLength <= n - topRow)
                    {
                        int bottomRow = topRow + squareLength - 1;
                        int rightCol = leftCol + squareLength - 1;
                        if (isSquareOfZeroes(matrix, topRow, leftCol, bottomRow,
                        rightCol)) return true;
                        squareLength++;
                    }
                }
            }
            return false;
        }
        // r1 is the top row, c1 is the left column
        // r2 is the bottom row, c2 is the right column
        public static bool isSquareOfZeroes(List<List<int>> matrix, int r1, int c1, int r2, int c2)
        {
            for (int row = r1; row < r2 + 1; row++)
            {
                if (matrix[row][c1] != 0 || matrix[row][c2] != 0) return false;
            }
            for (int col = c1; col < c2 + 1; col++)
            {
                if (matrix[r1][col] != 0 || matrix[r2][col] != 0) return false;
            }
            return true;
        }
    }
}
