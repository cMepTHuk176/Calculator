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

        public static double EquidistantMotion(double valuex0, double valueVx, double valuet)
        {
            return valuex0 + valueVx * valuet;
        }

    }


}