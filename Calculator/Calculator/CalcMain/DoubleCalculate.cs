using System;
using System.Collections.Generic;
using System.Text;
using static System.ValueTuple;

namespace Calculator.CalcMain
{
    class DoubleCalculator : Calculator
    {
        public static (double,double, double) DoubleCalculate(string input)
        {
            return SolveQuadraticEquation(CountingDouble(Modification(XMod(input))));
        }
        private static string XMod(string input)
        {
            if (input.IndexOf('x') != -1)
            {
                if (input.IndexOf('^') + 1 != -1)
                {
                    input = input.Replace("x^2", "a");
                }
                input = input.Replace("x", "b");
            }
            return input;
        }
        private static void Istemp(Stack<double> temp,int input)
        {
            double result = 0;
            double a = 0;
            double b = 0;
            if (temp.Peek() != 0)
                a = temp.Pop();
            if (temp.Peek() != 0)
                b = temp.Pop();
            else
                temp.Push(a);
            if (a != 0 && b != 0)
            {
                switch (input)
                {
                    case '+': result = b + a; break;
                    case '-': result = b - a; break;
                    case '×': result = b * a; break;
                    case '÷': result = b / a; break;
                }
                temp.Push(result);
            }
        }
        static (double, double, double) CountingDouble(string input)
        {
            Stack<double> tempA = new(); tempA.Push(0);
            Stack<double> tempB = new(); tempB.Push(0);
            Stack<double> tempC = new(); tempC.Push(0);
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]) || Ifx(input[i]))
                {
                    string c = string.Empty;

                    while (!Separator(input[i]) && !IfOperator(input[i]))
                    {
                        c += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    if (c.IndexOf('a') != -1)
                    {
                        c = c.Remove(c.IndexOf('a'));
                        if (c == "")
                            c = "1";
                        tempA.Push(double.Parse(c));
                    }
                    else if (c.IndexOf('b') != -1)
                    {
                        c = c.Remove(c.IndexOf('b'));
                        if (c == "")
                            c = "1";
                        tempB.Push(double.Parse(c));
                    }
                    else if (c != "0")
                        tempC.Push(double.Parse(c));
                    i--;
                }
                else if (IfOperator(input[i]))
                {
                    Istemp(tempA, input[i]);
                    Istemp(tempB, input[i]);
                    Istemp(tempC, input[i]);

                }
            }
            return (tempA.Peek(), tempB.Peek(), tempC.Peek());
        }
        public static (double, double, double) SolveQuadraticEquation((double a, double b, double c)tuple)
        {
            double discRoot = Math.Sqrt(tuple.b * tuple.b - 4 * tuple.a * tuple.c);
            double x1 = (tuple.b + discRoot) / (2 * tuple.a);
            double x2 = (tuple.b - discRoot) / (2 * tuple.a);
            return (x1, x2, discRoot);
        }

    }
}
