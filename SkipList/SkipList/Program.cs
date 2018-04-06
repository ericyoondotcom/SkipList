using System;

namespace SkipList
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SkipList<int> skippy = new SkipList<int>();
            skippy.AddNode(6);
            skippy.AddNode(3);
            skippy.AddNode(2);
            skippy.AddNode(7);
            skippy.AddNode(1);
            skippy.AddNode(4);
            skippy.AddNode(5);
            skippy.AddNode(9);
            skippy.AddNode(8);
            Console.Write(skippy);
            skippy.RemoveNode(6);
            Console.Write(skippy);
            Console.Write(skippy.Contains(6));
        }
    }
}
