using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    internal class Generator
    {
        public Board Board { get; set; }

        public Generator(Board board)
        {
            this.Board = board;
        }
        public Square[,] InsertMinesAndHints()
        {
            Random rnd=new Random();
            int mines = Constants.NUMBER_OF_MINES;
            Square[,] squares = Board.squares;
            while (mines > 0)
            {
                int x = rnd.Next(Constants.NUMBER_OF_WIDTH);
                int y = rnd.Next(Constants.NUMBER_OF_HEIGHT);
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

        private Square[,] CalculateNeigbours(Square[,] squares)
        {
            NumberTile value;
            for (int x = 0; x < Constants.NUMBER_OF_WIDTH; x++)
            {
                for (int y = 0; y < Constants.NUMBER_OF_HEIGHT; y++)
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

        private static bool IsMineAt(Square[,] squares, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Constants.NUMBER_OF_WIDTH && y < Constants.NUMBER_OF_HEIGHT)
                if (squares[x, y] is Mine)
                    return true;
            return false;
        }
    }
}