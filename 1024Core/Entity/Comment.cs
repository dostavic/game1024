using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024Core.Entity
{
    [Serializable]
    public class Comment
    {
        public string Player { get; set; }

        public string _Comment { get; set; }

        public int Points { get; set; }

        public DateTime dateTime { get; set; }
    }
}
