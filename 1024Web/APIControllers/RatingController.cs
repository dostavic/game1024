using _1024Core.Entity;
using _1024Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : Controller
    {
        
        private IRatingServiceDB ratingServiceDB = new RatingServiceEF();

        [HttpGet]
        public IEnumerable<RatingDB> GetScores()
        {
            return ratingServiceDB.GetRating();
        }

        [HttpPost]
        public void PostComment(RatingDB ratingtDB)
        {
            ratingtDB.dateTime = DateTime.Now;
            ratingServiceDB.AddRating(ratingtDB);
        }

        [HttpDelete]
        public void DeleteComment()
        {
            ratingServiceDB.ResetRating();
        }
    }
}
