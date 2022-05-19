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
    public partial class cube_sum_m : ContentPage
    {
        public cube_sum_m()
        {
            InitializeComponent();
            textForm.Text = "a\u00B3+b\u00B3 = (a+b)(a\u00B2-ab+b\u00B2)";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryA, entryB);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryA, entryB))
                Result_cube_sum_m(null, null);
        }

        private void Result_cube_sum_m(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryA, entryB))
            {
                resultText.Text = Multiplication_main.ErrorText;
                return;
            }

            var a = double.Parse(entryA.Text);
            var b = double.Parse(entryB.Text);
            var result = MultiplicationFormulas.SumCubs(a, b, out string resText);

            resultText.Text = resText + " = " + result.ToString();
        }
    }
}