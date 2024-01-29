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
        public Grid(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            GameEngine.GetInstance().CreateGrid(context);
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
                return GameEngine.GetInstance().GetCellAt(position);
            }
        }
    }
}

