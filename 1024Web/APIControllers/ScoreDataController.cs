using _1024Core.Entity;
using _1024Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.APIControllers
{
    //https://localhost:44393/api/Score
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class ScoreDataController : ControllerBase
    {
        private IScoreServiceDB scoreServiceDB = new ScoreServiceEF();

        [HttpGet]
        public IEnumerable<PlayerScoreDB> GetScores(int id)
        {
            return scoreServiceDB.GetScoreData(id);
        }

        [HttpDelete]
        public void DeleteScoreData(int id)
        {
            scoreServiceDB.DeleteScore(id);
        }
    }
}


