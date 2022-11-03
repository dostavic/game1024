using _1024Core.Entity;
using _1024Core.Service;
using _1024Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.Controllers
{
    public class Comment1Controller : Controller
    {
        private ICommentSeviceDB commentServiceDB = new CommentServiceEF();

        public IActionResult Index()
        {
            return View("Index", CreateModel());
        }

        private CommentModel CreateModel()
        {
            IList<CommentDB> comments = commentServiceDB.GetComments(); 
            return new CommentModel { Comments = comments };
        }
    }
}
