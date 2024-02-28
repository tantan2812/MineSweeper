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
    internal class leaderboardAdapter : BaseAdapter<LeaderboardPlayer>
    {
        private Context context;
        private List<LeaderboardPlayer> lstLeaderboardPlayer;

        public leaderboardAdapter(Context context)
        {
            this.context = context;
            lstLeaderboardPlayer = new List<LeaderboardPlayer>();
        }
        public override LeaderboardPlayer this[int position] => lstLeaderboardPlayer[position];

        public override int Count => lstLeaderboardPlayer.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater li = LayoutInflater.From(context);
            View v = li.Inflate(Resource.Layout.layout_leaderboard, parent, false);
            LeaderboardPlayer lbp = lstLeaderboardPlayer[position];
            TextView tvPlayer = v.FindViewById<TextView>(Resource.Id.tvPlayer);
            TextView tvTimeToWin = v.FindViewById<TextView>(Resource.Id.tvTimeToWin);
            tvPlayer.Text = lbp.Name;
            tvTimeToWin.Text = lbp.StringTime;
            return v;
        }

        public void AddGame(LeaderboardPlayer player)
        {
            lstLeaderboardPlayer.Add(player);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            lstLeaderboardPlayer.Clear();
            NotifyDataSetChanged();
        }
    }
}