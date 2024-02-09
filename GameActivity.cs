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
        private Game game;
        private Grid grid;
        private Board board;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SupportActionBar.Hide();
            InitObjects();
            SetContentView(Resource.Layout.activity_game);
            grid.UpdateBoard(board);
        }

        private void InitObjects()
        {
            game = Game.GetGameJson(Intent.GetStringExtra(General.KEY_GAME_JSON));
            grid=new Grid(this);
            board = new Board(this);
            board.GenerateFullBoard();
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