using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class CylinderVolume
    {
        public static double Volume(double radius, double height)
        {
            return Math.PI * Math.Pow(radius, 2) * height;
        }

    }
}
