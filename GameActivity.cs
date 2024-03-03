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
    /// <summary>
    /// creates the board and the game, also handles text to speech
    /// </summary>
    [Activity(Label = "GameActivity")]
    public class GameActivity : AppCompatActivity, IOnCompleteListener, IEventListener, TextToSpeech.IOnInitListener
    {
        private Game game;
        private Grid grid;
        private Board board;
        private Context context;
        TextToSpeech tts;

        /// <summary>
        /// creates the game and sets the text to speech, sends parameters to gameengine. create the activity and the board with it 
        /// </summary>
        /// <param name="savedInstanceState">used in base</param>
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

        /// <summary>
        /// creates the game and sets the text to speech, sends parameters to gameengine.
        /// </summary>
        private void InitObjects()
        {
            GameEngine.GetInstance().Activity=this;
            grid = new Grid(this);
            context = grid.Context;
            game = new Game(this, Intent.GetStringExtra(General.KEY_NAME));//Game.GetGameJson(Intent.GetStringExtra(General.KEY_GAME_JSON), this);
            tts = new TextToSpeech(this, this);
            tts.Speak("Game Start!", QueueMode.Flush,null,null);
            GameEngine.GetInstance().PlayerName = Intent.GetStringExtra(General.KEY_NAME);
        }

        /// <summary>
        /// if task is successful it send a toast that says the game is created and if it isnt it sends the error
        /// </summary>
        /// <param name="task">the task of the game</param>
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

        /// <summary>
        /// when the player closes the activity, delete the game and stop the timer
        /// </summary>
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

        /// <summary>
        /// tells the text to speech to say game start
        /// </summary>
        /// <param name="status"></param>
        public void OnInit([GeneratedEnum] OperationResult status)
        {
            tts.Speak("Game Start!", QueueMode.Flush, null, null);
        }
    }
}