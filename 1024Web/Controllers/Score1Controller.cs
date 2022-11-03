using _1024Core.Entity;
using _1024Core.Service;
using _1024Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.Controllers
{
    public class Score1Controller : Controller
    {
        // GET: Score1Controller
        private IScoreServiceDB scoreServiceDB = new ScoreServiceEF();

        public ActionResult Index()
        {
            return View("Index", CreateModel());
        }

        private ScoreModel CreateModel()
        {
            IList<PlayerScoreDB> scores = scoreServiceDB.GetTopScores(10);
            return new ScoreModel { Scores = scores };
        }
    }
}
