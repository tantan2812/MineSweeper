using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Kotlin.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Icu.Text.ListFormatter;

namespace MineSweeper
{
    public class Grid : GridView
    {
        public Grid(Context context) : base(context)
        {
            GameEngine.getInstance().createGrid(context);
            SetNumColumns(GameEngine.WIDTH);
#pragma warning disable CS0618 // Type or member is obsolete
            SetAdapter(new GridAdapter());
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public Grid(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            GameEngine.getInstance().createGrid(context);
            SetNumColumns(GameEngine.WIDTH);
#pragma warning disable CS0618 // Type or member is obsolete
            SetAdapter(new GridAdapter());
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public Grid(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            GameEngine.getInstance().createGrid(context);
            SetNumColumns(GameEngine.WIDTH);
#pragma warning disable CS0618 // Type or member is obsolete
            SetAdapter(new GridAdapter());
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public Grid(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            GameEngine.getInstance().createGrid(context);
            SetNumColumns(GameEngine.WIDTH);
#pragma warning disable CS0618 // Type or member is obsolete
            SetAdapter(new GridAdapter());
#pragma warning restore CS0618 // Type or member is obsolete
        }

        protected Grid(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
           
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
                return 0;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                return GameEngine.getInstance().getCellAt(position);
            }
        }
    }
}

