using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MineSweeper
{
    internal class Mine:Square
    {
        [JsonIgnore]
        Bitmap MineCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bomb_normal);
        [JsonIgnore]
        Bitmap ExploededMineCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bomb_exploded);


        public bool IsExploded { get; set; }
        public bool IsExplodedState { get; set; }
        public bool ShouldAnimate { get; set; }
        public bool IsCorner { get; set; }
        public Mine(Context context, int X, int Y) : base(context, X, Y)
        {
            IsExploded = false;
            IsExplodedState = true;
        }

        public Mine(Context context) : base(context)
        {
            IsExploded = false;
        }

        public void HasExploded()
        {
            IsExploded=true;
            IsRevealed=true;
            IsClicked=true;
            ShouldAnimate=true;
            Invalidate();
            PostInvalidate();
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
            Bitmap ScaledExploededMineCell = ScaleBitmap(ExploededMineCell, scaledWidth, scaledHeight);
            if (IsExploded&& ShouldAnimate)
            {
                if (IsExplodedState)
                    canvas.DrawBitmap(ScaledExploededMineCell, 0, 0, null);
                else
                    canvas.DrawBitmap(ScaledMineCell, 0, 0, null);
                IsExplodedState = !IsExplodedState;
                Handler.PostDelayed(() =>
                {
                    if (ShouldAnimate)
                    {
                        Invalidate();
                    }
                }, 100);
            }
            else if (IsRevealed)
                canvas.DrawBitmap(ScaledMineCell, 0, 0, null);
        }

        public void StopAnimation()
        {
            ShouldAnimate = false; 
            IsClicked=false;
            IsRevealed=false;
            IsFlagged = false;
            Handler.RemoveCallbacksAndMessages(null);
            Invalidate();
        }
    }
}