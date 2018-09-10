using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Transitionseverywhere;
using Info.Hoang8f.Widget;
using Master.Database;

namespace Master.Fragments
{
    public class GuessingImageFragment : Fragment
    {
        LinearLayout rootView, keyboardContainer;
        List<FButton> keyboardButtons = new List<FButton>(31);
        FButton clearAll, delete;
        TextView solution;
        CImage image;
        ImageView slika;
        string subSolution, correctSolution;
        int correctSolutionLenght;

        public GuessingImageFragment(int imageID)
        {
            image = App.db.GetImageByID(imageID);
        }

        public override void OnStop()
        {
            App.CurrentImagePossition = image.Id;
            Activity.RequestedOrientation = ScreenOrientation.Unspecified;
            base.OnStop();
        }

        public override void OnDestroy()
        {
            App.CurrentImagePossition = image.Id;

            Activity.RequestedOrientation = ScreenOrientation.Unspecified;

            base.OnDestroy();
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SharedElementEnterTransition = (Android.Transitions.TransitionInflater.From(Activity).InflateTransition(Android.Resource.Transition.Move));

            (Activity as AppCompatActivity).SupportActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Color.fbutton_color_wisteria));

            Window window = Activity.Window;

            Activity.RequestedOrientation = ScreenOrientation.Locked;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            window.SetStatusBarColor(Activity.Resources.GetColor(Resource.Color.fbutton_color_wisteria_dark));

            Activity.Title = GetString(Resource.String.citanje_i_pisanje);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = (LinearLayout)inflater.Inflate(Resource.Layout.guessing_image_fragment, container, false);
            keyboardContainer = rootView.FindViewById<LinearLayout>(Resource.Id.keyboardContainer);
            solution = rootView.FindViewById<TextView>(Resource.Id.solution);
            clearAll = rootView.FindViewById<FButton>(Resource.Id.clearAll);
            delete = rootView.FindViewById<FButton>(Resource.Id.delete);
            slika = rootView.FindViewById<ImageView>(Resource.Id.image);
            slika.TransitionName = image.Name;

            if (!clearAll.HasOnClickListeners)
            {
                clearAll.Click += ClearAllClick;
            }

            if (!delete.HasOnClickListeners)
            {
                delete.Click += DeleteClick;
            }

            InitFields();
            InitateKeyboard();

            return rootView;
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (subSolution.Length == 0)
            {
                return;
            }
            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            subSolution = subSolution.Substring(0, subSolution.Length - 1);
            solution.Text = subSolution;

            for (int i = solution.Text.Length; i < correctSolutionLenght; i++)
            {
                solution.Text += " _";
            }

        }

        private void ClearAllClick(object sender, EventArgs e)
        {
            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            subSolution = "";
            solution.Text = subSolution;

            for (int i = solution.Text.Length; i < correctSolutionLenght; i++)
            {
                solution.Text += " _";
            }
        }

        private void InitateKeyboard()
        {
            for (int i = 1; i <= 30; i++)
            {
                FButton btn = keyboardContainer.FindViewById<FButton>(Activity.Resources.GetIdentifier("letter" + i.ToString(), "id", Activity.PackageName));
                if (App.preferences.language == LangEnum.Latinica)
                {
                    btn.Text = App.Abeceda[i - 1];

                }
                else
                {
                    btn.Text = App.Azbuka[i - 1];
                }

                keyboardButtons.Add(btn);

                btn.Click += KeyboardClick;
            }
        }

        private void KeyboardClick(object sender, EventArgs e)
        {
            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            if (subSolution.Length == correctSolutionLenght)
            {
                return;
            }

            subSolution += (sender as FButton).Text.ToUpper(); ;
            solution.Text = subSolution;


            var solutionLower = subSolution.ToLower();
            if (subSolution.Length == correctSolutionLenght)
            {
                bool correct = true;
                for (int i = 0; i < correctSolutionLenght; i++)
                {
                    var ch1 = solutionLower[i];
                    var ch2 = correctSolution[i];
                    if(solutionLower[i] != correctSolution[i])
                    {
                        correct = false;
                    }
                    if(correctSolution[i] == 'а')
                    {
                        if(solutionLower[i] == 'а')
                        {
                            correct = true;
                        }
                    }
                }

                if(correct)
                {
                    if (App.preferences.language == LangEnum.Latinica)
                    {
                        image.SolvedLatin = true;
                    }
                    else
                    {
                        image.SolvedCyrilic = true;
                    }

                    App.db.UpdateImage(image);

                    int newID = image.Id + 1;

                    image = App.db.GetImageByID(newID);
                    if(image != null)
                        ResetFields();
                }
            }

            for (int i = solution.Text.Length; i < correctSolutionLenght; i++)
            {
                solution.Text += " _";
            }
        }

        public void InitFields()
        {
            correctSolution = (App.preferences.language == LangEnum.Latinica) ? image.SolutionLatin : image.SolutionCyrilic;

            correctSolutionLenght = correctSolution.Length;
            subSolution = "";

            solution.Text = "";

            slika.SetImageResource(Activity.Resources.GetIdentifier(image.Name, "drawable", Activity.PackageName));

            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            for (int i = solution.Text.Length; i < correctSolutionLenght; i++)
            {
                solution.Text += " _";
            }
        }

        private void ResetFields()
        {
            correctSolution = (App.preferences.language == LangEnum.Latinica) ? image.SolutionLatin : image.SolutionCyrilic;

            correctSolutionLenght = correctSolution.Length;
            subSolution = "";

            solution.Text = "";

            ImageViewAnimatedChange(Activity, slika, image.Name);

            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            for (int i = solution.Text.Length; i < correctSolutionLenght; i++)
            {
                solution.Text += " _";
            }
        }

        public void ImageViewAnimatedChange(Context c, ImageView v, string ImageName)
        {
            Animation anim_out = AnimationUtils.LoadAnimation(c, Android.Resource.Animation.FadeOut);
            Animation anim_in = AnimationUtils.LoadAnimation(c, Android.Resource.Animation.FadeIn);

            anim_out.AnimationEnd += delegate
            {
                v.SetImageResource(Activity.Resources.GetIdentifier(ImageName, "drawable", Activity.PackageName));
                v.StartAnimation(anim_in);
            };
            v.StartAnimation(anim_out);
        }
    }
}