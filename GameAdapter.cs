using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace MineSweeper
{
    internal class GameAdapter : BaseAdapter<Game>
    {
        private Context context;
        private List<Game> lstGames;
        public GameAdapter(Context context)
        {
            this.context = context;
            lstGames = new List<Game>();
        }
        public override Game this[int position] => lstGames[position];

        public override int Count => lstGames.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater li = LayoutInflater.From(context);
            View v = li.Inflate(Resource.Layout.layout_game, parent, false);
            Game g = lstGames[position];
            TextView tvHostName = v.FindViewById<TextView>(Resource.Id.tvHostName);
            TextView tvCreateTime = v.FindViewById<TextView>(Resource.Id.tvCreateTime);
            tvHostName.Text = g.HostName;
            tvCreateTime.Text = g.CreateTime.ToString("hh:mm:ss");
            return v;
        }

        public void AddGame(Game game)
        {
            lstGames.Add(game);
            NotifyDataSetChanged();
        }
        public void Clear()
        {
            lstGames.Clear();
            NotifyDataSetChanged();
        }
    }
}