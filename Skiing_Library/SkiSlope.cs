namespace Skiing_Library
{
    public class SkiSlope
    {
        private bool[,] treeBitMap;
        public int TreeHitCounter { get; }
        public int Height { get; }
        public int Width { get; }

        public SkiSlope(bool[,] treeBitMap)
        {
            this.treeBitMap = treeBitMap;
            this.Height = treeBitMap.GetLength(0);
            this.Width = treeBitMap.GetLength(1);

        }

        public int CountTrees()
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
    }
}