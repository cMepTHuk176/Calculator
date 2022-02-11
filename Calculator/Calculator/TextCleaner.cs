using Xamarin.Forms;

namespace Calculator
{
    public static class TextCleaner
    {
        // стирает значение в каждом Entry
        public static void EntryClean(params Entry[] entries)
        {
            foreach (var item in entries)
                item.Text = default;
        }
    }
    public static class TextChecker
    {
        // проверяет начилие возможности преобразования значения в каждом Entry
        public static bool EntryCheck(params Entry[] entries)
        {
            foreach (var item in entries)
                if (!double.TryParse(item.Text, out double result))
                    return false;

            return true;
        }
    }
}