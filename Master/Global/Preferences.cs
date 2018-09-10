using System;
namespace Master
{
	public enum LangEnum
	{
		Cirilica = 0,
		Latinica = 1	}

    public enum Operacije
    {
        Plus = 0,
        Minus = 1,
        Mnozenje = 2,
        Deljenje = 3
    }

    public class Preferences
	{
		public Preferences()
		{
		}

		public bool sound { get; set; }
		public bool vibration { get; set; }
		public int sound_volume { get; set; }
		public int sabiranje { get; set; } = 100;
		public int oduzimanje { get; set; } = 100;
		public int deljenje { get; set; } = 100;
		public int mnozenje { get; set; } = 100;
		public LangEnum language { get; set; } = LangEnum.Latinica;
	}
}
