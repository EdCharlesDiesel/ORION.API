﻿using System.Collections.Generic;

namespace ORION.Core.Graphs
{
    public class SquareOfZeroesClass
    {
        // O(n^4) time | O(n^3) space - where n is the height and width of the matrix
        public static bool SquareOfZeroes(List<List<int>> matrix)
        {
            int lastIdx = matrix.Count - 1;
            Dictionary<string, bool> cache = new Dictionary<string, bool>();
            return hasSquareOfZeroes(matrix, 0, 0, lastIdx, lastIdx, cache);
        }
        // r1 is the top row, c1 is the left column
        // r2 is the bottom row, c2 is the right column
        public static bool hasSquareOfZeroes(List<List<int>> matrix, int r1, int c1, int r2, int c2, Dictionary<string, bool> cache)
        {
            if (r1 >= r2 || c1 >= c2) return false;
            string key = r1.ToString() + '-' + c1.ToString() + '-' + r2.ToString() + '-' + c2.ToString();

            if (cache.ContainsKey(key)) return cache[key];
            cache[key] = 
            isSquareOfZeroes(matrix, r1, c1, r2, c2) ||
            hasSquareOfZeroes(matrix, r1 + 1, c1 + 1, r2 - 1, c2 - 1, cache) ||
            hasSquareOfZeroes(matrix, r1, c1 + 1, r2 - 1, c2, cache) ||
            hasSquareOfZeroes(matrix, r1 + 1, c1, r2, c2 - 1, cache) ||
            hasSquareOfZeroes(matrix, r1 + 1, c1 + 1, r2, c2, cache) ||
            hasSquareOfZeroes(matrix, r1, c1, r2 - 1, c2 - 1, cache);
            return cache[key];
        }
        // r1 is the top row, c1 is the left column
        // r2 is the bottom row, c2 is the right column
        public static bool isSquareOfZeroes(List<List<int>> matrix, int r1,int c1, int r2, int c2 )
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