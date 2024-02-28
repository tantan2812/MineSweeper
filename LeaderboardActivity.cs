using Android.App;
using Android.Content;
using Android.Gms.Tasks;
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
    [Activity(Label = "LeaderboardActivity")]
    public class LeaderboardActivity : AppCompatActivity, IEventListener, IOnCompleteListener
    {
        LeaderboardPlayers players;
        Task tskGetTopPlayers;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_leaderboard);
            InitObjects();
            InitViews();
        }

        private void InitViews()
        {
            ListView lvTopPlayers = FindViewById<ListView>(Resource.Id.lvTopPlayers);
            lvTopPlayers.Adapter = players.Adapter;
        }

        private void InitObjects()
        {
            players = new LeaderboardPlayers(this);
        }

        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException error)
        {
            tskGetTopPlayers = players.fbd.GetCollection(General.TIMES_COLLECTION).AddOnCompleteListener(this);
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                if (task== tskGetTopPlayers)
                {
                    QuerySnapshot qs = (QuerySnapshot)task.Result;
                    List<LeaderboardPlayer> topPlayers = new List<LeaderboardPlayer>();
                    foreach (DocumentSnapshot document in qs.Documents)
                        topPlayers.Add(new LeaderboardPlayer((string)(document.Get(General.FIELD_NAME)), (long)document.Get(General.FIELD_WIN_TIME)));
                    topPlayers.Sort((a, b) => a.IntTime.CompareTo(b.IntTime));
                    topPlayers.Take(10).ToList();
                    players.AddGames(topPlayers);
                }               
            }
        }
    }
}