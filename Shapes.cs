using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    internal class Shapes
    {

        public Board GameBoard { get; set; }
        private Score score;

        public Shapes(int screenWidth, int screenHight)
        {
            CreateShapes(screenWidth, screenHight);
        }

        private void CreateShapes(int screenWidth, int screenHight)
        {
            score = new Score(screenWidth, screenHight, Color.Blue, Constants.TEXT_SIZE);
            GameBoard= new Board(screenWidth, screenHight, Color.Black);
            GameBoard.GenerateFullBoard();
        }

        internal void DrawShapes(Canvas canvas)
        {
            score.Draw(canvas);
            GameBoard.Draw(canvas);

        }
    }
}