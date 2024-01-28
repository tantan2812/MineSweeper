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
    internal class NumberTile:Square
    {
        Bitmap number1Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_1);
        Bitmap number2Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_2);
        Bitmap number3Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_3);
        Bitmap number4Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_4);
        Bitmap number5Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_5);
        Bitmap number6Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_6);
        Bitmap number7Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_7);
        Bitmap number8Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_8);

        public int Hint { get; set; }
        public int NeighborMinesCount { get; set; }

        public NumberTile(Context context, int X, int Y) : base(context, X, Y)
        {
            NeighborMinesCount = 0;
        }

        public void SetHint(int value)
        {
            Hint = value;
            Invalidate();
        }

        protected override void OnDraw(Canvas canvas)
        {
            if (Hint == 1)
                canvas.DrawBitmap(number1Cell, 0, 0, null);
            else if (Hint == 2)
                canvas.DrawBitmap(number2Cell, 0, 0, null);
            else if (Hint == 3)
                canvas.DrawBitmap(number3Cell, 0, 0, null);
            else if (Hint == 4)
                canvas.DrawBitmap(number4Cell, 0, 0, null);
            else if (Hint == 5)
                canvas.DrawBitmap(number5Cell, 0, 0, null);
            else if (Hint == 6)
                canvas.DrawBitmap(number6Cell, 0, 0, null);
            else if (Hint == 7)
                canvas.DrawBitmap(number7Cell, 0, 0, null);
            else if (Hint == 8)
                canvas.DrawBitmap(number8Cell, 0, 0, null);
            base.OnDraw(canvas);
        }
    }
}