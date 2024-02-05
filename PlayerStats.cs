using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    [Table("Stats")]
    public class PlayerStats
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int GamesWon { get; set; }
        public int GamesPlayed { get; set; }
        public int MinesFound { get; set;}

        public PlayerStats(int gamesWon, int minesFound, int gamesPlayed)
        {
            GamesWon = gamesWon;
            MinesFound = minesFound;
            GamesPlayed = gamesPlayed;
        }

        public PlayerStats()
        {
            GamesWon = 0;
            MinesFound = 0;
            GamesPlayed = 0;
        }
        // retrn a %WinRate
        public String WinRate()
        {
            double NumaAvg=0;
            NumaAvg = (double)((double)GamesWon / (double)GamesPlayed);
            NumaAvg = NumaAvg * 100;
            int IntAvg = (int)NumaAvg;
            string StringAvg = IntAvg + "%";
            return StringAvg;

        }
    }
}