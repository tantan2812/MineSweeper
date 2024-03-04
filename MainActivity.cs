using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Threading;
using Intent = Android.Content.Intent;

namespace MineSweeper
{
    /// <summary>
    /// the mainactivity, has all the button that lead to other places in the app, and has a menu with all the rules
    /// </summary>
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        TextView tvGoRules, tvGoRulesAnswer, tvCurrent;
        Button btnGoGame, btnGoStats, btnGoLeaderBoard;
        Thread thread;

        /// <summary>
        /// creates the activity, and sets the XML
        /// </summary>
        /// <param name="savedInstanceState">used in base</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitViews();
        }

        /// <summary>
        /// connects all the views to the XML and sets listeners to the button and register the menu
        /// </summary>
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
            thread = new Thread(new ThreadStart(() => { return; }));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// creates the menu
        /// </summary>
        /// <param name="menu">the menu</param>
        /// <param name="v">on which view should i create the menu on</param>
        /// <param name="menuInfo">used in the base fanction</param>
        public override void OnCreateContextMenu(Android.Views.IContextMenu menu, Android.Views.View v, Android.Views.IContextMenuContextMenuInfo menuInfo)
        {
            tvCurrent = (TextView)v;
            if (v == tvGoRules)
                MenuInflater.Inflate(Resource.Menu.menu_rules, menu);
            base.OnCreateContextMenu(menu, v, menuInfo);
        }

        /// <summary>
        /// when an item is clicked i put an answer in the intended place with animation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool OnContextItemSelected(Android.Views.IMenuItem item)
        {
            thread.Abort();
            tvCurrent.Text = item.TitleFormatted.ToString();
            ParameterizedThreadStart ts = new ParameterizedThreadStart(Anim);
            thread = new Thread(ts);
            thread.Start(item.TooltipTextFormatted.ToString());
            return base.OnContextItemSelected(item);
        }

        /// <summary>
        /// animates the text and the menu to write itself in front of the user
        /// </summary>
        /// <param name="str">the text to animate</param>
        private void Anim(object str)
        {
            string text = (string)str;
            for (int i = 0; i <= text.Length; i++)
            {
                RunOnUiThread(() => { tvGoRulesAnswer.Text = text[..i]; });
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// happens when the user clicks on a button, goes to a diffrent function depending on the button
        /// </summary>
        /// <param name="v">the button clicked</param>
        public void OnClick(View v)
        {
            if (v == btnGoGame)
                OpenGameActivitys();          
            if (v== btnGoStats)
                OpenStatActivitys();
            if (v == btnGoLeaderBoard)
                OpenLeaderboardActivitys();
        }

        /// <summary>
        /// opens the leaderboard activity with the intent of the name of the user
        /// </summary>
        private void OpenLeaderboardActivitys()
        {
            Intent intent = new Intent(this, typeof(LeaderboardActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            StartActivity(intent);
        }

        /// <summary>
        /// opens the game activity with the intent of the name of the user
        /// </summary>
        private void OpenGameActivitys()
        {
            Intent intent = new Intent(this, typeof(GameActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            StartActivity(intent);
        }

        /// <summary>
        /// opens the statistic activity with the intent of the name of the user
        /// </summary>
        private void OpenStatActivitys()
        {
            Intent intent = new Intent(this, typeof(StatisticActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            StartActivity(intent);
        }
    }
}