using System;

namespace MethodsInEnums
{
    public enum Colors
    {
        White,
        Red,
        Blue,
        Yellow
    }

    // extension methods para o enum Colors
    public static class ColorsExtensions
    {
        public static bool IsWhite(this Colors c)
        {
            return c == Colors.White;
        }
        public static bool IsBlueOrYellow(this Colors c)
        {
            return c == Colors.Blue || c == Colors.Yellow;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Colors c = Colors.Yellow;
            Console.WriteLine(c.IsWhite()); // False
            Console.WriteLine(c.IsBlueOrYellow());  // True
            Console.ReadKey();
        }
    }
}
