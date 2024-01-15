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
                    squares[x, y] = new Mine(x,y);
                    squares[x, y].IsEmpty = false;
                    mines--;    
                }
            }
            squares = CalculateNeigbours(squares);
            return squares;
        }

        /*private Square[,] calculateNeigbours(Square[,] squares)
        {
            IEnumerable<Square> neighbours = null;
            for (int x = 0; x < Constants.NUMBER_OF_WIDTH; x++)
            {
                for (int y = 0; y < Constants.NUMBER_OF_HEIGHT; y++)
                {
                    if (squares[x, y] is Mine)
                        neighbours = Board.GetNeighbours(squares[x,y]);
                }
            }
            squares = PutHintInBoard(squares, neighbours);
            return squares;
        }

        private Square[,] PutHintInBoard(Square[,] squares, IEnumerable<Square> neighbours)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    for (int h = 0; h < neighbours.Count(); h++)
                    {

                    }
                }
            }
        }*/

        private static Square[,] CalculateNeigbours(Square[,] squares)
        {
            NumberTile value;
            for (int x = 0; x < Constants.NUMBER_OF_WIDTH; x++)
            {
                for (int y = 0; y < Constants.NUMBER_OF_HEIGHT; y++)
                {
                    if (IsMineAt(squares, x, y) == false)
                    {
                        value=new NumberTile(x, y);
                        value.NeighborMinesCount = GetNeighbourNumber(squares, x, y);
                        value.Hint=value.NeighborMinesCount;
                        if(value.Hint!=0)
                            squares[x, y]=value;
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