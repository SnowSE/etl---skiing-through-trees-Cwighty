using System;
using Skiing_Library;

namespace Skiing_Amongst_Trees
{
    static class Program
    {
        static SkiSlope skiSlope = new SkiSlope(Environment.CurrentDirectory + "/../../../TreeMap.txt");
        static void Main(string[] args)
        {
            Console.WriteLine(skiSlope.CountTreesHitForSlope(3));
        }
    }
}
