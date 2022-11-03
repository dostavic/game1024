using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public class CommentServiceFile : ICommentSevice
    {
        private IList<Comment> comments = new List<Comment>();
        private readonly string fileName = "comment.bin";

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
            SaveComments();
        }

        public IList<Comment> GetComments()
        {
            LoadComments();
            return comments.OrderByDescending(d => d.dateTime).ToList();
        }

        public void ResetComment()
        {
            comments.Clear();
            File.Delete(fileName);
        }

        private void SaveComments()
        {
            using (FileStream fs = File.OpenWrite(fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, comments);
            }
        }

        private void LoadComments()
        {
            if (File.Exists(fileName))
            {
                using(FileStream fs = File.OpenRead(fileName))
                {
                    BinaryFormatter bf = new();
                    comments = (List<Comment>)bf.Deserialize(fs);
                }
            }
        }
    }
}
