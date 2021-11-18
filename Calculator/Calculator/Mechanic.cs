using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Mechanic
    {
        public static double AverageSpeed(double S, double t)
        {
            return S / t;
        }

        public static double EquidistantMotion(double x0, double Vx, double t)
        {
            return x0 + Vx * t;
        }

        public static double Acceleration_projection(double V0x, double Vx, double t)
        {
            return (Vx - V0x) / t;
        }

    }


}