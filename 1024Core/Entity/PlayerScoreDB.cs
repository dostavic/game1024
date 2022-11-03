using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024Core.Entity
{
    [Serializable]
    public class PlayerScoreDB
    {
        //[Column("IdPlayer")]
        //[Key]
        public int Id { get; set; }

        public string Player { get; set; }

        public int Points { get; set; }

        public DateTime PlayedAt { get; set; }
    }
}
