using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    /// <summary>
    /// in charge of generating mines and hints in the board
    /// </summary>
    public class Generator
    {
        public Board Board { get; set; }

        /// <summary>
        /// creates a new generator
        /// </summary>
        /// <param name="board">sets into genrator's board</param>
        public Generator(Board board)
        {
            this.Board = board;
        }

        /// <summary>
        /// insert mines into the board and put hints in the corresponding places
        /// </summary>
        /// <returns></returns>
        public Square[,] InsertMinesAndHints()
        {
            Random rnd=new Random();
            int mines = Constants.NUMBER_OF_MINES;
            Square[,] squares = Board.Squares;
            while (mines > 0)
            {
                int x = rnd.Next(Constants.SIZE_OF_BOARD_WIDTH);
                int y = rnd.Next(Constants.SIZE_OF_BOARD_HEIGHT);
                if (IsMineAt(squares, x, y) == false)
                {
                    squares[x, y] = new Mine(Board.Context,x,y);
                    squares[x, y].SetEmpty();
                    mines--;    
                }
            }
            squares = CalculateNeigbours(squares);
            return squares;
        }

        /// <summary>
        /// put hints in the corresponding places
        /// </summary>
        /// <param name="squares">the squares with the mines</param>
        /// <returns></returns>
        private Square[,] CalculateNeigbours(Square[,] squares)
        {
            NumberTile value;
            for (int x = 0; x < Constants.SIZE_OF_BOARD_WIDTH; x++)
            {
                for (int y = 0; y < Constants.SIZE_OF_BOARD_HEIGHT; y++)
                    if (IsMineAt(squares, x, y) == false)
                    {
                        value=new NumberTile(Board.GetContext(),x, y);
                        value.NeighborMinesCount = GetNeighbourNumber(squares, x, y);
                        value.Hint=value.NeighborMinesCount;
                        if (value.Hint != 0)
                        {
                            squares[x, y]=value;
                            squares[x, y].SetEmpty();
                        }
                    }
            }
            return squares;
        }

        /// <summary>
        /// returns the number the hint should be for a specific square
        /// </summary>
        /// <param name="squares">the squares with the mines</param>
        /// <param name="x">specific square</param>
        /// <param name="y">specific square</param>
        /// <returns></returns>
        private static int GetNeighbourNumber(Square[,] squares, int x, int y)
        {
            int count = 0;

            if (IsMineAt(squares, x - 1, y + 1)) count++; // top-left
            if (IsMineAt(squares, x, y + 1)) count++; // top
            if (IsMineAt(squares, x + 1, y + 1)) count++; // top-right
            if (IsMineAt(squares, x - 1, y)) count++; // left
            if (IsMineAt(squares, x + 1, y)) count++; // right
            if (IsMineAt(squares, x - 1, y - 1)) count++; // bottom-left
            if (IsMineAt(squares, x, y - 1  )) count++; // bottom
            if (IsMineAt(squares, x + 1, y - 1)) count++; // bottom-right

            return count;
        }

        /// <summary>
        /// checks if a specific square is a mine
        /// </summary>
        /// <param name="squares">the squares with the mines</param>
        /// <param name="x">specific square</param>
        /// <param name="y">specific square</param>
        /// <returns></returns>
        private static bool IsMineAt(Square[,] squares, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Constants.SIZE_OF_BOARD_WIDTH && y < Constants.SIZE_OF_BOARD_HEIGHT)
                if (squares[x, y] is Mine)
                    return true;
            return false;
        }
    }
}