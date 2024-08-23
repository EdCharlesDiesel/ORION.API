using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORION.Core.Arrays
{
    public static class PrintMatrixClass
    {
        /// <summary>
        /// Read the matrix below.
        ///  { 1 5 9  13 }
        ///  { 2 6 10 14 }
        ///  { 3 7 11 15 }
        ///  { 4 8 12 16 }
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[,] DoMatrixA(int n)
        {
            var matrix = new int[n, n];
            matrix[0, 0] = 1;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                matrix[0, i] = matrix[0, i - 1] + n;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + 1;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Read the matrix below.
        ///  { 1 5 9  13 }
        ///  { 2 6 10 14 }
        ///  { 3 7 11 15 }
        ///  { 4 8 12 16 }
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        public static int[,] DoMatrixB(int dim)
        {
            var matrix = new int[dim, dim];
            matrix[0, 0] = 1;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 1)
                {
                    matrix[0, i] = matrix[0, i - 1] + dim * 2 - 1;
                }
                else
                {
                    matrix[0, i] = matrix[0, i - 1] + 1;
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j % 2 == 1)
                    {
                        matrix[i, j] = matrix[i - 1, j] - 1;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j] + 1;
                    }                    
                }                
            }

            return matrix;
        }
    }
}
