using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;
using static Android.Icu.Text.Transliterator;

namespace MineSweeper
{
    public class Grid : GridView
    {
        public Board Board { get; set; }
        Context ContextGird { get; set; }
        public Grid(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            ContextGird = context;
            GameEngine.GetInstance().CreateGrid(ContextGird);
            Board = GameEngine.GetInstance().Board;
            SetNumColumns(GameEngine.WIDTH);
            Adapter = new GridAdapter();
        }

        public Grid(Context context) : base(context)
        {

        }

        public void UpdateBoard(Board board)
        {
            Board=board;
            Board.Context = ContextGird;
            GameEngine.GetInstance().Context=ContextGird;
            Board = Board.CreateCopyBoard(Board);
            GameEngine.GetInstance().Board=Board;
            GameEngine.GetInstance().SetBoard(GameEngine.GetInstance().Board);
            GameEngine.GetInstance().Board.InvalidateSquares();
            SetNumColumns(GameEngine.WIDTH);
            Adapter = new GridAdapter();
        }

        protected override void OnMeasure(int WidthMeasureSpec, int HeightMeasureSpec)
        {
            base.OnMeasure(WidthMeasureSpec, WidthMeasureSpec);
        }

        private class GridAdapter : BaseAdapter
        {
            public override int Count => Constants.SIZE_OF_BOARD_WIDTH * Constants.SIZE_OF_BOARD_HEIGHT;
            public override Java.Lang.Object GetItem(int position)
            {
                return null;
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View v =  GameEngine.GetInstance().GetCellAt(position);
                NotifyDataSetChanged();
                return v;
            }
        }
    }
}

