using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1024Core.Core;

namespace _1024Console._Console
{
    class Program
    {
        static void Main()
        {
            Field field = new(4, 4);
            Score score = new Score();
            ConsoleUI consoleUI = new(field);
            consoleUI.Play();
        }
    }
}