using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MineSweeper
{
    internal class BaseCell:View
    {
        private int value { get; set; }
        private float X { get; set; }
        private float Y { get; set; }
        private int position { get; set; }
        private bool IsRevealed { get; set; }
        private bool IsFlagged { get; set; }
        private bool IsClicked { get; set; }
        private bool IsBomb { get; set; }


        public BaseCell(Context context) : base(context)
        {

        }

        public void setValue(int value)
        {
            IsBomb = false;
            IsRevealed = false;
            IsClicked = false;
            IsFlagged = false;

            if (value == -1)
            {
                IsBomb = true;
            }

            this.value = value;
        }

        public void Reveal() 
        {
            IsRevealed = true;
        }
    }
}