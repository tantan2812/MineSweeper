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
        LeaderboardPlayer player;
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
            tskGetTopPlayers = players.GetTopPlayers().AddOnCompleteListener(this);
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                QuerySnapshot qs = (QuerySnapshot)task.Result;
                players.AddGames(qs.Documents);
            }
        }
    }
}