namespace Skiing_Library
{
    public class Skier
    {
        private int slope;
        private int maxWidth;

        public Skier(int xPos, int yPos)
        {
            this.XPosition = xPos;
            this.YPosition = yPos;
            this.slope = 0;
            this.maxWidth = 31;
        }

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public void Move()
        {
            YPosition++;
            XPosition = (XPosition + slope) % maxWidth;
        }

        public void SetSlope(int slope, int maxWidth)
        {
            this.slope = slope;
            this.maxWidth = maxWidth;
        }

        public int GetXPosition()
        {
            return this.XPosition;
        }

        public int GetYPosition()
        {
            return this.YPosition;
        }
    }
}