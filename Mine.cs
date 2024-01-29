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
    internal class Mine:Square
    {
        Bitmap MineCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bomb_normal);
        Bitmap ExploededMineCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bomb_exploded);


        public bool IsExploded { get; set; }
        public bool IsCorner { get; set; }
        public Mine(Context context, int X, int Y) : base(context, X, Y)
        {
            IsExploded = false;
        }

        public void HasExploded()
        {
            IsExploded=true;
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
            Bitmap ScaledMineCell = ScaleBitmap(MineCell, scaledWidth, scaledHeight);
            Bitmap ScaledScaledMineCell = ScaleBitmap(ScaledMineCell, scaledWidth, scaledHeight);
            if (this.IsClicked && this.IsRevealed)
            {
                if (IsExploded == true)
                    canvas.DrawBitmap(ScaledScaledMineCell, 0, 0, null);
                else
                    canvas.DrawBitmap(ScaledMineCell, 0, 0, null);
            }
               
        }

    }
}