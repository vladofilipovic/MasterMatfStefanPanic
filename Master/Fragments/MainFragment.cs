using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Transitionseverywhere;
using Info.Hoang8f.Widget;
using Java.Util;
using Master.Database;

namespace Master.Fragments
{
    public class MainFragment : Fragment
    {
        View rootView;

        FButton play, latinica, cirilica, settings, records, quit;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            FButton fb = new FButton(Activity);

            rootView = inflater.Inflate(Resource.Layout.main_fragment, container, false);

            play = rootView.FindViewById<FButton>(Resource.Id.play);
            latinica = rootView.FindViewById<FButton>(Resource.Id.latinica);
            cirilica = rootView.FindViewById<FButton>(Resource.Id.cirilica);
            settings = rootView.FindViewById<FButton>(Resource.Id.settings);
            records = rootView.FindViewById<FButton>(Resource.Id.records);
            quit = rootView.FindViewById<FButton>(Resource.Id.quit);

            //Typeface typeface = Activity.Resources.GetFont(Resource.Font.alegreya_font_family);
            //settings.Typeface = typeface;
            //records.Typeface = typeface;

            cirilica.Click += delegate
            {
                App.preferences.language = LangEnum.Cirilica;
                App.Current.WriteSharedPreferences();

                Java.Util.Locale.Default = new Locale("sr", "RS");
                Resources.Configuration.Locale = Java.Util.Locale.Default;
                Resources.UpdateConfiguration(Resources.Configuration, Resources.DisplayMetrics);

                ChangeLanguage();
                play.Text = GetString(Resource.String.igraj);
                this.Activity.Title = GetString(Resource.String.app_name);
            };

            latinica.Click += delegate
             {
                 App.preferences.language = LangEnum.Latinica;
                 App.Current.WriteSharedPreferences();
                 Java.Util.Locale.Default = App.default_locale;
                 Resources.Configuration.Locale = Java.Util.Locale.Default;
                 Resources.UpdateConfiguration(Resources.Configuration, Resources.DisplayMetrics);

                 ChangeLanguage();
                 play.Text = GetString(Resource.String.igraj);
                 this.Activity.Title = GetString(Resource.String.app_name);
             };

            play.Click += delegate
            {
                PlayFragment pf = new PlayFragment();
                Activity.FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, pf, "play_fragment").AddToBackStack(null).Commit();
                App.CurrentFragment = pf;
            };

            settings.Click += delegate
            {
                Intent intent = new Intent(Activity, typeof(SettingsActivity));
                StartActivity(intent);
            };

            records.Click += delegate
            {
                RecordFragment rf = new RecordFragment();
                Activity.FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, rf, "record_fragment").AddToBackStack(null).Commit();
                App.CurrentFragment = rf;

                //var rec = App.db.GetAllRecords().Where(t => t.GameId == "m1").ToList();
                //Toast.MakeText(Activity, rec.ToString(), ToastLength.Long).Show();
            };


            quit.Click += delegate
            {
                Activity.FinishAffinity();
            };

            return rootView;
        }

        private void ChangeLanguage()
        {
            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));
            play.Text = GetString(Resource.String.igraj);
            this.Activity.Title = GetString(Resource.String.app_name);
            settings.Text = GetString(Resource.String.podesavanja);
            records.Text = GetString(Resource.String.rekordi);
            quit.Text = GetString(Resource.String.quit);
        }

        public override void OnResume()
        {
            base.OnResume();
            this.Activity.Title = GetString(Resource.String.app_name);
        }
    }
}