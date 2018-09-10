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
using Master.Database;

namespace Master.Fragments
{
    public class RecordFragment : Fragment
    {
        View rootView;
        TableLayout mso_sabiranje, mso_oduzimanje, mso_mnozenje, mso_deljenje;
        TableLayout m_sabiranje, m_oduzimanje, m_mnozenje, m_deljenje;
        TextView latinica_ukupno, cirilica_ukupno;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Activity.Title = GetString(Resource.String.rekordi);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = inflater.Inflate(Resource.Layout.record_fragment, container, false);

            mso_sabiranje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_sa_odgovorima_sabiranje);
            mso_oduzimanje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_sa_odgovorima_oduzimanje);
            mso_mnozenje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_sa_odgovorima_mnozenje);
            mso_deljenje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_sa_odgovorima_deljenje);

            m_sabiranje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_sabiranje);
            m_oduzimanje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_oduzimanje);
            m_mnozenje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_mnozenje);
            m_deljenje = rootView.FindViewById<TableLayout>(Resource.Id.matematika_deljenje);

            latinica_ukupno = rootView.FindViewById<TextView>(Resource.Id.latinica_ukupno);
            cirilica_ukupno = rootView.FindViewById<TextView>(Resource.Id.cirilica_ukupno);

            Init();

            return rootView;
        }

        public void Init()
        {
            SetMathWithAnswersTable(Operacije.Plus, mso_sabiranje);
            SetMathWithAnswersTable(Operacije.Minus, mso_oduzimanje);
            SetMathWithAnswersTable(Operacije.Mnozenje, mso_mnozenje);
            SetMathWithAnswersTable(Operacije.Deljenje, mso_deljenje);

            SetMathTable(Operacije.Plus, m_sabiranje);
            SetMathTable(Operacije.Minus, m_oduzimanje);
            SetMathTable(Operacije.Mnozenje, m_mnozenje);
            SetMathTable(Operacije.Deljenje, m_deljenje);

            latinica_ukupno.Text = "Latinica: " + App.db.GetLatinicaTotal().ToString();
            cirilica_ukupno.Text = "Ћирилица: " + App.db.GetCirilciaTotal().ToString();
        }

        public void SetMathWithAnswersTable(Operacije pOperacija, TableLayout pTable)
        {
            List<CRecord> listOfRecords = App.db.GetTopThreeRecords(pOperacija, App.MathWithAnswersCode);

            pTable.RemoveAllViews();

            if (listOfRecords == null || listOfRecords.Count == 0)
            {
                var prazanRed = Activity.LayoutInflater.Inflate(Resource.Layout.matematika_sa_odgovorima_record_row, null);
                prazanRed.FindViewById<TextView>(Resource.Id.broj_pogodjenih).Text = GetString(Resource.String.nema_rezultata);
                pTable.AddView(prazanRed);
                return;
            }

            var zaglavlje = Activity.LayoutInflater.Inflate(Resource.Layout.matematika_sa_odgovorima_record_row, null);
            zaglavlje.FindViewById<TextView>(Resource.Id.broj_pogodjenih).Text = GetString(Resource.String.tacnih_odgovora);
            zaglavlje.FindViewById<TextView>(Resource.Id.vreme).Text = GetString(Resource.String.vreme);
            pTable.AddView(zaglavlje);

            int i = 0;
            foreach (var record in listOfRecords)
            {
                var view = Activity.LayoutInflater.Inflate(Resource.Layout.matematika_sa_odgovorima_record_row, null);
                if (i == 0)
                {
                    view.FindViewById<ImageView>(Resource.Id.star).SetImageResource(Resource.Drawable.ic_star_g);
                }
                else if (i == 1)
                {
                    view.FindViewById<ImageView>(Resource.Id.star).SetImageResource(Resource.Drawable.ic_star_s);
                }
                else if (i == 2)
                {
                    view.FindViewById<ImageView>(Resource.Id.star).SetImageResource(Resource.Drawable.ic_star_b);
                }

                view.FindViewById<TextView>(Resource.Id.broj_pogodjenih).Text = record.Result.ToString();
                view.FindViewById<TextView>(Resource.Id.vreme).Text = record.Time.ToString();

                pTable.AddView(view);
                i++;
            }

        }
        public void SetMathTable(Operacije pOperacija, TableLayout pTable)
        {
            List<CRecord> listOfRecords = App.db.GetTopThreeRecords(pOperacija, App.MathCode);

            pTable.RemoveAllViews();

            if (listOfRecords == null || listOfRecords.Count == 0)
            {
                var prazanRed = Activity.LayoutInflater.Inflate(Resource.Layout.matematika_sa_odgovorima_record_row, null);
                prazanRed.FindViewById<TextView>(Resource.Id.broj_pogodjenih).Text = GetString(Resource.String.nema_rezultata);
                pTable.AddView(prazanRed);
                return;
            }

            var zaglavlje = Activity.LayoutInflater.Inflate(Resource.Layout.matematika_sa_odgovorima_record_row, null);
            zaglavlje.FindViewById<TextView>(Resource.Id.broj_pogodjenih).Text = GetString(Resource.String.tacnih_odgovora);
            zaglavlje.FindViewById<TextView>(Resource.Id.vreme).Text = GetString(Resource.String.vreme);
            pTable.AddView(zaglavlje);

            int i = 0;
            foreach (var record in listOfRecords)
            {
                var view = Activity.LayoutInflater.Inflate(Resource.Layout.matematika_sa_odgovorima_record_row, null);
                if (i == 0)
                {
                    view.FindViewById<ImageView>(Resource.Id.star).SetImageResource(Resource.Drawable.ic_star_g);
                }
                else if (i == 1)
                {
                    view.FindViewById<ImageView>(Resource.Id.star).SetImageResource(Resource.Drawable.ic_star_s);
                }
                else if (i == 2)
                {
                    view.FindViewById<ImageView>(Resource.Id.star).SetImageResource(Resource.Drawable.ic_star_b);
                }

                view.FindViewById<TextView>(Resource.Id.broj_pogodjenih).Text = record.Result.ToString();
                view.FindViewById<TextView>(Resource.Id.vreme).Text = record.Time.ToString();

                pTable.AddView(view);
                i++;
            }

        }

    }
}