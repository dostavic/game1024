using _1024Core.Entity;
using _1024Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.APIControllers
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class RatingDataController : Controller
    {
        private IRatingServiceDB ratingServiceDB = new RatingServiceEF();

        [HttpGet]
        public IEnumerable<RatingDB> GetComment(int id)
        {
            return ratingServiceDB.GetRatingData(id);
        }

        [HttpDelete]
        public void DeleteComment(int id)
        {
            ratingServiceDB.DeleteRating(id);
        }
    }
}
