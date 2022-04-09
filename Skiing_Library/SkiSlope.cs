namespace Skiing_Library
{
    public class SkiSlope
    {
        private bool[,] treeBitMap;

        private string[] skiSlopeFileLines;
        public int TreeHitCounter { get; }
        public int Height { get; }
        public int Width { get; }

        public SkiSlope(string treeMapPath)
        {
            skiSlopeFileLines = TreeParser.ReadFile(treeMapPath);
            this.treeBitMap = TreeParser.Parse(skiSlopeFileLines);

            this.Height = treeBitMap.GetLength(0);
            this.Width = treeBitMap.GetLength(1);
        }

        public int CountAllTrees()
        {
            int totalTreeCount = 0;
            for(var row = 0; row < treeBitMap.GetLength(0); row++)
            {
                for(var col = 0; col < treeBitMap.GetLength(1); col++)
                {
                    if(treeBitMap[row,col])
                    {
                        totalTreeCount++;
                    }
                }
            }
            return totalTreeCount;
        }

        public bool CheckCollision(int xPos, int yPos)
        {
           if(treeBitMap[yPos,xPos])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CountTreesHitForSlope(int slope)
        {
            int treesHit = 0;
            var skier = new Skier(slope, this.Width);
            for (int i = 0; i < this.Height; i++)
            {
                if (CheckCollision(skier.XPosition, skier.YPosition))
                {
                    treesHit++;
                }
                skier.Move();
            }
            return treesHit;
        }

        public int CalculateBestSlope()
        {
            var slopeTreeHitCounts = new Dictionary<int, int>();
            for(int i = 0; i <= this.Width; i++)
            {
                slopeTreeHitCounts.Add(i, CountTreesHitForSlope(i));
            }
            var slopesOrdered = slopeTreeHitCounts.OrderBy(slope => slope.Value);
            return slopesOrdered.First().Key;
        }

        public void DisplaySkiSlope()
        {
            foreach(var line in skiSlopeFileLines)
            {
                Console.WriteLine(line);
            }
        }

        public void DisplaySkierPathForSlope(int slope)
        {
            var skier = new Skier(slope, this.Width);
            for (int i = 0; i < this.Height; i++)
            {
                Console.Write(skiSlopeFileLines[i]);
                Console.SetCursorPosition(skier.XPosition, Console.CursorTop);
                Console.Write('O');
                if (CheckCollision(skier.XPosition, skier.YPosition))
                {
                    Console.SetCursorPosition(skier.XPosition, Console.CursorTop);
                    Console.Write('=');
                }
                Console.WriteLine();
                skier.Move();
            }
        }

        internal static class TreeParser
        {
            public static string[] ReadFile(string filePath)
            {
                return System.IO.File.ReadAllLines(filePath);
            }

            public static bool[,] Parse(string[] lines)
            {
                var treeBitMap = new bool[lines.Length, lines[0].Length];
                int row = 0;
                foreach (var line in lines)
                {
                    int col = 0;
                    foreach (char character in line)
                    {
                        if (character == '#')
                        {
                            treeBitMap[row, col] = true;
                        }
                        else
                        {
                            treeBitMap[row, col] = false;
                        }
                        col++;
                    }
                    row++;
                }
                return treeBitMap;
            }
        }
    }
}