
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Master
{
	[Activity(Label = "OtherSettingsFragment")]
	public class OtherSettingsFragment : Android.Support.V4.App.Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			 var rootView =  inflater.Inflate(Resource.Layout.other_settings_fragment, container, false);

			return rootView;
		}
	}
}
