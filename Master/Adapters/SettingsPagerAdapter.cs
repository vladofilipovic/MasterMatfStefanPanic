using System;
using Android.App;
using Android.Support.V4.App;

namespace Master
{
	public class SettingsPagerAdapter : FragmentPagerAdapter
	{
		Activity activity;
		Android.Support.V4.App.FragmentManager fragmentManager;
		Android.Support.V4.App.Fragment fragmentPlay;
		Android.Support.V4.App.Fragment fragmentSound;
		Android.Support.V4.App.Fragment fragmentOther;

		public SettingsPagerAdapter(Activity activity, Android.Support.V4.App.FragmentManager fm) : base(fm)
		{
			this.activity = activity;
			this.fragmentManager = fm;
		}

		public override int Count
		{
			get { return 3; }
		}

		public override int GetItemPosition(Java.Lang.Object objectValue)
		{
			return base.GetItemPosition(objectValue);
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			if (position == 0)
			{
				fragmentPlay = new PlaySettingsFragment();
				return fragmentPlay;
			}
			else if (position == 1)
			{
				fragmentSound = new SoundSettingsFragment();
				return fragmentSound;
			}
			else
			{
				fragmentOther = new OtherSettingsFragment();
				return fragmentOther;
			}
		}

	}
}

