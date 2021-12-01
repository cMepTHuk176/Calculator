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
    public partial class Pr : ContentPage
    {
        public Pr()
        {
            InitializeComponent();
        }

        private void OnCalculate(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryF, entryS))
            {
                resultText.Text = "ОШИБКА";
                return;
            }

            var force = double.Parse(entryF.Text);
            var square = double.Parse(entryS.Text);

            var result = force / square;

            resultText.Text = result is >= 0.01 and <= 1000
                ? result.ToString("N2") + " Па"
                : result.ToString("0.00E+0") + " Па";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryF, entryS);
        }

        public void OnIndexChanged(object sender, EventArgs e)
        {

        }

    }
}