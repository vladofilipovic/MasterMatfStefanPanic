package md51a8842729a4471da8ba48da41f505c49;


public class MathWithAnswersFragment
	extends android.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onStop:()V:GetOnStopHandler\n" +
			"";
		mono.android.Runtime.register ("Master.Fragments.MathWithAnswersFragment, Master", MathWithAnswersFragment.class, __md_methods);
	}


	public MathWithAnswersFragment ()
	{
		super ();
		if (getClass () == MathWithAnswersFragment.class)
			mono.android.TypeManager.Activate ("Master.Fragments.MathWithAnswersFragment, Master", "", this, new java.lang.Object[] {  });
	}

	public MathWithAnswersFragment (int p0)
	{
		super ();
		if (getClass () == MathWithAnswersFragment.class)
			mono.android.TypeManager.Activate ("Master.Fragments.MathWithAnswersFragment, Master", "Master.Operacije, Master", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onStop ()
	{
		n_onStop ();
	}

	private native void n_onStop ();

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
