using Xamarin.Forms;

namespace Calculator.Service
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