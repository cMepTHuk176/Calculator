using Calculator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Algebra
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class square_sum : ContentPage
    {
        public square_sum()
        {
            InitializeComponent();
            textForm.Text = "(a + b)\u00B2 = a\u00B2 + 2ab + b\u00B2";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryA, entryB);
        }

        private void Result_square_sum(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryA, entryB))
            {
                resultText.Text = Multiplication_main.ErrorText;
                return;
            }

            var a = double.Parse(entryA.Text);
            var b = double.Parse(entryB.Text);
            var result = MultiplicationFormulas.SquareSum(a, b, out string resText);

            resultText.Text = resText + " = " + result.ToString();
        }
    }
}