using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace MineSweeper
{
    internal class BoardAdapter : BaseAdapter<Square>
    {
        private Context context;
        private List<Square> lstSquares;

        public BoardAdapter(Context context)
        {
            this.context = context;
            lstSquares = new List<Square>();
        }
        public override Square this[int position] => lstSquares[position];

        public override int Count => lstSquares.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater li = LayoutInflater.From(context);
            View v = li.Inflate(Resource.Layout.layout_board, parent, false);
            Square square = lstSquares[position];
            GridView theBoard = v.FindViewById<GridView>(Resource.Id.theBoard);
            return v;
        }

        public void Add(Square square)
        {
            lstSquares.Add(square);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            lstSquares.Clear();
            NotifyDataSetChanged();
        }
    }
}