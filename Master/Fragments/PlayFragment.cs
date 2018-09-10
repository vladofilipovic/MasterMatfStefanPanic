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
using Info.Hoang8f.Widget;

namespace Master.Fragments
{
    public class PlayFragment : Fragment
    {
        View rootView;
        FButton citanjePisanje, izborOperacijeSaOdgovorima, matematikaSaOdgovorima, izborOperacije, matematika;
        List<string> operacije = new List<string>();
        Operacije operacijaSaOdgovorima;
        Operacije operacija;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            operacije.Add("+   (" + GetString(Resource.String.sabiranje).ToLower() + ")");
            operacije.Add("-   (" + GetString(Resource.String.oduzimanje).ToLower() + ")");
            operacije.Add("x   (" + GetString(Resource.String.mnozenje).ToLower() + ")");
            operacije.Add("/   (" + GetString(Resource.String.deljenje).ToLower() + ")");

            (Activity as Android.Support.V7.App.AppCompatActivity).SupportActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Color.colorPrimary));

            Window window = Activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            window.SetStatusBarColor(Activity.Resources.GetColor(Resource.Color.colorPrimaryDark));
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = inflater.Inflate(Resource.Layout.play_fragment, container, false);
            citanjePisanje = rootView.FindViewById<FButton>(Resource.Id.pisanje);
            izborOperacijeSaOdgovorima = rootView.FindViewById<FButton>(Resource.Id.izborOperacijeSaOdgovorima);
            izborOperacije = rootView.FindViewById<FButton>(Resource.Id.izborOperacije);
            matematikaSaOdgovorima = rootView.FindViewById<FButton>(Resource.Id.matematikaSaOdgovorima);
            matematika = rootView.FindViewById<FButton>(Resource.Id.matematika);

            citanjePisanje.Click += delegate
            {
                ReadingAndWritingFragment rawf = new ReadingAndWritingFragment();
                Activity.FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, rawf, "reading_and_writing").AddToBackStack(null).Commit();
                App.CurrentFragment = rawf;
            };

            izborOperacijeSaOdgovorima.Click += delegate
            {
                var builder = new AlertDialog.Builder(Activity);
                builder.SetTitle(GetString(Resource.String.matematicke_operacije));
                builder.SetItems(operacije.ToArray(), OnOpcijaSelectedSaOdgovorima);
                builder.Show();
            };

            izborOperacije.Click += delegate
            {
                var builder = new AlertDialog.Builder(Activity);
                builder.SetTitle(GetString(Resource.String.matematicke_operacije));
                builder.SetItems(operacije.ToArray(), OnOpcijaSelected);
                builder.Show();
            };

            matematikaSaOdgovorima.Click += delegate
            {
                MathWithAnswersFragment mwaf = new MathWithAnswersFragment(operacijaSaOdgovorima);
                Activity.FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, mwaf, "math_with_answers").AddToBackStack(null).Commit();
                App.CurrentFragment = mwaf;
            };

            matematika.Click += delegate
            {
                MathFragment mf = new MathFragment(operacija);
                Activity.FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, mf, "math").AddToBackStack(null).Commit();
                App.CurrentFragment = mf;
            };

            return rootView;
        }

        private void OnOpcijaSelectedSaOdgovorima(object sender, DialogClickEventArgs e)
        {
            operacijaSaOdgovorima = (Operacije)e.Which;
            string selected = operacije[(int)e.Which];
            izborOperacijeSaOdgovorima.Text = selected[0].ToString();

        }

        private void OnOpcijaSelected(object sender, DialogClickEventArgs e)
        {
            operacija = (Operacije)e.Which;
            string selected = operacije[(int)e.Which];
            izborOperacije.Text = selected[0].ToString();
        }

        public override void OnResume()
        {
            base.OnResume();
            this.Activity.Title = GetString(Resource.String.app_name);
        }
    }
}