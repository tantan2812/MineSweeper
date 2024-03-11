package mono.com.google.firebase.appcheck;


public class FirebaseAppCheck_AppCheckListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.firebase.appcheck.FirebaseAppCheck.AppCheckListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAppCheckTokenChanged:(Lcom/google/firebase/appcheck/AppCheckToken;)V:GetOnAppCheckTokenChanged_Lcom_google_firebase_appcheck_AppCheckToken_Handler:Firebase.AppCheck.FirebaseAppCheck/IAppCheckListenerInvoker, Xamarin.Firebase.AppCheck\n" +
			"";
		mono.android.Runtime.register ("Firebase.AppCheck.FirebaseAppCheck+IAppCheckListenerImplementor, Xamarin.Firebase.AppCheck", FirebaseAppCheck_AppCheckListenerImplementor.class, __md_methods);
	}


	public FirebaseAppCheck_AppCheckListenerImplementor ()
	{
		super ();
		if (getClass () == FirebaseAppCheck_AppCheckListenerImplementor.class) {
			mono.android.TypeManager.Activate ("Firebase.AppCheck.FirebaseAppCheck+IAppCheckListenerImplementor, Xamarin.Firebase.AppCheck", "", this, new java.lang.Object[] {  });
		}
	}


	public void onAppCheckTokenChanged (com.google.firebase.appcheck.AppCheckToken p0)
	{
		n_onAppCheckTokenChanged (p0);
	}

	private native void n_onAppCheckTokenChanged (com.google.firebase.appcheck.AppCheckToken p0);

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
