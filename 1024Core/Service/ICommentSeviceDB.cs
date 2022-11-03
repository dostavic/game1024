using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public interface ICommentSeviceDB
    {
        void AddComment(CommentDB comment);

        IList<CommentDB> GetComments();

        void ResetComment();

        public void DeleteComment(int id);

        List<CommentDB> GetCommentData(int id);
    }
}
