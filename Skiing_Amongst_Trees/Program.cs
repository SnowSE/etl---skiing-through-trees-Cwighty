using System;
using Skiing_Library;

namespace Skiing_Amongst_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLines = TreeParser.ReadFile(Environment.CurrentDirectory + "/../../../TreeMap.txt");
            var skiSlope = new SkiSlope(TreeParser.Parse(fileLines));
            var skier = new Skier(0, 0);
            int treesHit = 0;
            skier.SetSlope(3, skiSlope.Width);
            for (int i = 0; i < skiSlope.Height; i++)
            {
                if (skiSlope.CheckCollision(skier.XPosition, skier.YPosition))
                {
                    treesHit++;
                }
                skier.Move();
            }
            Console.WriteLine("Trees Hit: " + treesHit);
        }
    }
}
