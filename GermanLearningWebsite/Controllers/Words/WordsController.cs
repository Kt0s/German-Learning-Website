using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GermanLearningWebsite.Models;
using GermanLearningWebsite.Models.ViewModels;

namespace GermanLearningWebsite.Controllers.Words
{
    public class WordsController : Controller
    {
        public ActionResult Words()
        {
            GLWDB db = new GLWDB();
            List<Models.Words> dbWordsList = db.Words.ToList();

            WordsVM wordsVM = new WordsVM();
            wordsVM.WordsList = dbWordsList.AsEnumerable();

            return View(wordsVM);
        }

        public ActionResult AddWord(WordsVM wordVM)
        {
            GLWDB db = new GLWDB();

            Models.Words word = new Models.Words
            {
                Id = 0,
                Article = wordVM.Article,
                IsActiveWord = wordVM.IsActiveWord,
                LastUse = DateTime.Today,           // LastUse = wordVM.LastUse
                TimesRight = 0,
                TimesUsed = 0,
                TimesWrong = 0,
                Translation = wordVM.Translation,
                Word = wordVM.Word
            };

            db.Words.Add(word);
            db.SaveChanges();

            return RedirectToAction("Words");
        }

        public ActionResult DeleteWord(int wordId)
        {
            var db = new GLWDB();

            var word = new Models.Words {Id = wordId};
            db.Words.Attach(word);
            db.Words.Remove(word);

            db.SaveChanges();

            return RedirectToAction("Words");
        }
    }
}