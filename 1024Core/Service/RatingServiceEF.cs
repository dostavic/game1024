using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace _1024Core.Service
{
    public class RatingServiceEF : IRatingServiceDB
    {
        public void AddRating(RatingDB rating)
        {
            using (_1024DbContext context = new())
            {
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }

        public void DeleteRating(int id)
        {
            throw new NotImplementedException();
        }

        public IList<RatingDB> GetRating()
        {
            using (_1024DbContext context = new())
                return (from c in context.Ratings orderby c.Points descending select c).Take(3).ToList();
        }

        public List<RatingDB> GetRatingData(int id)
        {
            using (_1024DbContext context = new())
            {
                return (from c in context.Ratings where c.Id == id select c).ToList();
            }
        }

        public void ResetRating()
        {
            using (_1024DbContext context = new())
                context.Database.ExecuteSqlRaw("DELETE FROM Ratings");
        }
    }
}
