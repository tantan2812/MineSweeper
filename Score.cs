using Android.Graphics;
using System;

namespace MineSweeper
{
    internal class Score:Shape
    {
        public int ClearSquares { get; set; }
        private int textSize;

        public Score(float screenWidth, float screenHigth, Color color, int textSize) : base(screenWidth, screenHigth / 2, color)
        {
            ClearSquares = 0;
            ScreenWidth = screenWidth;
            ScreenHight = screenHigth;
            this.textSize = textSize;
            ShapePaint.TextSize = this.textSize;
        }

        public override void Draw(Canvas canvas)
        {
            string scoreText = string.Format("Score: {0}", ClearSquares);
            X = (int)(ScreenWidth - ShapePaint.MeasureText(scoreText)) / 2;
            canvas.DrawText(scoreText, X, Y, ShapePaint);
        }
    }
}