using Android.Content;
using Android.Widget;
using System;

namespace MineSweeper
{
    internal class GameEngine
    {
        private static GameEngine instance;
        private Context context;
        public static readonly int BOMB_NUMBER = Constants.NUMBER_OF_MINES;
        public static readonly int WIDTH = Constants.SIZE_OF_BOARD_WIDTH;
        public static readonly int HEIGHT = Constants.SIZE_OF_BOARD_HEIGHT;
        public Board Board { get; private set; }

        public static GameEngine getInstance()
        {
            if (instance == null)
            {
                instance = new GameEngine();
            }
            return instance;
        }

        public void createGrid(Context context)
        {
            this.context = context;
            Board = new Board(context);
            Board.GenerateFullBoard();
        }

        public Square getCellAt(int position)
        {
            int x = position % WIDTH;
            int y = position / WIDTH;

            return Board.GetSquare(x,y);
            //return Board.squares[x, y];

        }

        public Square getCellAt(int x, int y)
        {
            // return Board.GetSquare(x,y);
            return Board.squares[x,y];
        }

        private bool checkEnd()
        {
            int bombNotFound = BOMB_NUMBER;
            int notRevealed = WIDTH * HEIGHT;
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    if (getCellAt(x, y).IsRevealed || getCellAt(x, y).IsFlagged)
                        notRevealed--;
                    if (getCellAt(x, y).IsFlagged && getCellAt(x, y) is Mine)
                        bombNotFound--;
                }

            if (bombNotFound == 0 && notRevealed == 0)
                Toast.MakeText(context, "Game won", ToastLength.Long).Show();
            return false;
        }

        internal void Click(int x, int y)
        {
            throw new NotImplementedException();
        }

        internal void Flag(int x, int y)
        {
            bool isFlagged = getCellAt(x, y).IsFlagged;
            getCellAt(x, y).SetFlagged(!isFlagged);
            getCellAt(x, y).Invalidate();
        }
    }
}