using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1024Core.Core
{
    [Serializable]
    public class Tile
    {
        public Tile(int value)
        {
            Value = value;
            IsCalculate = false;
        }
        public int Value { get; set; }
        public bool IsCalculate { get; set; }
    }
}
