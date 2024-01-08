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
    internal class NumberTile:Square
    {
        public int numOnTile { get; set; }
        public int NeighborMinesCount { get; set; }

    }
}