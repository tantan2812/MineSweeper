using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using static Android.Icu.Text.Transliterator;

namespace MineSweeper
{
    /// <summary>
    /// creates the gridview full of the views and creates the board 
    /// </summary>
    public class Grid : GridView
    {
        public Board Board { get; set; }
        Context ContextGird { get; set; }

        /// <summary>
        /// gets called from the xml, creates the board and sets the adapter
        /// </summary>
        /// <param name="context"></param>
        /// <param name="attrs"></param>
        public Grid(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            ContextGird = context;
            GameEngine.GetInstance().CreateGrid(ContextGird);
            Board = GameEngine.GetInstance().Board;
            SetNumColumns(GameEngine.WIDTH);
            Adapter = new GridAdapter();
        }

        public Grid(Context context, Board board) : base(context)
        {
            Board = board;
            Board.Context = context;
            GameEngine.GetInstance().Context = context;
            //Board = Board.CreateCopyBoard(Board);
            GameEngine.GetInstance().Board = Board;
            GameEngine.GetInstance().SetBoard(GameEngine.GetInstance().Board);
            GameEngine.GetInstance().Board.InvalidateSquares();
            SetNumColumns(GameEngine.WIDTH);
            Adapter = new GridAdapter();
        }

        public Grid(Context context) : base(context) { }

        public void UpdateBoard(Board board, Context context)
        {
            Board=board;
            Board.Context = ContextGird;
            GameEngine.GetInstance().Context=ContextGird;
            //Board = Board.CreateCopyBoard(Board);
            GameEngine.GetInstance().Board=Board;
            GameEngine.GetInstance().SetBoard(GameEngine.GetInstance().Board);
            GameEngine.GetInstance().Board.InvalidateSquares();
            SetNumColumns(GameEngine.WIDTH);
            Adapter = new GridAdapter();
        }

        /// <summary>
        /// measures the grid
        /// </summary>
        /// <param name="WidthMeasureSpec"></param>
        /// <param name="HeightMeasureSpec"></param>
        protected override void OnMeasure(int WidthMeasureSpec, int HeightMeasureSpec)
        {
            base.OnMeasure(WidthMeasureSpec, WidthMeasureSpec);
        }

        /// <summary>
        /// shows the views and grid for the player on the screen
        /// </summary>
        private class GridAdapter : BaseAdapter
        {
            /// <summary>
            /// size of the board
            /// </summary>
            public override int Count => Constants.SIZE_OF_BOARD_WIDTH * Constants.SIZE_OF_BOARD_HEIGHT;

            /// <summary>
            /// implement class
            /// </summary>
            /// <param name="position"></param>
            /// <returns></returns>
            public override Java.Lang.Object GetItem(int position)
            {
                return null;
            }

            /// <summary>
            /// returns the views position
            /// </summary>
            /// <param name="position">position of view</param>
            /// <returns></returns>
            public override long GetItemId(int position)
            {
                return position;
            }

            /// <summary>
            /// gets the square and put it on the screen
            /// </summary>
            /// <param name="position">position of view</param>
            /// <param name="convertView">unused</param>
            /// <param name="parent">unused</param>
            /// <returns></returns>
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View v =  GameEngine.GetInstance().GetCellAt(position);
                NotifyDataSetChanged();
                return v;
            }
        }
    }
}

