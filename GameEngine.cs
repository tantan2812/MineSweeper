using Android.App;
using Android.Content;
using Android.OS;
using Android.Print;
using Android.Runtime;
using Android.Telecom;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

           // return Board.GetSquare(x,y);
            return Board.squares[x, y];

        }

        public Square getCellAt(int x, int y)
        {
            // return Board.GetSquare(x,y);
            return Board.squares[x,y];
        }
    }
}