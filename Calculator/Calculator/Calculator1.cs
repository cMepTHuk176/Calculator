﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Calculator1
    {
        public static double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "×":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
                case "^":
                    result = Math.Pow(value1, value2);
                    break;
            }

            return result;
        }
    }
}
