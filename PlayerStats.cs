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
    internal class PlayerStats
    {

        public int GamesWon { get; set; }
        public int MinesFound { get; set;}
        public List<Game> games { get; set; }

        public PlayerStats(int gamesWon, int minesFound, List<Game> games)
        {
            GamesWon = gamesWon;
            MinesFound = minesFound;
            this.games = games;
        }

        public PlayerStats()
        {

        }
    }
}