﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// inherits from square, handles the numbertile parameters and drawing it
    /// </summary>
    internal class NumberTile:Square
    {
        [JsonIgnore]
        Bitmap number1Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_1);
        [JsonIgnore]
        Bitmap number2Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_2);
        [JsonIgnore]
        Bitmap number3Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_3);
        [JsonIgnore]
        Bitmap number4Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_4); 
        [JsonIgnore]
        Bitmap number5Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_5);
        [JsonIgnore]
        Bitmap number6Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_6);
        [JsonIgnore]
        Bitmap number7Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_7);
        [JsonIgnore]
        Bitmap number8Cell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_8);

        public int Hint { get; set; }
        public int NeighborMinesCount { get; set; }

        /// <summary>
        /// creates a mine and it gives it the default parameters
        /// </summary>
        /// <param name="context"></param>
        /// <param name="X">specific square</param>
        /// <param name="Y">specific square</param>
        public NumberTile(Context context, int X, int Y) : base(context, X, Y)
        {
            NeighborMinesCount = 0;
        }

        /// <summary>
        /// creates a mine and it gives it the default parameters
        /// </summary>
        /// <param name="context"></param>
        public NumberTile(Context context) : base(context)
        {
            NeighborMinesCount = 0;
        }

        /// <summary>
        /// set hint func and draws it
        /// </summary>
        /// <param name="value"></param>
        public void SetHint(int value)
        {
            Hint = value;
            Invalidate();
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
        /// scales the bitmap and handles the drawing of a hint
        /// </summary>
        /// <param name="canvas">the canvas were drawing on</param>
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