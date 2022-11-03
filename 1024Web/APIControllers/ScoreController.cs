using _1024Core.Entity;
using _1024Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.APIControllers
{
    //https://localhost:44393/api/Score
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreServiceDB scoreServiceDB = new ScoreServiceEF();

        [HttpGet]
        public IEnumerable<PlayerScoreDB> GetScores()
        {
            return scoreServiceDB.GetTopScores(10);
        }

        [HttpPost]
        public void PostScore(PlayerScoreDB playerScoreDB)
        {
            playerScoreDB.PlayedAt = DateTime.Now;
            scoreServiceDB.AddScore(playerScoreDB);
        }

        [HttpDelete]
        public void DeleteScore()
        {
            scoreServiceDB.ResetScore();
        }
    }
}
