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
    internal class Square
    {
        public float X { get; set; }
        public float Y { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsFlagged { get; set; }

        public Square(float X, float Y)
        {
            IsRevealed = false;
            IsEmpty = true;
            IsFlagged = false;
        }
        public Square() { }

        public void Reveal() 
        {
            IsRevealed = true;
        }

        public void Flag()
        {
            IsFlagged=true;
        }

    }
}