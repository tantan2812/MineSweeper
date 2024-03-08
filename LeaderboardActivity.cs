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
    /// <summary>
    /// shows the list of leaderboard that has a name of a player and the time he took to finish the game
    /// </summary>
    [Activity(Label = "LeaderboardActivity")]
    public class LeaderboardActivity : AppCompatActivity, IEventListener, IOnCompleteListener
    {
        LeaderboardPlayers players;
        Task tskGetTopPlayers;

        /// <summary>
        /// creates the activity, and sets the XML, also creates LeaderboardPlayers
        /// </summary>
        /// <param name="savedInstanceState">used in base</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_leaderboard);
            InitObjects();
            InitViews();
        }

        /// <summary>
        /// sets the listview to the XML and connects the adapters
        /// </summary>
        private void InitViews()
        {
            ListView lvTopPlayers = FindViewById<ListView>(Resource.Id.lvTopPlayers);
            lvTopPlayers.Adapter = players.Adapter;
        }

        /// <summary>
        /// create a new LeaderboardPlayers
        /// </summary>
        private void InitObjects()
        {
            players = new LeaderboardPlayers(this);
        }

        /// <summary>
        /// gets all the tmes collection into the task and gets oncomplete to listen to it
        /// </summary>
        /// <param name="obj">not used</param>
        /// <param name="error">not used</param>
        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException error)
        {
            tskGetTopPlayers = players.GetCollection();
        }

        /// <summary>
        /// if the task is successful, add all the entries in the collection into LeaderboardPlayers
        /// </summary>
        /// <param name="task">the task from the onevent</param>
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                if (task== tskGetTopPlayers)
                {
                    QuerySnapshot qs = (QuerySnapshot)task.Result;
                    List<LeaderboardPlayer> topPlayers = new List<LeaderboardPlayer>();
                    foreach (DocumentSnapshot document in qs.Documents)
                        topPlayers.Add(new LeaderboardPlayer((string)document.Get(General.FIELD_NAME), (int)document.Get(General.FIELD_WIN_TIME), (string)document.Get(General.FIELD_DIFFICULTY_BOARD)));
                    topPlayers.Sort((a, b) => a.IntTime.CompareTo(b.IntTime));
                    topPlayers.Take(10).ToList();
                    players.AddGames(topPlayers);
                }               
            }
        }
    }
}