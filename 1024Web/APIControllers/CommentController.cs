using _1024Core.Entity;
using _1024Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.APIControllers
{
    //https://localhost:44393/api/Comment
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentSeviceDB commentServiceDB = new CommentServiceEF();

        [HttpGet]
        public IEnumerable<CommentDB> GetScores()
        {
            return commentServiceDB.GetComments();
        }

        [HttpPost]
        public void PostComment(CommentDB commentDB)
        {
            commentDB.dateTime = DateTime.Now;
            commentServiceDB.AddComment(commentDB);
        }

        [HttpDelete]
        public void DeleteComment()
        {
            commentServiceDB.ResetComment();
        }
    }
}
