using _1024Core.Service;
using _1024Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _1024Test
{
    [TestClass]
    public class ScoreServiceTest
    {
        [TestMethod]
        public void Addtest1()
        {
            IScoreService scoreService = CreateService();

            scoreService.AddScore(new PlayerScore
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            Assert.AreEqual(1, scoreService.GetTopScores().Count);
            Assert.AreEqual("Dima", scoreService.GetTopScores()[0].Player);
            Assert.AreEqual(200, scoreService.GetTopScores()[0].Points);
        }

        [TestMethod]
        public void Addtest3()
        {
            IScoreService scoreService = CreateService();

            scoreService.AddScore(new PlayerScore
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Peter",
                Points = 100,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Jaro",
                Points = 400,
                PlayedAt = DateTime.Now
            });

            Assert.AreEqual(3, scoreService.GetTopScores().Count);

            Assert.AreEqual("Jaro", scoreService.GetTopScores()[0].Player);
            Assert.AreEqual(400, scoreService.GetTopScores()[0].Points);

            Assert.AreEqual("Dima", scoreService.GetTopScores()[1].Player);
            Assert.AreEqual(200, scoreService.GetTopScores()[1].Points);

            Assert.AreEqual("Peter", scoreService.GetTopScores()[2].Player);
            Assert.AreEqual(100, scoreService.GetTopScores()[2].Points);
        }

        [TestMethod]
        public void Addtest5()
        {
            IScoreService scoreService = CreateService();

            scoreService.AddScore(new PlayerScore
            {
                Player = "Zuzko",
                Points = 20,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Peter",
                Points = 100,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Anna",
                Points = 10,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Jaro",
                Points = 400,
                PlayedAt = DateTime.Now
            });

            Assert.AreEqual(3, scoreService.GetTopScores().Count);

            Assert.AreEqual("Jaro", scoreService.GetTopScores()[0].Player);
            Assert.AreEqual(400, scoreService.GetTopScores()[0].Points);

            Assert.AreEqual("Dima", scoreService.GetTopScores()[1].Player);
            Assert.AreEqual(200, scoreService.GetTopScores()[1].Points);

            Assert.AreEqual("Peter", scoreService.GetTopScores()[2].Player);
            Assert.AreEqual(100, scoreService.GetTopScores()[2].Points);
        }

        [TestMethod]

        public void ResetTest()
        {
            IScoreService scoreService = CreateService();

            scoreService.AddScore(new PlayerScore
            {
                Player = "Dima",
                Points = 200,
                PlayedAt = DateTime.Now
            });

            scoreService.AddScore(new PlayerScore
            {
                Player = "Peter",
                Points = 100,
                PlayedAt = DateTime.Now
            });

            scoreService.ResetScore();

            Assert.AreEqual(0, scoreService.GetTopScores().Count);
        }

        private IScoreService CreateService()
        {
            return new ScoreServiceFile();
        }

        //private IScoreService CreateService()
        //{
        //    ScoreServiceEF service = new();
        //    service.ResetScore();
        //    return service;
        //}
    }
}
