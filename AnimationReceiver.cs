using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Media;
using Android.Widget;
using MineSweeper;

namespace MineSweeper
{
    /// <summary>
    /// Broadcast receiver for handling image animation based on received intents.
    /// </summary>
    [BroadcastReceiver]
    public class AnimationReceiver : BroadcastReceiver
    {
        ImageView myPicture1;
        ImageView myPicture2;
        ImageView myPicture3;
        ImageView myPicture4;
        ImageView myPicture5;

        /// <summary>
        /// Called when the broadcast receiver receives an intent.
        /// </summary>
        /// <param name="context">The Context in which the receiver is running.</param>
        /// <param name="intent">The Intent being received.</param>
        public override void OnReceive(Context context, Intent intent)
        {
            int resourceId, num = 0;
            if (intent.Action == General.ACTION_ANIMATE)
                num = intent.GetIntExtra(General.KEY_FRAME, 0);
            switch (num)
            {
                case 1:
                    resourceId = (int)typeof(Resource.Drawable).GetField("bomb_normal").GetValue(null);
                    myPicture1.SetImageResource(resourceId);
                    myPicture2.SetImageResource(resourceId);
                    myPicture3.SetImageResource(resourceId);
                    myPicture4.SetImageResource(resourceId);
                    myPicture5.SetImageResource(resourceId);
                    break;
                case 2:
                    resourceId = (int)typeof(Resource.Drawable).GetField("bomb_exploded").GetValue(null);
                    myPicture1.SetImageResource(resourceId);
                    myPicture2.SetImageResource(resourceId);
                    myPicture3.SetImageResource(resourceId);
                    myPicture4.SetImageResource(resourceId);
                    myPicture5.SetImageResource(resourceId);
                    break;
                default:
                    myPicture1.SetImageResource(0);
                    myPicture2.SetImageResource(0);
                    myPicture3.SetImageResource(0);
                    myPicture4.SetImageResource(0);
                    myPicture5.SetImageResource(0);
                    break;
            }
        }

        /// <summary>
        /// Constructor for initializing the receiver with specific ImageView objects.
        /// </summary>
        /// <param name="myImage1">The first ImageView object.</param>
        /// <param name="myImage2">The second ImageView object.</param>
        /// <param name="myImage3">The third ImageView object.</param>
        /// <param name="myImage4">The fourth ImageView object.</param>
        /// <param name="myImage5">The fifth ImageView object.</param>
        public AnimationReceiver(ImageView myImage1, ImageView myImage2, ImageView myImage3, ImageView myImage4, ImageView myImage5)
        {
            myPicture1 = myImage1;
            myPicture2 = myImage2;
            myPicture3 = myImage3;
            myPicture4 = myImage4;
            myPicture5 = myImage5;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AnimationReceiver() { }
    }
}
