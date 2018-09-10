
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Master
{
	public class PlaySettingsFragment : Android.Support.V4.App.Fragment
	{
		Spinner oduzimanjeSpinner, sabiranjeSpinner, deljenjeSpinner, mnozenjeSpinner;
		ArrayAdapter adapter;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var rootView = inflater.Inflate(Resource.Layout.play_settings_fragment, container, false);

			sabiranjeSpinner = rootView.FindViewById<Spinner>(Resource.Id.sabiranjeSpinner);
			oduzimanjeSpinner = rootView.FindViewById<Spinner>(Resource.Id.oduzimanjeSpinner);
			mnozenjeSpinner = rootView.FindViewById<Spinner>(Resource.Id.mnozenjeSpinner);
			deljenjeSpinner = rootView.FindViewById<Spinner>(Resource.Id.deljenjeSpinner);

			adapter = ArrayAdapter.CreateFromResource(Activity, Resource.Array.numbers_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sabiranjeSpinner.Adapter = adapter;
			oduzimanjeSpinner.Adapter = adapter;
			deljenjeSpinner.Adapter = adapter;
			mnozenjeSpinner.Adapter = adapter;

			sabiranjeSpinner.SetSelection(adapter.GetPosition(App.preferences.sabiranje.ToString()));
			oduzimanjeSpinner.SetSelection(adapter.GetPosition(App.preferences.oduzimanje.ToString()));
			mnozenjeSpinner.SetSelection(adapter.GetPosition(App.preferences.mnozenje.ToString()));
			deljenjeSpinner.SetSelection(adapter.GetPosition(App.preferences.deljenje.ToString()));

			sabiranjeSpinner.ItemSelected += SabiranjeSpinner_ItemSelected;
			oduzimanjeSpinner.ItemSelected += OduzimanjeSpinner_ItemSelected;
			mnozenjeSpinner.ItemSelected += MnozenjeSpinner_ItemSelected;
			deljenjeSpinner.ItemSelected += DeljenjeSpinner_ItemSelected;

			return rootView;
		}


		void SabiranjeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			App.preferences.sabiranje = Int32.Parse(sabiranjeSpinner.SelectedItem.ToString());
		}

		void OduzimanjeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			App.preferences.oduzimanje = Int32.Parse(oduzimanjeSpinner.SelectedItem.ToString());
		}

		void MnozenjeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			App.preferences.mnozenje = Int32.Parse(mnozenjeSpinner.SelectedItem.ToString());
		}

		void DeljenjeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			App.preferences.deljenje = Int32.Parse(deljenjeSpinner.SelectedItem.ToString());
		}
	}
}
