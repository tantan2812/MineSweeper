using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Annotations;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace MineSweeper
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : AppCompatActivity, IOnCompleteListener
    {
        TextView tvTime, tvScore;
        TextView tvTimer, tvScoreNow;
        GridView gvBoard;
        GameTimer gameTimer;
        private Game game;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SupportActionBar.Hide();
            InitObjects();
            InitViews();

            SetContentView(Resource.Layout.activity_game);
        }

        private void InitViews()
        {
            tvTime = FindViewById<TextView>(Resource.Id.tvTime);
            tvScore = FindViewById<TextView>(Resource.Id.tvScore);
            tvTimer = FindViewById<TextView>(Resource.Id.tvTimer);
            tvScoreNow = FindViewById<TextView>(Resource.Id.tvScoreNow);
            gvBoard = FindViewById<GridView>(Resource.Id.gvBoard);
            gvBoard.Adapter = game.MineSweeperView.Board.Adapter;
        }

        private void InitObjects()
        {
            game = Game.GetGameJson(Intent.GetStringExtra(General.KEY_GAME_JSON));
            game.Context = this;
            game.MineSweeperView = new MineSweeperView(game.Context);
            GameTimer cd = new GameTimer(300000, 1000, this);
            cd.Start();
        }

        public void OnComplete(Task task)
        {
            string msg;
            if (task.IsSuccessful)
                msg = "Game Created";
            else
                msg = task.Exception.Message;
            if(msg!=string.Empty)
                Toast.MakeText(this, msg, ToastLength.Long).Show();
        }

        protected override void OnPause()
        {
            game.Exit();
            base.OnPause();
        }
    }
}