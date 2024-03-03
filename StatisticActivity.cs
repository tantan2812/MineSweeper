using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MineSweeper
{
    /// <summary>
    /// shows the stats of the player
    /// </summary>
    [Activity(Label = "StatisticActivity")]
    public class StatisticActivity : AppCompatActivity
    {
        TextView tvGamesPlayedStat, tvGamesWonStat, tvMinesFoundStat, tvWinRateStat;
        public PlayerStats PlayerStats { get; set; }

        /// <summary>
        /// create the activity, sets the XML and prints the saved data in the sql into it 
        /// </summary>
        /// <param name="savedInstanceState">used in base</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_statistics);
            InitViews();
            InitObjects();

        }

        /// <summary>
        /// prints the saved data in the sql into registered places 
        /// </summary>
        private void InitObjects()
        {          
                PlayerStats = new PlayerStats(1);
                tvGamesPlayedStat.Text = PlayerStats.GamesPlayed.ToString();
                tvGamesWonStat.Text = PlayerStats.GamesWon.ToString();
                tvMinesFoundStat.Text = PlayerStats.MinesFound.ToString();
                tvWinRateStat.Text = PlayerStats.WinRate().ToString();
        }

        /// <summary>
        /// connects all the views to the XML
        /// </summary>
        private void InitViews()
        {
            tvGamesPlayedStat = FindViewById<TextView>(Resource.Id.tvGamesPlayedStat);
            tvGamesWonStat = FindViewById<TextView>(Resource.Id.tvGamesWonStat);
            tvMinesFoundStat = FindViewById<TextView>(Resource.Id.tvMinesFoundStat);
            tvWinRateStat = FindViewById<TextView>(Resource.Id.tvWinRateStat);
        }
    }
}