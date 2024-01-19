using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    internal class Square: View
    {
        Bitmap EmptyCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.number_0);
        Bitmap FlaggedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.flag);
        Bitmap UnRevealedCell = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.button);

        public bool IsRevealed { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsFlagged { get; set; }

        public Square(Context context, float X, float Y):base(context)
        {
            IsRevealed = false;
            IsEmpty = true;
            IsFlagged = false;
        }
        public Square(Context context):base(context) { }

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

        protected override void OnDraw(Canvas canvas)
        {
            if (IsEmpty==true)
                canvas.DrawBitmap(EmptyCell, 0, 0, null);
            if(IsRevealed==false)
                canvas.DrawBitmap(UnRevealedCell, 0, 0, null);
            if(IsFlagged==true)
                canvas.DrawBitmap(FlaggedCell, 0, 0, null);
            base.OnDraw(canvas);
        }

        protected override void OnMeasure(int widthMeasure, int heightMeasure)
        {
            base.OnMeasure(widthMeasure, heightMeasure);
        }

    }
}