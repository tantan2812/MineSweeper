using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using Intent = Android.Content.Intent;

namespace MineSweeper
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        TextView tvGoRules, tvGoRulesAnswer, tvCurrent;
        Button btnGoGame, btnGoStats, btnGoLeaderBoard;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitViews();
        }

        private void InitViews()
        {
            tvGoRules = FindViewById<TextView>(Resource.Id.tvGoRules);
            tvGoRulesAnswer = FindViewById<TextView>(Resource.Id.tvGoRulesAnswer);
            btnGoGame = FindViewById<Button>(Resource.Id.btnGoGame);
            btnGoStats = FindViewById<Button>(Resource.Id.btnGoStats);
            btnGoLeaderBoard = FindViewById<Button>(Resource.Id.btnGoLeaderBoard);
            btnGoGame.SetOnClickListener(this);
            btnGoStats.SetOnClickListener(this);
            btnGoLeaderBoard.SetOnClickListener(this);
            RegisterForContextMenu(tvGoRules);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnCreateContextMenu(Android.Views.IContextMenu menu, Android.Views.View v, Android.Views.IContextMenuContextMenuInfo menuInfo)
        {
            tvCurrent = (TextView)v;
            if (v == tvGoRules)
                MenuInflater.Inflate(Resource.Menu.menu_rules, menu);
            base.OnCreateContextMenu(menu, v, menuInfo);
        }

        public override bool OnContextItemSelected(Android.Views.IMenuItem item)
        {
            tvCurrent.Text = item.TitleFormatted.ToString();
            tvGoRulesAnswer.Text= item.TooltipTextFormatted.ToString();
            return base.OnContextItemSelected(item);
        }

        public void OnClick(View v)
        {
            if (v == btnGoGame)
                OpenGamesActivitys();
           
            if (v== btnGoStats)
                OpenStatActivitys();
            if (v == btnGoLeaderBoard)
                OpenLeaderboardActivitys();
        }

        private void OpenLeaderboardActivitys()
        {
            Intent intent = new Intent(this, typeof(LeaderboardActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            StartActivity(intent);
        }

        private void OpenGamesActivitys()
        {
            Intent intent = new Intent(this, typeof(GamesActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            StartActivity(intent);
        }
 
        private void OpenStatActivitys()
        {
            Intent intent = new Intent(this, typeof(StatisticActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            StartActivity(intent);
        }
    }
}