using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    internal class Grid : GridView
    {
        public Grid(Context context, IAttributeSet attrs) : base(context, attrs)
        {

        }
    }
}