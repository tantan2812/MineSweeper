using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MineSweeper
{
    [Activity(Label = "StatisticActivity")]
    public class StatisticActivity : AppCompatActivity
    {
        TextView tvGamesPlayedStat, tvGamesWonStat, tvMinesFoundStat, tvWinRateStat;
        public PlayerStats PlayerStats { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_statistics);
            InitViews();
            InitObjects();

        }

        private void InitObjects()
        {
           
                PlayerStats = new PlayerStats(1);
                tvGamesPlayedStat.Text = PlayerStats.GamesPlayed.ToString();
                tvGamesWonStat.Text = PlayerStats.GamesWon.ToString();
                tvMinesFoundStat.Text = PlayerStats.MinesFound.ToString();
                tvWinRateStat.Text = PlayerStats.WinRate().ToString();
        }

        private void InitViews()
        {
            tvGamesPlayedStat = FindViewById<TextView>(Resource.Id.tvGamesPlayedStat);
            tvGamesWonStat = FindViewById<TextView>(Resource.Id.tvGamesWonStat);
            tvMinesFoundStat = FindViewById<TextView>(Resource.Id.tvMinesFoundStat);
            tvWinRateStat = FindViewById<TextView>(Resource.Id.tvWinRateStat);
        }
    }
}