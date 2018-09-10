
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
	public class SoundSettingsFragment : Android.Support.V4.App.Fragment
	{
		Switch switchButtonSound, switchButtonVibration;
		SeekBar seekBar;
		TextView volumeTW;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var rootView = inflater.Inflate(Resource.Layout.sound_settings_fragment, container, false);

			switchButtonSound = rootView.FindViewById<Switch>(Resource.Id.switchButtonSound);
			switchButtonVibration = rootView.FindViewById<Switch>(Resource.Id.switchButtonVibration);
			volumeTW = rootView.FindViewById<TextView>(Resource.Id.volume);
			seekBar = rootView.FindViewById<SeekBar>(Resource.Id.soundVolume);

			switchButtonSound.Checked = App.preferences.sound;
			seekBar.Enabled = App.preferences.sound;
			switchButtonVibration.Checked = App.preferences.vibration;

			if (App.preferences.sound)
			{
				seekBar.Progress = App.preferences.sound_volume;
				volumeTW.Text = App.preferences.sound_volume.ToString();
			}
			else
			{
				volumeTW.Text = "0";
			}

			switchButtonSound.Click += (sender, e) =>
			{
				seekBar.Enabled = switchButtonSound.Checked;
				if (switchButtonSound.Checked)
				{
					seekBar.Progress = App.preferences.sound_volume;
					volumeTW.Text = App.preferences.sound_volume.ToString();
				}
				else
				{
					volumeTW.Text = "0";
				}
				App.preferences.sound = switchButtonSound.Checked;
			};

			switchButtonVibration.Click += (sender, e) =>
			{
				App.preferences.vibration = switchButtonVibration.Checked;
			};

			seekBar.ProgressChanged += delegate
			{
				volumeTW.Text = seekBar.Progress.ToString();
				App.preferences.sound_volume = seekBar.Progress;
			};

			return rootView;
		}
	}
}
