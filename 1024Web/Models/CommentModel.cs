using _1024Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.Models
{
    public class CommentModel
    {
        public IList<CommentDB> Comments { get; set; }
    }
}
