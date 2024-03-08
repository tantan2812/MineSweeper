using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// shows every entry int the leaderboard in the list 
    /// </summary>
    internal class leaderboardAdapter : BaseAdapter<LeaderboardPlayer>
    {
        private Context context;
        private List<LeaderboardPlayer> lstLeaderboardPlayer;

        /// <summary>
        /// creates a new adapter
        /// </summary>
        /// <param name="context"> tells on which screen to show the leaderboard</param>
        public leaderboardAdapter(Context context)
        {
            this.context = context;
            lstLeaderboardPlayer = new List<LeaderboardPlayer>();
        }

        /// <summary>
        /// takes the LeaderboardPlayer in the position on the list and looks at it as is
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public override LeaderboardPlayer this[int position] => lstLeaderboardPlayer[position];

        /// <summary>
        /// returns the length of the list
        /// </summary>
        public override int Count => lstLeaderboardPlayer.Count;

        /// <summary>
        /// returns the LeaderboardPlayer position
        /// </summary>
        /// <param name="position">position of LeaderboardPlayer in the list</param>
        /// <returns></returns>
        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// inflates every enrty and put it on the list
        /// </summary>
        /// <param name="position">the number of the entry</param>
        /// <param name="convertView">unused</param>
        /// <param name="parent">unused</param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater li = LayoutInflater.From(context);
            View v = li.Inflate(Resource.Layout.layout_leaderboard, parent, false);
            LeaderboardPlayer lbp = lstLeaderboardPlayer[position];
            TextView tvPlayer = v.FindViewById<TextView>(Resource.Id.tvPlayer);
            TextView tvTimeToWin = v.FindViewById<TextView>(Resource.Id.tvTimeToWin);
            TextView tvDifficulty = v.FindViewById<TextView>(Resource.Id.tvDifficulty);
            tvPlayer.Text = lbp.Name;
            tvTimeToWin.Text = lbp.StringTime;
            tvDifficulty.Text = lbp.Difficulty;
            return v;
        }

        /// <summary>
        /// adds an entry to the list
        /// </summary>
        /// <param name="player">the entry</param>
        public void AddGame(LeaderboardPlayer player)
        {
            lstLeaderboardPlayer.Add(player);
            NotifyDataSetChanged();
        }

        /// <summary>
        /// clears the list
        /// </summary>
        public void Clear()
        {
            lstLeaderboardPlayer.Clear();
            NotifyDataSetChanged();
        }
    }
}