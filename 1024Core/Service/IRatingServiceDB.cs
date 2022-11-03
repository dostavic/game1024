using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;

namespace _1024Core.Service
{
    public interface IRatingServiceDB
    {
        void AddRating(RatingDB rating);

        IList<RatingDB> GetRating();

        void ResetRating();

        public void DeleteRating(int id);

        List<RatingDB> GetRatingData(int id);
    }
}
