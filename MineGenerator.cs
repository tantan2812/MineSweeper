using Android.App;
using Android.Content;
using Android.Hardware.Lights;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Icu.Text.ListFormatter;

namespace MineSweeper
{
    internal class MineGenerator
    {
        public Square[,] PlaceMines(Square[,] squares)
        {
            Random rnd=new Random();
            int mines = Constants.NUMBER_OF_MINES;
            Square[,] dArr = squares;
           
            while (mines > 0)
            {
                int x = rnd.Next(Constants.NUMBER_OF_WIDTH);
                int y = rnd.Next(Constants.NUMBER_OF_HEIGHT);
                if (dArr[x, y].IsEmpty)
                {
                    dArr[x, y] = new Mine();
                    mines--;    
                }
            }
            return dArr;
        } 
    }
}