using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace MineSweeper
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : AppCompatActivity, IOnCompleteListener
    {
        TextView tvTime, tvScore;
        TextView tvTimer, tvScoreNow;
        private Game game;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SupportActionBar.Hide();
            InitObjects();
            InitViews();
            SetContentView(Resource.Layout.activity_game);
            //GameEngine.GetInstance().CreateGrid(this);
        }

        private void InitViews()
        {
            tvTime = FindViewById<TextView>(Resource.Id.tvTime);
            tvScore = FindViewById<TextView>(Resource.Id.tvScore);
            tvTimer = FindViewById<TextView>(Resource.Id.tvTimer);
            tvScoreNow = FindViewById<TextView>(Resource.Id.tvScoreNow);
        }

        private void InitObjects()
        {
            game = Game.GetGameJson(Intent.GetStringExtra(General.KEY_GAME_JSON));
            //game.GameEngine=GameEngine.GetInstance();
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