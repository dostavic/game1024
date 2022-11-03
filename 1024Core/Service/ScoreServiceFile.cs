using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public class ScoreServiceFile : IScoreService
    {
        private IList<PlayerScore> playerScores = new List<PlayerScore>();
        private readonly string _fileName = "score.bin";

        public void AddScore(PlayerScore playerScore)
        {            
            playerScores.Add(playerScore);            
            SaveScores();
        }

        public IList<PlayerScore> GetTopScores()
        {
            LoadScores();            
            return playerScores.OrderByDescending(s => s.Points).Take(3).ToList();
        }

        public void ResetScore()
        {
            playerScores.Clear();
            File.Delete(_fileName);
        }

        private void SaveScores()
        {
            using(FileStream fs = File.OpenWrite(_fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, playerScores);
            }
        }

        private void LoadScores()
        {
            if (File.Exists(_fileName))
            {
                using(FileStream fs = File.OpenRead(_fileName))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    playerScores = (List<PlayerScore>)bf.Deserialize(fs);
                }
            }
        }
    }
}
