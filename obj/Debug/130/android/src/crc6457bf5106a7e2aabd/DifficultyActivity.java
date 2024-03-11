package crc6457bf5106a7e2aabd;


public class DifficultyActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("MineSweeper.DifficultyActivity, MineSweeper", DifficultyActivity.class, __md_methods);
	}


	public DifficultyActivity ()
	{
		super ();
		if (getClass () == DifficultyActivity.class) {
			mono.android.TypeManager.Activate ("MineSweeper.DifficultyActivity, MineSweeper", "", this, new java.lang.Object[] {  });
		}
	}


	public DifficultyActivity (int p0)
	{
		super (p0);
		if (getClass () == DifficultyActivity.class) {
			mono.android.TypeManager.Activate ("MineSweeper.DifficultyActivity, MineSweeper", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
