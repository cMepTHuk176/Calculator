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
    public partial class square_sum : ContentPage
    {
        public square_sum()
        {
            InitializeComponent();
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(a, b);
        }

        private void Result_square_sum(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(a, b))
            {
                resultText.Text = "ОШИБКА";
                return;
            }

            double valueA = double.Parse(a.Text);
            double valueB = double.Parse(b.Text);
            string result = (Math.Pow(valueA, 2) + 2 * valueA * valueB + Math.Pow(valueB, 2)).ToString();
            resultText.Text = $"({valueA} + {valueB})\u00B2 = {valueA}\u00B2 + 2 * {valueA} * {valueB} + {valueB}\u00B2"
                + $" = {result}";
        }
    }
}