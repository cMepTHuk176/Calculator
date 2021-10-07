using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculator
{
    public static class TextChecker
    {
        // проверяет начилие значения в Entry
        public static bool EntryCheck(params Entry[] entries)
        {
            foreach (var item in entries)
                if (!double.TryParse(item.Text, out double result))
                    return false;

            return true;
        }
    }
    public static class TextCleaner
    {
        // стирает Entry
        public static void EntryClean(params Entry[] entries)
        {
            foreach (var item in entries)
                item.Text = default;
        }
    }
}
