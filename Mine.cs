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
        public Mine(Context context, float X, float Y) : base(context, X, Y)
        {
            IsExploded = false;
        }

        public void HasExploded()
        {
            IsExploded=true;
        }

        protected override void OnDraw(Canvas canvas)
        {
            if (IsExploded == true)
                canvas.DrawBitmap(ExploededMineCell, 0, 0, null);
            else
                canvas.DrawBitmap(MineCell, 0, 0, null);
            base.OnDraw(canvas);
        }

    }
}