using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;

namespace MineSweeper
{
    internal class Square: View, View.IOnClickListener,View.IOnLongClickListener
    {
        Bitmap EmptyCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_0);
        Bitmap FlaggedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.flag);
        Bitmap UnRevealedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.button);

        public bool IsRevealed { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsFlagged { get; set; }

        //private readonly float length, height;

        private int x, y;
        private int position;

        public Square(Context context, int X, int Y):base(context)
        {
            x = X;
            y = Y;
            IsRevealed = false;
            IsEmpty = true;
            IsFlagged = false;
            /*length = Constants.SIZE_OF_CELL_WIDTH;
            height = Constants.SIZE_OF_CELL_HEIGHT;*/
            SetPosition(x, y);
            SetOnClickListener(this);
            SetOnLongClickListener(this);
        }

        public Square(Context context) : base(context)
        {

        }

        public void Revealed()
        {
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

        protected override void OnDraw(Canvas canvas)
        {
            if (IsEmpty == true)
                canvas.DrawBitmap(EmptyCell, 0, 0, null);
            if (IsRevealed == false)
                canvas.DrawBitmap(UnRevealedCell, 0, 0, null);
            if (IsFlagged == true)
                canvas.DrawBitmap(FlaggedCell, 0, 0, null);
            base.OnDraw(canvas);
        }

        protected override void OnMeasure(int widthMeasure, int heightMeasure)
        {
            base.OnMeasure(widthMeasure, heightMeasure);
        }

       /* public bool Touched(float x, float y)
        {
            return x >= GetX() && y >= GetY() && x <= GetX() + length & y <= GetY() + height;
        }*/

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
            /* if(IsEmpty==false)
             {
                 if (this is Mine)
                 {

                 }
                 else
                 {
                     Revealed();
                 }
             }*/
            GameEngine.getInstance().Click(GetXPos(), GetYPos());
        }

        public bool OnLongClick(View v)
        {
            /*if (IsFlagged)
                UnFlagged();
            else
                Flagged();
            return true;*/
            GameEngine.getInstance().Flag(GetXPos(), GetYPos());
            return true;
        }
    }
}