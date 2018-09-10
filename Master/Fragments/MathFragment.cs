using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using Info.Hoang8f.Widget;
using Master.Database;
using Com.Transitionseverywhere;
using Android.Views.Animations;
using Android.Graphics.Drawables;
using Android.Animation;
using static Android.Animation.ValueAnimator;
using Android.Support.V7.App;

namespace Master.Fragments
{
    public class MathFragment : Fragment
    {
        FButton number1Btn, number2Btn, number3Btn, number4Btn, number5Btn, number6Btn, number7Btn, number8Btn, number9Btn, number0Btn, delete, start;
        TextView number1TW, number2TW, vreme, redniBrojZadatka, operacijaTW, tacnihOdgovoraTW;
        TextView brojTacnihNaKraju, vremeNaKraju, solutionTW;
        FButton igrajPonovo, izlaz;
        FrameLayout rootView;
        Operacije operacija;
        int maxValue, number1, number2, correctAnswer;
        int numberOfCorrectAnswers = 0;
        int question = 1;
        int vremeResavanja = 0;
        Random rand;
        LinearLayout startLayout, igrajPonovoLayout;
        Timer timer;
        CRecord record;
        public LinearLayout questionLayout;

        public MathFragment(Operacije pOperacija)
        {
            this.operacija = pOperacija;
        }

        public MathFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (savedInstanceState != null)
            {
                operacija = (Operacije)savedInstanceState.GetInt("operacija", 0);
            }

            Activity.RequestedOrientation = ScreenOrientation.Locked;

            (Activity as AppCompatActivity).SupportActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Color.fbutton_color_green_sea));

            Window window = Activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            
            window.SetStatusBarColor(Activity.Resources.GetColor(Resource.Color.fbutton_color_green_sea_dark));

            Activity.Title = GetString(Resource.String.matematika);
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("operacija", (int)operacija);
            base.OnSaveInstanceState(outState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = (FrameLayout)inflater.Inflate(Resource.Layout.math_fragment, container, false);
            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            igrajPonovo = rootView.FindViewById<FButton>(Resource.Id.igrajPonovo);

            izlaz = rootView.FindViewById<FButton>(Resource.Id.izlaz);
            number1Btn = rootView.FindViewById<FButton>(Resource.Id.number1);
            number2Btn = rootView.FindViewById<FButton>(Resource.Id.number2);
            number3Btn = rootView.FindViewById<FButton>(Resource.Id.number3);
            number4Btn = rootView.FindViewById<FButton>(Resource.Id.number4);
            number5Btn = rootView.FindViewById<FButton>(Resource.Id.number5);
            number6Btn = rootView.FindViewById<FButton>(Resource.Id.number6);
            number7Btn = rootView.FindViewById<FButton>(Resource.Id.number7);
            number8Btn = rootView.FindViewById<FButton>(Resource.Id.number8);
            number9Btn = rootView.FindViewById<FButton>(Resource.Id.number9);
            number0Btn = rootView.FindViewById<FButton>(Resource.Id.number0);
            delete = rootView.FindViewById<FButton>(Resource.Id.delete);
            start = rootView.FindViewById<FButton>(Resource.Id.start);
            startLayout = rootView.FindViewById<LinearLayout>(Resource.Id.startLayout);

            number1TW = rootView.FindViewById<TextView>(Resource.Id.number1TW);
            number2TW = rootView.FindViewById<TextView>(Resource.Id.number2TW);
            solutionTW = rootView.FindViewById<TextView>(Resource.Id.solutionTW);
            vreme = rootView.FindViewById<TextView>(Resource.Id.vreme);
            redniBrojZadatka = rootView.FindViewById<TextView>(Resource.Id.redniBrojZadatka);
            operacijaTW = rootView.FindViewById<TextView>(Resource.Id.operacija);
            tacnihOdgovoraTW = rootView.FindViewById<TextView>(Resource.Id.tacnihOdgovora);
            brojTacnihNaKraju = rootView.FindViewById<TextView>(Resource.Id.brojTacnihNaKraju);
            vremeNaKraju = rootView.FindViewById<TextView>(Resource.Id.vremeNaKraju);
            igrajPonovoLayout = rootView.FindViewById<LinearLayout>(Resource.Id.igrajPonovoLayout);
            questionLayout = rootView.FindViewById<LinearLayout>(Resource.Id.questionLayout);

            Init();

            start.Click += delegate
            {
                Start();
            };

            izlaz.Click += delegate
            {
                //Activity.FragmentManager.PopBackStack();
                PlayFragment pf = new PlayFragment();
                Activity.FragmentManager.BeginTransaction().Replace(App.fragmentContainer.Id, pf, "play").Commit();
                App.CurrentFragment = pf;
            };

            igrajPonovo.Click += delegate
            {
                Start();
            };

            return rootView;
        }

        public override void OnStop()
        {
            Activity.RequestedOrientation = ScreenOrientation.Unspecified;
            base.OnStop();
        }

        public void Init()
        {
            rand = new Random();

            switch (operacija)
            {
                case Operacije.Plus:
                    {
                        operacijaTW.Text = "+";
                        maxValue = App.preferences.sabiranje;
                        break;
                    }
                case Operacije.Minus:
                    {
                        operacijaTW.Text = "-";
                        maxValue = App.preferences.oduzimanje;
                        break;
                    }
                case Operacije.Mnozenje:
                    {
                        operacijaTW.Text = "X";
                        if (App.preferences.mnozenje == 10)
                            maxValue = 10;
                        else if (App.preferences.mnozenje == 100)
                            maxValue = 10;
                        else
                            maxValue = 100;
                        break;
                    }
                case Operacije.Deljenje:
                    {
                        operacijaTW.Text = "/";
                        if (App.preferences.deljenje == 10)
                            maxValue = 10;
                        else if (App.preferences.deljenje == 100)
                            maxValue = 10;
                        else
                            maxValue = 100;
                        break;
                    }
            }

            //solutionTW.TextChanged += SolutionTextChanged;

            if (!number1Btn.HasOnClickListeners)
                number1Btn.Click += NumericButtonClick;
            if (!number2Btn.HasOnClickListeners)
                number2Btn.Click += NumericButtonClick;
            if (!number3Btn.HasOnClickListeners)
                number3Btn.Click += NumericButtonClick;
            if (!number4Btn.HasOnClickListeners)
                number4Btn.Click += NumericButtonClick;
            if (!number5Btn.HasOnClickListeners)
                number5Btn.Click += NumericButtonClick;
            if (!number6Btn.HasOnClickListeners)
                number6Btn.Click += NumericButtonClick;
            if (!number7Btn.HasOnClickListeners)
                number7Btn.Click += NumericButtonClick;
            if (!number8Btn.HasOnClickListeners)
                number8Btn.Click += NumericButtonClick;
            if (!number9Btn.HasOnClickListeners)
                number9Btn.Click += NumericButtonClick;
            if (!number0Btn.HasOnClickListeners)
                number0Btn.Click += NumericButtonClick;
            if (!delete.HasOnClickListeners)
                delete.Click += DeleteButtonClick;
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            int lenght = solutionTW.Text.Length;
            if (lenght > 0)
            {
                solutionTW.Text = solutionTW.Text.Substring(0, lenght - 1);
            }
        }

        private void NumericButtonClick(object sender, EventArgs e)
        {
            if (solutionTW.Text.Equals("_"))
            {
                solutionTW.Text = (sender as FButton).Text;
            }
            else
            {
                solutionTW.Text += (sender as FButton).Text;
            }

            string text = solutionTW.Text;
            try
            {
                int rez = Int32.Parse(text);
                if (rez == correctAnswer)
                {
                    numberOfCorrectAnswers++;

                    if (question == 10)
                    {
                        timer.Stop();
                        startLayout.Visibility = ViewStates.Visible;
                        igrajPonovoLayout.Visibility = ViewStates.Visible;
                        brojTacnihNaKraju.Text = numberOfCorrectAnswers.ToString();
                        vremeNaKraju.Text = vremeResavanja.ToString();

                        CRecord record = new CRecord();
                        record.GameId = App.MathCode + (int)operacija;
                        record.Result = 10;
                        record.Time = vremeResavanja;
                        App.db.InsertRecord(record);
                        return;
                    }

                    int colorFrom = Resources.GetColor(Resource.Color.transparent);
                    int colorTo = Resources.GetColor(Resource.Color.fbutton_color_green_sea);

                    ValueAnimator colorAnim = ObjectAnimator.OfInt(questionLayout, "backgroundColor", (int)colorFrom, (int)colorTo);
                    colorAnim.SetDuration(500);
                    colorAnim.SetEvaluator(new ArgbEvaluator());
                    colorAnim.RepeatCount = 1;
                    colorAnim.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                    colorAnim.Start();

                    //ValueAnimator anim = (ObjectAnimator)AnimatorInflater.LoadAnimator(Activity, Resource.Animator.blinking_background);
                    //anim.SetTarget(objectToFlash);

                    question++;
                    TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));
                    solutionTW.Text = "";
                    redniBrojZadatka.Text = question.ToString();
                    tacnihOdgovoraTW.Text = numberOfCorrectAnswers.ToString();
                    SetValues();
                }
            }
            catch (Exception exc)
            {

            }
        }

        public void SetValues()
        {
            switch (operacija)
            {
                case Operacije.Plus:
                    {
                        number1 = rand.Next(maxValue);
                        number2 = rand.Next(maxValue - number1);

                        correctAnswer = number1 + number2;
                        break;
                    }
                case Operacije.Minus:
                    {
                        number1 = rand.Next(maxValue);
                        number2 = rand.Next(number1);

                        correctAnswer = number1 - number2;
                        break;
                    }
                case Operacije.Mnozenje:
                    {
                        number1 = rand.Next(maxValue);
                        number2 = rand.Next(maxValue);

                        while (number1 * number2 > App.preferences.mnozenje)
                        {
                            number2 = rand.Next(maxValue);
                        }

                        correctAnswer = number1 * number2;
                        break;
                    }
                case Operacije.Deljenje:
                    {
                        number1 = rand.Next(maxValue);
                        number2 = rand.Next(1, maxValue);

                        while (number1 * number2 > App.preferences.deljenje)
                        {
                            number2 = rand.Next(maxValue);
                        }

                        correctAnswer = number1;
                        number1 = number1 * number2;
                        break;
                    }
            }

            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));
            number1TW.Text = number1.ToString();
            number2TW.Text = number2.ToString();


        }

        private void Start()
        {
            solutionTW.Text = "_";
            vremeResavanja = 0;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += (s, e) =>
            {
                vremeResavanja++;
                this.Activity.RunOnUiThread(() =>
                {
                    vreme.Text = vremeResavanja.ToString();
                }
                    );
            };
            timer.Enabled = true;

            numberOfCorrectAnswers = 0;
            question = 1;
            startLayout.Visibility = ViewStates.Gone;
            redniBrojZadatka.Text = question.ToString();
            tacnihOdgovoraTW.Text = numberOfCorrectAnswers.ToString();

            SetValues();
            start.Visibility = ViewStates.Gone;
        }
    }
}