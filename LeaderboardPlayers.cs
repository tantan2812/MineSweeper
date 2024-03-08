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
    /// <summary>
    /// used for getting the LeaderboardPlayers from firebase and sending them into the adapter
    /// </summary>
    internal class LeaderboardPlayers
    {
        private FbData fbd;
        public leaderboardAdapter Adapter { get; }
        public Context Context { get; }
        
        public LeaderboardPlayer this[int position]
        {
            get
            {
                return Adapter[position];
            }
        }

        /// <summary>
        /// creates a new LeaderboardPlayers. creates an adapter and listen for a collection
        /// </summary>
        /// <param name="context">used for creating the adapter</param>
        public LeaderboardPlayers(Activity context)
        {
            this.Context = context;
            Adapter = new leaderboardAdapter(context);
            fbd = new FbData();
            fbd.AddSnapshotListener(context, General.TIMES_COLLECTION);
        }

        /// <summary>
        /// adds all the leaderboard enteries into the adapter
        /// </summary>
        /// <param name="documents">list of all the enteries</param>
        internal void AddGames(IList<DocumentSnapshot> documents)
        {
            Adapter.Clear();
            LeaderboardPlayer player;
            foreach (DocumentSnapshot document in documents)
            {
                player = new LeaderboardPlayer(document.GetString(General.FIELD_NAME), (int)document.Get(General.FIELD_WIN_TIME),document.GetString(General.FIELD_DIFFICULTY_BOARD));
                Adapter.AddGame(player);
            }
        }

        /// <summary>
        /// adds all the leaderboard enteries into the adapter
        /// </summary>
        /// <param name="players">list of all the enteries</param>
        public void AddGames(List<LeaderboardPlayer> players)
        {
            Adapter.Clear();
            foreach (LeaderboardPlayer player in players)
                Adapter.AddGame(player);
        }

        /// <summary>
        /// returns the times collection as a task and listens to it with IOnCompleteListener
        /// </summary>
        /// <returns></returns>
        public Task GetCollection()
        {
            return fbd.GetCollection(General.TIMES_COLLECTION).AddOnCompleteListener((IOnCompleteListener)Context);
        }
    }
}