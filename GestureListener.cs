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
using static Android.Views.GestureDetector;

namespace MineSweeper
{
    internal class GestureListener: SimpleOnGestureListener
    {
        public override bool OnSingleTapConfirmed(MotionEvent e)
        {
            return base.OnSingleTapConfirmed(e);
        }

        public override void OnLongPress(MotionEvent e)
        {
            base.OnLongPress(e);
        }
    }
}