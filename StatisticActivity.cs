﻿using Android.App;
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
            if(GameEngine.GetInstance().SqlStats != null)
            {
                PlayerStats = new PlayerStats();
                PlayerStats = GameEngine.GetInstance().SqlStats.UpdatedPlayerStats();
                tvGamesPlayedStat.Text = PlayerStats.GamesPlayed.ToString();
                tvGamesWonStat.Text = PlayerStats.GamesWon.ToString();
                tvMinesFoundStat.Text = PlayerStats.MinesFound.ToString();
                tvWinRateStat.Text = PlayerStats.WinRate().ToString();
            }
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