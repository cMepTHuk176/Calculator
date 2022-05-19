using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.CalcMain
{
    class DoubleCalculator : Calculator1
    {

        public static string DoubleCalculate(string input)
        {
            string output = Modification(input);
            return "0";
        }
        static string InParseX(string input)
        {
            return "0";
        }
    }
}
