using _1024Core.Entity;
using _1024Core.Service;
using _1024Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.Controllers
{
    public class Rating1Controller : Controller
    {
        private IRatingServiceDB ratingServiceDB = new RatingServiceEF();

        public IActionResult Index()
        {
            return View("Index", CreateModel());
        }

        private RatingModel CreateModel()
        {
            IList<RatingDB> ratings = ratingServiceDB.GetRating();
            return new RatingModel { Ratings = ratings };
        }
    }
}
