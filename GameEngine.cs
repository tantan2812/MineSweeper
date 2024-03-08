using Android.App;
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
        private Context Context;
        public Activity Activity;
        private AnimationReceiver myAnimationReceiver;
        public static int BOMB_NUMBER { get; set; }
        public static int WIDTH { get; set; }
        public static int HEIGHT { get; set; }
        private Board Board { get; set; }
        private PlayerStats PlayerStats { get; set; }
        private SqlDataStats SqlStats { get; set; }
        private Dialog WinDialog { get; set; }
        private ImageView img1;
        private ImageView img2;
        private ImageView img3;
        private ImageView img4;
        private ImageView img5;
        private Chronometer chrono;
        public GameTimer cd;
        private TextView tvScoreNow;
        public string PlayerName { get; set; }
        private int NumOfClicks { get; set; }
        private int Score { get; set; }
        private bool IsWon { get; set; }
        public int Difficulty { get; set; }

        /// <summary>
        /// gets the instance of the class, checks it hasnt been created again
        /// </summary>
        /// <returns>the instance</returns>
        public static GameEngine GetInstance()
        {
            Instance ??= new GameEngine();
            return Instance;
        }

        /// <summary>
        /// creates the board with the intended difficulty, start the afk timer and sets parameters to default and handles starting the sql 
        /// </summary>
        /// <param name="context">the grid context</param>
        public void CreateGrid(Context context)
        {
            if (Difficulty == 1)
            {
                BOMB_NUMBER = Constants.NUMBER_OF_MINES_1_DIFF;
                WIDTH = Constants.SIZE_OF_BOARD_WIDTH_1_DIFF;
                HEIGHT = Constants.SIZE_OF_BOARD_HEIGHT_1_DIFF;

            }
            else if (Difficulty == 2)
            {
                BOMB_NUMBER = Constants.NUMBER_OF_MINES_2_DIFF;
                WIDTH = Constants.SIZE_OF_BOARD_WIDTH_2_DIFF;
                HEIGHT = Constants.SIZE_OF_BOARD_HEIGHT_2_DIFF;
            }
            else if (Difficulty == 3)
            {
                BOMB_NUMBER = Constants.NUMBER_OF_MINES_3_DIFF;
                WIDTH = Constants.SIZE_OF_BOARD_WIDTH_3_DIFF;
                HEIGHT = Constants.SIZE_OF_BOARD_HEIGHT_3_DIFF;
            }
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

        /// <summary>
        /// gets a cell from the board
        /// </summary>
        /// <param name="position">what cell</param>
        /// <returns>the specific square</returns>
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
        /// <returns>the specific square</returns>
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
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    if (GetCellAt(x, y).IsRevealed || GetCellAt(x, y).IsFlagged)
                        notRevealed--;
                    if (GetCellAt(x, y).IsFlagged && GetCellAt(x, y) is Mine)
                        bombNotFound--;
                }

            if (bombNotFound == 0 && notRevealed == 0)
            {
                if (IsWon == false)
                {
                    IsWon = true;
                    Toast.MakeText(Context, Constants.GAME_WOM, ToastLength.Long).Show();
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
            Toast.MakeText(Context, Constants.MINE_CLICKED, ToastLength.Long).Show();
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
                if (NumOfClicks == 0)
                    Toast.MakeText(Context, Constants.FIRST_FLAG, ToastLength.Long).Show();
                else
                {
                    NumOfClicks++;
                    bool isFlagged = GetCellAt(x, y).IsFlagged;
                    GetCellAt(x, y).SetFlagged(!isFlagged);
                    if (isFlagged)
                        Score++;
                    else if (!isFlagged)
                        Score--;
                    tvScoreNow ??= Activity.FindViewById<TextView>(Resource.Id.tvScoreNow);
                    tvScoreNow.Text = Score.ToString();
                    GetCellAt(x, y).Invalidate();
                    if (GetCellAt(x, y) is Mine)
                    {
                        PlayerStats.MinesFound++;
                        SqlStats.Update(PlayerStats);
                    }              
                }
            }
        }

        /// <summary>
        /// starts the animation in the end dialog
        /// </summary>
        /// <param name="img1">imageview to animate</param>
        /// <param name="img2">imageview to animate</param>
        /// <param name="img3">imageview to animate</param>
        /// <param name="img4">imageview to animate</param>
        /// <param name="img5">imageview to animate</param>
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
            WinDialog = new Dialog(Activity);
            WinDialog.SetContentView(Resource.Layout.win_dialog);
            img1 = WinDialog.FindViewById<ImageView>(Resource.Id.animation1);
            img2 = WinDialog.FindViewById<ImageView>(Resource.Id.animation2);
            img3 = WinDialog.FindViewById<ImageView>(Resource.Id.animation3);
            img4 = WinDialog.FindViewById<ImageView>(Resource.Id.animation4);
            img5 = WinDialog.FindViewById<ImageView>(Resource.Id.animation5);
            TextView nm = WinDialog.FindViewById<TextView>(Resource.Id.clicks);
            nm.Text=NumOfClicks.ToString();
            StartAnimation(img1, img2, img3, img4, img5);
            WinDialog.SetCancelable(true);
            WinDialog.Show();
        }

        /// <summary>
        /// takes the time the timer finished in and coverts it to numeric value
        /// </summary>
        /// <returns>the time in numeric value</returns>
        private int ChronometerToNumericValue()
        {
            long baseTime = chrono.Base;
            long currentElapsedTime = SystemClock.ElapsedRealtime();
            int elapsedTimeInSeconds = (int)((currentElapsedTime - baseTime) / 1000);
            return elapsedTimeInSeconds;
        }

        /// <summary>
        /// returns the name of the difficulty 
        /// </summary>
        /// <returns></returns>
        private string DifficultyName()
        {
            string diff=string.Empty;
            if (Difficulty == 1)
                diff = "Easy";
            else if (Difficulty == 2)
                diff = "Intermediate";
            else
                diff = "Expert";
            return diff;

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
            hashMap.Put(General.FIELD_DIFFICULTY_BOARD, DifficultyName());
            fbd.SetDocument(General.TIMES_COLLECTION, string.Empty, out string id, hashMap);
        }
    }
}