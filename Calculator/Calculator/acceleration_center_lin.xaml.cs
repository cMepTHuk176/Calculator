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
    public partial class acceleration_center_lin : ContentPage
    {
        public acceleration_center_lin()
        {
            InitializeComponent();
            textForm.Text = "a = V\u00B2/R";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryVelocity, entryRadius);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryVelocity, entryRadius))
                Result_cent(null, null);
        }

        private void Result_cent(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryVelocity, entryRadius))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var velocity = double.Parse(entryVelocity.Text);
            var radius = double.Parse(entryRadius.Text);
            var resultAcceleration = Mechanic.CenterAcceleration_v(velocity, radius);

            var precision = (resultAcceleration - (int)resultAcceleration == 0)
                ? "0"
                : "2";

            resultText.Text = resultAcceleration is >= 0.01 and <= 1000
                ? resultAcceleration.ToString($"N{precision}") + " м/с\u00B2"
                : resultAcceleration.ToString("0.00E+0") + " м/с\u00B2";
        }
    }
}