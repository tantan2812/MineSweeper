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
    /// <summary>
    /// save every entry of game winning that we are putting in the leaderboard and return the numeric value back into readable human format of time
    /// </summary>
    internal class LeaderboardPlayer
    {
        public string Name { get; set; }
        public int IntTime { get; set; }
        public string StringTime { get; set; }
        public string Difficulty { get; set; }

        /// <summary>
        /// creates a new LeaderboardPlayer
        /// </summary>
        /// <param name="name">name of player</param>
        /// <param name="time">time it took to beat the game</param>
        public LeaderboardPlayer(string name, int time, string difficulty)
        {
            Name = name;
            IntTime = time;
            SetTimeFormat();
            Difficulty = difficulty;
        }

        /// <summary>
        /// return the numeric value back into readable human format of time
        /// </summary>
        public void SetTimeFormat()
        {
            int temp = IntTime;
            int min = temp / 60;
            int sec = temp & 60;
            StringTime = $"{min:D2} min {sec:D2} sec";
        }
    }
}