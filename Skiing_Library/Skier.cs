namespace Skiing_Library
{
    public class Skier
    {
        private int v1;
        private int v2;
        private int slope;

        public Skier(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void SetSlope(int slope)
        {
            throw new NotImplementedException();
        }

        public int GetXPosition()
        {
            throw new NotImplementedException();
        }

        public int GetYPosition()
        {
            throw new NotImplementedException();
        }
    }
}