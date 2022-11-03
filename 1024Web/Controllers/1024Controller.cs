using _1024Core.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using _1024Core.Service;
using _1024Core.Entity;
using System.Collections.Generic;
using _1024Web.Models;

namespace _1024Web.Controllers
{
    public class _1024Controller : Controller
    {
        private const string FieldSessionKey = "field";
        private IScoreServiceDB serviceScoreDB = new ScoreServiceEF();
        private ICommentSeviceDB commentSeviceDB = new CommentServiceEF();
        private IRatingServiceDB ratingServiceDB = new RatingServiceEF();

        public IActionResult Index()
        {
            Field field = new(4, 4);
            HttpContext.Session.SetObject(FieldSessionKey, field);

            return View("Index", CreateModel());
        }

        public IActionResult Move(Direction direction)
        {
            //Field field = new(4, 4);
            Field field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            switch (direction)
            {
                case Direction.Up:
                    field.Move(Direction.Up);
                    break;
                case Direction.Down:
                    field.Move(Direction.Down);
                    break;
                case Direction.Left:
                    field.Move(Direction.Left);
                    break;
                case Direction.Right:
                    field.Move(Direction.Right);
                    break;
                default:
                    break;
            }
            HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Index", CreateModel());
        }
    
        public IActionResult Check()
        {
            try
            {
                Field field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
                HttpContext.Session.SetObject(FieldSessionKey, field);
            }
            catch
            {
                Field field = new(4, 4);
                HttpContext.Session.SetObject(FieldSessionKey, field);
            }
            return View("Index", CreateModel());
        }

        private _1024Model CreateModel()
        {
            IList<PlayerScoreDB> scores = serviceScoreDB.GetTopScores(3);
            Field field = (Field)HttpContext.Session.GetObject(FieldSessionKey);

            return new _1024Model { Field = field, Scores = scores };
        }

        public IActionResult SaveScore(PlayerScoreDB playerScoreDB)
        {
            playerScoreDB.PlayedAt = DateTime.Now;
            serviceScoreDB.AddScore(playerScoreDB);
            return View("Index", CreateModel());
        }

        public IActionResult SaveComment(CommentDB commentDB)
        {
            commentDB.dateTime = DateTime.Now;
            commentSeviceDB.AddComment(commentDB);
            return View("Index", CreateModel());
        }

        public IActionResult SaveRating(RatingDB ratingDB)
        {
            ratingDB.dateTime = DateTime.Now;
            ratingServiceDB.AddRating(ratingDB);
            return View("Index", CreateModel());
        }
    }
}
