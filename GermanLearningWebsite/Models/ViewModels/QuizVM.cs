﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GermanLearningWebsite.Models.ViewModels
{
    public class QuizVM : Words
    {
        public IEnumerable<Words> WordsList { get; set; }
    }
}