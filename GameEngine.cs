using Android.App;
using Android.Content;
using Android.Widget;
using ServiceSample;
using Intent = Android.Content.Intent;
using Android.Views;
using Android.OS;
using System;

namespace MineSweeper
{
    internal class GameEngine
    {
        private static GameEngine Instance;
        public Context Context;
        public Activity Activity;
        public AnimationReceiver myAnimationReceiver;
        public static readonly int BOMB_NUMBER = Constants.NUMBER_OF_MINES;
        public static readonly int WIDTH = Constants.SIZE_OF_BOARD_WIDTH;
        public static readonly int HEIGHT = Constants.SIZE_OF_BOARD_HEIGHT;
        public Board Board { get; set; }
        public PlayerStats PlayerStats { get; set; }

        public SqlDataStats SqlStats { get; set; }
        private Dialog winDialog { get; set; }
        private ImageView img1;
        private ImageView img2;
        private ImageView img3;
        private ImageView img4;
        private ImageView img5;
        public Chronometer chrono;
        GameTimer cd;
        TextView nm;
        private int NumOfClicks { get; set; }
        public static GameEngine GetInstance()
        {
            Instance ??= new GameEngine();
            return Instance;
        }

        public void CreateGrid(Context context)
        {
            Context = context;
            Board = new Board(context);
            Board.GenerateFullBoard();
            /* cd = new GameTimer(300000, 1000, (Activity)context);
             cd.Start();*/
           // chrono = Activity.FindViewById<Chronometer>(Resource.Id.tvTimer);
            PlayerStats = new PlayerStats();
            SqlStats = new SqlDataStats();
            SqlStats.Insert(PlayerStats);
            PlayerStats.GamesPlayed++;
            SqlStats.Update(PlayerStats);
            NumOfClicks = 0;
        }

        public void SetBoard(Board board)
        {
            for (int i = 0; i < WIDTH; i++)
                for (int j = 0; j < HEIGHT; j++)
                {
                    Board.Squares[i, j] = board.Squares[i, j];
                    Board.Squares[i, j].BringToFront();
                    //Board.Squares[i, j].Context = Context;
                }
        }

        public Square GetCellAt(int position)
        {
            int x = position % WIDTH;
            int y = position / WIDTH;
            Board.Squares[x, y].PostInvalidate();
            return Board.Squares[x, y];

        }

        public Square GetCellAt(int x, int y)
        {
            return Board.Squares[x,y];
        }

        private void CheckEnd()
        {
            int bombNotFound = BOMB_NUMBER;
            int notRevealed = WIDTH * HEIGHT;
            int flags = 0;
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    if (GetCellAt(x, y).IsRevealed || GetCellAt(x, y).IsFlagged)
                        notRevealed--;
                    if (GetCellAt(x, y).IsFlagged && GetCellAt(x, y) is Mine)
                        bombNotFound--;
                    if (GetCellAt(x, y).IsFlagged)
                        flags++;
                }

            if (bombNotFound == 0 && notRevealed == 0&&flags==10)
            {
                Toast.MakeText(Context, "Game won", ToastLength.Long).Show();
                //chrono.Stop();
                ShowWinDialog();
                Board.RevealBoard();
                PlayerStats.GamesWon++;
                SqlStats.Update(PlayerStats);
            }
        }

        internal void Click(int x, int y)
        {
            if(x>=0&&y>=0&&x<WIDTH && y<HEIGHT&&!GetCellAt(x, y).IsClicked&& !GetCellAt(x, y).IsFlagged)
            {
                /*if(NumOfClicks==0)
                {
                    chrono.Base= SystemClock.ElapsedRealtime();
                    chrono.Start();
                }*/
                NumOfClicks++;
                GetCellAt(x, y).Revealed();
                if (!(GetCellAt(x, y) is NumberTile)&&!(GetCellAt(x, y) is Mine))
                    for (int xt = -1; xt <= 1; xt++)
                        for (int yt = -1; yt <= 1; yt++)
                            if (xt != yt)
                                Click(x + xt, y + yt);
                if (GetCellAt(x, y) is Mine)
                    MineClicked(x,y);
            }
            CheckEnd();
        }

        private void MineClicked(int x,int y)
        {
            Toast.MakeText(Context, "Mine Clicked, try again", ToastLength.Long).Show();
            ((Mine)GetCellAt(x, y)).HasExploded();
            Board.UnRevealBoard();
        }

        internal void Flag(int x, int y)
        {
            if(!GetCellAt(x, y).IsClicked&& !GetCellAt(x, y).IsRevealed)
            {
                bool isFlagged = GetCellAt(x, y).IsFlagged;
                GetCellAt(x, y).SetFlagged(!isFlagged);
                GetCellAt(x, y).Invalidate();
                if(GetCellAt(x, y) is Mine)
                {
                    PlayerStats.MinesFound++;
                    SqlStats.Update(PlayerStats);
                }
            }
        }

        protected void StartAnimation(ImageView img1, ImageView img2, ImageView img3, ImageView img4, ImageView img5)
        {
            myAnimationReceiver = new AnimationReceiver(img1, img2, img3, img4, img5);
            IntentFilter filter = new IntentFilter();
            filter.AddAction(General.ACTION_ANIMATE);
            Context.RegisterReceiver(myAnimationReceiver, filter);
            Intent intent = new Intent(Context, typeof(AnimationService));
            Context.StartService(intent);
        }

        private void ShowWinDialog()
        {
            winDialog = new Dialog(Activity);
            winDialog.SetContentView(Resource.Layout.win_dialog);
            img1 = winDialog.FindViewById<ImageView>(Resource.Id.animation1);
            img2 = winDialog.FindViewById<ImageView>(Resource.Id.animation2);
            img3 = winDialog.FindViewById<ImageView>(Resource.Id.animation3);
            img4 = winDialog.FindViewById<ImageView>(Resource.Id.animation4);
            img5 = winDialog.FindViewById<ImageView>(Resource.Id.animation5);
            nm = winDialog.FindViewById<TextView>(Resource.Id.clicks);
            nm.Text=NumOfClicks.ToString();
            //chrono = (Chronometer)winDialog.FindViewById<TextView>(Resource.Id.simpleChronometer);
            StartAnimation(img1, img2, img3, img4, img5);
            winDialog.SetCancelable(true);
            winDialog.Show();
        }
    }
}