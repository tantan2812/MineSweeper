using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using MineSweeper;
using System.Threading;

namespace MineSweeper
{
    /// <summary>
    /// Service for periodically sending broadcasts to animate images.
    /// </summary>
    [Service]
    internal class AnimationService : Service
    {
        /// <summary>
        /// The total number of frames to animate through.
        /// </summary>
        public const int FRAME_COUNTER = 30;

        /// <summary>
        /// The number of milliseconds to wait between frames.
        /// </summary>
        public const int PER_SECOND = 200;
        private bool stopped;

        /// <summary>
        /// Called by the system every time a client explicitly starts the service by calling startService(Intent), providing the arguments it supplied and a unique integer token representing the start request.
        /// </summary>
        /// <param name="intent">The Intent supplied to startService(Intent), as given.</param>
        /// <returns>The integer token representing the start request.</returns>
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        /// <summary>
        /// Called by the system every time a client explicitly starts the service by calling startService(Intent), providing the arguments it supplied and a unique integer token representing the start request.
        /// </summary>
        /// <param name="intent">The Intent supplied to startService(Intent), as given.</param>
        /// <param name="flags">Additional data about this start request.</param>
        /// <param name="startId">A unique integer representing this specific start request.</param>
        /// <returns>The integer token representing the start request.</returns>
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            stopped = false;
            ThreadStart ts = new ThreadStart(SendAnimationBroadcast);
            Thread thread = new Thread(ts);
            thread.Start();
            return base.OnStartCommand(intent, flags, startId);
        }


        /// <summary>
        /// Sends a broadcast to animate images based on a frame counter.
        /// </summary>
        private void SendAnimationBroadcast()
        {
            int frame, counter = 0;
            Intent intent = new Intent(General.ACTION_ANIMATE);
            while (!stopped && counter <= FRAME_COUNTER)
            {
                Thread.Sleep(PER_SECOND);
                counter++;
                frame = Frames(counter);
                intent.PutExtra(General.KEY_FRAME, frame);
                SendBroadcast(intent);
            }
            StopSelf();
        }

        /// <summary>
        /// Determines the current frame number based on the frame counter.
        /// </summary>
        /// <param name="counter">The current frame counter.</param>
        /// <returns>The current frame number.</returns>
        private int Frames(int counter)
        {
            counter--;
            if (counter == FRAME_COUNTER)
                return 0;
            int[] frameManager = new int[] { 1, 2 };
            counter %= frameManager.Length;
            return frameManager[counter];
        }

        /// <summary>
        /// Called by the system to notify a Service that it is no longer used and is being removed.
        /// </summary>
        public override void OnDestroy()
        {
            stopped = true;
            base.OnDestroy();
        }
    }
}
