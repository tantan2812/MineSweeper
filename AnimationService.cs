using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using MineSweeper;
using System.Threading;

namespace ServiceSample
{
    [Service]
    internal class AnimationService : Service
    {
        public const int FRAME_COUNTER = 30;
        public const int PER_SECOND = 200;

        private bool stopped;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            stopped = false;
            ThreadStart ts = new ThreadStart(SendAnimationBroadcast);
            Thread thread = new Thread(ts);
            thread.Start();
            return base.OnStartCommand(intent, flags, startId);
        }

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

        private int Frames(int counter)
        {
            counter--;
            if (counter == FRAME_COUNTER)
                return 0;
            int[] frameManager = new int[] { 1, 2 };
            counter %= frameManager.Length;
            return frameManager[counter];
        }

        public override void OnDestroy()
        {
            stopped = true;
            base.OnDestroy();
        }
    }
}
