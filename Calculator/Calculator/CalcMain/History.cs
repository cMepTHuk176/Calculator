using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Calculator
{
    class History
    {
        static Stack<string> Last = new();
        static Stack<string> First = new();
        public static string LastFormula
        {
            set => Last.Push(value);
            get
            {
                try
                {
                    return Last.Pop();
                }
                catch
                {
                    return "0";
                }
            }
    }
        public static string FirstFormula
        {
            set => First.Push(value);
            get
            {
                try
                {
                    return First.Pop();
                }
                catch
                {
                    return "0";
                }
            }
        }
    }
}
