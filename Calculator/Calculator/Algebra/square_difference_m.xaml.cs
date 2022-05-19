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
    public partial class square_difference_m : ContentPage
    {
        public square_difference_m()
        {
            InitializeComponent();
            textForm.Text = "a\u00B2-b\u00B2=(a-b)(a+b)";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryA, entryB);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryA, entryB))
                Result_square_difference_m(null, null);
        }

        private void Result_square_difference_m(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryA, entryB))
            {
                resultText.Text = Multiplication_main.ErrorText;
                return;
            }

            var a = double.Parse(entryA.Text);
            var b = double.Parse(entryB.Text);
            var result = MultiplicationFormulas.DiffSquares(a, b, out string resText);

            resultText.Text = resText + " = " + result.ToString();
        }
    }
}