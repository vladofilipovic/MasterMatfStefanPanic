using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Info.Hoang8f.Widget;
using Master.Database;
using Com.Transitionseverywhere;

using Android.Support.V4.View.Animation;
using Android.Animation;
using Android.Support.V7.App;
using Android.Content.PM;

namespace Master.Fragments
{
    public class MathWithAnswersFragment : Fragment
    {
        FButton answer1, answer2, answer3, answer4, start;
        TextView number1TW, number2TW, vreme, redniBrojZadatka, operacijaTW, tacnihOdgovoraTW;
        TextView brojTacnihNaKraju, vremeNaKraju;
        FButton igrajPonovo, izlaz;
        FrameLayout rootView;
        Operacije operacija;
        int maxValue, number1, number2, correctAnswer;
        int numberOfCorrectAnswers = 0;
        int question = 1;
        int vremeResavanja = 0;
        Random rand;
        LinearLayout startLayout, igrajPonovoLayout, questionLayout;
        Timer timer;
        CRecord record;

        public MathWithAnswersFragment(Operacije pOperacija)
        {
            this.operacija = pOperacija;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            (Activity as AppCompatActivity).SupportActionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Color.fbutton_color_pumpkin));

            Window window = Activity.Window;

            Activity.RequestedOrientation = ScreenOrientation.Locked;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            window.SetStatusBarColor(Activity.Resources.GetColor(Resource.Color.fbutton_color_pumpkin_dark));

            Activity.Title = GetString(Resource.String.matematika_sa_odgovorima);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = (FrameLayout)inflater.Inflate(Resource.Layout.math_with_answers_fragment, container, false);
            answer1 = rootView.FindViewById<FButton>(Resource.Id.answer1);
            answer2 = rootView.FindViewById<FButton>(Resource.Id.answer2);
            answer3 = rootView.FindViewById<FButton>(Resource.Id.answer3);
            answer4 = rootView.FindViewById<FButton>(Resource.Id.answer4);
            igrajPonovo = rootView.FindViewById<FButton>(Resource.Id.igrajPonovo);
            izlaz = rootView.FindViewById<FButton>(Resource.Id.izlaz);

            start = rootView.FindViewById<FButton>(Resource.Id.start);
            startLayout = rootView.FindViewById<LinearLayout>(Resource.Id.startLayout);

            number1TW = rootView.FindViewById<TextView>(Resource.Id.number1);
            number2TW = rootView.FindViewById<TextView>(Resource.Id.number2);
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

            if (!answer1.HasOnClickListeners)
                answer1.Click += Answer_Click;
            if (!answer2.HasOnClickListeners)
                answer2.Click += Answer_Click;
            if (!answer3.HasOnClickListeners)
                answer3.Click += Answer_Click;
            if (!answer4.HasOnClickListeners)
                answer4.Click += Answer_Click;
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

            number1TW.Text = number1.ToString();
            number2TW.Text = number2.ToString();

            int j = rand.Next(1, 4);
            String idCorrect = "answer" + j;
            int btnIdCorrect = Resources.GetIdentifier(idCorrect, "id", Activity.PackageName);
            FButton btnCorrect = rootView.FindViewById<FButton>(btnIdCorrect);
            //TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
            //          new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));
            btnCorrect.Text = correctAnswer.ToString();

            for (int i = 1; i <= 4; i++)
            {
                if (!i.Equals(j))
                {
                    String id = "answer" + i;
                    int btnID = Resources.GetIdentifier(id, "id", Activity.PackageName);
                    FButton btn = rootView.FindViewById<FButton>(btnID);
                    int fakeAnswer = GenerateFakeAnswer();
                    //TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                    //  new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));
                    btn.Text = fakeAnswer.ToString();
                }
            }
        }

        int GenerateFakeAnswer()
        {
            int rez = 0;
            switch (operacija)
            {
                case Operacije.Plus:
                    {
                        int offset = 5;
                        if (App.preferences.sabiranje == 100)
                        {
                            offset = 15;
                        }
                        else
                        {
                            offset = correctAnswer / 10;
                        }
                        if (offset == 0)
                        {
                            offset = 5;
                        }
                        do
                        {
                            rez = rand.Next(correctAnswer - offset, correctAnswer + offset);
                        } while (rez < 0 || rez > App.preferences.sabiranje || rez == correctAnswer);
                        break;
                    }
                case Operacije.Minus:
                    {
                        int offset = 5;
                        if (App.preferences.oduzimanje == 100)
                        {
                            offset = 15;
                        }
                        else
                        {
                            offset = correctAnswer / 10;
                        }
                        if (offset == 0)
                        {
                            offset = 5;
                        }
                        do
                        {
                            rez = rand.Next(correctAnswer - offset, correctAnswer + offset);
                        } while (rez < 0 || rez > App.preferences.oduzimanje || rez == correctAnswer);
                        break;
                    }
                case Operacije.Mnozenje:
                    {
                        int offset = 5;
                        if (App.preferences.oduzimanje == 100)
                        {
                            offset = 15;
                        }
                        else
                        {
                            offset = correctAnswer / 10;
                        }
                        if (offset == 0)
                        {
                            offset = 5;
                        }
                        do
                        {
                            rez = rand.Next(correctAnswer - offset, correctAnswer + offset);
                        } while (rez < 0 || rez > App.preferences.mnozenje || rez == correctAnswer);
                        break;
                    }
                case Operacije.Deljenje:
                    {
                        int offset = 5;
                        do
                        {
                            rez = rand.Next(correctAnswer - offset, correctAnswer + offset);
                        } while (rez < 0 || rez > App.preferences.deljenje || rez == correctAnswer);
                        break;
                    }
            }
            return rez;
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            TransitionManager.BeginDelayedTransition((ViewGroup)rootView,
                      new ChangeText().SetChangeBehavior(ChangeText.ChangeBehaviorOutIn));

            FButton btn = sender as FButton;
            if (btn.Text.Equals(correctAnswer.ToString()))
            {
                numberOfCorrectAnswers++;

                int colorFrom = Resources.GetColor(Resource.Color.transparent);
                int colorTo = Resources.GetColor(Resource.Color.fbutton_color_green_sea);

                ValueAnimator colorAnim = ObjectAnimator.OfInt(questionLayout, "backgroundColor", (int)colorFrom, (int)colorTo);
                colorAnim.SetDuration(500);
                colorAnim.SetEvaluator(new ArgbEvaluator());
                colorAnim.RepeatCount = 1;
                colorAnim.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                colorAnim.Start();
            }
            else
            {
                int colorFrom = Resources.GetColor(Resource.Color.transparent);
                int colorTo = Resources.GetColor(Android.Resource.Color.HoloRedDark);

                ValueAnimator colorAnim = ObjectAnimator.OfInt(questionLayout, "backgroundColor", (int)colorFrom, (int)colorTo);
                colorAnim.SetDuration(500);
                colorAnim.SetEvaluator(new ArgbEvaluator());
                colorAnim.RepeatCount = 1;
                colorAnim.RepeatMode = ValueAnimatorRepeatMode.Reverse;
                colorAnim.Start();
            }

            if (question == 10)
            {
                timer.Stop();
                
                startLayout.Visibility = ViewStates.Visible;
                igrajPonovoLayout.Visibility = ViewStates.Visible;
                brojTacnihNaKraju.Text = numberOfCorrectAnswers.ToString();
                vremeNaKraju.Text = vremeResavanja.ToString();

                CRecord record = new CRecord();
                record.GameId = App.MathWithAnswersCode + (int)operacija;
                record.Result = numberOfCorrectAnswers;
                record.Time = vremeResavanja;
                App.db.InsertRecord(record);
                return;
            }

            SetValues();
            question++;

            redniBrojZadatka.Text = question.ToString();
            tacnihOdgovoraTW.Text = numberOfCorrectAnswers.ToString();
        }

        private void Start()
        {
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
            
            redniBrojZadatka.Text = question.ToString();
            tacnihOdgovoraTW.Text = numberOfCorrectAnswers.ToString();

            SetValues();
            start.Visibility = ViewStates.Gone;
            startLayout.Visibility = ViewStates.Gone;
        }

        public override void OnStop()
        {
            Activity.RequestedOrientation = ScreenOrientation.Unspecified;
            base.OnStop();
        }
    }
}