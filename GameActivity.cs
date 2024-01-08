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

namespace MineSweeper
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : AppCompatActivity, IOnCompleteListener
    {
        private Game game;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SupportActionBar.Hide();
            InitObjects();
            SetContentView(game.GameView);
        }

        private void InitObjects()
        {
            game = Game.GetGameJson(Intent.GetStringExtra(General.KEY_GAME_JSON));
            game.Context = this;
            Point screenSize = new Point();
#pragma warning disable CS0618 // Type or member is obsolete
            WindowManager.DefaultDisplay.GetSize(screenSize);
#pragma warning restore CS0618 // Type or member is obsolete
            game.screenSize = screenSize;
            game.GameView = new GameView(game.Context, game.screenSize.X, game.screenSize.Y);
        }

        public void OnComplete(Task task)
        {
            string msg;
            if (task.IsSuccessful)
                msg = "Game Created";
            else
                msg = task.Exception.Message;
            Toast.MakeText(this, msg, ToastLength.Long).Show();
        }
    }
}