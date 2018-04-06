using System;
using System.Threading;

namespace SkipList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SkipList<int> skippy = new SkipList<int>();
            for (int i = 0; i <= 25; i++) {
                Random randy = new Random(Guid.NewGuid().GetHashCode());
                skippy.AddNode(randy.Next(0, 1001));
            }

            foreach(char c in skippy.ToString()){
                if (c != ' ')
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write(c);
                Thread.Sleep(2);
            }
        }
    }
}
