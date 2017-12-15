using System;
using System.Collections.Generic;
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

        public bool CheckCorrect(QuizVM model)
        {
            GLWDB db = new GLWDB();
            Models.Words dbWords = db.Words.ToList().First(x => x.Id == model.Id);

            if (dbWords == null)
                return false;

            return false;
        }
    }
}