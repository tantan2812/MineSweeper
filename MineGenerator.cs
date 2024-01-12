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
                int x = rnd.Next(Constants.NUMBER_OF_WIDTH+1);
                int y = rnd.Next(Constants.NUMBER_OF_HEIGHT+1);
                if (dArr[x, y].IsEmpty)
                {
                    dArr[x, y] = new Mine(x,y);
                    dArr[x, y].IsEmpty = false;
                    mines--;    
                }
            }
            return dArr;
        }

        private static Square[,] calculateNeigbours(Square[,] squares)
        {
            for (int x = 0; x < Constants.NUMBER_OF_WIDTH; x++)
            {
                for (int y = 0; y < Constants.NUMBER_OF_HEIGHT; y++)
                {
                    //squares[x,y] = getNeighbourNumber(squares, x, y);
                }
            }
            return squares;
        }


       

    }
}