using Xamarin.Forms;

namespace Calculator.Service
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
