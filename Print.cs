using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletAlmak
{
    internal static class Print
    {
        internal static void Write(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal static void WriteLine(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
