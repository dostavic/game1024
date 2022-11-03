using _1024Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace _1024Web.Models
{
    public class RatingModel
    {
        public IList<RatingDB> Ratings { get; set; }
    }
}
