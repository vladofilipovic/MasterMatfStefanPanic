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
    public class CImage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SolutionLatin { get; set; }
        public string SolutionCyrilic { get; set; }
        public bool SolvedLatin { get; set; } = false;
        public bool SolvedCyrilic { get; set; } = false;

        public CImage(string pName, string pSolutionLatin, string pSolutionCyrilic)
        {
            this.Name = pName;
            this.SolutionLatin = pSolutionLatin;
            this.SolutionCyrilic = pSolutionCyrilic;
        }

        public CImage()
        {

        }
    }
}