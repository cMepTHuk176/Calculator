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
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(a,b))
                Result_square_sum(null, null);
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
            double result = 2;
            resultText.Text = result.ToString("0.00E+0");
        }
    }
}