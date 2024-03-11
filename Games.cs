using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Java.Util.Jar.Attributes;

namespace MineSweeper
{
    internal class Games
    {
        private FbData fbd;
        public GameAdapter Adapter { get; }
        //public Game this[int position] => Adapter[position];
        public Game this[int position]
        {
            get
            {
                return Adapter[position];
            }
        }

        public Games(Activity context)
        {
            Adapter = new GameAdapter(context);
            fbd = new FbData();
            fbd.AddSnapshotListener(context, General.GAMES_COLLECTION);
        }

        internal void AddGames(IList<DocumentSnapshot> documents)
        {
            Adapter.Clear();
            Game game;
            foreach (DocumentSnapshot document in documents)
            {
                game = new Game
                {
                    Id = document.Id,
                    HostName = document.GetString(General.FIELD_HOST_NAME),
                    CreateTime = fbd.FirestoreTimestampToDateTime(document.GetTimestamp(General.FIELD_CREATE_TIME))
                };
                Adapter.AddGame(game);
            }
        }

        internal Task GetAvailbleGames()
        {
            return fbd.GetEqualToDocs(General.GAMES_COLLECTION, General.FIELD_PLAYERS, 1);
        }
    }
}