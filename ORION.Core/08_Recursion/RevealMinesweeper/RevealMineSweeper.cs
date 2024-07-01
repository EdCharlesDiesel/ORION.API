using System.Collections.Generic;

namespace RevealMinesweeper
{
    /// <summary>
    /// Minesweeper is popular video game. From Wikipedia, "The game features a grid
    /// of clikable squares, with hidden "mines" scattered throughout the board. The
    /// objective is to clear the
    /// board without detonating any mines. with help from clues about the number of 
    /// neighboring mines in each field." Specifically, when a player clicks on square(
    /// also called cell) that doen't contain a mine, the square reveals a number representing
    /// the number of immediately adjacent (including diagonally adjacent mines).
    /// 
    /// You're given a two-dimentional array of string that represent a minesweeper board 
    /// for a game a in progress. You're also given a row
    /// and a column representing the indices of the next square that player clicks on the 
    /// board. write a function that returns an updated board after the click (Your function
    /// can mutate the input board).
    /// 
    /// The board will always contain only strings, and string will be one of the following:
    /// "M": A mine that has not been clicked
    /// "X": A mine that has been clicked on.
    /// "H": A cell with no mine, but whose content is still hidden to the player.
    /// "0-8": A Cell with no mine, wuth an integer from 0 to 8 representing the numberof 
    /// adjacent mines. Note that this is a single-digit integer represented as a string for example
    /// "2" would mean there are 2 adjacent cells with mines. Numbered calls are not
    /// clickable as the have already been revealed.
    /// 
    /// If the player clicks on a mine, replace "M" with "X", indicating the game was lost.
    /// if the player clicks on a cell adjacent to a mine, replace "H" with a string 
    /// representing the number of adjacent mines.
    /// 
    /// if the player clicks on a cell with no adjacent mines, replace with "H" with "0". Additionally
    /// reveal all of the adjacent hidden cells as if the player had clicked on those cells as well.
    /// 
    /// You can assume the given row and column will always represent a legal move. the board can be 
    /// of any size and have any number of mines in it.
    /// 
    /// </summary>
    public class RevealMineSweeper
    {
        public string[][] RevealMineSweeperMethod(string[][] board, int row, int column)
        {
            if (board[row][column].Equals("M"))
            {
                board[row][column] = "X";
                return board;
            }

            List<CellLocation> neighbors = getNeighbors(board, row, column);
            int adjacentMinesCount = 0;
            foreach (var neighbor in neighbors)
            {
                if (board[neighbor.row][neighbor.column].Equals("M"))
                {
                    adjacentMinesCount++;
                }
            }

            if (adjacentMinesCount > 0)
            {
                board[row][column] = adjacentMinesCount.ToString();
            }
            else
            {
                board[row][column] = "0";
                foreach (var neighbor in neighbors)
                {
                    if (board[neighbor.row][neighbor.column].Equals("H"))
                    {
                        RevealMineSweeperMethod(board, neighbor.row, neighbor.column);
                    }
                }
            }
            return board;
        }

        private List<CellLocation> getNeighbors(string[][] board, int row, int column)
        {
            int[,] directions = new int[8, 2]
            {
                { 0, 1 },{ 0,-1 },{ 1,0 },{ -1,0 },{ 1,1 },{ 1,-1 },{ -1,1 },{ -1,-1 }
            };

            List<CellLocation> neighbors = new List<CellLocation>();
            for (var i = 0; i < directions.GetLength(0); i++)
            {
                int newRow = row + directions[i, 0];
                int newColumn = column + directions[i, 1];

                if (0 <= newRow && newRow< board.Length && 0 <= newColumn && newColumn < board[0].Length)
                {
                    neighbors.Add(new CellLocation(newRow, newColumn));
                }
            }

            return neighbors;
        }
    }

    public class CellLocation
    {
        public int row;
        public int column;

        public CellLocation(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}