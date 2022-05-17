using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class finding_impulse : ContentPage
    {
        public finding_impulse()
        {
            InitializeComponent();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryM, entryV);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryM, entryV))
                Result_Impulse(null, null);
        }

        private void Result_Impulse(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryM, entryV))
            {
                resultText.Text = Impulse_Main.ErrorText;
                return;
            }

            var m = double.Parse(entryM.Text);
            var v = double.Parse(entryV.Text);
            var result = ImpulseFormulas.Impulse(m, v);
            var precision = (result - (int)result == 0)
                ? "0"
                : "2";

            resultText.Text = result is >= 0.01 or <= 1000
                ? result.ToString($"N{precision}") + " кг\u00B7м/с"
                : result.ToString("0.00E+0") + " кг\u00B7м/с";
        }
    }
}