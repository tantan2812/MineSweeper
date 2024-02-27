﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    internal class GameTimer : CountDownTimer
    {
        readonly Activity activity;
        private int TotalMilisec { get; set; }
        public GameTimer(long totalMilisec, long intervalMilisec, Activity activity) : base(totalMilisec, intervalMilisec)
        {
            this.activity = activity;
            TotalMilisec = (int)totalMilisec;
        }

        public override void OnFinish()
        {
            var bulider = new AlertDialog.Builder(activity);
            bulider.SetMessage(activity.Resources.GetString(Resource.String.time_finished));
            bulider.SetPositiveButton(Resource.String.ok, OnPositiveButtonClick);
            bulider.SetCancelable(true);
            bulider.Create().Show();
        }

        public override void OnTick(long timeLeftMilisec)
        {
            TimeSpan ts = new TimeSpan(10000 * timeLeftMilisec);
        }

        private void OnPositiveButtonClick(object sender, DialogClickEventArgs e)
        {
            ((Dialog)sender).Dismiss();
            GameEngine.GetInstance().ForceEnd();
        }
    }
}