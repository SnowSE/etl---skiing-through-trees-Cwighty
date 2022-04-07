namespace Skiing_Library
{
    public class SkiSlope
    {
        private bool[,] treeBitMap;
        public int treeHitCounter { get; }

        public SkiSlope(bool[,] treeBitMap)
        {
            this.treeBitMap = treeBitMap;
        }

        public object TreeCount { get; set; }

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
            return false;
        }
    }
}