using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Widget;
using MineSweeper;

namespace ServiceSample
{
    [BroadcastReceiver]
    public class AnimationReceiver : BroadcastReceiver
    {
        ImageView myPicture;
        //TextView myText;
        public override void OnReceive(Context context, Intent intent)
        {
            int resourceId, num = 0;
            if (intent.Action == General.ACTION_ANIMATE)
                num = intent.GetIntExtra(General.KEY_FRAME, 0);
            //myText.Text = General.IRC_TEXT;
            switch (num)
            {
                case 1:
                    resourceId = (int)typeof(Resource.Drawable).GetField("bomb_normal").GetValue(null);
                    myPicture.SetImageResource(resourceId);
                    break;
                case 2:
                    resourceId = (int)typeof(Resource.Drawable).GetField("bomb_exploded").GetValue(null);
                    myPicture.SetImageResource(resourceId);
                    break;
                default:
                    myPicture.SetImageResource(0);
                    break;
            }
            //if (num == 0)
            //{
            //    myText.Text = "";
            //}
        }

        public AnimationReceiver(ImageView myImage/*, TextView myText*/)
        {
            this.myPicture = myImage;
            //this.myText = myText;
        }

        public AnimationReceiver() { }
    }
}
