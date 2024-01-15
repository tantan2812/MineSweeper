using Android.App;
using Android.Content;
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
        public bool IsExploded { get; set; }
        public bool IsCorner { get; set; }
        public Mine(float X, float Y) : base(X, Y)
        {
            IsExploded = false;
        }

        public void HasExploded()
        {
            IsExploded=true;
        }
    }
}