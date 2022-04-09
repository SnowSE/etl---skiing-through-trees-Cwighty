using System;
using Skiing_Library;

namespace Skiing_Amongst_Trees
{
    static class Program
    {
        static SkiSlope skiSlope = new SkiSlope(Environment.CurrentDirectory + "/../../../TreeMap.txt");
        static void Main(string[] args)
        {
            int bestSlope = skiSlope.CalculateBestSlope();
            skiSlope.DisplaySkierPathForSlope(bestSlope);
            Console.WriteLine("\nBest Slope is: " + bestSlope);
            Console.WriteLine("Trees hit: " + skiSlope.CountTreesHitForSlope(bestSlope));
        }
    }
}
