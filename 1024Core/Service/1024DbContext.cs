using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace _1024Core.Service
{
    public class _1024DbContext : DbContext
    {
        public DbSet<PlayerScoreDB> PlayerScores { get; set; }

        public DbSet<CommentDB> Comments { get; set; }

        public DbSet<RatingDB> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=1024;Trusted_Connection=True;");
        }
    }
}
