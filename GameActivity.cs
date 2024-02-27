using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Firestore;
using System;
using static Xamarin.Grpc.InternalChannelz;

namespace MineSweeper
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : AppCompatActivity, IOnCompleteListener, IEventListener, TextToSpeech.IOnInitListener
    {
        private Game game;
        private Grid grid;
        private Board board;
        private Context context;
        TextToSpeech tts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SupportActionBar.Hide();
            InitObjects();
            InitViews();
            SetContentView(Resource.Layout.activity_game);
            game.Context = GameEngine.GetInstance().Context;
            board = GameEngine.GetInstance().Board;
            if (board != null && Intent.HasExtra("IsHost"))
                game.SetStringBoard(board);
            //game.SetStringBoardJson(board);
        }

        private void InitViews()
        {
            
        }

        private void InitObjects()
        {
            GameEngine.GetInstance().Activity=this;
            grid = new Grid(this);
            context = grid.Context;
            game = Game.GetGameJson(Intent.GetStringExtra(General.KEY_GAME_JSON), this);
            tts = new TextToSpeech(this, this);
            tts.Speak("Game Start!", QueueMode.Flush,null,null);
            GameEngine.GetInstance().PlayerName = Intent.GetStringExtra(General.KEY_NAME);
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
            GameEngine.GetInstance().cd.Cancel();
            base.OnPause();
        }

        public void OnEvent(Java.Lang.Object obj, FirebaseFirestoreException error)
        {
            DocumentSnapshot ds = obj as DocumentSnapshot;
            if (ds.Contains(General.FIELD_BOARD_SQUARES) && Intent.HasExtra("IsGuest"))
            {
                board = game.ReceiveBoard((JavaList)ds.Get(General.FIELD_BOARD_SQUARES));
                //grid.UpdateBoard(board);
                grid=new Grid(game.Context, board);
            }
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            tts.Speak("Game Start!", QueueMode.Flush, null, null);
        }

        /* public void OnClick(View v)
         {
             bool found = false;
             for (int i = 0; i < game.Board.Squares.GetLength(0) && !found; i++)
             {
                 for (int j = 0; j < game.Board.Squares.GetLength(1) && !found; j++)
                 {
                     if (v == game.Board.Squares[i, j])
                     {
                         GameEngine.GetInstance().Click(i, j);
                         found = true;
                     }
                 }
             }
         }

         public bool OnLongClick(View v)
         {
             bool found = false;
             for (int i = 0; i < game.Board.Squares.GetLength(0) && !found; i++)
             {
                 for (int j = 0; j < game.Board.Squares.GetLength(1) && !found; j++)
                 {
                     if (v == game.Board.Squares[i, j])
                     {
                         GameEngine.GetInstance().Flag(i, j);
                         found = true;
                     }
                 }
             }
             return true;
         }*/
    }
}