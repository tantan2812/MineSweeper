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
    internal class LeaderboardPlayer
    {
        public string Name { get; set; }
        public long IntTime { get; set; }
        public string StringTime { get; set; }

        public LeaderboardPlayer(string name, long time)
        {
            Name = name;
            IntTime = time;
            SetTimeFormat();
        }

        public void SetTimeFormat()
        {
            long temp = IntTime;
            long min = temp / 60;
            long sec = temp & 60;
            StringTime = min + ": " + sec;
        }
    }
}