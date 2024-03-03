using Android.App;
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
    /// <summary>
    /// inherits from count down, does the AFK system, when a player doesnt play for a min hi game finishes
    /// </summary>
    internal class GameTimer : CountDownTimer
    {
        readonly Activity activity;

        /// <summary>
        /// creates a new timer
        /// </summary>
        /// <param name="totalMilisec">total time for timer to run</param>
        /// <param name="intervalMilisec">the jump intervals</param>
        /// <param name="activity">on which activity</param>
        public GameTimer(long totalMilisec, long intervalMilisec, Activity activity) : base(totalMilisec, intervalMilisec)
        {
            this.activity = activity;
        }

        /// <summary>
        /// when the timer finishes, create a dialog the tells that the time is over
        /// </summary>
        public override void OnFinish()
        {
            var bulider = new AlertDialog.Builder(activity);
            bulider.SetMessage(activity.Resources.GetString(Resource.String.time_finished));
            bulider.SetPositiveButton(Resource.String.ok, OnPositiveButtonClick);
            bulider.SetCancelable(true);
            bulider.Create().Show();
        }

        /// <summary>
        /// implements the CountDownTimer class
        /// </summary>
        /// <param name="millisUntilFinished">unused</param>
        public override void OnTick(long timeLeftMilisec)
        {
        }

        /// <summary>
        /// when clicking the button in the dialog it force closes the game
        /// </summary>
        /// <param name="sender">the dialog</param>
        /// <param name="e">not used</param>
        private void OnPositiveButtonClick(object sender, DialogClickEventArgs e)
        {
            ((Dialog)sender).Dismiss();
            GameEngine.GetInstance().ForceEnd();
        }
    }
}