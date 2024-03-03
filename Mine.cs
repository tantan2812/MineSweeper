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
    /// <summary>
    /// inherits from square, handles the mine parameters and drawing it
    /// </summary>
    internal class Mine:Square
    {
        [JsonIgnore]
        public Bitmap MineCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bomb_normal);
        [JsonIgnore]
        public Bitmap ExploededMineCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.bomb_exploded);


        public bool IsExploded { get; set; }
        public bool IsExplodedState { get; set; }
        public bool ShouldAnimate { get; set; }
        public bool IsCorner { get; set; }

        /// <summary>
        /// creates a mine and it gives it the default parameters
        /// </summary>
        /// <param name="context">the activity to put the view on</param>
        /// <param name="X">specific square</param>
        /// <param name="Y">specific square</param>
        public Mine(Context context, int X, int Y) : base(context, X, Y)
        {
            IsExploded = false;
            IsExplodedState = true;
        }

        /// <summary>
        ///  creates a mine and it gives it the default parameters
        /// </summary>
        /// <param name="context">the activity to put the view on</param>
        public Mine(Context context) : base(context)
        {
            IsExploded = false;
        }

        /// <summary>
        /// sets exploded parameters
        /// </summary>
        public void HasExploded()
        {
            IsExploded=true;
            IsRevealed=true;
            IsClicked=true;
            ShouldAnimate=true;
            Invalidate();
            PostInvalidate();
        }

        /// <summary>
        /// scales the bitmap
        /// </summary>
        /// <param name="original">the bitmap</param>
        /// <param name="newWidth">size of scaling</param>
        /// <param name="newHeight">size of scaling</param>
        /// <returns></returns>
        private Bitmap ScaleBitmap(Bitmap original, int newWidth, int newHeight)
        {
            return Bitmap.CreateScaledBitmap(original, newWidth, newHeight, true);
        }

        /// <summary>
        /// scales the bitmap and handles the drawing of a mine
        /// </summary>
        /// <param name="canvas">the canvas were drawing on</param>
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