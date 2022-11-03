using _1024Core.Entity;
using _1024Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.APIControllers
{
    //https://localhost:44393/api/ScoreData/{id}
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class CommentDataController : ControllerBase
    {
        private ICommentSeviceDB commentServiceDB = new CommentServiceEF();

        [HttpGet]
        public IEnumerable<CommentDB> GetComment(int id)
        {
            return commentServiceDB.GetCommentData(id);
        }

        [HttpDelete]
        public void DeleteComment(int id)
        {
            commentServiceDB.DeleteComment(id);
        }
    }
}
