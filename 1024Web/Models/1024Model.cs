using _1024Core.Core;
using _1024Core.Entity;

namespace _1024Web.Models
{
    public class _1024Model
    {
        public Field Field { get; set; }

        public IList<PlayerScoreDB> Scores { get; set; }
    }
}
