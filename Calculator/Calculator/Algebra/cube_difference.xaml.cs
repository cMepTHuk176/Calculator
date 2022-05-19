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
    public partial class cube_difference : ContentPage
    {
        public cube_difference()
        {
            InitializeComponent();
            textForm.Text = "(a-b)\u00B3 = a\u00B3-3a\u00B2b+3ab\u00B2-b\u00B3";
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(entryA, entryB);
        }

        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(entryA, entryB))
                Result_cube_difference(null, null);
        }

        private void Result_cube_difference(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(entryA, entryB))
            {
                resultText.Text = Multiplication_main.ErrorText;
                return;
            }

            var a = double.Parse(entryA.Text);
            var b = double.Parse(entryB.Text);
            var result = MultiplicationFormulas.CubeDiff(a, b, out string resText);

            resultText.Text = resText + " = " + result.ToString();
        }
    }
}