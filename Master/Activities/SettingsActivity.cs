
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Master
{
    [Activity(Label = "SettingsActivity")]
	public class SettingsActivity : BaseActivity
    {
		ViewPager pager;
		TabLayout tabLayout;
		SettingsPagerAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.settings_activity);

            Title = Resources.GetString(Resource.String.settings_activity_title);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

			pager = FindViewById<ViewPager>(Resource.Id.viewPager);
			tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
			adapter = new SettingsPagerAdapter(this, SupportFragmentManager);

			pager.Adapter = adapter;
			tabLayout.SetupWithViewPager(pager);
            SetupTabIcons();
        }

		private void SetupTabIcons()
		{
			if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Portrait)
			{
				tabLayout.GetTabAt(0).SetIcon(GetDrawable(Resource.Drawable.ic_play_w));
				tabLayout.GetTabAt(1).SetIcon(GetDrawable(Resource.Drawable.ic_sound_w));
				tabLayout.GetTabAt(2).SetIcon(GetDrawable(Resource.Drawable.ic_settings_w));
			}

			tabLayout.GetTabAt(0).SetText(GetString(Resource.String.igra));
			tabLayout.GetTabAt(1).SetText(GetString(Resource.String.zvuk));
			tabLayout.GetTabAt(2).SetText(GetString(Resource.String.ostalo));
		}

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Finish();
			App.Current.WriteSharedPreferences();
            return base.OnOptionsItemSelected(item);
        }
    }
}
