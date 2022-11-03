using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace _1024Core.Service
{
    public class ScoreServiceEF : IScoreServiceDB
    {
        public void AddScore(PlayerScoreDB playerScore)
        {
            using (_1024DbContext context = new())
            {
                context.PlayerScores.Add(playerScore);
                context.SaveChanges();
            }
        }


        public IList<PlayerScoreDB> GetTopScores(int kol)
        {
            using (_1024DbContext context = new())
            {
                 return (from s in context.PlayerScores orderby s.Points descending select s).Take(kol).ToList();
            }
        }

        public void ResetScore()
        {
            using(_1024DbContext context = new())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM PlayerScores");
            }
        }

        public void DeleteScore(int id)
        {
            using (_1024DbContext context = new())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM PlayerScores WHERE Id = " + id);
            }
        }

        public List<PlayerScoreDB> GetScoreData(int id)
        {
            using (_1024DbContext context = new())
            {
                return (from s in context.PlayerScores where s.Id == id select s).ToList();
            }
        }
    }
}
