using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public interface ICommentSevice
    {
        void AddComment(Comment comment);

        IList<Comment> GetComments();

        void ResetComment();
    }
}
