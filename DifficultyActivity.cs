using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    /// <summary>
    /// let the user chosse o which difficulty he wants to lay in
    /// </summary>
    [Activity(Label = "DifficultyActivity")]
    public class DifficultyActivity : AppCompatActivity, View.IOnClickListener
    {
        Button btnDifficultyOne, btnDifficultyTwo, btnDifficultyThree;

        /// <summary>
        /// creates the activity, and sets the XML
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_difficulty);
            InitViews();
        }

        /// <summary>
        /// connects all the views to the XML and sets listeners to the button
        /// </summary>
        private void InitViews()
        {
            btnDifficultyOne = FindViewById<Button>(Resource.Id.btnDifficultyOne);
            btnDifficultyTwo = FindViewById<Button>(Resource.Id.btnDifficultyTwo);
            btnDifficultyThree = FindViewById<Button>(Resource.Id.btnDifficultyThree);
            btnDifficultyOne.SetOnClickListener(this);
            btnDifficultyTwo.SetOnClickListener(this);
            btnDifficultyThree.SetOnClickListener(this);
        }

        /// <summary>
        /// happens when the user clicks on a button, goes to a diffrent function depending on the button
        /// </summary>
        /// <param name="v">the button clicked</param>
        public void OnClick(View v)
        {
            if (v == btnDifficultyOne)
                OpenGameDifficultyOne();
            if (v == btnDifficultyTwo)
                OpenGameDifficultyTwo();
            if (v == btnDifficultyThree)
                OpenGameDifficultyThree();
        }

        /// <summary>
        /// opens the game activity for an expert game
        /// </summary>
        private void OpenGameDifficultyThree()
        {
            Intent intent = new Intent(this, typeof(GameActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            intent.PutExtra(General.DIFFICULTY, 3);
            StartActivity(intent);
        }

        /// <summary>
        /// opens the game activity for an intermediate game
        /// </summary>
        private void OpenGameDifficultyTwo()
        {
            Intent intent = new Intent(this, typeof(GameActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            intent.PutExtra(General.DIFFICULTY, 2);
            StartActivity(intent);
        }

        /// <summary>
        /// opens the game activity for an easy game
        /// </summary>
        private void OpenGameDifficultyOne()
        {
            Intent intent = new Intent(this, typeof(GameActivity));
            intent.PutExtra(General.KEY_NAME, Intent.GetStringExtra(General.KEY_NAME));
            intent.PutExtra(General.DIFFICULTY, 1);
            StartActivity(intent);
        }
    }
}