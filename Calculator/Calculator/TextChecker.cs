using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculator
{
    public static class TextChecker
    {/// <summary>
     /// проверяет начилие возможности преобразования значения в каждом Entry
     /// </summary>
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
        /// <summary>
        ///  стирает значение в каждом Entry
        /// </summary>
        public static void EntryClean(params Entry[] entries)
        {
            foreach (var item in entries)
                item.Text = default;
        }
    }
}
