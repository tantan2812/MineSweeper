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
            public override int Count => GameEngine.WIDTH * GameEngine.HEIGHT;

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
            /// <returns>the view</returns>
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View v =  GameEngine.GetInstance().GetCellAt(position);
                NotifyDataSetChanged();
                return v;
            }
        }
    }
}

