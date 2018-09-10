using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Master.Database
{
    public class CRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string GameId { get; set; }
        public int Result { get; set; }
        public int Time { get; set; }
    }
}