using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public static class ImpulseFormulas
    {
        public static double Impulse(double m, double v)
        {
            return m * v;
        }

        public static double Impulse(double m1, double v1, double m2, double v2, ImpulseCollisionMode mode)
        {
            return 0;
        }

    }
}
