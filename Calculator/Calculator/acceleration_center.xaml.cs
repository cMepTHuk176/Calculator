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
    public partial class acceleration_center : ContentPage
    {
        public acceleration_center()
        {
            InitializeComponent();
            textForm.Text = "a = \u03C9\u00B2\u00B7R";
            w.Placeholder = "\u03C9";
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(w, R);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(w, R))
                Result_cent(null, null);
        }

        private void Result_cent(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(w, R))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var circleVelocity = double.Parse(w.Text);
            var radius = double.Parse(R.Text);
            var resultAcceleration = Mechanic.CenterAcceleration_w(circleVelocity, radius);

            var precision = (resultAcceleration - (int)resultAcceleration == 0)
                ? "0"
                : "2";

            resultText.Text = resultAcceleration is >= 0.01 and <= 1000
                ? resultAcceleration.ToString($"N{precision}") + " м/c\u00B2"
                : resultAcceleration.ToString("0.00E+0") + " м/с\u00B2";

        }
    }
}