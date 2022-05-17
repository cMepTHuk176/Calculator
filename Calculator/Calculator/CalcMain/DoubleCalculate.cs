using System;
using System.Collections.Generic;
using System.Text;
using static System.ValueTuple;

namespace Calculator.CalcMain
{
    class DoubleCalculator : Calculator
    {
        public static (double, double, double) DoubleCalculate(string input)
        {
            string a, b, c;
            (a, b, c) = XMod(input);
            a = Counting(Modification(a));
            b = Counting(Modification(b));
            c = Counting(Modification(c));
            if (a != "Ошибка" || b != "Ошибка" || c != "Ошибка")
                return SolveQuadraticEquation(double.Parse(a), double.Parse(b), double.Parse(c));
            else
                return (-1, -1, -1);
        }
        private static (string, string, string) XMod(string input)
        {
            string a = "0", b = "0", c = "0";
            if (input.IndexOf('x') != -1)
            {
                if (input.IndexOf('^') + 1 != -1)
                {
                    input = input.Replace("x^2", "a");
                }
                input = input.Replace("x", "b");
            }

            for (int i = 0; i < input.Length; i++)
            {
                string buf = null;
                if(IfOperator(input[i]))
                {
                    buf += input[i];
                    i++;
                }
                while (!IfOperator(input[i]))
                {
                    buf += input[i];
                    i++;
                    if (i == input.Length) break;
                }
                if (buf.IndexOf('a') != -1)
                {
                    buf = buf.Remove(buf.IndexOf('a'));
                    if (buf == "" || buf == "-")
                        buf += "1";
                    a += buf;
                }
                else if (buf.IndexOf('b') != -1)
                {
                    buf = buf.Remove(buf.IndexOf('b'));
                    if (buf == "" || buf == "-")
                        buf += "1";
                    b += buf;
                }
                else if (buf != "0")
                    c += buf;
                i--;
            }
            return (a, b, c);
        }
        public static (double, double, double) SolveQuadraticEquation(double a, double b, double c)
        {
            double discRoot = Math.Sqrt(b * b - 4 * a * c);
            double x1 = (-b + discRoot) / (2 * a);
            double x2 = (-b - discRoot) / (2 * a);
            return (x1, x2, discRoot);
        }

    }
}
