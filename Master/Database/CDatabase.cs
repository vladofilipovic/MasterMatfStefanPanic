using System.Collections.Generic;
using System.Linq;
using Android.Util;
using SQLite;

namespace Master.Database
{
    public class CDatabase
    {
        public string folder = GetGlobaDbFolder();
        public SQLiteConnection dbImages;
        public SQLiteConnection dbRecords;

        public static string GetGlobaDbFolder()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //path = Path.combine(path, 'pbcare.db3');
            //string appPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var appname = "Master";
            path = path + '/' + appname;

            var dir = new Java.IO.File(path);
            if (!dir.Exists())
            {
                dir.Mkdirs();
            }
            else
            {

            }

            return path;
        }

        public bool CreateDatabase()
        {
            try
            {
                var dbpathCom = System.IO.Path.Combine(folder, "Images.db");
                dbImages = new SQLiteConnection(dbpathCom, false);
                dbImages.CreateTable<CImage>();

                var dbPathScores = System.IO.Path.Combine(folder, "Records.db");
                dbRecords = new SQLiteConnection(dbPathScores, false);
                dbRecords.CreateTable<CRecord>();

                SeedDatabase();

                return true;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        void SeedDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    var tempTabela = connection.Table<CImage>().ToList();
                    if(tempTabela.Count == 0)
                    {
                        Seed();
                    }
                    
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
            }
        }

        public List<CRecord> GetAllRecords()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Records.db")))
                {
                    var tempTabela = connection.Table<CRecord>().ToList();
                    var result = (from m in tempTabela
                                  select m).Take(20);

                    //return connection.Table<CScore>().ToList();
                    return result.ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }

        }

        public int GetLatinicaTotal()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    int sum = 0;
                    var tempTabela = connection.Table<CImage>().Where(t => t.SolvedLatin == true).ToList();
                    foreach(var item in tempTabela)
                    {
                        if (item.Id < 70)
                            sum += 1;
                        else if (item.Id < 150)
                            sum += 2;
                        else
                            sum += 3;
                    }

                    return sum;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return 0;
            }

        }

        public int GetCirilciaTotal()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    int sum = 0;
                    var tempTabela = connection.Table<CImage>().Where(t => t.SolvedCyrilic == true).ToList();
                    foreach (var item in tempTabela)
                    {
                        if (item.Id < 70)
                            sum += 1;
                        else if (item.Id < 150)
                            sum += 2;
                        else
                            sum += 3;
                    }

                    return sum;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return 0;
            }

        }

        public bool InsertRecord(CRecord record)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Records.db")))
                {
                    connection.Insert(record);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public List<CImage> GetAllImages()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    var tempTabela = connection.Table<CImage>().ToList();
                    return tempTabela;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public List<CRecord> GetTopThreeRecords(Operacije pOperacija, string pGameId)
        {
            string filterGameId = pGameId + ((int)pOperacija).ToString();
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Records.db")))
                {
                    string sql = "select * from CRecord where GameId = '" + filterGameId + "' order by result desc, time";

                    var res = connection.Query<CRecord>(sql);
                    res = res.Take(3).ToList();

                    return res;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }

        }

        public CImage GetImageByID(int ID)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    string sql = "select * from CImage where id = '" + ID + "'";

                    var res = connection.Query<CImage>(sql);
                    CImage rezultat = res.FirstOrDefault();
                   
                    return rezultat;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public void UpdateImage(CImage pImage)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    connection.Update(pImage);
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
            }
        }

        public void Seed()
        {

            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Images.db")))
                {
                    connection.InsertAll(CreateImagesList());
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
            }
        }

        List<CImage> CreateImagesList()
        {
            List<CImage> imagesList = new List<CImage>();

            imagesList.Add(new CImage("img2", "miš", "миш"));
            imagesList.Add(new CImage("img1", "žir", "жир"));
            imagesList.Add(new CImage("img3", "puž", "пуж"));
            imagesList.Add(new CImage("img4", "sat", "сат"));
            imagesList.Add(new CImage("img5", "crv", "црв"));
            imagesList.Add(new CImage("img6", "pas", "пас"));
            imagesList.Add(new CImage("img7", "bor", "бор"));
            imagesList.Add(new CImage("img8", "zub", "зуб"));
            imagesList.Add(new CImage("img9", "noj", "ној"));

            imagesList.Add(new CImage("img10", "šah", "шах"));
            imagesList.Add(new CImage("img11", "sir", "сир"));
            imagesList.Add(new CImage("img12", "lav", "лав"));
            imagesList.Add(new CImage("img13", "nož", "нож"));
            imagesList.Add(new CImage("img14", "džak", "џак"));
            imagesList.Add(new CImage("img15", "oko", "око"));
            imagesList.Add(new CImage("img16", "voz", "воз"));
            imagesList.Add(new CImage("img17", "mač", "мач"));
            imagesList.Add(new CImage("img18", "konj", "коњ"));
            imagesList.Add(new CImage("img19", "put", "пут"));

            imagesList.Add(new CImage("img20", "rak", "рак"));
            imagesList.Add(new CImage("img21", "uho", "ухо"));
            imagesList.Add(new CImage("img22", "nos", "нос"));
            imagesList.Add(new CImage("img23", "zec", "зец"));
            imagesList.Add(new CImage("img24", "top", "топ"));
            imagesList.Add(new CImage("img25", "sto", "сто"));
            imagesList.Add(new CImage("img26", "kit", "кит"));
            imagesList.Add(new CImage("img27", "jež", "јеж"));
            imagesList.Add(new CImage("img28", "luk", "лук"));
            imagesList.Add(new CImage("img29", "sok", "сок"));

            imagesList.Add(new CImage("img30", "koza", "коза"));
            imagesList.Add(new CImage("img31", "drvo", "дрво"));
            imagesList.Add(new CImage("img32", "orao", "орао"));
            imagesList.Add(new CImage("img33", "bure", "буре"));
            imagesList.Add(new CImage("img34", "roda", "рода"));
            imagesList.Add(new CImage("img35", "lula", "лула"));
            imagesList.Add(new CImage("img36", "igla", "игла"));
            imagesList.Add(new CImage("img37", "slon", "слон"));
            imagesList.Add(new CImage("img38", "kaiš", "каиш"));
            imagesList.Add(new CImage("img39", "beba", "беба"));

            imagesList.Add(new CImage("img40", "pile", "пиле"));
            imagesList.Add(new CImage("img41", "kost", "кост"));
            imagesList.Add(new CImage("img42", "brod", "брод"));
            imagesList.Add(new CImage("img43", "mrav", "мрав"));
            imagesList.Add(new CImage("img44", "pero", "перо"));
            imagesList.Add(new CImage("img45", "kapa", "капа"));
            imagesList.Add(new CImage("img46", "prst", "прст"));
            imagesList.Add(new CImage("img47", "zmaj", "змај"));
            imagesList.Add(new CImage("img48", "sova", "сова"));
            imagesList.Add(new CImage("img49", "orah", "орах"));

            imagesList.Add(new CImage("img50", "ključ", "кључ"));
            imagesList.Add(new CImage("img51", "reka", "река"));
            imagesList.Add(new CImage("img52", "čaša", "чаша"));
            imagesList.Add(new CImage("img53", "kuća", "кућа"));
            imagesList.Add(new CImage("img54", "riba", "риба"));
            imagesList.Add(new CImage("img55", "znak", "знак"));
            imagesList.Add(new CImage("img56", "kivi", "киви"));
            imagesList.Add(new CImage("img57", "ovca", "овца"));
            imagesList.Add(new CImage("img58", "kada", "када"));
            imagesList.Add(new CImage("img59", "hleb", "хлеб"));

            imagesList.Add(new CImage("img60", "tenk", "тенк"));
            imagesList.Add(new CImage("img61", "most", "мост"));
            imagesList.Add(new CImage("img62", "srce", "срце"));
            imagesList.Add(new CImage("img63", "cvet", "цвет"));
            imagesList.Add(new CImage("img64", "pauk", "паук"));
            imagesList.Add(new CImage("img65", "kralj", "краљ"));
            imagesList.Add(new CImage("img66", "duga", "дуга"));
            imagesList.Add(new CImage("img67", "jaje", "јаје"));
            imagesList.Add(new CImage("img68", "list", "лист"));
            imagesList.Add(new CImage("img69", "noga", "нога"));

            imagesList.Add(new CImage("img70", "lupa", "лупа"));
            imagesList.Add(new CImage("img71", "lopta", "лопта"));
            imagesList.Add(new CImage("img72", "pasulj", "пасуљ"));
            imagesList.Add(new CImage("img73", "vatra", "ватра"));
            imagesList.Add(new CImage("img74", "zebra", "зебра"));
            imagesList.Add(new CImage("img75", "avion", "авион"));
            imagesList.Add(new CImage("img76", "kocka", "коцка"));
            imagesList.Add(new CImage("img77", "panda", "панда"));
            imagesList.Add(new CImage("img78", "oblak", "облак"));
            imagesList.Add(new CImage("img79", "čekić", "чекић"));

            imagesList.Add(new CImage("img80", "kuvar", "кувар"));
            imagesList.Add(new CImage("img81", "pismo", "писмо"));
            imagesList.Add(new CImage("img82", "lopov", "лопов"));
            imagesList.Add(new CImage("img83", "petao", "петао"));
            imagesList.Add(new CImage("img84", "ćurka", "ћурка"));
            imagesList.Add(new CImage("img85", "zmija", "змија"));
            imagesList.Add(new CImage("img86", "krava", "крава"));
            imagesList.Add(new CImage("img87", "sveća", "свећа"));
            imagesList.Add(new CImage("img88", "točak", "точак"));
            imagesList.Add(new CImage("img89", "flaša", "флаша"));

            imagesList.Add(new CImage("img90", "tigar", "тигар"));
            imagesList.Add(new CImage("img91", "mačka", "мачка"));
            imagesList.Add(new CImage("img92", "tepih", "тепих"));
            imagesList.Add(new CImage("img93", "patka", "патка"));
            imagesList.Add(new CImage("img94", "truba", "труба"));
            imagesList.Add(new CImage("img95", "balon", "балон"));
            imagesList.Add(new CImage("img96", "kupus", "купус"));
            imagesList.Add(new CImage("img97", "lovac", "ловац"));
            imagesList.Add(new CImage("img98", "prase", "прасе"));
            imagesList.Add(new CImage("img99", "šljiva", "шљива"));

            imagesList.Add(new CImage("img100", "čizme", "чизме"));
            imagesList.Add(new CImage("img101", "puška", "пушка"));
            imagesList.Add(new CImage("img102", "golub", "голуб"));
            imagesList.Add(new CImage("img103", "vrata", "врата"));
            imagesList.Add(new CImage("img104", "ribar", "рибар"));
            imagesList.Add(new CImage("img105", "torta", "торта"));
            imagesList.Add(new CImage("img106", "jelen", "јелен"));
            imagesList.Add(new CImage("img107", "sunce", "сунце"));
            imagesList.Add(new CImage("img108", "knjiga", "књига"));
            imagesList.Add(new CImage("img109", "reket", "рекет"));

            imagesList.Add(new CImage("img110", "lampa", "лампа"));
            imagesList.Add(new CImage("img111", "palma", "палма"));
            imagesList.Add(new CImage("img112", "mesec", "месец"));
            imagesList.Add(new CImage("img113", "kompas", "компас"));
            imagesList.Add(new CImage("img114", "majmun", "мајмун"));
            imagesList.Add(new CImage("img115", "patike", "патике"));
            imagesList.Add(new CImage("img116", "krevet", "кревет"));
            imagesList.Add(new CImage("img117", "ananas", "ананас"));
            imagesList.Add(new CImage("img118", "prsten", "прстен"));
            imagesList.Add(new CImage("img119", "kamila", "камила"));

            imagesList.Add(new CImage("img120", "banana", "банана"));
            imagesList.Add(new CImage("img121", "ograda", "ограда"));
            imagesList.Add(new CImage("img122", "kamion", "камион"));
            imagesList.Add(new CImage("img123", "gumica", "гумица"));
            imagesList.Add(new CImage("img124", "pištolj", "пиштољ"));
            imagesList.Add(new CImage("img125", "klavir", "клавир"));
            imagesList.Add(new CImage("img126", "malina", "малина"));
            imagesList.Add(new CImage("img127", "groždje", "грожђе"));
            imagesList.Add(new CImage("img128", "kruška", "крушка"));
            imagesList.Add(new CImage("img129", "majica", "мајица"));

            imagesList.Add(new CImage("img130", "aparat", "апарат"));
            imagesList.Add(new CImage("img131", "kašika", "кашика"));
            imagesList.Add(new CImage("img132", "zvezda", "звезда"));
            imagesList.Add(new CImage("img133", "medved", "медвед"));
            imagesList.Add(new CImage("img134", "žirafa", "жирафа"));
            imagesList.Add(new CImage("img135", "leptir", "лептир"));
            imagesList.Add(new CImage("img136", "jabuka", "јабука"));
            imagesList.Add(new CImage("img137", "raketa", "ракета"));
            imagesList.Add(new CImage("img138", "trešnja", "трешња"));
            imagesList.Add(new CImage("img139", "jagoda", "јагода"));

            imagesList.Add(new CImage("img140", "brkovi", "бркови"));
            imagesList.Add(new CImage("img141", "sveska", "свеска"));
            imagesList.Add(new CImage("img142", "delfin", "делфин"));
            imagesList.Add(new CImage("img143", "papuče", "папуче"));
            imagesList.Add(new CImage("img144", "gitara", "гитара"));
            imagesList.Add(new CImage("img145", "olovka", "оловка"));
            imagesList.Add(new CImage("img146", "jabuka", "јабука"));
            imagesList.Add(new CImage("img147", "magare", "магаре"));
            imagesList.Add(new CImage("img148", "lisica", "лисица"));
            imagesList.Add(new CImage("img149", "kamera", "камера"));

            imagesList.Add(new CImage("img150", "kupina", "купина"));
            imagesList.Add(new CImage("img151", "paprika", "паприка"));
            imagesList.Add(new CImage("img152", "kornjača", "корњача"));
            imagesList.Add(new CImage("img153", "traktor", "трактор"));
            imagesList.Add(new CImage("img154", "kokoška", "кокошка"));
            imagesList.Add(new CImage("img155", "pečurka", "печурка"));
            imagesList.Add(new CImage("img156", "breskva", "бресква"));
            imagesList.Add(new CImage("img157", "zastava", "застава"));
            imagesList.Add(new CImage("img158", "katanac", "катанац"));
            imagesList.Add(new CImage("img159", "papagaj", "папагај"));

            imagesList.Add(new CImage("img160", "violina", "виолина"));
            imagesList.Add(new CImage("img161", "krompir", "кромпир"));
            imagesList.Add(new CImage("img162", "dvogled", "двоглед"));
            imagesList.Add(new CImage("img163", "kajsija", "кајсија"));
            imagesList.Add(new CImage("img164", "autobus", "аутобус"));
            imagesList.Add(new CImage("img165", "viljuška", "виљушка"));
            imagesList.Add(new CImage("img166", "telefon", "телефон"));
            imagesList.Add(new CImage("img167", "stolica", "столица"));
            imagesList.Add(new CImage("img168", "pingvin", "пингвин"));
            imagesList.Add(new CImage("img169", "leopard", "леопард"));

            imagesList.Add(new CImage("img170", "kukuruz", "кукуруз"));
            imagesList.Add(new CImage("img171", "jazavac", "јазавац"));
            imagesList.Add(new CImage("img172", "krokodil", "крокодил"));
            imagesList.Add(new CImage("img173", "lubenica", "лубеница"));
            imagesList.Add(new CImage("img174", "balerina", "балерина"));
            imagesList.Add(new CImage("img175", "buldožer", "булдожер"));
            imagesList.Add(new CImage("img176", "teleskop", "телескоп"));
            imagesList.Add(new CImage("img177", "sijalica", "сијалица"));

            return imagesList;
        }
    }
}