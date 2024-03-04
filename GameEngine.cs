﻿using Android.App;
using Android.Content;
using Android.Widget;
using Intent = Android.Content.Intent;
using Android.OS;
using Java.Util;

namespace MineSweeper
{
    /// <summary>
    /// handles the logic of the game, the saving into sql and firebase, and animation
    /// </summary>
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
        public GameTimer cd;
        TextView tvScoreNow;
        public string PlayerName { get; set; }
        private int NumOfClicks { get; set; }
        private int Score { get; set; }
        private bool IsWon { get; set; }

        /// <summary>
        /// gets the instance of the class, checks it hasnt been created again
        /// </summary>
        /// <returns></returns>
        public static GameEngine GetInstance()
        {
            Instance ??= new GameEngine();
            return Instance;
        }

        /// <summary>
        /// creates the board, start the afk timer and sets parameters to default and handles starting the sql 
        /// </summary>
        /// <param name="context"></param>
        public void CreateGrid(Context context)
        {
            Context = context;
            Board = new Board(context);
            Board.GenerateFullBoard();
            cd = new GameTimer(60000, 1000, (Activity)Context);
            cd.Start();
            PlayerStats = new PlayerStats();
            SqlStats = new SqlDataStats();
            SqlStats.Insert(PlayerStats);
            PlayerStats.GamesPlayed++;
            SqlStats.Update(PlayerStats);
            NumOfClicks = 0;
            Score = BOMB_NUMBER;
            IsWon = false;
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

        /// <summary>
        /// gets a cell from the board
        /// </summary>
        /// <param name="position">what cell</param>
        /// <returns></returns>
        public Square GetCellAt(int position)
        {
            int x = position % WIDTH;
            int y = position / WIDTH;
            Board.Squares[x, y].PostInvalidate();
            return Board.Squares[x, y];

        }

        /// <summary>
        /// gets a cell from the board
        /// </summary>
        /// <param name="x">position of cell</param>
        /// <param name="y">position of cell</param>
        /// <returns></returns>
        public Square GetCellAt(int x, int y)
        {
            return Board.Squares[x,y];
        }

        /// <summary>
        /// checks for the end of the game, if the game is won it shows the end dialog, stops the timers and handles the data sent to sql and firebase
        /// </summary>
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
                if (IsWon == false)
                {
                    IsWon = true;
                    Toast.MakeText(Context, "Game won", ToastLength.Long).Show();
                    chrono.Stop();
                    cd.Cancel();
                    ShowWinDialog();
                    Board.RevealBoard();
                    PlayerStats.GamesWon++;
                    SqlStats.Update(PlayerStats);
                    SentTimeToFirebase();
                }
            }
        }

        /// <summary>
        /// forces the end of the game, doesnt send data to sql and firebase, stops the timer
        /// </summary>
        public void ForceEnd()
        {
            cd.Cancel();
            if(NumOfClicks> 0)
                chrono.Stop();
            Board.RevealBoard();
        }

        /// <summary>
        /// handles clicks, start chrono timer on first click, start the afk timer again,
        /// increase the number of clicks, reveal the cell and open the board if there is space,
        /// checks if the cell is a mine and the end of the game
        /// </summary>
        /// <param name="x">position of cell</param>
        /// <param name="y">position of cell</param>
        internal void Click(int x, int y)
        {
            if(x>=0&&y>=0&&x<WIDTH && y<HEIGHT&&!GetCellAt(x, y).IsClicked&& !GetCellAt(x, y).IsFlagged)
            {
                if(NumOfClicks==0)
                {
                    chrono = Activity.FindViewById<Chronometer>(Resource.Id.tvTimer);
                    chrono.Base= SystemClock.ElapsedRealtime();
                    chrono.Start();
                    tvScoreNow = Activity.FindViewById<TextView>(Resource.Id.tvScoreNow);
                }
                cd.Cancel();
                cd = new GameTimer(60000, 1000, (Activity)Context);
                cd.Start();
                if (GetCellAt(x, y) is NumberTile || GetCellAt(x, y) is Mine)
                    NumOfClicks++;
                GetCellAt(x, y).Revealed();
                if (!(GetCellAt(x, y) is NumberTile)&&!(GetCellAt(x, y) is Mine))
                    for (int xt = -1; xt <= 1; xt++)
                        for (int yt = -1; yt <= 1; yt++)
                            if (xt!=0||yt!=0)
                                Click(x + xt, y + yt);
                if (GetCellAt(x, y) is Mine)
                    MineClicked(x,y);
            }
            CheckEnd();
        }

        /// <summary>
        /// restart the game
        /// </summary>
        /// <param name="x">position of cell</param>
        /// <param name="y">position of cell</param>
        private void MineClicked(int x,int y)
        {
            Score = BOMB_NUMBER;
            tvScoreNow.Text = Score.ToString();
            Toast.MakeText(Context, "Mine Clicked, try again", ToastLength.Long).Show();
            ((Mine)GetCellAt(x, y)).HasExploded();
            Board.UnRevealBoard();
        }

        /// <summary>
        /// flags the cell, updates the number of flags clicked in the sql, handles the score
        /// </summary>
        /// <param name="x">position of cell</param>
        /// <param name="y">position of cell</param>
        internal void Flag(int x, int y)
        {
            if(!GetCellAt(x, y).IsClicked&& !GetCellAt(x, y).IsRevealed)
            {
                NumOfClicks++;
                bool isFlagged = GetCellAt(x, y).IsFlagged;
                GetCellAt(x, y).SetFlagged(!isFlagged);
                GetCellAt(x, y).Invalidate();
                if(GetCellAt(x, y) is Mine)
                {
                    PlayerStats.MinesFound++;
                    SqlStats.Update(PlayerStats);
                    Score--;
                    tvScoreNow.Text = Score.ToString();
                }
            }
        }

        /// <summary>
        /// starts the animation in the end dialog
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <param name="img3"></param>
        /// <param name="img4"></param>
        /// <param name="img5"></param>
        protected void StartAnimation(ImageView img1, ImageView img2, ImageView img3, ImageView img4, ImageView img5)
        {
            myAnimationReceiver = new AnimationReceiver(img1, img2, img3, img4, img5);
            IntentFilter filter = new IntentFilter();
            filter.AddAction(General.ACTION_ANIMATE);
            Context.RegisterReceiver(myAnimationReceiver, filter);
            Intent intent = new Intent(Context, typeof(AnimationService));
            Context.StartService(intent);
        }

        /// <summary>
        /// when winning, open the win dialog and thre there is an animation and the number of clicks it took to win 
        /// </summary>
        private void ShowWinDialog()
        {
            winDialog = new Dialog(Activity);
            winDialog.SetContentView(Resource.Layout.win_dialog);
            img1 = winDialog.FindViewById<ImageView>(Resource.Id.animation1);
            img2 = winDialog.FindViewById<ImageView>(Resource.Id.animation2);
            img3 = winDialog.FindViewById<ImageView>(Resource.Id.animation3);
            img4 = winDialog.FindViewById<ImageView>(Resource.Id.animation4);
            img5 = winDialog.FindViewById<ImageView>(Resource.Id.animation5);
            TextView nm = winDialog.FindViewById<TextView>(Resource.Id.clicks);
            nm.Text=NumOfClicks.ToString();
            StartAnimation(img1, img2, img3, img4, img5);
            winDialog.SetCancelable(true);
            winDialog.Show();
        }

        /// <summary>
        /// takes the time the timer finished in and coverts it to numeric value
        /// </summary>
        /// <returns></returns>
        private int ChronometerToNumericValue()
        {
            long baseTime = chrono.Base;
            long currentElapsedTime = SystemClock.ElapsedRealtime();
            int elapsedTimeInSeconds = (int)((currentElapsedTime - baseTime) / 1000);
            return elapsedTimeInSeconds;
        }

        /// <summary>
        /// sends the name of the player and the time it took him to win to firebase
        /// </summary>
        public void SentTimeToFirebase()
        {
            HashMap hashMap = new HashMap();
            FbData fbd = new FbData();
            hashMap.Put(General.FIELD_NAME, PlayerName);
            hashMap.Put(General.FIELD_WIN_TIME, ChronometerToNumericValue());
            fbd.SetDocument(General.TIMES_COLLECTION, string.Empty, out string id, hashMap);
        }
    }
}