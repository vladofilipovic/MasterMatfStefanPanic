using Android.App;
using Android.Widget;
using Android.OS;
using Master.Fragments;
using Master.Database;


namespace Master
{
    [Activity(Label = "Master", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        bool doubleBackToExitPressedOnce = false;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            App.db = new CDatabase();
            App.db.CreateDatabase();

            Title = Resources.GetString(Resource.String.app_name);

            SetContentView(Resource.Layout.Main);

            App.fragmentContainer = FindViewById<LinearLayout>(Resource.Id.container);

            if (App.CurrentFragment != null)
            {
                FragmentManager.BeginTransaction().Add(App.fragmentContainer.Id, App.CurrentFragment, "").Commit();
            }
            else
            {
                MainFragment mf = new MainFragment();
                FragmentManager.BeginTransaction().Add(App.fragmentContainer.Id, mf, "main_fragment").Commit();
                App.CurrentFragment = mf;
            }
        }

        public override void OnBackPressed()
        {

            if (App.CurrentFragment is MainFragment)
            {
                //if (doubleBackToExitPressedOnce)
                //{
                //    FinishAffinity();
                //    return;
                //}

                //this.doubleBackToExitPressedOnce = true;
                //Toast.MakeText(this, "Jos jednom za izlaz!", ToastLength.Short).Show();

                //new Handler().PostDelayed(() =>
                //{
                //    doubleBackToExitPressedOnce = false;
                //}, 2000);
            }
            else if (App.CurrentFragment is MathFragment || App.CurrentFragment is MathWithAnswersFragment || App.CurrentFragment is ReadingAndWritingFragment)
            {
                //FragmentManager.PopBackStack();
                PlayFragment pf = new PlayFragment();
                FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, pf, "play").Commit();
                App.CurrentFragment = pf;

                //MainFragment mf = new MainFragment();
                //FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, mf, "main_fragment").Commit();
                //App.CurrentFragment = mf;
            }
            else if (App.CurrentFragment is GuessingImageFragment)
            {
                ReadingAndWritingFragment rawf = new ReadingAndWritingFragment();
                FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, rawf, "reading_and_writing").AddToBackStack(null).Commit();
                App.CurrentFragment = rawf;
            }
            else if(App.CurrentFragment is PlayFragment || App.CurrentFragment is RecordFragment)
            {
                MainFragment mf = new MainFragment();
                FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, mf, "main_fragment").Commit();
                App.CurrentFragment = mf;
            }
        }
    }
}

