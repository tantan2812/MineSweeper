using Android.App;
using Android.Content;
using Android.Gms.Tasks;
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
    internal class LeaderboardPlayers
    {
        private FbData fbd;
        public leaderboardAdapter Adapter { get; }
        
        public LeaderboardPlayer this[int position]
        {
            get
            {
                return Adapter[position];
            }
        }

        public LeaderboardPlayers(Activity context)
        {
            Adapter = new leaderboardAdapter(context);
            fbd = new FbData();
            fbd.AddSnapshotListener(context, General.TIMES_COLLECTION);
        }

        internal void AddGames(IList<DocumentSnapshot> documents)
        {
            Adapter.Clear();
            LeaderboardPlayer player;
            foreach (DocumentSnapshot document in documents)
            {
                player = new LeaderboardPlayer(document.GetString(General.FIELD_NAME), (long)document.GetLong(General.FIELD_WIN_TIME));
                Adapter.AddGame(player);
            }
        }

        /*internal Task GetTopPlayers()
        {
            Task task = fbd.GetCollection(General.TIMES_COLLECTION);
            QuerySnapshot qs = (QuerySnapshot)task.Result;
            List<long> topPlayers = new List<long>();
            foreach (DocumentSnapshot document in qs.Documents)
            {
                topPlayers.Add((long)document.Get(General.FIELD_WIN_TIME));
            }
            topPlayers.Sort((a, b) => a.CompareTo(b));
            topPlayers.Take(10).ToList();
        }*/
    }
}