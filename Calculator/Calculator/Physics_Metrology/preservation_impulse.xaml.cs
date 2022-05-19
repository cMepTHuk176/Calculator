using Calculator.Service;
using System;
using Calculator.Root;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Physics_Metrology
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class preservation_impulse : ContentPage
    {
        public preservation_impulse()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entry_m1, entry_v1, entry_m2, entry_v2);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entry_m1, entry_v1, entry_m2, entry_v2))
                Result_Impulse(null, null);
        }

        private void Result_Impulse(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entry_m1, entry_v1, entry_m2, entry_v2))
            {
                resultText.Text = App.ErrorText;
                return;
            }



        }
    }
}