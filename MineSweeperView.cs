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

namespace MineSweeper
{
    internal class MineSweeperView : GridView
    {
        GestureDetector gestureDetector;
        public Board Board { get; set; }
        public Square[,] Squares { get; set; }
        public MineSweeperView(Context context, int screenWidth, int screenHight) : base(context)
        {
            Board= new Board(context, screenWidth, screenHight, Color.Green);
            Board.GenerateSquares();
            Squares = Board.squares;
            GestureDetector gestureDetector = new GestureDetector(context, new GestureListener());
        }

        public void Run()
        {

        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
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