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
using System.Threading;

namespace MineSweeper
{
    internal class GameView:SurfaceView
    {
        private bool play = true;
        private Shapes shapes;
        private Paint paint;
        private Thread gameThread;
        private ThreadStart ts;
        GestureDetector gestureDetector;
        public GameView(Context context, int screenWidth, int screenHight) : base(context)
        {
            ts = new ThreadStart(Run);
            gameThread = new Thread(ts);
            gameThread.Start();
            shapes = new Shapes(screenWidth, screenHight);
            ts = new ThreadStart(Run);
            gameThread = new Thread(ts);
            gameThread.Start();
            GestureDetector gestureDetector = new GestureDetector(context, new GestureListener());
        }

        public void Run()
        {
            Canvas canvas = null;
            while (play)
            {
                if (Holder.Surface.IsValid)
                {
                    try
                    {
                        canvas = Holder.LockCanvas();
                        canvas.DrawColor(Color.Gray);
                        shapes.DrawShapes(canvas);
                    }
                    catch (System.Exception e)
                    {
                        Android.Util.Log.Debug("Err:", e.Message);
                    }
                    finally
                    {
                        if (canvas != null)
                            Holder.UnlockCanvasAndPost(canvas);
                    }
                }
            }
            Intent intent = new Intent();
            ((GameActivity)this.Context).SetResult(Result.Ok, intent);
            ((GameActivity)this.Context).Finish();

        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            return gestureDetector.OnTouchEvent(e);
        }
    }
}