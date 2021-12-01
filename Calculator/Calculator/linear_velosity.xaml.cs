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
    public partial class linear_velocity : ContentPage
    {
        public linear_velocity()
        {
            InitializeComponent();
            textForm.Text = "V = 2\u03C0\u00B7R/T";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryRadius, entryPeriod);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryRadius, entryPeriod))
                Result_linear(null, null);
        }

        private void Result_linear(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryRadius, entryPeriod))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var radius = double.Parse(entryRadius.Text);
            var period = double.Parse(entryPeriod.Text);
            var resultVelocity = Mechanic.LinearVelocity(radius, period);

            var precision = (resultVelocity - (int)resultVelocity == 0)
                ? "0"
                : "2";

            resultText.Text = resultVelocity is >= 0.01 and <= 1000
                ? resultVelocity.ToString($"N{precision}") + " м/с"
                : resultVelocity.ToString("0.00E+0") + " м/с";
        }

    }
}