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
    public partial class PrGidro : ContentPage
    {
        private const double g = PhysConstants.g;

        public PrGidro()
        {
            InitializeComponent();
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryDensity, entryHeight))
            {
                resultText.Text = "ОШИБКА";
                return;
            }

            var density = double.Parse(entryDensity.Text);
            var height = double.Parse(entryHeight.Text);
            var result = density * g * height;

            resultText.Text = result is >= 0.01 and <= 1000
                ? result.ToString("N2") + " Па"
                : result.ToString("0.00E+0") + " Па";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryDensity, entryHeight);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {

        }
    }
}