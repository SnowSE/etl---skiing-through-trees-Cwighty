namespace Skiing_Library
{
    public static class TreeParser
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
                foreach(char character in line)
                {
                    if (character == '#')
                    {
                        treeBitMap[row,col] = true;
                    }
                    else
                    {
                        treeBitMap[row,col] = false;
                    }
                    col++;
                }
                row++;
            }
            return treeBitMap;
        }
    }
}