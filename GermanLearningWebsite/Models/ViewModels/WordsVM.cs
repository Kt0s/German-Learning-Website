using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GermanLearningWebsite.Models.ViewModels
{
    public class WordsVM
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Article { get; set; }
        public Nullable<System.DateTime> LastUse { get; set; }
        public int TimesUsed { get; set; }
        public int TimesRight { get; set; }
        public int TimesWrong { get; set; }
        public bool IsActiveWord { get; set; }
        public string Translation { get; set; }

        public IEnumerable<Words> WordsList { get; set; }
    }
}