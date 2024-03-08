using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using AndroidX.AppCompat.App;

namespace MineSweeper
{
    /// <summary>
    /// creates the board and the game, also handles text to speech
    /// </summary>
    [Activity(Label = "GameActivity")]
    public class GameActivity : AppCompatActivity, TextToSpeech.IOnInitListener
    {
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
            SetContentView(Resource.Layout.activity_game);
        }

        /// <summary>
        /// creates the game and sets the text to speech, sends parameters to gameengine.
        /// </summary>
        private void InitObjects()
        {
            GameEngine.GetInstance().Activity=this;           
            tts = new TextToSpeech(this, this);
            tts.Speak(Constants.TEXT_TO_SPEECH_GAME_START, QueueMode.Flush,null,null);
            GameEngine.GetInstance().PlayerName = Intent.GetStringExtra(General.KEY_NAME);
            GameEngine.GetInstance().Difficulty = Intent.GetIntExtra(General.DIFFICULTY,1);
        }

        /// <summary>
        /// when the player closes the activity, delete the game and stop the timer
        /// </summary>
        protected override void OnPause()
        {
            GameEngine.GetInstance().cd.Cancel();
            base.OnPause();
        }
       
        /// <summary>
        /// tells the text to speech to say game start
        /// </summary>
        /// <param name="status"></param>
        public void OnInit([GeneratedEnum] OperationResult status)
        {
            tts.Speak(Constants.TEXT_TO_SPEECH_GAME_START, QueueMode.Flush, null, null);
        }
    }
}