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

        public static GameEngine GetInstance()
        {
            instance ??= new GameEngine();
            return instance;
        }

        public void CreateGrid(Context context)
        {
            this.context = context;
            Board = new Board(context);
            Board.GenerateFullBoard();
        }

        public Square GetCellAt(int position)
        {
            int x = position % WIDTH;
            int y = position / WIDTH;
            Board.Squares[x, y].PostInvalidate();
            return Board.Squares[x, y];

        }

        public Square GetCellAt(int x, int y)
        {
            return Board.Squares[x,y];
        }

        private bool CheckEnd()
        {
            int bombNotFound = BOMB_NUMBER;
            int notRevealed = WIDTH * HEIGHT;
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    if (GetCellAt(x, y).IsRevealed || GetCellAt(x, y).IsFlagged)
                        notRevealed--;
                    if (GetCellAt(x, y).IsFlagged && GetCellAt(x, y) is Mine)
                        bombNotFound--;
                }

            if (bombNotFound == 0 && notRevealed == 0)
                Toast.MakeText(context, "Game won", ToastLength.Long).Show();
            return false;
        }

        internal void Click(int x, int y)
        {
            if(x>=0&&y>=0&&x<WIDTH && y<HEIGHT&&!GetCellAt(x, y).IsClicked&& !GetCellAt(x, y).IsFlagged)
            {
                GetCellAt(x, y).Revealed();
                if (!(GetCellAt(x, y) is NumberTile)&&!(GetCellAt(x, y) is Mine))
                    for (int xt = -1; xt <= 1; xt++)
                        for (int yt = -1; yt <= 1; yt++)
                            if (xt != yt)
                                Click(x + xt, y + yt);
                if (GetCellAt(x, y) is Mine)
                    MineClicked(x,y);
            }
                
            CheckEnd();
        }

        private void MineClicked(int x, int y)
        {
            //temp
            GetCellAt(x, y).Revealed();
        }

        internal void Flag(int x, int y)
        {
            if(!GetCellAt(x, y).IsClicked&& !GetCellAt(x, y).IsRevealed)
            {
                bool isFlagged = GetCellAt(x, y).IsFlagged;
                GetCellAt(x, y).SetFlagged(!isFlagged);
                GetCellAt(x, y).Invalidate();
            }
        }
    }
}