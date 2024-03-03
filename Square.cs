using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Newtonsoft.Json;

namespace MineSweeper
{
    /// <summary>
    /// has a square with bools that tell it state and draw it accordingly, also listen for clicks and long clicks on it
    /// </summary>
    public class Square: View, View.IOnClickListener,View.IOnLongClickListener
    {
        [JsonIgnore]
        Bitmap EmptyCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_0);
        [JsonIgnore]
        Bitmap FlaggedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.flag);
        [JsonIgnore]
        Bitmap UnRevealedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.button);

        public bool IsRevealed { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsClicked { get; set; }
        public int x, y;
        public int position;

        /// <summary>
        /// creates the square, and it gives it the diffult parameters and sets listeners
        /// </summary>
        /// <param name="context">the activity to put the view on</param>
        /// <param name="X">specific square</param>
        /// <param name="Y">specific square</param>
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

        /// <summary>
        /// creates the square, and it gives it the default parameters and sets listeners
        /// </summary>
        /// <param name="context">the activity to put the view on</param>
        public Square(Context context) : base(context)
        {
            IsRevealed = false;
            IsEmpty = true;
            IsFlagged = false;
            IsClicked = false;
            SetOnClickListener(this);
            SetOnLongClickListener(this);
            PostInvalidate();
        }

        /// <summary>
        /// empty constractor
        /// </summary>
        public Square():base(null)
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

        /// <summary>
        /// reveals the square, sets it parameters accordingly and draws it 
        /// </summary>
        public void Revealed()
        {
            IsClicked = true;
            IsRevealed = true;
            Invalidate();
            PostInvalidate();
        }

        /// <summary>
        /// sets the square empty, sets it parameters accordingly and draws it 
        /// </summary>
        public void SetEmpty()
        {
            IsEmpty = false;
            Invalidate();
        }

        /// <summary>
        /// sets the square flagged, sets it parameters accordingly and draws it 
        /// </summary>
        public void Flagged()
        {
            IsFlagged = true;
            Invalidate();
        }

        /// <summary>
        /// sets the square unflagged, sets it parameters accordingly and draws it 
        /// </summary>
        public void UnFlagged()
        {
            IsFlagged = false;
            Invalidate();
        }

        /// <summary>
        /// set func for flagged
        /// </summary>
        /// <param name="flagged"></param>
        public void SetFlagged(bool flagged)
        {
            IsFlagged = flagged;
        }

        /// <summary>
        /// scales the bitmap
        /// </summary>
        /// <param name="original">the bitmap</param>
        /// <param name="newWidth">size of scaling</param>
        /// <param name="newHeight">size of scaling</param>
        /// <returns></returns>
        private Bitmap ScaleBitmap(Bitmap original, int newWidth, int newHeight)
        {
            return Bitmap.CreateScaledBitmap(original, newWidth, newHeight, true);
        }

        /// <summary>
        /// scales the bitmap and handles the drawing of an empty square
        /// </summary>
        /// <param name="canvas">the canvas were drawing on</param>
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

        /// <summary>
        /// measure the view
        /// </summary>
        /// <param name="WidthMeasureSpec">size of measure</param>
        /// <param name="HeightMeasureSpec">size of measure</param>
        protected override void OnMeasure(int WidthMeasureSpec, int HeightMeasureSpec)
        {
            base.OnMeasure(WidthMeasureSpec, WidthMeasureSpec);
        }

        /// <summary>
        /// get func for x position
        /// </summary>
        /// <returns></returns>
        public int GetXPos()
        {
            return x;
        }

        /// <summary>
        /// get func for y position
        /// </summary>
        /// <returns></returns>
        public int GetYPos()
        {
            return y;
        }

        /// <summary>
        /// get func for position
        /// </summary>
        /// <returns></returns>
        public int GetPosition()
        {
            return position;
        }

        /// <summary>
        /// set func for position
        /// </summary>
        /// <returns></returns>
        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
            position = y * GameEngine.WIDTH + x;
            Invalidate();
        }

        /// <summary>
        /// sends square position for click func in gameengine an draws it 
        /// </summary>
        /// <param name="v"></param>
        public void OnClick(View v)
        {
            GameEngine.GetInstance().Click(GetXPos(), GetYPos());
            Invalidate();
            PostInvalidate();
        }

        /// <summary>
        /// sends square position for longclick func in gameengine tha flags thw square
        /// </summary>
        /// <param name="v"></param>
        public bool OnLongClick(View v)
        {
            GameEngine.GetInstance().Flag(GetXPos(), GetYPos());
            return true;
        }
        /*public string GetJsonSquare()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Square GetSquareJson(string json)
        {
            return JsonConvert.DeserializeObject<Square>(json);
        }*/
    }
}