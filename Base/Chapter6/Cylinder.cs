
using System;

namespace Base.Chapter6
{
    public class Cylinder
    {
        public Cylinder(double radius, double height)
        {
            if (height <= 0 || radius <= 0)
            {
                throw new ArgumentException("Invalid height or radius");
            }
            
            Height = height;
            Radius = radius;
        }

        public double Height { get; set; }
        public double Radius { get; set; }

        public double CalculateVolume()
        {
            return Height * Radius * Radius * Math.PI;
        }
    }
}