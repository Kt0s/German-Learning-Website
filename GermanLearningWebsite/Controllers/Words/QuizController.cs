using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using GermanLearningWebsite.Models;
using GermanLearningWebsite.Models.ViewModels;

namespace GermanLearningWebsite.Controllers.Words
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Quiz()
        {
            List<Models.Words> wordsList = GenerateWordsList(10);

            QuizVM model = new QuizVM();
            model.WordsList = wordsList;

            return View(model);
        }

        private List<Models.Words> GenerateWordsList(int numOfWords)
        {
            GLWDB db = new GLWDB();
            List<Models.Words> resultList = db.Words
                .OrderBy(x => x.LastUse)
                .Take(numOfWords)
                .ToList();   

            return resultList;
        }

        private void UpdateWord(int id, bool isRight)
        {
            GLWDB db = new GLWDB();
            Models.Words dbWord = db.Words.First(x => x.Id == id);
            dbWord.LastUse = DateTime.Now;
            dbWord.TimesUsed++;
            if (isRight)
                dbWord.TimesRight++;
            else
                dbWord.TimesWrong++;
            
            db.Words.AddOrUpdate(dbWord);
            db.SaveChanges();
        }

        public bool CheckCorrect(int id, string translation)
        {
            GLWDB db = new GLWDB();
            Models.Words dbWords = db.Words
                .FirstOrDefault(x => x.Id == id && x.Translation.ToLower() == translation.ToLower());

            if (dbWords == null)
            {
                UpdateWord(id, false);
                return false;
            }
            else
            {
                UpdateWord(id, true);
                return true;
            }
        }
    }
}