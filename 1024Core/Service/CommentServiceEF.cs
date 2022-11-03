using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace _1024Core.Service
{
    public class CommentServiceEF : ICommentSeviceDB
    {
        public void AddComment(CommentDB comment)
        {
            using(_1024DbContext context = new())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        public IList<CommentDB> GetComments()
        {
            using (_1024DbContext context = new())
                return (from c in context.Comments orderby c.Points descending select c).Take(10).ToList();
        }

        public void ResetComment()
        {
            using (_1024DbContext context = new())
                context.Database.ExecuteSqlRaw("DELETE FROM Comments");
        }

        public void DeleteComment(int id)
        {
            using (_1024DbContext context = new())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Comments WHERE Id = " + id);
            }
        }

        public List<CommentDB> GetCommentData(int id)
        {
            using(_1024DbContext context = new())
            {
                return (from c in context.Comments where c.Id == id select c).ToList();
            }
        }
    }
}
