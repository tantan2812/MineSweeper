using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using AndroidX.Core.Content;

namespace MineSweeper
{
    internal class Square: View, View.IOnClickListener,View.IOnLongClickListener
    {
        readonly Bitmap EmptyCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_0);
        readonly Bitmap FlaggedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.flag);
        readonly Bitmap UnRevealedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.button);

        public bool IsRevealed { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsClicked { get; set; }
        private int x, y;
        private int position;

        public Square(Context context, int X, int Y):base(context)
        {
            x = X;
            y = Y;
            IsRevealed = false;
            IsEmpty = true;
            IsFlagged = false;
            IsClicked = false;
            SetPosition(x, y);
            SetOnClickListener(this);
            SetOnLongClickListener(this);
            PostInvalidate();
        }

        public Square(Context context) : base(context)
        {

        }

        public Square(Context context, IAttributeSet attrs, int X, int Y) : base(context, attrs)
        {
            x = X;
            y = Y;
            IsRevealed = false;
            IsEmpty = true;
            IsFlagged = false;
            IsClicked = false;
            SetPosition(x, y);
            SetOnClickListener(this);
            SetOnLongClickListener(this);
            PostInvalidate();
        }

        public void Revealed()
        {
            IsClicked = true;
            IsRevealed = true;
            Invalidate();
        }
        public void SetEmpty()
        {
            IsEmpty = false;
            Invalidate();
        }
        public void Flagged()
        {
            IsFlagged = true;
            Invalidate();
        } 
        public void UnFlagged()
        {
            IsFlagged = false;
            Invalidate();
        }

        public void SetFlagged(bool flagged)
        {

            IsFlagged = flagged;
        }

        private Bitmap ScaleBitmap(Bitmap original, int newWidth, int newHeight)
        {
            return Bitmap.CreateScaledBitmap(original, newWidth, newHeight, true);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            int scaledWidth = Width;
            int scaledHeight = Height;

            Bitmap scaledEmptyCell = ScaleBitmap(EmptyCell, scaledWidth, scaledHeight);
            Bitmap scaledFlaggedCell = ScaleBitmap(FlaggedCell, scaledWidth, scaledHeight);
            Bitmap scaledUnRevealedCell = ScaleBitmap(UnRevealedCell, scaledWidth, scaledHeight);
            if(!(this is NumberTile) && !(this is Mine))
            if (IsEmpty == true)
                canvas.DrawBitmap(scaledEmptyCell, 0, 0, null);
            if (IsRevealed == false)
                canvas.DrawBitmap(scaledUnRevealedCell, 0, 0, null);
            if (IsFlagged == true)
                canvas.DrawBitmap(scaledFlaggedCell, 0, 0, null);
        }

        protected override void OnMeasure(int WidthMeasureSpec, int HeightMeasureSpec)
        {
            base.OnMeasure(WidthMeasureSpec, WidthMeasureSpec);
        }

        public int GetXPos()
        {
            return x;
        }

        public int GetYPos()
        {
            return y;
        }

        public int GetPosition()
        {
            return position;
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.position = y * GameEngine.WIDTH + x;
            Invalidate();
        }

        public void OnClick(View v)
        {
            GameEngine.GetInstance().Click(GetXPos(), GetYPos());
        }

        public bool OnLongClick(View v)
        {
            GameEngine.GetInstance().Flag(GetXPos(), GetYPos());
            return true;
        }
    }
}