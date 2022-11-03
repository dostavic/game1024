using _1024Core.Service;
using _1024Core.Entity;
using _1024Core.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _1024Test
{
    [TestClass]
    public class CommentServiceTest
    {
        [TestMethod]
        public void AddComment1()
        {
            ICommentSevice commentSevice = CreateService();

            commentSevice.AddComment(new Comment
            {
                Player = "Dima",
                _Comment = "Commment",
                Points = 5,
                dateTime = DateTime.Now
            });

            Assert.AreEqual(1, commentSevice.GetComments().Count);
            Assert.AreEqual("Dima", commentSevice.GetComments()[0].Player);
            Assert.AreEqual("Commment", commentSevice.GetComments()[0]._Comment);
            Assert.AreEqual(5, commentSevice.GetComments()[0].Points);
        }


        [TestMethod]
        public void AddComment3()
        {
            ICommentSevice commentSevice = CreateService();

            commentSevice.AddComment(new Comment
            {
                Player = "Dima",
                _Comment = "Commment",
                Points = 2,
                dateTime = DateTime.Now
            });

            commentSevice.AddComment(new Comment
            {
                Player = "Dima1",
                _Comment = "Commment1",
                Points = 4,
                dateTime = DateTime.Now
            });

            commentSevice.AddComment(new Comment
            {
                Player = "Dima2",
                _Comment = "Commment2",
                Points = 5,
                dateTime = DateTime.Now
            });

            Assert.AreEqual(3, commentSevice.GetComments().Count);

            Assert.AreEqual("Dima", commentSevice.GetComments()[2].Player);
            Assert.AreEqual("Commment", commentSevice.GetComments()[2]._Comment);
            Assert.AreEqual(2, commentSevice.GetComments()[2].Points);

            Assert.AreEqual("Dima1", commentSevice.GetComments()[1].Player);
            Assert.AreEqual("Commment1", commentSevice.GetComments()[1]._Comment);
            Assert.AreEqual(4, commentSevice.GetComments()[1].Points);

            Assert.AreEqual("Dima2", commentSevice.GetComments()[0].Player);
            Assert.AreEqual("Commment2", commentSevice.GetComments()[0]._Comment);
            Assert.AreEqual(5, commentSevice.GetComments()[0].Points);
        }

        
        [TestMethod]

        public void ResetTest()
        {
            ICommentSevice commentSevice = CreateService();

            commentSevice.AddComment(new Comment
            {
                Player = "Dima",
                _Comment = "Commment",
                Points = 2,
                dateTime = DateTime.Now
            });

            commentSevice.AddComment(new Comment
            {
                Player = "Dima1",
                _Comment = "Commment1",
                Points = 4,
                dateTime = DateTime.Now
            });

            commentSevice.ResetComment();

            Assert.AreEqual(0, commentSevice.GetComments().Count);
        }

        private ICommentSevice CreateService()
        {
            return new CommentServiceFile();
        }
    }
}