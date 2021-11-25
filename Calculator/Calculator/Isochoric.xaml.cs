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
    public partial class Isochoric : ContentPage
    {
        public Isochoric()
        {
            InitializeComponent();
        }
        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
            TextCleaner.EntryClean(p, v, t);
        }
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (TextChecker.EntryCheck(p, v, t))
                Result_isohoric(null, null);
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Result_isohoric(object sender, EventArgs e)
        {
            if (!TextChecker.EntryCheck(p, v, t))
            {
                resultText.Text = "ОШИБКА";
                return;
            }

            double valueA = double.Parse(p.Text);
            double valueB = double.Parse(v.Text);
            double valueC = double.Parse(t.Text);
            double result = 2;
            resultText.Text = result.ToString("0.00E+0");
        }
    }
}