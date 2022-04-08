namespace Skiing_Library
{
    public class Skier
    {
        private int slope;
        private int maxWidth;

        public Skier(int slope, int slopeMaxWidth)
        {
            this.XPosition = 0;
            this.YPosition = 0;
            this.slope = slope;
            this.maxWidth = slopeMaxWidth;
        }

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public void Move()
        {
            YPosition++;
            XPosition = (XPosition + slope) % maxWidth;
        }

        public int GetXPosition()
        {
            return this.XPosition;
        }

        public int GetYPosition()
        {
            return this.YPosition;
        }

        public int GetSlope()
        {
            return this.slope;
        }

    }
}