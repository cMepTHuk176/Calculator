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
    public partial class accelerate : ContentPage
    {
        public accelerate()
        {
            InitializeComponent();
            textForm.Text = "a = (Vx-Vx\u2080)/t";
            entryVx0.Placeholder = "Vx\u2080";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryVx0, entryVx, entryT);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryVx0, entryVx, entryT))
                Result_accel(null, null);
        }

        private void Result_accel(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryVx0, entryVx, entryT))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var Vx0 = double.Parse(entryVx0.Text);
            var Vx = double.Parse(entryVx.Text);
            var t = double.Parse(entryT.Text);
            var resultAcceleration = Mechanic.Acceleration_projection(Vx0, Vx, t);

            var precision = (resultAcceleration - (int)resultAcceleration == 0)
                ? "0"
                : "2";

            resultText.Text = resultAcceleration is >= 0.01 and <= 1000
                ? resultAcceleration.ToString($"N{precision}") + " м/с\u00B2"
                : resultAcceleration.ToString("0.00E+0") + " м/с\u00B2";
        }


    }
}