using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Sphere
    {
        public static double Volume(double radius)
        {
            return Math.PI * Math.Pow(radius, 3) * 4 / 3;
        }
    }
}
