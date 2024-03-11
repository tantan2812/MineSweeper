package crc6457bf5106a7e2aabd;


public class AnimationReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("MineSweeper.AnimationReceiver, MineSweeper", AnimationReceiver.class, __md_methods);
	}


	public AnimationReceiver ()
	{
		super ();
		if (getClass () == AnimationReceiver.class) {
			mono.android.TypeManager.Activate ("MineSweeper.AnimationReceiver, MineSweeper", "", this, new java.lang.Object[] {  });
		}
	}

	public AnimationReceiver (android.widget.ImageView p0, android.widget.ImageView p1, android.widget.ImageView p2, android.widget.ImageView p3, android.widget.ImageView p4)
	{
		super ();
		if (getClass () == AnimationReceiver.class) {
			mono.android.TypeManager.Activate ("MineSweeper.AnimationReceiver, MineSweeper", "Android.Widget.ImageView, Mono.Android:Android.Widget.ImageView, Mono.Android:Android.Widget.ImageView, Mono.Android:Android.Widget.ImageView, Mono.Android:Android.Widget.ImageView, Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
		}
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
