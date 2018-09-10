package md5113697ea6091fc53900b9ccb26c87da9;


public class RecyclerViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Master.Adapters.RecyclerViewHolder, Master", RecyclerViewHolder.class, __md_methods);
	}


	public RecyclerViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == RecyclerViewHolder.class)
			mono.android.TypeManager.Activate ("Master.Adapters.RecyclerViewHolder, Master", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
