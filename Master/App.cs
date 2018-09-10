using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using Master.Database;


// ikonica 32 - 6

namespace Master
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    public class App : Application
	{
		public static CDatabase db;
		public static Preferences preferences;
		public static App Current;
		public static Locale default_locale = Locale.Default;
        public static LinearLayout fragmentContainer;
        public static Fragment CurrentFragment;
        public static string MathCode = "m2";
        public static string MathWithAnswersCode = "m1";
        public static string[] Abeceda;
        public static int CurrentImagePossition = -1;

        public static string[] Azbuka;

        public App(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
			: base(handle, transfer)
		{
			Current = this;
			preferences = new Preferences();
            Abeceda = new string[] { "A", "B", "C", "Č","Ć", "D","Dž", "Đ","E", "F","G", "H","I", "J","K", "L",
                                                        "Lj", "M", "N", "Nj","O", "P","R", "S","Š", "T","U", "V","Z", "Ž" };

            Azbuka = new string[] { "А", "Б", "В", "Г","Д", "Ђ", "е","Ж", "З","И", "Ј","К", "Л","Љ", "М","Н", "Њ",
                                                        "О", "П", "Р", "С","Т", "Ћ","У", "Ф","Х", "Ц","Ч", "Џ","Ш"};
            ReadSharedPreferences();
		}

		public override void OnCreate()
		{
			base.OnCreate();
		}

		public void ReadSharedPreferences()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Current);

			preferences.sound = prefs.GetBoolean("sound", false);
			preferences.sound_volume = prefs.GetInt("sound_volume", 10);
			preferences.vibration = prefs.GetBoolean("vibration", false);
			preferences.sabiranje = prefs.GetInt("sabiranje", 100);
			preferences.oduzimanje = prefs.GetInt("oduzimanje", 100);
			preferences.mnozenje = prefs.GetInt("mnozenje", 100);
			preferences.deljenje = prefs.GetInt("deljenje", 100);
            var lang = prefs.GetInt("language", 0);
            preferences.language = (lang == 0) ? LangEnum.Cirilica : LangEnum.Latinica;
		}

		public void WriteSharedPreferences()
		{
			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Current);

			var editor = prefs.Edit();

			editor.PutBoolean("sound", preferences.sound);
			editor.PutBoolean("vibration", preferences.vibration);
			editor.PutInt("sound_volume", preferences.sound_volume);
			editor.PutInt("sabiranje", preferences.sabiranje);
			editor.PutInt("oduzimanje", preferences.oduzimanje);
			editor.PutInt("mnozenje", preferences.mnozenje);
			editor.PutInt("deljenje", preferences.deljenje);
            if (preferences.language == LangEnum.Cirilica)
            {
                editor.PutInt("language", 0);
            }
            else
            {
                editor.PutInt("language", 1);
            }

			editor.Commit();
		}

	}
}