package mono.com.transitionseverywhere;


public class Transition_TransitionListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.transitionseverywhere.Transition.TransitionListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTransitionCancel:(Lcom/transitionseverywhere/Transition;)V:GetOnTransitionCancel_Lcom_transitionseverywhere_Transition_Handler:Com.Transitionseverywhere.Transition/ITransitionListenerInvoker, BindingTransitionsEverywhere\n" +
			"n_onTransitionEnd:(Lcom/transitionseverywhere/Transition;)V:GetOnTransitionEnd_Lcom_transitionseverywhere_Transition_Handler:Com.Transitionseverywhere.Transition/ITransitionListenerInvoker, BindingTransitionsEverywhere\n" +
			"n_onTransitionPause:(Lcom/transitionseverywhere/Transition;)V:GetOnTransitionPause_Lcom_transitionseverywhere_Transition_Handler:Com.Transitionseverywhere.Transition/ITransitionListenerInvoker, BindingTransitionsEverywhere\n" +
			"n_onTransitionResume:(Lcom/transitionseverywhere/Transition;)V:GetOnTransitionResume_Lcom_transitionseverywhere_Transition_Handler:Com.Transitionseverywhere.Transition/ITransitionListenerInvoker, BindingTransitionsEverywhere\n" +
			"n_onTransitionStart:(Lcom/transitionseverywhere/Transition;)V:GetOnTransitionStart_Lcom_transitionseverywhere_Transition_Handler:Com.Transitionseverywhere.Transition/ITransitionListenerInvoker, BindingTransitionsEverywhere\n" +
			"";
		mono.android.Runtime.register ("Com.Transitionseverywhere.Transition+ITransitionListenerImplementor, BindingTransitionsEverywhere", Transition_TransitionListenerImplementor.class, __md_methods);
	}


	public Transition_TransitionListenerImplementor ()
	{
		super ();
		if (getClass () == Transition_TransitionListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Transitionseverywhere.Transition+ITransitionListenerImplementor, BindingTransitionsEverywhere", "", this, new java.lang.Object[] {  });
	}


	public void onTransitionCancel (com.transitionseverywhere.Transition p0)
	{
		n_onTransitionCancel (p0);
	}

	private native void n_onTransitionCancel (com.transitionseverywhere.Transition p0);


	public void onTransitionEnd (com.transitionseverywhere.Transition p0)
	{
		n_onTransitionEnd (p0);
	}

	private native void n_onTransitionEnd (com.transitionseverywhere.Transition p0);


	public void onTransitionPause (com.transitionseverywhere.Transition p0)
	{
		n_onTransitionPause (p0);
	}

	private native void n_onTransitionPause (com.transitionseverywhere.Transition p0);


	public void onTransitionResume (com.transitionseverywhere.Transition p0)
	{
		n_onTransitionResume (p0);
	}

	private native void n_onTransitionResume (com.transitionseverywhere.Transition p0);


	public void onTransitionStart (com.transitionseverywhere.Transition p0)
	{
		n_onTransitionStart (p0);
	}

	private native void n_onTransitionStart (com.transitionseverywhere.Transition p0);

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
