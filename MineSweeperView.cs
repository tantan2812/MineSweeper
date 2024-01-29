using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MineSweeper
{
    internal class MineSweeperView : GridView
    {
        GestureDetector gestureDetector;
        public Board Board { get; set; }
        public Square[,] Squares { get; set; }

        public MineSweeperView(Context context) : base(context)
        {
            Board = new Board(context);
            Board.GenerateFullBoard();
            Squares = Board.Squares;
            GestureDetector gestureDetector = new GestureDetector(context, new GestureListener());
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            canvas.DrawColor(Color.Aqua);
            for (int i = 0; i < Constants.SIZE_OF_BOARD_WIDTH; i++)
            {
                for (int j = 0; j < Constants.SIZE_OF_BOARD_HEIGHT; j++)
                {
                    Squares[i, j].Draw(canvas);
                }
            }
        }

        protected override void OnMeasure(int widthMeasure, int heightMeasure)
        {
            base.OnMeasure(widthMeasure, heightMeasure);
        }


        public override bool OnTouchEvent(MotionEvent e)
        {
            return gestureDetector.OnTouchEvent(e);
        }
    }
}