﻿using Android.App;
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
    internal class Board:Shape
    {
        public Board(float x, float y, Color color) : base(x,y,color)
        {
        }

        public override void Draw(Canvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}