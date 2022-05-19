using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Algebra
{
    public static class MultiplicationFormulas
    {
        public static double SquareSum(double a, double b, out string textResult)
        {
            textResult = $"{a}\u00B2 + 2\u00B7{a}\u00B7{b} + {b}\u00B2";
            return (a * a) + (2 * a * b) + (b * b);
        }

        public static double SquareDiff(double a, double b, out string textResult)
        {
            textResult = $"{a}\u00B2 - 2\u00B7{a}\u00B7{b} + {b}\u00B2";
            return (a * a) - (2 * a * b) + (b * b);
        }

        public static double DiffSquares(double a, double b, out string textResult)
        {
            textResult = $"({a} - {b})\u00B7({a} + {b})";
            return (a - b) * (a + b);
        }

        public static double CubeSum(double a, double b, out string textResult)
        {
            textResult = $"{a}\u00B3 + 3\u00B7{a}\u00B2\u00B7{b} + 3\u00B7{a}\u00B7{b}\u00B2 + {b}\u00B3";
            return Math.Pow(a, 3) + (3 * a * a * b) + (3 * a * b * b) + Math.Pow(b, 3);
        }

        public static double SumCubs(double a, double b, out string textResult)
        {
            textResult = $"({a} + {b})\u00B7({a}\u00B2 - {a}\u00B7{b} + {b}\u00B2)";
            return (a + b) * ((a * a) - (a * b) + (b * b));
        }

        public static double CubeDiff(double a, double b, out string textResult)
        {
            textResult = $"{a}\u00B3 - 3\u00B7{a}\u00B2\u00B7{b} + 3\u00B7{a}\u00B7{b}\u00B2 - {b}\u00B3";
            return Math.Pow(a, 3) - (3 * a * a * b) + (3 * a * b * b) - Math.Pow(b, 3);
        }

        public static double DiffCube(double a, double b, out string resultText)
        {
            resultText = $"({a} - {b})\u00B7({a}\u00B2 + {a}\u00B7{b} + {b}\u00B2)";
            return (a - b) * ((a * a) + (a * b) + (b * b));
        }
    }
}
