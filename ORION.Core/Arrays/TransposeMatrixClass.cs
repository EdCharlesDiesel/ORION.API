using System;

namespace ORION.Core.Arrays
{
    /// <summary>
    /// You're given a 2D array of integers matrix. Write a function that returns the transpose
    /// of the matrix.
    /// 
    /// The transpose of a matrix is a flipped version of the original matrix across it's main diagonal
    /// (which runs from top-left to bottom-righ); It switches the row and column indices of the
    /// original matrix.
    /// 
    /// You can assume that the inout matrix always has atleast 1 value;however its width and heigh 
    /// are not necessarily the same.
    /// </summary>
    public class TransposeMatrixClass
    {
        public int[,] TransposeMatrix(int[,] matrix)
        {
            var transposeMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    transposeMatrix[col, row] = matrix[row, col];
                }
            }

            return transposeMatrix;
        }
    }
}