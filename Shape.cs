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
    internal abstract class Shape
    {
        public float X { get; set; }
        public float Y { get; set; }
        protected float ScreenWidth;
        protected float ScreenHight;

        protected Paint ShapePaint;
        protected Color ShapeColor;

        public Shape(float x, float y, Color color)
        {
            X = x;
            Y = y;
            ShapeColor = color;
            ShapePaint = new Paint();
            ShapePaint.Color = color;
        }

        public abstract void Draw(Canvas canvas);

    }
}