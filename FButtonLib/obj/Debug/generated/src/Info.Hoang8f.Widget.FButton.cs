using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Info.Hoang8f.Widget {

	// Metadata.xml XPath class reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']"
	[global::Android.Runtime.Register ("info/hoang8f/widget/FButton", DoNotGenerateAcw=true)]
	public partial class FButton : global::Android.Widget.Button, global::Android.Views.View.IOnTouchListener {

		internal static new IntPtr java_class_handle;
		internal static new IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("info/hoang8f/widget/FButton", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FButton); }
		}

		protected FButton (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/constructor[@name='FButton' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet'] and parameter[3][@type='int']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
		public unsafe FButton (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1, int p2)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				if (((object) this).GetType () != typeof (FButton)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/constructor[@name='FButton' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet']]"
		[Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
		public unsafe FButton (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				if (((object) this).GetType () != typeof (FButton)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, __args);
			} finally {
			}
		}

		static IntPtr id_ctor_Landroid_content_Context_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/constructor[@name='FButton' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe FButton (global::Android.Content.Context p0)
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				if (((object) this).GetType () != typeof (FButton)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (((object) this).GetType (), "(Landroid/content/Context;)V", __args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "(Landroid/content/Context;)V", __args);
					return;
				}

				if (id_ctor_Landroid_content_Context_ == IntPtr.Zero)
					id_ctor_Landroid_content_Context_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;)V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_, __args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, class_ref, id_ctor_Landroid_content_Context_, __args);
			} finally {
			}
		}

		static Delegate cb_getButtonColor;
#pragma warning disable 0169
		static Delegate GetGetButtonColorHandler ()
		{
			if (cb_getButtonColor == null)
				cb_getButtonColor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetButtonColor);
			return cb_getButtonColor;
		}

		static int n_GetButtonColor (IntPtr jnienv, IntPtr native__this)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ButtonColor;
		}
#pragma warning restore 0169

		static Delegate cb_setButtonColor_I;
#pragma warning disable 0169
		static Delegate GetSetButtonColor_IHandler ()
		{
			if (cb_setButtonColor_I == null)
				cb_setButtonColor_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetButtonColor_I);
			return cb_setButtonColor_I;
		}

		static void n_SetButtonColor_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ButtonColor = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getButtonColor;
		static IntPtr id_setButtonColor_I;
		public virtual unsafe int ButtonColor {
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='getButtonColor' and count(parameter)=0]"
			[Register ("getButtonColor", "()I", "GetGetButtonColorHandler")]
			get {
				if (id_getButtonColor == IntPtr.Zero)
					id_getButtonColor = JNIEnv.GetMethodID (class_ref, "getButtonColor", "()I");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getButtonColor);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getButtonColor", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='setButtonColor' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setButtonColor", "(I)V", "GetSetButtonColor_IHandler")]
			set {
				if (id_setButtonColor_I == IntPtr.Zero)
					id_setButtonColor_I = JNIEnv.GetMethodID (class_ref, "setButtonColor", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (((object) this).GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setButtonColor_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setButtonColor", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getCornerRadius;
#pragma warning disable 0169
		static Delegate GetGetCornerRadiusHandler ()
		{
			if (cb_getCornerRadius == null)
				cb_getCornerRadius = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetCornerRadius);
			return cb_getCornerRadius;
		}

		static int n_GetCornerRadius (IntPtr jnienv, IntPtr native__this)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.CornerRadius;
		}
#pragma warning restore 0169

		static Delegate cb_setCornerRadius_I;
#pragma warning disable 0169
		static Delegate GetSetCornerRadius_IHandler ()
		{
			if (cb_setCornerRadius_I == null)
				cb_setCornerRadius_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetCornerRadius_I);
			return cb_setCornerRadius_I;
		}

		static void n_SetCornerRadius_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.CornerRadius = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getCornerRadius;
		static IntPtr id_setCornerRadius_I;
		public virtual unsafe int CornerRadius {
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='getCornerRadius' and count(parameter)=0]"
			[Register ("getCornerRadius", "()I", "GetGetCornerRadiusHandler")]
			get {
				if (id_getCornerRadius == IntPtr.Zero)
					id_getCornerRadius = JNIEnv.GetMethodID (class_ref, "getCornerRadius", "()I");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCornerRadius);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getCornerRadius", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='setCornerRadius' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setCornerRadius", "(I)V", "GetSetCornerRadius_IHandler")]
			set {
				if (id_setCornerRadius_I == IntPtr.Zero)
					id_setCornerRadius_I = JNIEnv.GetMethodID (class_ref, "setCornerRadius", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (((object) this).GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCornerRadius_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setCornerRadius", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_isShadowEnabled;
#pragma warning disable 0169
		static Delegate GetIsShadowEnabledHandler ()
		{
			if (cb_isShadowEnabled == null)
				cb_isShadowEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsShadowEnabled);
			return cb_isShadowEnabled;
		}

		static bool n_IsShadowEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ShadowEnabled;
		}
#pragma warning restore 0169

		static Delegate cb_setShadowEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetShadowEnabled_ZHandler ()
		{
			if (cb_setShadowEnabled_Z == null)
				cb_setShadowEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetShadowEnabled_Z);
			return cb_setShadowEnabled_Z;
		}

		static void n_SetShadowEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ShadowEnabled = p0;
		}
#pragma warning restore 0169

		static IntPtr id_isShadowEnabled;
		static IntPtr id_setShadowEnabled_Z;
		public virtual unsafe bool ShadowEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='isShadowEnabled' and count(parameter)=0]"
			[Register ("isShadowEnabled", "()Z", "GetIsShadowEnabledHandler")]
			get {
				if (id_isShadowEnabled == IntPtr.Zero)
					id_isShadowEnabled = JNIEnv.GetMethodID (class_ref, "isShadowEnabled", "()Z");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isShadowEnabled);
					else
						return JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "isShadowEnabled", "()Z"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='setShadowEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setShadowEnabled", "(Z)V", "GetSetShadowEnabled_ZHandler")]
			set {
				if (id_setShadowEnabled_Z == IntPtr.Zero)
					id_setShadowEnabled_Z = JNIEnv.GetMethodID (class_ref, "setShadowEnabled", "(Z)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (((object) this).GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShadowEnabled_Z, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShadowEnabled", "(Z)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_getShadowHeight;
#pragma warning disable 0169
		static Delegate GetGetShadowHeightHandler ()
		{
			if (cb_getShadowHeight == null)
				cb_getShadowHeight = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetShadowHeight);
			return cb_getShadowHeight;
		}

		static int n_GetShadowHeight (IntPtr jnienv, IntPtr native__this)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.ShadowHeight;
		}
#pragma warning restore 0169

		static Delegate cb_setShadowHeight_I;
#pragma warning disable 0169
		static Delegate GetSetShadowHeight_IHandler ()
		{
			if (cb_setShadowHeight_I == null)
				cb_setShadowHeight_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetShadowHeight_I);
			return cb_setShadowHeight_I;
		}

		static void n_SetShadowHeight_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ShadowHeight = p0;
		}
#pragma warning restore 0169

		static IntPtr id_getShadowHeight;
		static IntPtr id_setShadowHeight_I;
		public virtual unsafe int ShadowHeight {
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='getShadowHeight' and count(parameter)=0]"
			[Register ("getShadowHeight", "()I", "GetGetShadowHeightHandler")]
			get {
				if (id_getShadowHeight == IntPtr.Zero)
					id_getShadowHeight = JNIEnv.GetMethodID (class_ref, "getShadowHeight", "()I");
				try {

					if (((object) this).GetType () == ThresholdType)
						return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getShadowHeight);
					else
						return JNIEnv.CallNonvirtualIntMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getShadowHeight", "()I"));
				} finally {
				}
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='setShadowHeight' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setShadowHeight", "(I)V", "GetSetShadowHeight_IHandler")]
			set {
				if (id_setShadowHeight_I == IntPtr.Zero)
					id_setShadowHeight_I = JNIEnv.GetMethodID (class_ref, "setShadowHeight", "(I)V");
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (value);

					if (((object) this).GetType () == ThresholdType)
						JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShadowHeight_I, __args);
					else
						JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShadowHeight", "(I)V"), __args);
				} finally {
				}
			}
		}

		static Delegate cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_;
#pragma warning disable 0169
		static Delegate GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler ()
		{
			if (cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_ == null)
				cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, bool>) n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent_);
			return cb_onTouch_Landroid_view_View_Landroid_view_MotionEvent_;
		}

		static bool n_OnTouch_Landroid_view_View_Landroid_view_MotionEvent_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View p0 = global::Java.Lang.Object.GetObject<global::Android.Views.View> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.MotionEvent p1 = global::Java.Lang.Object.GetObject<global::Android.Views.MotionEvent> (native_p1, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.OnTouch (p0, p1);
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onTouch_Landroid_view_View_Landroid_view_MotionEvent_;
		// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='onTouch' and count(parameter)=2 and parameter[1][@type='android.view.View'] and parameter[2][@type='android.view.MotionEvent']]"
		[Register ("onTouch", "(Landroid/view/View;Landroid/view/MotionEvent;)Z", "GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler")]
		public virtual unsafe bool OnTouch (global::Android.Views.View p0, global::Android.Views.MotionEvent p1)
		{
			if (id_onTouch_Landroid_view_View_Landroid_view_MotionEvent_ == IntPtr.Zero)
				id_onTouch_Landroid_view_View_Landroid_view_MotionEvent_ = JNIEnv.GetMethodID (class_ref, "onTouch", "(Landroid/view/View;Landroid/view/MotionEvent;)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);

				bool __ret;
				if (((object) this).GetType () == ThresholdType)
					__ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_onTouch_Landroid_view_View_Landroid_view_MotionEvent_, __args);
				else
					__ret = JNIEnv.CallNonvirtualBooleanMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onTouch", "(Landroid/view/View;Landroid/view/MotionEvent;)Z"), __args);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_refresh;
#pragma warning disable 0169
		static Delegate GetRefreshHandler ()
		{
			if (cb_refresh == null)
				cb_refresh = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Refresh);
			return cb_refresh;
		}

		static void n_Refresh (IntPtr jnienv, IntPtr native__this)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Refresh ();
		}
#pragma warning restore 0169

		static IntPtr id_refresh;
		// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='refresh' and count(parameter)=0]"
		[Register ("refresh", "()V", "GetRefreshHandler")]
		public virtual unsafe void Refresh ()
		{
			if (id_refresh == IntPtr.Zero)
				id_refresh = JNIEnv.GetMethodID (class_ref, "refresh", "()V");
			try {

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_refresh);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "refresh", "()V"));
			} finally {
			}
		}

		static Delegate cb_setFButtonPadding_IIII;
#pragma warning disable 0169
		static Delegate GetSetFButtonPadding_IIIIHandler ()
		{
			if (cb_setFButtonPadding_IIII == null)
				cb_setFButtonPadding_IIII = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, int, int, int>) n_SetFButtonPadding_IIII);
			return cb_setFButtonPadding_IIII;
		}

		static void n_SetFButtonPadding_IIII (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2, int p3)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetFButtonPadding (p0, p1, p2, p3);
		}
#pragma warning restore 0169

		static IntPtr id_setFButtonPadding_IIII;
		// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='setFButtonPadding' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='int']]"
		[Register ("setFButtonPadding", "(IIII)V", "GetSetFButtonPadding_IIIIHandler")]
		public virtual unsafe void SetFButtonPadding (int p0, int p1, int p2, int p3)
		{
			if (id_setFButtonPadding_IIII == IntPtr.Zero)
				id_setFButtonPadding_IIII = JNIEnv.GetMethodID (class_ref, "setFButtonPadding", "(IIII)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setFButtonPadding_IIII, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setFButtonPadding", "(IIII)V"), __args);
			} finally {
			}
		}

		static Delegate cb_setShadowColor_I;
#pragma warning disable 0169
		static Delegate GetSetShadowColor_IHandler ()
		{
			if (cb_setShadowColor_I == null)
				cb_setShadowColor_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_SetShadowColor_I);
			return cb_setShadowColor_I;
		}

		static void n_SetShadowColor_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::Info.Hoang8f.Widget.FButton __this = global::Java.Lang.Object.GetObject<global::Info.Hoang8f.Widget.FButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetShadowColor (p0);
		}
#pragma warning restore 0169

		static IntPtr id_setShadowColor_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='info.hoang8f.widget']/class[@name='FButton']/method[@name='setShadowColor' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setShadowColor", "(I)V", "GetSetShadowColor_IHandler")]
		public virtual unsafe void SetShadowColor (int p0)
		{
			if (id_setShadowColor_I == IntPtr.Zero)
				id_setShadowColor_I = JNIEnv.GetMethodID (class_ref, "setShadowColor", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (((object) this).GetType () == ThresholdType)
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShadowColor_I, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShadowColor", "(I)V"), __args);
			} finally {
			}
		}

	}
}
