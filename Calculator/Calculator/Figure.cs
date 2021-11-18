using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Figure
    {
        public static double SphereVolume(double radius)
        {
            return Math.PI * Math.Pow(radius, 3) * 4 / 3;
        }

        public static double ParallepipedVolume(double side1, double side2, double side3)
        {
            return side1 * side2 * side3;
        }

        public static double SquarePyramidVolume(double side1, double side2, double height)
        {
            return side1 * side2 * height / 3;
        }

        public static double ConeVolume(double radius, double height)
        {
            return Math.PI * Math.Pow(radius, 2) * height / 3;
        }

        public static double TriangularPyramidVolume(double square, double height)
        {
            return square * height / 3;
        }

        public static double CylinderVolume(double radius, double height)
        {
            return Math.PI * Math.Pow(radius, 2) * height;
        }
    }

    
}
