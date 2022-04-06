namespace Skiing_Library
{
    public class SkiSlope
    {
        private bool[,] vs;
        public int treeHitCounter { get; }

        public SkiSlope(bool[,] vs)
        {
            this.vs = vs;
        }

        public object TreeCount { get; set; }

        public object CountTrees()
        {
            throw new NotImplementedException();
        }

        public bool CheckCollision(int xPos, int yPos)
        {
            return false;
        }
    }
}