using _1024Core.Service;
using _1024Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _1024Test
{
    [TestClass]
    public class ScoreServiceTestDB
    {       
        [TestMethod]
        public void Addtest1()
        {
            IScoreServiceDB scoreService = CreateService();

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            Assert.AreEqual(1, scoreService.GetTopScores(3).Count);
            Assert.AreEqual("Dima", scoreService.GetTopScores(3)[0].Player);
            Assert.AreEqual(200, scoreService.GetTopScores(3)[0].Points);
        }

        [TestMethod]
        public void Addtest3()
        {
            IScoreServiceDB scoreService = CreateService();

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Peter",
                Points = 100,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Jaro",
                Points = 400,
                PlayedAt = DateTime.Now
            });

            Assert.AreEqual(3, scoreService.GetTopScores(3).Count);

            Assert.AreEqual("Jaro", scoreService.GetTopScores(3)[0].Player);
            Assert.AreEqual(400, scoreService.GetTopScores(3)[0].Points);

            Assert.AreEqual("Dima", scoreService.GetTopScores(3)[1].Player);
            Assert.AreEqual(200, scoreService.GetTopScores(3)[1].Points);

            Assert.AreEqual("Peter", scoreService.GetTopScores(3)[2].Player);
            Assert.AreEqual(100, scoreService.GetTopScores(3)[2].Points);
        }

        [TestMethod]
        public void Addtest5()
        {
            IScoreServiceDB scoreService = CreateService();

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Zuzko",
                Points = 20,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Peter",
                Points = 100,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Anna",
                Points = 10,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Jaro",
                Points = 400,
                PlayedAt = DateTime.Now
            });

            Assert.AreEqual(3, scoreService.GetTopScores(3).Count);

            Assert.AreEqual("Jaro", scoreService.GetTopScores(3)[0].Player);
            Assert.AreEqual(400, scoreService.GetTopScores(3)[0].Points);

            Assert.AreEqual("Dima", scoreService.GetTopScores(3)[1].Player);
            Assert.AreEqual(200, scoreService.GetTopScores(3)[1].Points);

            Assert.AreEqual("Peter", scoreService.GetTopScores(3)[2].Player);
            Assert.AreEqual(100, scoreService.GetTopScores(3)[2].Points);
        }

        [TestMethod]

        public void ResetTest()
        {
            IScoreServiceDB scoreService = CreateService();

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScoreDB
            {
                Player = "Peter",
                Points = 100,
                PlayedAt = DateTime.Now
            });

            scoreService.ResetScore();

            Assert.AreEqual(0, scoreService.GetTopScores(3).Count);
        }

        //private IScoreService CreateService()
        //{            
        //    return new ScoreServiceFile();
        //}

        private IScoreServiceDB CreateService()
        {
            ScoreServiceEF service = new();
            service.ResetScore();
            return service;
        }
    }
}