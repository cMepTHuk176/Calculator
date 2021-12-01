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
    public partial class PrAtm : ContentPage
    {
        private const double R = PhysConstants.R;
        private const double g = PhysConstants.g;
        private const double P0 = PhysConstants.DefaultPressure;
        private double M = PhysConstants.MolarMass_Air;

        public PrAtm()
        {
            InitializeComponent();
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryT, entryH))
            {
                resultText.Text = "ОШИБКА";
                return;
            }

            var temperature = double.Parse(entryT.Text);
            var height = double.Parse(entryH.Text);
            var result = P0 * Math.Exp(-M * g * height / (R * temperature));

            resultText.Text = result is >= 0.01 and <= 1000
                ? result.ToString("N2") + " Па"
                : result.ToString("0.00E+0") + " Па";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryT, entryH);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {

        }
    }
}