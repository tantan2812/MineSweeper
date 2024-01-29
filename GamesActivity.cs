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
    [Activity(Label = "GamesActivity")]
    public class GamesActivity : AppCompatActivity, Android.Views.View.IOnClickListener, ListView.IOnItemLongClickListener, IEventListener, IOnCompleteListener
    {
        private const int NEW_GAME = -1;
        Games games;
        Game game;
        Task tskGetAvailbleGames;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_games);
            InitObjects();
            InitViews();
        }

        private void InitViews()
        {
            Button btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            btnCreate.SetOnClickListener(this);
            ListView lvGames = FindViewById<ListView>(Resource.Id.lvGames);
            lvGames.Adapter = games.Adapter;
            lvGames.OnItemLongClickListener = this;
            this.Title = GetString(Resource.String.minesweeper_games) + " - " + Intent.GetStringExtra(General.KEY_NAME);
        }

        private void InitObjects()
        {
            games = new Games(this);
        }

        public void OnClick(Android.Views.View v)
        {
            OpenGame(NEW_GAME);
        }

        public bool OnItemLongClick(AdapterView parent, Android.Views.View view, int position, long id)
        {
            OpenGame(position);
            return true;
        }

        private void OpenGame(int position)
        {
            Intent intent = new Intent(this, typeof(GameActivity));
            string name = Intent.GetStringExtra(General.KEY_NAME);
            intent.PutExtra(General.KEY_NAME, name);
            if (position != NEW_GAME)
            {
                 intent.PutExtra(General.KEY_ID, games[position].Id);
                 intent.PutExtra(General.KEY_HOST_NAME, games[position].HostName);
                game = new Game(this, games[position].HostName, games[position].Id)
                {
                    GuestName = name
                };
            }
            else
            {
                game = new Game(this, Intent.GetStringExtra(General.KEY_NAME));
                game.TskInitGameTask.AddOnCompleteListener(this);
            }
            intent.PutExtra(General.KEY_GAME_JSON, game.Json);
            StartActivity(intent);
        }


        public void OnComplete(Task task)
        {
            string msg=string.Empty;
            if (task.IsSuccessful)
            {
                if (task == tskGetAvailbleGames)
                {
                    QuerySnapshot qs = (QuerySnapshot)task.Result;
                    games.AddGames(qs.Documents);
                }
                else if (task == game.TskInitGameTask)
                    msg = "Game Created";
            }
            else
                msg = task.Exception.Message;
            Toast.MakeText(this, msg, ToastLength.Long).Show();
        }

        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException error)
        {
            tskGetAvailbleGames = games.GetAvailbleGames().AddOnCompleteListener(this);
        }
    }
}