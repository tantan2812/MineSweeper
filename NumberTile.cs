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

        private Bitmap ScaleBitmap(Bitmap original, int newWidth, int newHeight)
        {
            return Bitmap.CreateScaledBitmap(original, newWidth, newHeight, true);
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            int scaledWidth = Width;
            int scaledHeight = Height;
            Bitmap Scalednumber1Cell = ScaleBitmap(number1Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber2Cell = ScaleBitmap(number2Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber3Cell = ScaleBitmap(number3Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber4Cell = ScaleBitmap(number4Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber5Cell = ScaleBitmap(number5Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber6Cell = ScaleBitmap(number6Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber7Cell = ScaleBitmap(number7Cell, scaledWidth, scaledHeight);
            Bitmap Scalednumber8Cell = ScaleBitmap(number8Cell, scaledWidth, scaledHeight);
            if (this.IsClicked&&this.IsRevealed)
            {
                if (Hint == 1)
                    canvas.DrawBitmap(Scalednumber1Cell, 0, 0, null);
                else if (Hint == 2)
                    canvas.DrawBitmap(Scalednumber2Cell, 0, 0, null);
                else if (Hint == 3)
                    canvas.DrawBitmap(Scalednumber3Cell, 0, 0, null);
                else if (Hint == 4)
                    canvas.DrawBitmap(Scalednumber4Cell, 0, 0, null);
                else if (Hint == 5)
                    canvas.DrawBitmap(Scalednumber5Cell, 0, 0, null);
                else if (Hint == 6)
                    canvas.DrawBitmap(Scalednumber6Cell, 0, 0, null);
                else if (Hint == 7)
                    canvas.DrawBitmap(Scalednumber7Cell, 0, 0, null);
                else if (Hint == 8)
                    canvas.DrawBitmap(Scalednumber8Cell, 0, 0, null);
            }
            
        }
    }
}