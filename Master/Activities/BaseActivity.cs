
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace Master
{
	[Activity(Label = "BaseActivity")]
	public class BaseActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if (App.preferences.language == LangEnum.Cirilica)
			{
				Java.Util.Locale.Default = new Locale("sr", "RS");
				Resources.Configuration.Locale = Java.Util.Locale.Default;
				Resources.UpdateConfiguration(Resources.Configuration, Resources.DisplayMetrics);
			}
			else
			{
				Java.Util.Locale.Default = App.default_locale;
				Resources.Configuration.Locale = Java.Util.Locale.Default;
				Resources.UpdateConfiguration(Resources.Configuration, Resources.DisplayMetrics);
			}
			// Create your application here
		}
	}
}
