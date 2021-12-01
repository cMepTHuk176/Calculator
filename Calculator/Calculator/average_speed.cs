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
    public partial class average_speed : ContentPage
    {
        public average_speed()
        {
            InitializeComponent();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(S, t);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(S, t))
                Result_averageSpeed(null, null);
        }

        private void Result_averageSpeed(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(S, t))
            {
                resultText.Text = mechanic_main.ErrorText;
                return;
            }

            var distance = double.Parse(S.Text);
            var time = double.Parse(t.Text);
            var resultVelocity = Mechanic.AverageSpeed(distance, time);

            var precision = (resultVelocity - (int)resultVelocity == 0)
                ? "0"
                : "2";

            resultText.Text = resultVelocity is >= 0.01 and <= 1000
                ? resultVelocity.ToString($"N{precision}") + " м/с"
                : resultVelocity.ToString("0.00E+0") + " м/с";
        }

    }
}