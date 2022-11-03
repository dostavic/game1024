using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public interface IScoreService
    {
        void AddScore(PlayerScore playerScore);

        IList<PlayerScore> GetTopScores();

        void ResetScore();
    }
}
