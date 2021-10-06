using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculator
{
    public static class TextCleaner
    {
        public static void EntryClean(params Entry[] entries)
        {
            foreach (var item in entries)
                item.Text = default;
        }
    }
}
