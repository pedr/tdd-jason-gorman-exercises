
using System;

namespace Base.Chapter6
{
    public class Cube
    {
        public Cube(double x, double y, double z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
            {
                throw new ArgumentException("Dimension can't be empty");
            }

            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public double CalculateArea()
        {
            return x * y * z;
        }
    }
}