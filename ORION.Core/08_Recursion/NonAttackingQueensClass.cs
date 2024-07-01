using System;

namespace NonAttackingQueens
{
    /// <summary>
    /// Write a function that takes in positive  integer n and returns the number
    /// of non-attacking place placements of n queens on n x n chessboard.
    /// 
    /// A non-attaching placement is one where no queen can attack another queen
    /// in a single turn. In other words, It's a placement where no queen can move to the same 
    /// position as another queen is a single turn.
    /// 
    /// In Chess, queens can move any number of square horizontally, vertically or diagonally 
    /// in a single turn.
    /// 
    /// +--+--+--+--+
    /// |  | Q|  |  |
    /// +--+--+--+--+
    /// |  |  |  |Q |
    /// +--+--+--+--+
    /// |Q |  |  |  |
    /// +--+--+--+--+
    /// |  |  |Q |  |
    /// +--+--+--+--+
    /// 
    /// The chessboard above is an example of a non-attaching placements of 4 queens on a 4x4
    /// chessboard. For reference, there are only 2 non-attaching placements of 4 queens on a
    /// 4x4 chessboard. 
    /// </summary>
    public class NonAttackingQueensClass
    {
        public int NonAttachingQueens(int n)
        {
            int[] columnPlacements = new int[n];

            return getNumberOfNonAttachingQueenPlacements(0, columnPlacements, n);
        }

        public int getNumberOfNonAttachingQueenPlacements(int row, int[] columnPlacements, int boardSize)
        {
            if (row==boardSize)
            {
                return 1;
            }

            int validPlacements =0;
            for (int col = 0; col < boardSize; col++)
            {
                if (IsNonAttackingPlacement(row, col, columnPlacements))
                {
                    columnPlacements[row] = col;
                    validPlacements += getNumberOfNonAttachingQueenPlacements(row + 1, columnPlacements, boardSize);
                }
            }

            return validPlacements;
        }

        private bool IsNonAttackingPlacement(int row, int col, int[] columnPlacements)
        {
            for (int previousRow = 0; previousRow < row; previousRow++)
            {
                int columnToCheck = columnPlacements[previousRow];
                bool sameColumn = (columnToCheck == col);
                bool onDiagonal = Math.Abs(columnToCheck - col) == (row - previousRow);
                if (sameColumn || onDiagonal)
                {
                    return false;
                }
            }

            return true;
        }
    }
}