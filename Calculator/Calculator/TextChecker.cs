using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculator
{
    public static class TextChecker
    {
        public static bool EntryCheck(params Entry[] entries)
        {
            foreach (var item in entries)
                if (!double.TryParse(item.Text, out double result))
                    return false;

            return true;
        }
    }
}
