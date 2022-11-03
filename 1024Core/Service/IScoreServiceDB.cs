using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public interface IScoreServiceDB
    {
        void AddScore(PlayerScoreDB playerScore);

        IList<PlayerScoreDB> GetTopScores(int kol);

        void ResetScore();

        public void DeleteScore(int id);

        List<PlayerScoreDB> GetScoreData(int id);
    }
}
